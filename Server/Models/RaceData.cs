using System.Collections.Generic;
using System.Linq;

namespace Server.Models
{
    public enum GameState
    {
        INIT,
        LOADING,
        SPECTATING,
        VEHICLE_SELECT,
        READY,
        PRE_COUNTDOWN,
        COUNTDOWN,
        ONGOING,
        FINISHED,
        POST
    }

    public class RaceData
    {
        public GameState GameState { get; set; } = GameState.INIT;
        public List<PlayerRaceData> PlayersInRace { get; set; } = new List<PlayerRaceData>();
        public long FirstFinishTime { get; set; }

        public PlayerRaceData GetPlayer(string handle)
        {
            return PlayersInRace.FirstOrDefault(p => p.Handle == handle);
        }

        public void RemovePlayer(string handle)
        {
            var player = GetPlayer(handle);

            if (player != null)
            {
                PlayersInRace.Remove(player);
            }
        }

        public bool AreAllPlayersInState(GameState state)
        {
            return PlayersInRace.All(p => p.GameState == state);
        }

        public bool IsFirstPlayerToFinish()
        {
            var count = 0;

            foreach (var p in PlayersInRace)
            {
                if(p.GameState == GameState.FINISHED)
                {
                    count++;
                }
            }

            if (count == 1)
            {
                FirstFinishTime = CitizenFX.Core.Native.API.GetGameTimer();
                return true;
            }

            return false;
        }
    }

    public class PlayerRaceData
    {
        public string Handle { get; set; }
        public GameState GameState { get; set; }
        public int GridPosition { get; set; }
        public int BestLap { get; set; }
        public int CurrentLap { get; set; }

        public PlayerRaceData(string handle, int gridPosition)
        {
            Handle = handle;
            GridPosition = gridPosition;

            GameState = GameState.INIT;
            BestLap = 0;
            CurrentLap = 0;
        }

        public void Reset()
        {
            GameState = GameState.INIT;
            BestLap = 0;
            CurrentLap = 0;
        }
    }
}
