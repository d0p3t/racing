using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using System.Collections.Generic;
using System.Linq;

namespace Server.Models
{
    public enum GameState
    {
        INIT, // Ready for new map
        LOADING, // Loading the map file and vehicle select (or spawn into race if race ongoing)
        VEHICLE_SELECT, // Players choosing vehicles and props spawning
        READY, // Props can still spawn and player is ready for race
        PRE_COUNTDOWN, // Loaded into race and getting countdown ready
        COUNTDOWN, // 3,2,1, GO
        ONGOING, // Race ongoing
        FINISHED, // Player is finished and will now go to spectating
        SPECTATING, // spectating waiting for others to finish
        POST // race results screen
    }

    public class RaceData
    {
        public GameState GameState { get; private set; } = GameState.INIT;
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

        public void ChangeGlobalGameState(GameState state)
        {
            if (state == GameState.INIT)
                PlayersInRace.Clear();

            GameState = state;
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
                FirstFinishTime = GetGameTimer();
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
