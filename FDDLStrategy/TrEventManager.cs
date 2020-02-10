using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDDLStrategy
{
    class TrEventManager
    {
        private TrEventManager()
        {
        }

        private static Dictionary<string, TrEventCallback> s_callbacks = new Dictionary<string, TrEventCallback>();

        public static void addCallback(string reqName, TrEventCallback callback)
        {
            if(s_callbacks.ContainsKey(reqName))
            {
                //Debug Log
                ProgramControl.getLogger().Debug(string.Format("TrEventManager : addCallback : 이미 있는 reqName임.(RQName : {0})", reqName));
            }
            else
            {
                s_callbacks[reqName] = callback;
            }
        }

        public static void gotTrData(string trcode, string reqName)
        {
            s_callbacks[reqName].eventCallback(new TrInfoWrapper(ProgramControl.getGateway(), trcode, reqName));
            s_callbacks.Remove(reqName);
        }
    }
}
