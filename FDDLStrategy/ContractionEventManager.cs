using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FDDLStrategy
{

    class ContractionEventManager
    {
        private ContractionEventManager()
        {
        }
 
        private static Dictionary<string, ContractionEventCallback> s_callbacks = new Dictionary<string, ContractionEventCallback>();
        private static Dictionary<string, string> s_orderMap = new Dictionary<string, string>();//orderid -> reqName

        public static void addCallback(string reqName, ContractionEventCallback callback)
        {
            if (s_callbacks.ContainsKey(reqName))
            {
                //Debug Log : 이미 있는 reqName (요청 이름 유일성 문제) -> 가장 마지막으로 대체
                ProgramControl.getLogger().Debug(string.Format("ContractionEventManager : addCallback : 이미 있는 reqName임.(RQName : {0})", reqName));
            }
            s_callbacks[reqName] = callback;
        }

        public static void gotContracting(string trcode, string reqName)
        {
            string sOrderId = ProgramControl.getGateway().GetCommData(trcode, reqName, 0, "주문번호"); sOrderId.Trim();
            if(!sOrderId.Equals(""))
            {
                s_orderMap[sOrderId] = reqName;
                if(s_callbacks.ContainsKey(reqName))
                {
                    s_callbacks[reqName].eventTrCallback(sOrderId);
                }
                else
                {
                    //Debug Log : callback 등록되지 않음 -> 실행 안함
                    ProgramControl.getLogger().Debug(string.Format("ContractionEventManager : gotContracting : reqName에 대해 적절한 callback 정의되지 않음(RQName : {0})", reqName));
                }
            }
            else
            {
                //Debug log : 증권 서비스 운영 문제 -> 프로그램 종료
                ProgramControl.getLogger().Error(string.Format("ContractionEventManager : gotContracting : 증권 서비스 없음(RQName : {0})", reqName));
                ProgramControl.systemShutdown();
            }
        }

        public static void gotContractionMessage(string reqName, string message)
        {
            if(s_callbacks.ContainsKey(reqName))
            {
                s_callbacks[reqName].eventMessageCallback(message);
            }
            else
            {
                //Debug Log : callback 등록되지 않음
                ProgramControl.getLogger().Debug(string.Format("ContractionEventManager : gotContractionMessage : reqName에 대해 적절한 callback 정의되지 않음(RQName : {0})", reqName));
            }
        }

        public static void gotContracted(string infoType, string fidList)
        {
            string[] strfids = fidList.Split(';');
            int[] fids = Array.ConvertAll(strfids, item => int.Parse(item));
            ContractionInfoWrapper wrapper = new ContractionInfoWrapper(ProgramControl.getGateway(), fids, int.Parse(infoType));
            string orderid = wrapper.getData("주문번호");
            if (s_orderMap.ContainsKey(orderid) && s_callbacks.ContainsKey(s_orderMap[orderid]))
            {
                s_callbacks[orderid].eventContractionCallback(wrapper);
            }
            else
            {
                //Debug Log : callback 등록되지 않음. 정상적(TrData, Message -> Chejan)으로 메시지 송신되지 않음.
                ProgramControl.getLogger().Debug(string.Format("ContractionEventManager : gotContracted : orderID에 대해 적절한 callback 정의되지 않음. 메세지 송신 순서 뒤틀림(OrderID : {0})", orderid));
            }
        }
    }
}
