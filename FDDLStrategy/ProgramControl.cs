using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxKHOpenAPILib;
using SimpleHttpServer;
using System.Threading;
using log4net;
using System.Diagnostics;


namespace FDDLStrategy
{
    class ProgramControl
    {
        private ProgramControl()
        {
        }

        private static AxKHOpenAPI m_gateway;
        private static HttpServer m_server;
        private static Thread m_serverThrd;
        private static ILog m_log;


        public static void start(AxKHOpenAPI gateway)
        {
            m_log = log4net.LogManager.GetLogger("ProgramControl");
            m_gateway = gateway;
            m_server = new HttpServer(SystemInfo.PORT, DirectExecutionCommands.router);
            m_serverThrd = new Thread(new ThreadStart(m_server.Listen));
            if(PlanManager.loadPlans())
            {
                PlanManager.runPlans();
                m_serverThrd.Start();
            }
            else
            {
                //Info log
                //exit
                m_log.Error("계획을 로드하는데 실패함.");
                systemShutdown();
            }
        }

        public static void normalStop()
        {
        }

        public static void systemShutdown()
        {
            Process.Start("shutdown", "/s /t 0");
        }

        public static ILog getLogger()
        {
            return m_log;
        }

        public static AxKHOpenAPI getGateway()
        {
            return m_gateway;
        }
    }
}
