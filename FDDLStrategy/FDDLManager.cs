using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Timers;

namespace FDDLStrategy
{
    class FDDLManager
    {
        private List<TodayPlan> m_fddlPlans = new List<TodayPlan>();

        public FDDLManager()
        {
        }


        public void addPlan(FDDLBuyExecution plan)
        {
            m_fddlPlans.Add(plan);
        }

        public void addPlan(FDDLSellExecution plan)
        {
            m_fddlPlans.Add(plan);
        }

        public void runPlans()
        {
            foreach (var plan in m_fddlPlans)
            {
                plan.run();
            }
        }

        private void sendto(string content)
        {
            string url = SystemInfo.COMMAND_SERVER_URL_BASE + "/FDDL_report";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            byte[] requestData = Encoding.UTF8.GetBytes(content);
            request.Method = "POST";
            request.Timeout = 30 * 1000;
            request.ContentType = "application/json";
            request.ContentLength = requestData.Length;

            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(requestData, 0, requestData.Length);
            }
        }

        public void reportResults()
        {
            var callback = new DirectExecutionCommands.HostCapTrCallback(1);
            ProgramControl.getGateway().CommRqData("FDDLManager-cap", "opw00001", 0, Screens.SCREEN_HOSTCAP);
            TrEventManager.addCallback("FDDLManager-cap", callback);

            int timeoutCounter = 0;
            while (!callback.isDataReady() && timeoutCounter < 30000)
            {
                System.Threading.Thread.Sleep(10);
                timeoutCounter += 10;
            }

            foreach (var plan in m_fddlPlans)
            {
                string planReport = "{" +
                    "\"RunningID\" : " + plan.getID() + "," +
                    "\"HostName\" : " + SystemInfo.HOST_NAME + "," +
                    "\"Achieved\" : " + plan.getAchieved().ToString() + "," +
                    "\"Budget\" : " + callback.getBudget().ToString() + "}";

                sendto(planReport);
            }
        }
    }
}
