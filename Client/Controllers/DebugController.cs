using CitizenFX.Core;
using CitizenFX.Core.UI;
using static CitizenFX.Core.Native.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Enums;
using Client.Models.Mapping;

namespace Client.Controllers
{
    public class DebugController: BaseController
    {
        internal DebugController() : base(nameof(DebugController)) { }

        // [Tick]
        public async Task OnDebugTick()
        {
            try
            {
            }
            catch (Exception e)
            {
                Logger.Exception(e, "OnDebugTick");
                await Delay(5000);
            }

            await Task.FromResult(0);
        }
    }
}
