using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleHttpServer.Models;
using SimpleHttpServer.RouteHandlers;
using Newtonsoft.Json;
using System.Timers;
using System.Diagnostics;

namespace FDDLStrategy
{
    class DirectExecutionCommands
    {
        public static List<Route> router
        {
            get
            {
                return new List<Route>()
                {
                    new Route()
                    {
                        Callable = FDDLBuy,
                        UrlRegex = "^\\/FDDL_buy$",
                        Method = "POST"
                    },

                    new Route()
                    {
                        Callable = hostCap,
                        UrlRegex = "^\\/host_cap$",
                        Method = "GET"
                    },

                    new Route()
                    {
                        Callable = schedulePlan,
                        UrlRegex = "^\\/schedule_plan",
                        Method = "POST"
                    }
                };
            }
        }
        private static HttpResponse FDDLBuy(HttpRequest request)
        {
            if (request.Headers["Pass"].Equals(SystemInfo.PASS))
            {
                DownloadedTodayPlan downloadedInfo = JsonConvert.DeserializeObject<DownloadedTodayPlan>(request.Content);

                FDDLBuyExecution exe = new FDDLBuyExecution(downloadedInfo.ID, downloadedInfo.StockCode, downloadedInfo.Quantity, downloadedInfo.Price);
                PlanManager.getFDDLManager().addPlan(exe);
                exe.run();

                return new HttpResponse()
                {
                    ReasonPhrase = "OK",
                    StatusCode = "200"
                };
            }

            return new HttpResponse()
            {
                ReasonPhrase = "Unauth",
                StatusCode = "401"
            };
        }

        public class HostCapTrCallback : TrEventCallback
        {
            int m_type;
            bool m_bDataReady = false;
            int m_budget;

            public HostCapTrCallback(int type)
            {
                m_type = type;
            }
            public void eventCallback(TrInfoWrapper wrapper)
            {
                if(m_type == 0)
                {
                    m_budget = int.Parse(wrapper.getData("예수금", 0));
                }
                else if(m_type == 1)
                {
                    m_budget = int.Parse(wrapper.getData("d+1추정예수금", 0));
                }
                m_bDataReady = true;
            }

            public bool isDataReady()
            {
                return m_bDataReady;
            }

            public int getBudget()
            {
                return m_budget;
            }
        }

        private static HttpResponse hostCap(HttpRequest request)
        {
            if (request.Headers["Pass"].Equals(SystemInfo.PASS))
            {
                int type = int.Parse(request.Headers["Type"]);

                // Make Tr
                ProgramControl.getGateway().SetInputValue("계좌번호",SystemInfo.ACCOUNT);
                ProgramControl.getGateway().SetInputValue("비밀번호", "");
                ProgramControl.getGateway().SetInputValue("비밀번호입력매체구분", "00");
                ProgramControl.getGateway().SetInputValue("조회구분", "2");

                var callback = new HostCapTrCallback(type);
                ProgramControl.getGateway().CommRqData("direct-hostcap", "opw00001", 0, Screens.SCREEN_HOSTCAP);
                TrEventManager.addCallback("direct-hostcap", callback);

                int timeoutCounter = 0;
                while (!callback.isDataReady() && timeoutCounter < 30000)
                {
                    System.Threading.Thread.Sleep(10);
                    timeoutCounter += 10;
                }

                if(timeoutCounter == 30000)
                {
                    string resultContent = "{ \"result\" : \"Failed\" }";
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = resultContent,
                        ReasonPhrase = "Failed",
                        StatusCode = "408"
                    };
                }
                else
                {
                    string resultContent = "{ \"result\" : \"Success\", \"budget\" : " + callback.getBudget().ToString() + "}";
                    return new HttpResponse()
                    {
                        ContentAsUTF8 = resultContent,
                        ReasonPhrase = "OK",
                        StatusCode = "200"
                    };
                }

            }

            return new HttpResponse()
            {
                ReasonPhrase = "Unauth",
                StatusCode = "401"
            };
        }

        private static HttpResponse schedulePlan(HttpRequest request)
        {
            if (request.Headers["Pass"].Equals(SystemInfo.PASS))
            {
                PlanManager.saveTomorrowPlans(request.Content);

                Timer timer = new Timer();
                timer.AutoReset = false;
                timer.Interval = (DateTime.Now.AddSeconds(30) - DateTime.Now).TotalMilliseconds;
                timer.Elapsed += shutdownComputer;

                return new HttpResponse()
                {
                    ReasonPhrase = "OK",
                    StatusCode = "200"
                };
            }

            return new HttpResponse()
            {
                ReasonPhrase = "Unauth",
                StatusCode = "401"
            };
        }

        private static void shutdownComputer(object sender, ElapsedEventArgs e)
        {
            ProgramControl.systemShutdown();
        }
    }
}
