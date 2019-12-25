using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public abstract class BaseController: CitizenFX.Core.BaseScript
    {
        internal BaseController(string className)
        {
            Logger.Info($"Initialising {className}");
        }
    }
}
