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
        private static Dictionary<MapCheckpoint, int> m_checkpoints = new Dictionary<MapCheckpoint, int>();
        private static Dictionary<MapCheckpoint, int> m_secondaryCheckpoints = new Dictionary<MapCheckpoint, int>();

        private Dictionary<Blip, int> m_blips = new Dictionary<Blip, int>();

        private List<MapCheckpoint> m_checkpointstwo = new List<MapCheckpoint>();
        private List<MapCheckpoint> m_secondaryCheckpointstwo = new List<MapCheckpoint>();

        private int m_currentCheckpointId = -1;

        private int m_checkpointHandle = -1;
        private int m_secondaryCheckpointHandle = -1;

        private Blip m_currentCheckpointBlip = null;
        private Blip m_secondaryCheckpointBlip = null;
        private Blip m_nextCheckpointBlip = null;

        private int m_nextCheckpoint = 0;

        private Color m_cylinderColor;
        private Color m_iconColor;

        internal CheckpointController(): base(nameof(CheckpointController))
        {
            int m_cylinderR = 0;
            int m_cylinderG = 0;
            int m_cylinderB = 0;
            int m_cylinderA = 0;

            int m_iconR = 0;
            int m_iconG = 0;
            int m_iconB = 0;
            int m_iconA = 0;

            GetHudColour(13, ref m_cylinderR, ref m_cylinderG, ref m_cylinderB, ref m_cylinderA);
            GetHudColour(134, ref m_iconR, ref m_iconG, ref m_iconB, ref m_iconA);

            m_cylinderColor = Color.FromArgb(m_cylinderA, m_cylinderR, m_cylinderG, m_cylinderB);
            m_iconColor = Color.FromArgb(m_iconA, m_iconR, m_iconG, m_iconB);
        }

        public Vector4 GetRespawnPosition()
        {
            var prevCpInd = m_currentCheckpointId == 0 ? m_currentCheckpointId : m_currentCheckpointId - 1;

            var previous_cp = m_checkpointstwo[prevCpInd];

            return new Vector4(previous_cp.Position, previous_cp.Heading); // possibly heading wrong
        }

        public void SetCheckPoints(List<Chl> checkpoints, float[] headings, float[] scale, List<Sndchk> secondaryCheckpoints = null)
        {
            for (int i = 0; i < checkpoints.Count; i++)
            {
                m_checkpointstwo.Add(new MapCheckpoint
                {
                    Position = new Vector3(checkpoints[i].x, checkpoints[i].y, checkpoints[i].z + 5f),
                    Heading = headings[i],
                    Scale = scale[i]
                });
            }

            if (secondaryCheckpoints == null)
                return;

            for (int i = 0; i < secondaryCheckpoints.Count; i++)
            {
                m_secondaryCheckpointstwo.Add(new MapCheckpoint
                {
                    Position = new Vector3(secondaryCheckpoints[i].x, secondaryCheckpoints[i].y, secondaryCheckpoints[i].z + 5f),
                    Heading = headings[i],
                    Scale = scale[i]
                });
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

                float dist = m_checkpointstwo[m_currentCheckpointId].Position.DistanceToSquared2D(Game.PlayerPed.CurrentVehicle.Position);
                float distSecondary = m_secondaryCheckpointstwo[m_currentCheckpointId].Position.DistanceToSquared2D(Game.PlayerPed.CurrentVehicle.Position);

                int totalLaps = Client.Instance.Game.CurrentMap.mission.RaceData.NumberOfLaps;

                if(dist < 100f || distSecondary < 100f)
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
                            Client.Instance.Audio.PlaySound("Checkpoint_Finish", "DLC_Stunt_Race_Frontend_Sounds");
                            Debug.WriteLine("Finished");
                            GameController.GameState = GameState.FINISHED;

                            m_currentCheckpointId = -1;
                            m_checkpointHandle = -1;
                            m_secondaryCheckpointHandle = -1;
                            m_checkpointstwo.Clear();
                            m_secondaryCheckpointstwo.Clear();
                            m_currentCheckpointBlip = null;
                            m_secondaryCheckpointBlip = null;

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
                Logger.Exception(e);
                await Delay(5000);
            }
            await Task.FromResult(0);
        }

        private void NewCheckpoints()
        {
            var current = m_checkpointstwo[m_currentCheckpointId];

            Checkpoint checkpoint;

            if (m_checkpointstwo.Count == m_currentCheckpointId + 1)
            {
                checkpoint = World.CreateCheckpoint(CheckpointIcon.CylinderCheckerboard2, current.Position - new Vector3(0,0,2.5f), Vector3.Zero, 10f, m_cylinderColor);
                SetCheckpointCylinderHeight(checkpoint.Handle, 9.5f, 9.5f, 6.5f);
                SetCheckpointIconRgba(checkpoint.Handle, m_iconColor.R, m_iconColor.G, m_iconColor.B, m_iconColor.A);
                m_checkpointHandle = checkpoint.Handle;

                m_currentCheckpointBlip = World.CreateBlip(current.Position);
                m_currentCheckpointBlip.Sprite = BlipSprite.RaceFinish;
                m_currentCheckpointBlip.Color = BlipColor.Blue;
                return;
            }
            
            var next = m_checkpointstwo[m_currentCheckpointId + 1];

            m_nextCheckpointBlip = World.CreateBlip(next.Position);
            m_nextCheckpointBlip.Sprite = BlipSprite.Standard;
            m_nextCheckpointBlip.Color = BlipColor.Yellow;
            m_nextCheckpointBlip.Scale = 0.5f;

            checkpoint = World.CreateCheckpoint(CheckpointIcon.CylinderDoubleArrow2, current.Position, next.Position, 10f, m_cylinderColor);

            SetCheckpointCylinderHeight(checkpoint.Handle, 9.5f, 9.5f, 6.5f);
            SetCheckpointIconRgba(checkpoint.Handle, m_iconColor.R, m_iconColor.G, m_iconColor.B, m_iconColor.A);

            m_checkpointHandle = checkpoint.Handle;

            m_currentCheckpointBlip = World.CreateBlip(current.Position);
            m_currentCheckpointBlip.Sprite = BlipSprite.Standard;
            m_currentCheckpointBlip.Color = BlipColor.Yellow;

            if (m_secondaryCheckpointstwo[m_currentCheckpointId].Position != new Vector3(0,0,5))
            {
                current = m_secondaryCheckpointstwo[m_currentCheckpointId];
                checkpoint = World.CreateCheckpoint(CheckpointIcon.CylinderDoubleArrow2, current.Position, next.Position, 10f, m_cylinderColor);

                SetCheckpointCylinderHeight(checkpoint.Handle, 9.5f, 9.5f, 6.5f);
                SetCheckpointIconRgba(checkpoint.Handle, m_iconColor.R, m_iconColor.G, m_iconColor.B, m_iconColor.A);

                m_secondaryCheckpointHandle = checkpoint.Handle;

                m_secondaryCheckpointBlip = World.CreateBlip(current.Position);
                m_secondaryCheckpointBlip.Sprite = BlipSprite.Standard;
                m_secondaryCheckpointBlip.Color = BlipColor.Yellow;
            }
            else
            {
                m_secondaryCheckpointHandle = -1;
            }
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
