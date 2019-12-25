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
        public PropController Props { get; private set; }
        public SpawnController Spawn { get; private set; }

        // private bool m_setupComplete = false;

        public Client()
        {

            Audio = new AudioController();
            Checkpoints = new CheckpointController();
            Debug = new DebugController();
            Game = new GameController();
            Props = new PropController();
            Spawn = new SpawnController();

            RegisterScript(Audio);
            RegisterScript(Checkpoints);
            RegisterScript(Debug);
            RegisterScript(Game);
            RegisterScript(Props);
            RegisterScript(Spawn);

            Instance = this;
        }

        //[Tick]
        //public async Task SetupTick()
        //{
        //    try
        //    {
        //        if (m_setupComplete)
        //        {
        //            Tick -= SetupTick;
        //            return;
        //        }

        //        // TriggerEvent("racing_firstLoad");
        //        m_setupComplete = true;
        //    }
        //    catch (Exception e)
        //    {
        //        Logger.Exception(e, "SetupTick");
        //        await Delay(5000);
        //    }

        //    await Task.FromResult(0);
        //}
    }
}
