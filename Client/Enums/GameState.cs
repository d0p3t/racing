namespace Client.Enums
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
}
