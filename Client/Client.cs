using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Controllers;

namespace Client
{
    public class Client: BaseScript
    {
        public static Client Instance { get; private set; }
        public AudioController Audio { get; private set; }
        public CheckpointController Checkpoints { get; private set; }
        public DebugController Debug { get; private set; }
        public GameController Game { get; private set; }
        public LobbyController Lobby { get; private set; }
        public PropController Props { get; private set; }
        public SpawnController Spawn { get; private set; }
        public VehicleController Vehicle { get; private set; }

        public Client()
        {

            Audio = new AudioController();
            Checkpoints = new CheckpointController();
            Debug = new DebugController();
            Game = new GameController();
            Lobby = new LobbyController();
            Props = new PropController();
            Spawn = new SpawnController();
            Vehicle = new VehicleController();

            RegisterScript(Audio);
            RegisterScript(Checkpoints);
            RegisterScript(Debug);
            RegisterScript(Game);
            RegisterScript(Lobby);
            RegisterScript(Props);
            RegisterScript(Spawn);
            RegisterScript(Vehicle);

            Instance = this;
        }

        [EventHandler("onClientResourceStart")]
        public void OnClientResourceStart(string resource)
        {
            if (CitizenFX.Core.Native.API.GetCurrentResourceName() != resource)
                return;

            TriggerServerEvent("racing:playerJoined");
        }
    }
}
