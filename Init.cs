using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCVRClient;
using MelonLoader;

namespace XCVRClient
{
    public class Init : MelonMod
    {
        [Obsolete]
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("pip?");
        }
    }
}
