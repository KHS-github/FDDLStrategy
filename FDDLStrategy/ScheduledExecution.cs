using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FDDLStrategy
{
    class ScheduledExecution : TodayPlan
    {
        public delegate void ExeTask(object sender, ElapsedEventArgs e);

        private List<DateTime> m_scheTime = new List<DateTime>();
        private List<ExeTask> m_tasks = new List<ExeTask>();
        private List<Timer> m_timers = new List<Timer>();

        public ScheduledExecution(string id, string planName, string stockCode, int quantity, OrderType orderType, int price) : base(id, planName, stockCode, quantity, orderType, price)
        {
        }

        public void addSchedule(DateTime time, ExeTask task)
        {
            m_scheTime.Add(time);
            m_tasks.Add(task);
        }

        public override void run()
        {
            DateTime now = DateTime.Now;
                int flag = 0;
            for (int i = 0; i < m_scheTime.Count; i++)
            {
                try
                {
                    if (m_scheTime[i] > now)
                    {
                        if (flag == 0)
                        {
                            if (i > 0)
                            {
                                m_tasks[i - 1](null, null);
                            }
                            flag = 1;
                        }
                        reserveTask(m_scheTime[i] - now, m_tasks[i]);
                    }
                }
                catch (Exception e)
                {
                    string errorMessage = string.Format(
                        "Exception : ScheduledExecution : run\n" +
                        "Exception Message : {0}\n" +
                        "Detail\n" +
                        "ID : {1}\n" +
                        "PlanName : {2}\n" +
                        "StockCode : {3}", e.Message, getID(), getPlanName(), getStockCode());
                    ProgramControl.getLogger().Error(errorMessage);
                }
            }
        }


        private void reserveTask(TimeSpan remained, ExeTask task)
        {
            Timer timer = new Timer();
            timer.Interval = remained.TotalMilliseconds;
            timer.Elapsed += new ElapsedEventHandler(task);
            timer.AutoReset = false;
            timer.Start();
            m_timers.Add(timer);
        }

        public void finalize()
        {
            foreach (var timer in m_timers)
            {
                timer.Stop();
            }
        }
    }
}
