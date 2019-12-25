using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class AudioController: BaseController
    {
        private int m_currentSoundId = 0;
        internal AudioController() : base(nameof(AudioController))
        {

        }

        [EventHandler("onClientResourceStart")]
        public void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;

            RequestScriptAudioBank("DLC_STUNT/STUNT_RACE_01", false);
            RequestScriptAudioBank("DLC_STUNT/STUNT_RACE_02", false);
            RequestScriptAudioBank("DLC_STUNT/STUNT_RACE_03", false);
        }

        public void PlaySound(string soundName, string soundSet)
        {
            if(m_currentSoundId != 0)
            {
                Audio.StopSound(m_currentSoundId);
                Audio.ReleaseSound(m_currentSoundId);
            }

            m_currentSoundId = Audio.PlaySoundFrontend(soundName, soundSet);
        }
    }
}
