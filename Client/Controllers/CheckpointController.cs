using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;
using Client.Enums;
using Client.Models;
using Client.Models.Mapping;

namespace Client.Controllers
{
    public class CheckpointController : BaseController
    {
        private List<MapCheckpoint> m_checkpointstwo = new List<MapCheckpoint>();
        private List<MapCheckpoint> m_secondaryCheckpointstwo = new List<MapCheckpoint>();

        private int m_currentCheckpointId = -1;
        private int m_checkpointHandle = -1;
        private int m_secondaryCheckpointHandle = -1;

        private Blip m_currentCheckpointBlip = null;
        private Blip m_secondaryCheckpointBlip = null;
        private Blip m_nextCheckpointBlip = null;

        private Color m_cylinderColor;
        private Color m_iconColor;

        private static readonly float m_cpDist = 100f;

        internal CheckpointController(): base(nameof(CheckpointController))
        {
            int m_cylinderR = 0, m_cylinderG = 0, m_cylinderB = 0, m_cylinderA = 0;
            int m_iconR = 0, m_iconG = 0, m_iconB = 0, m_iconA = 0;

            GetHudColour(13, ref m_cylinderR, ref m_cylinderG, ref m_cylinderB, ref m_cylinderA);   // yellow
            GetHudColour(134, ref m_iconR, ref m_iconG, ref m_iconB, ref m_iconA);                  // blue

            m_cylinderColor = Color.FromArgb(m_cylinderA, m_cylinderR, m_cylinderG, m_cylinderB);
            m_iconColor = Color.FromArgb(m_iconA, m_iconR, m_iconG, m_iconB);
        }

        public Vector4 GetRespawnPosition()
        {
            var prevCpInd = m_currentCheckpointId == 0 ? m_currentCheckpointId : m_currentCheckpointId - 1;

            var previous_cp = m_checkpointstwo[prevCpInd];

            return new Vector4(previous_cp.Position, previous_cp.Heading); // possibly heading wrong -- heading is for..vehicle respawn?
        }

        public void SetCheckPoints(List<Chl> checkpoints, List<bool> isRound, float[] headings, float[] scale, List<Sndchk> secondaryCheckpoints, List<bool> isRoundSecondary)
        {
            for (int i = 0; i < checkpoints.Count; i++)
            {
                m_checkpointstwo.Add(new MapCheckpoint
                {
                    Position = new Vector3(checkpoints[i].x, checkpoints[i].y, checkpoints[i].z),
                    Heading = headings[i],
                    Scale = (isRound[i] ? 20f : 10f) * scale[i] ,
                    Type = isRound[i] ? 10 : 5,
                    ZAxis = isRound[i] ? 10f : 3f,
                    TriggerRadius = isRound[i] ? 400f : 144f
                });
            }

            if (secondaryCheckpoints != null)
            {
                for (int i = 0; i < secondaryCheckpoints.Count; i++)
                {
                    m_secondaryCheckpointstwo.Add(new MapCheckpoint
                    {
                        Position = new Vector3(secondaryCheckpoints[i].x, secondaryCheckpoints[i].y, secondaryCheckpoints[i].z),
                        Heading = headings[i],
                        Scale = (isRoundSecondary[i] ? 20f : 10f) * scale[i],
                        Type = isRoundSecondary[i] ? 10 : 5,
                        ZAxis = isRound[i] ? 10f : 3f,
                        TriggerRadius = isRound[i] ? 400f : 144f
                    });
                }
            }
        }

        [Tick]
        public async Task OnCheckpointTick()
        {
            try
            {
                if (GameController.GameState != GameState.ONGOING || m_checkpointstwo.Count == 0 || Game.PlayerPed.CurrentVehicle == null)
                    return;

                var count = m_checkpointstwo.Count;

                if(m_currentCheckpointId == -1)
                {
                    m_currentCheckpointId = 0;

                    NewCheckpoints();
                }

                var currentCP = m_checkpointstwo[m_currentCheckpointId];
                var currentSecondaryCP = m_secondaryCheckpointstwo[m_currentCheckpointId];
                float dist = currentCP.Position.DistanceToSquared(Game.PlayerPed.CurrentVehicle.Position);
                float distSecondary = currentSecondaryCP.Position.DistanceToSquared(Game.PlayerPed.CurrentVehicle.Position);

                int totalLaps = Client.Instance.Game.CurrentMap.mission.RaceData.NumberOfLaps;

                if(dist < currentCP.TriggerRadius || distSecondary < currentSecondaryCP.TriggerRadius)
                {
                    DeleteCheckpoint(m_checkpointHandle);
                    m_currentCheckpointBlip.Delete();

                    m_nextCheckpointBlip.Delete();

                    if (m_secondaryCheckpointHandle != -1)
                    {
                        DeleteCheckpoint(m_secondaryCheckpointHandle);
                        m_secondaryCheckpointBlip.Delete();
                    }

                    m_currentCheckpointId++;

                    if(m_currentCheckpointId == m_checkpointstwo.Count)
                    {
                        Logger.Info($"Lap {Client.Instance.Game.GameInfo.CurrentLap}/{totalLaps}");
                        if(Client.Instance.Game.GameInfo.CurrentLap == totalLaps || totalLaps == 0)
                        {
                            Logger.Info("Finished Race!");

                            Client.Instance.Audio.PlaySound("Checkpoint_Finish", "DLC_Stunt_Race_Frontend_Sounds");

                            Client.Instance.TimerBars.Enabled(false);
                            Client.Instance.Game.GameStateListener.Invoke(GameState.FINISHED);

                            UnloadCheckpoints();

                            var veh = Game.PlayerPed.CurrentVehicle;
                            await Delay(1500);
                            
                            NetworkFadeOutEntity(veh.Handle, true, false);

                            await Delay(1000);
                            veh.Delete();
                            return;
                        }

                        Client.Instance.Game.GameInfo.CurrentLap++;

                        m_currentCheckpointId = 0;
                    }

                    Client.Instance.Audio.PlaySound("Checkpoint", "DLC_Stunt_Race_Frontend_Sounds");

                    NewCheckpoints();
                }
            }
            catch (Exception e)
            {
                Logger.Exception(e, "OnCheckpointTick");
                await Delay(5000);
            }
            await Task.FromResult(0);
        }

        private void UnloadCheckpoints()
        {
            m_currentCheckpointId = -1;
            m_checkpointHandle = -1;
            m_secondaryCheckpointHandle = -1;
            m_checkpointstwo.Clear();
            m_secondaryCheckpointstwo.Clear();
            m_currentCheckpointBlip = null;
            m_secondaryCheckpointBlip = null;
        }

        private void NewCheckpoints()
        {
            var current = m_checkpointstwo[m_currentCheckpointId];

            Checkpoint checkpoint;

            if (m_checkpointstwo.Count == m_currentCheckpointId + 1)
            {
                int totalLaps = Client.Instance.Game.CurrentMap.mission.RaceData.NumberOfLaps;
                var type = CheckpointIcon.CylinderCheckerboard2;
                var pointTo = Vector3.Zero;

                if (Client.Instance.Game.GameInfo.CurrentLap != totalLaps && totalLaps != 0)
                {
                    type = CheckpointIcon.CylinderSingleArrow;
                    pointTo = m_checkpointstwo[0].Position;
                }

                checkpoint = World.CreateCheckpoint(type, current.Position + new Vector3(0,0, 2.5f),pointTo, current.Scale, m_cylinderColor);
                SetCheckpointCylinderHeight(checkpoint.Handle, 9.5f, 9.5f, 9.5f);
                SetCheckpointIconRgba(checkpoint.Handle, m_iconColor.R, m_iconColor.G, m_iconColor.B, m_iconColor.A);
                m_checkpointHandle = checkpoint.Handle;
                m_currentCheckpointBlip = World.CreateBlip(current.Position);
                m_currentCheckpointBlip.Sprite = BlipSprite.RaceFinish;
                m_currentCheckpointBlip.Color = BlipColor.Blue;
                m_currentCheckpointBlip.Scale = 1.2f;

                SetBlipNameFromTextFile(m_currentCheckpointBlip.Handle, "FMMC_B_6");
                return;
            }
            
            var next = m_checkpointstwo[m_currentCheckpointId + 1];

            m_nextCheckpointBlip = World.CreateBlip(next.Position);
            m_nextCheckpointBlip.Sprite = BlipSprite.Standard;
            m_nextCheckpointBlip.Color = BlipColor.Yellow;
            m_nextCheckpointBlip.Scale = 0.5f;


            int numberOfArrows = NumberOfArrows(m_currentCheckpointId, m_checkpointstwo);

            checkpoint = World.CreateCheckpoint((CheckpointIcon)current.Type + numberOfArrows, current.Position + new Vector3(0, 0, current.ZAxis), next.Position, current.Scale, m_cylinderColor);

            SetCheckpointCylinderHeight(checkpoint.Handle, 9.5f, 9.5f, 9.5f);
            SetCheckpointIconRgba(checkpoint.Handle, m_iconColor.R, m_iconColor.G, m_iconColor.B, m_iconColor.A);

            m_checkpointHandle = checkpoint.Handle;

            m_currentCheckpointBlip = World.CreateBlip(current.Position);
            m_currentCheckpointBlip.Sprite = BlipSprite.Standard;
            m_currentCheckpointBlip.Color = BlipColor.Yellow;

            if(m_secondaryCheckpointstwo.Count == 0)
            {
                m_secondaryCheckpointHandle = -1;
                return;
            }
            if (m_secondaryCheckpointstwo[m_currentCheckpointId].Position != new Vector3(0,0,0))
            {
                current = m_secondaryCheckpointstwo[m_currentCheckpointId];

                if (m_secondaryCheckpointstwo[m_currentCheckpointId + 1].Position != new Vector3(0, 0, 0))
                {
                    next = m_secondaryCheckpointstwo[m_currentCheckpointId + 1];
                }

                numberOfArrows = NumberOfArrows(m_currentCheckpointId, m_secondaryCheckpointstwo);

                checkpoint = World.CreateCheckpoint((CheckpointIcon)current.Type + numberOfArrows, current.Position + new Vector3(0, 0, current.ZAxis), next.Position, current.Scale, m_cylinderColor);

                SetCheckpointCylinderHeight(checkpoint.Handle, 9.5f, 9.5f, 9.5f);
                SetCheckpointIconRgba(checkpoint.Handle, m_iconColor.R, m_iconColor.G, m_iconColor.B, m_iconColor.A);

                m_secondaryCheckpointHandle = checkpoint.Handle;

                m_secondaryCheckpointBlip = World.CreateBlip(current.Position);
                m_secondaryCheckpointBlip.Sprite = BlipSprite.Standard;
                m_secondaryCheckpointBlip.Color = BlipColor.Yellow;
                return;
            }
            m_secondaryCheckpointHandle = -1;
        }

        private int NumberOfArrows(int currentIdx, List<MapCheckpoint> mapCheckpoints)
        {
            Vector3 currentPos = mapCheckpoints[currentIdx].Position;
            
            Vector3 nextPos = currentPos;
            if (mapCheckpoints[currentIdx + 1].Position != Vector3.Zero) // next CP is always there as check is done in NextCheckpoint for checkerboard
                nextPos = mapCheckpoints[currentIdx + 1].Position;
            else
                nextPos = m_checkpointstwo[currentIdx + 1].Position; // Only secondaries are Vector3.Zero so this is safe

            Vector3 previousPos = currentPos;
            if(currentIdx > 0)
            {
                if(mapCheckpoints[currentIdx - 1].Position != Vector3.Zero)
                    previousPos = mapCheckpoints[currentIdx - 1].Position;
                else
                    previousPos = m_checkpointstwo[currentIdx - 1].Position;
            }

            var left = Vector3.Normalize(Vector3.Subtract(currentPos, previousPos));
            var right = Vector3.Normalize(Vector3.Subtract(nextPos, currentPos));

            float angle = MathUtil.RadiansToDegrees(Math.Abs((float)Math.Acos(Vector3.Dot(left,right))));

            if(angle > 180.0f)
            {
                angle = 360.0f - angle;
            }

            if (angle < 80f)
                return 0;
            else if (angle < 140f)
                return 1;
            else if (angle < 180f)
                return 2;
            else
                return 0;
        }

        [EventHandler("onClientMapStop")]
        public void OnMapStop()
        {
            if (m_currentCheckpointId != -1)
            {
                DeleteCheckpoint(m_checkpointHandle);
                m_currentCheckpointBlip.Delete();
                m_currentCheckpointBlip = null;

                if (m_secondaryCheckpointHandle != -1)
                {
                    DeleteCheckpoint(m_secondaryCheckpointHandle);
                    m_secondaryCheckpointBlip.Delete();
                    m_secondaryCheckpointBlip = null;
                }

                m_currentCheckpointId = -1;
                m_checkpointHandle = -1;
                m_secondaryCheckpointHandle = -1;
                m_checkpointstwo.Clear();
                m_secondaryCheckpointstwo.Clear();
            }
        }

    }
}
