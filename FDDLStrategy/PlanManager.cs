using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Timers;

namespace FDDLStrategy
{
    class DownloadedTodayPlan
    {
        public string ID { get; set; }
        public string PlanName { get; set; }
        public string StockCode { get; set; }
        public int Quantity { get; set; }
        public int OrderType { get; set; }
        public int Price { get; set; }
    }
    class PlanManager
    {
        private static FDDLManager s_fddls = new FDDLManager();
        private static readonly DateTime s_timeLimit = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 50, 0);
        private static readonly DateTime s_reportTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 1, 0);

        private PlanManager()
        {
        }

        public static bool loadPlans()
        {
            try
            {
                string[] planList = Directory.GetFiles("./DownloadedPlans");
                foreach (string filename in planList)
                {
                    DownloadedTodayPlan plan = JsonConvert.DeserializeObject<DownloadedTodayPlan>(filename);
                    addPlan(plan);
                }
                reserveReport();
            }
            catch(Exception e)
            {
                //Log : file error
                ProgramControl.getLogger().Error("Exception : PlanManager : " + e.Message);
                return false;
            }
            return true;
        }

        public static void saveTomorrowPlans(string jsonReq)
        {
            DownloadedTodayPlan plan = JsonConvert.DeserializeObject<DownloadedTodayPlan>(jsonReq);
            File.WriteAllText(string.Format("./DownloadedPlans/{0}.json", plan.ID), jsonReq);
        }

        private static void addPlan(DownloadedTodayPlan plan)
        {
            if (plan.PlanName.Equals("FDDL"))
            {
                if(plan.OrderType == 0)//매수
                {
                    s_fddls.addPlan(new FDDLBuyExecution(plan.ID, plan.StockCode, plan.Quantity, plan.Price));
                }
                else if(plan.OrderType == 1)//매도
                {
                    s_fddls.addPlan(new FDDLSellExecution(plan.ID, plan.StockCode, plan.Quantity, plan.Price));
                }
            }
        }

        public static FDDLManager getFDDLManager()
        {
            return s_fddls;
        }

        public static void runPlans()
        {
            s_fddls.runPlans();
        }

        private static void reserveReport()
        {
            Timer timer = new Timer();
            timer.AutoReset = false;
            timer.Interval = (s_reportTime - DateTime.Now).TotalMilliseconds;
            timer.Elapsed += runReport;
        }

        private static void deleteTodayPlans()
        {
            string[] planList = Directory.GetFiles("./DownloadedPlans");
            foreach (string filename in planList)
            {
                File.Delete(string.Format("./DownloadedPlans/{0}", filename));
            }
        }
        private static void runReport(object sender, ElapsedEventArgs e)
        {
            deleteTodayPlans();
            s_fddls.reportResults();
        }
    }
}
