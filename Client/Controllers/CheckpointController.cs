using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Controllers
{
    public class CheckpointController : BaseController
    {
        private static Dictionary<MapCheckpoint, int> m_checkpoints = new Dictionary<MapCheckpoint, int>();
        private static Dictionary<MapCheckpoint, int> m_secondaryCheckpoints = new Dictionary<MapCheckpoint, int>();

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
            var prevCpInd = m_nextCheckpoint == 0 ? m_nextCheckpoint : m_nextCheckpoint - 1;

            var previous_cp = m_checkpoints.ElementAt(prevCpInd);

            return new Vector4(previous_cp.Key.Position, previous_cp.Key.Heading); // possibly heading wrong
        }

        [EventHandler("onClientMapStart")]
        public async void OnClientMapStart()
        {
            try
            {
                while (Client.Instance.Game.CurrentMap == null || Client.Instance.Game.CurrentMap.mission.RaceData == null)
                    await Delay(0);


                var raceData = Client.Instance.Game.CurrentMap.mission.RaceData;

                var checkpoints = new List<MapCheckpoint>();
                for (int i = 0; i < raceData.CheckpointTotal; i++)
                {
                    checkpoints.Add(new MapCheckpoint
                    {
                        Position = new Vector3(raceData.CheckpointLocations[i].x, raceData.CheckpointLocations[i].y, raceData.CheckpointLocations[i].z + 5f),
                        Heading = raceData.CheckpointHeadings[i],
                        Scale = raceData.CheckpointScale[i],
                        Type = 5
                    });
                }

                var secondaryCheckpoints = new List<MapCheckpoint>();

                for (int i = 0; i < raceData.CheckpointTotal; i++)
                {
                    secondaryCheckpoints.Add(new MapCheckpoint
                    {
                        Position = new Vector3(raceData.SecondaryCheckPointPositions[i].x, raceData.SecondaryCheckPointPositions[i].y, raceData.SecondaryCheckPointPositions[i].z + 5f),
                        Heading = raceData.CheckpointHeadings[i],
                        Scale = raceData.CheckpointScale[i],
                        Type = 5
                    });
                }

                CreateCheckpoints(checkpoints, secondaryCheckpoints);
            }
            catch (Exception e)
            {
                Logger.Exception(e, "OnClientMapStart");
            }
            await Task.FromResult(0);
        }

        [EventHandler("onClientMapStop")]
        public void OnMapStop()
        {
            ResetCheckpoints();
        }

        public void CreateCheckpoints(List<MapCheckpoint> primaryCheckpoints, List<MapCheckpoint> secondaryCheckpoints)
        {
            try
            {
                ResetCheckpoints();

                for (int i = 0; i < primaryCheckpoints.Count; i++)
                {
                    if(i == 0 || i == 1)
                    {
                        var cpIcon = (CheckpointIcon)primaryCheckpoints[i].Type;
                        var pointTo = primaryCheckpoints[i + 1].Position;

                        var cp = World.CreateCheckpoint(cpIcon, primaryCheckpoints[i].Position, pointTo, 10f, m_cylinderColor);
                        SetCheckpointCylinderHeight(cp.Handle, 9.5f, 9.5f, 6.5f);
                        SetCheckpointIconRgba(cp.Handle, m_iconColor.R, m_iconColor.G, m_iconColor.B, m_iconColor.A);

                        bool hasSecondary = secondaryCheckpoints[i].Position != Vector3.Zero;
                        primaryCheckpoints[i].HasSecondary = hasSecondary;

                        Checkpoint scp = null;
                        if (hasSecondary)
                        {
                            scp = World.CreateCheckpoint(cpIcon, secondaryCheckpoints[i].Position, pointTo, 10f, m_cylinderColor);
                            SetCheckpointCylinderHeight(scp.Handle, 9.5f, 9.5f, 6.5f);
                            SetCheckpointIconRgba(scp.Handle, m_iconColor.R, m_iconColor.G, m_iconColor.B, m_iconColor.A);
                        }

                        m_secondaryCheckpoints.Add(secondaryCheckpoints[i], scp == null ? -1 : scp.Handle);
                        m_checkpoints.Add(primaryCheckpoints[i], cp.Handle);
                    }
                    else
                    {
                        m_checkpoints.Add(primaryCheckpoints[i], -1);
                        m_secondaryCheckpoints.Add(secondaryCheckpoints[i], -1);
                    }
                }

                Tick += OnCheckPointTick;
            }
            catch (Exception e)
            {
                Logger.Exception(e, "CreateCheckpoints");
            }
        }

        public async Task OnCheckPointTick()
        {
            try
            {
                if(m_nextCheckpoint == m_checkpoints.Count)
                {
                    ResetCheckpoints();

                    Debug.WriteLine("Finished");

                    GameController.GameState = Enums.GameState.FINISHED;
                    Tick -= OnCheckPointTick;
                    return;
                }

                var currentCheckpoint = m_checkpoints.ElementAt(m_nextCheckpoint);

                bool hasSecondary = currentCheckpoint.Key.HasSecondary;

                var secondaryCheckpoint = hasSecondary ? m_secondaryCheckpoints.ElementAt(m_nextCheckpoint) : default;

                if(Game.PlayerPed.CurrentVehicle == null)
                {
                    return;
                }

                var vehPos = Game.PlayerPed.CurrentVehicle.Position;
                var isInDistance = vehPos.DistanceToSquared2D(currentCheckpoint.Key.Position) < 100f;

                if(currentCheckpoint.Key.HasSecondary)
                {
                    isInDistance = isInDistance || vehPos.DistanceToSquared2D(secondaryCheckpoint.Key.Position) < 100f;
                }

                if (isInDistance)
                {
                    DeleteCheckpoint(currentCheckpoint.Value);

                    if (hasSecondary)
                        DeleteCheckpoint(secondaryCheckpoint.Value);

                    Client.Instance.Audio.PlaySound("Checkpoint", "DLC_Stunt_Race_Frontend_Sounds");

                    m_nextCheckpoint++;

                    if(m_nextCheckpoint == m_checkpoints.Count)
                    {
                        return;
                    }

                    CreateNewCheckpoint(m_nextCheckpoint);

                    if (hasSecondary)
                        CreateNewCheckpoint(m_nextCheckpoint, true);
                }
            }
            catch (Exception e)
            {
                Logger.Exception(e, "OnCheckPointTick");
                await Delay(2500);
            }

            await Task.FromResult(0);
        }

        private void ResetCheckpoints()
        {
            foreach (var cp in m_checkpoints.Values)
            {
                if (cp == -1)
                    continue;

                DeleteCheckpoint(cp);
            }

            foreach (var cp in m_secondaryCheckpoints.Values)
            {
                if (cp == -1)
                    continue;

                DeleteCheckpoint(cp);
            }

            m_checkpoints.Clear();
            m_secondaryCheckpoints.Clear();

            m_nextCheckpoint = 0;
        }

        private void CreateNewCheckpoint(int nextIdx, bool isSecondary = false)
        {
            Dictionary<MapCheckpoint, int> cps = isSecondary ? m_secondaryCheckpoints : m_checkpoints;

            var nextCheckPoint = cps.ElementAt(nextIdx);
            if (nextCheckPoint.Value == -1)
            {
                var pointTo = nextCheckPoint.Key;

                if (m_nextCheckpoint + 1 == cps.Count)
                {
                    nextCheckPoint.Key.Type = 4;
                }
                else
                {
                    pointTo = cps.ElementAt(nextIdx + 1).Key;
                }
                var cp = World.CreateCheckpoint((CheckpointIcon)nextCheckPoint.Key.Type, nextCheckPoint.Key.Position, pointTo.Position, 10f, m_cylinderColor);
                SetCheckpointCylinderHeight(cp.Handle, 9.5f, 9.5f, 6.5f);
                SetCheckpointIconRgba(cp.Handle, m_iconColor.R, m_iconColor.G, m_iconColor.B, m_iconColor.A);

                cps[cps.ElementAt(nextIdx).Key] = cp.Handle;
            }
        }
    }
}
