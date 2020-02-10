using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDDLStrategy
{
    interface ContractionEventCallback
    {
        void eventTrCallback(string orderId);
        void eventMessageCallback(string message);
        void eventContractionCallback(ContractionInfoWrapper wrapper);
    }
}
