using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models;

namespace Server
{
    public class Test : BaseScript
    {
        private static RaceData m_raceData = new RaceData();

        private bool m_rotatingMap = false;

        private Random r = new Random();
        public Test() { }

        [EventHandler("onPlayerJoining")]
        public void PlayerJoining([FromSource]Player player)
        {
            if (m_raceData.PlayersInRace.Any(p => p.Handle == player.Handle))
                return;

            JoinAndGetGridSpawn(player);
        }

        [EventHandler("onMapStart")]
        public void MapStart()
        {
            m_raceData = new RaceData();

            foreach (var player in Players.OrderBy(p => r.Next()))
            {
                JoinAndGetGridSpawn(player);
            }

            m_rotatingMap = false;
        }

        [EventHandler("racing:rotateReady")]
        public void PlayerReadyToRotate([FromSource]Player player)
        {
            if (m_rotatingMap) return;

            try
            {
                var foundPlayer = m_raceData.GetPlayer(player.Handle);

                if (foundPlayer != null)
                    foundPlayer.GameState = GameState.FINISHED;

                if(m_raceData.IsFirstPlayerToFinish())
                {
                    TriggerClientEvent("racing:firstFinish");
                    Tick += CountDownTick;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public async Task CountDownTick()
        {
            try
            {
                if(m_raceData.FirstFinishTime - GetGameTimer() > 60000 || m_raceData.AreAllPlayersInState(GameState.FINISHED))
                {
                    TriggerClientEvent("racing:post");
                    m_raceData.PlayersInRace.ForEach(p => p.GameState = GameState.POST);
                    Tick -= CountDownTick;
                    return;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                await Delay(5000);
            }
            await Task.FromResult(0);
        }

        [EventHandler("racing:changeState")]
        public void ChangeState([FromSource]Player player, int newState)
        {
            if (m_rotatingMap)
                return;

            var p = m_raceData.GetPlayer(player.Handle);

            if(p != null)
            {
                p.GameState = (GameState)newState;

                if (m_raceData.AreAllPlayersInState(GameState.INIT))
                {
                    m_rotatingMap = true;
                    Exports["mapmanager"].roundEnded();
                }
            }
            else
            {
                DropPlayer(player.Handle, "Error with player data. Reconnect");
            }
        }

        public void JoinAndGetGridSpawn(Player player)
        {
            var gridSpot = Enumerable.Range(0, Players.Count()).Select(a => new
            {
                Position = a
            }).Where(x => !m_raceData.PlayersInRace.Any(p => p.GridPosition == x.Position)).FirstOrDefault();

            if(gridSpot != null)
            {
                var pD = m_raceData.GetPlayer(player.Handle);

                if(pD == null)
                {
                    pD = new PlayerRaceData(player.Handle, gridSpot.Position);
                    m_raceData.PlayersInRace.Add(pD);
                }
                else
                {
                    pD.GridPosition = gridSpot.Position;
                }

                player.TriggerEvent("racing:gridSpot", gridSpot.Position);
            }
        }

        [EventHandler("playerDropped")]
        public void PlayerDropped([FromSource]Player player, string reason)
        {
            m_raceData.RemovePlayer(player.Handle);

            TriggerClientEvent("racing:dropped", player.Name, reason);
        }
    }
}
