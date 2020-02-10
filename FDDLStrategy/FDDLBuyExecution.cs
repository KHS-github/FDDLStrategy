using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FDDLStrategy
{
    class FDDLAfterMarketEP : TrEventCallback
    {
        private FDDLBuyExecution m_parent;

        public FDDLAfterMarketEP(FDDLBuyExecution parent)
        {
            m_parent = parent;
        }
        public void eventCallback(TrInfoWrapper wrapper)
        {
            int ep = int.Parse(wrapper.getData("현재가", 0));
            if (ep <= m_parent.getPrice())
            {
                int orderQuantity = m_parent.getQuantity() - m_parent.getAchieved();
                var exeData = new FDDLExecutionData(m_parent.getStockName(), OrderType.BUY, m_parent.getQuantity(), orderQuantity);
                FDDLContractionEventCallback evcall = new FDDLContractionEventCallback(m_parent, exeData, FDDLUIBinder.getAfterWrapper());
                ContractionEventManager.addCallback("FDDL-AfterOrder", evcall);
                int res = ProgramControl.getGateway().SendOrder("FDDL-AfterOrder", Screens.SCREEN_FDDLORDER, SystemInfo.ACCOUNT, 1, m_parent.getStockCode(), orderQuantity, 0, "81", "");
                if(res != 0)
                {
                    //Debug Log -> 리턴코드 값 / 리턴코드표 참고
                }
            }
        }
    }

    class FDDLBuyExecution : ScheduledExecution
    {

        private string m_stockName;

        public FDDLBuyExecution(string id, string stockCode, int quantity, int price) :
            base(id, "FDDL", stockCode, quantity, OrderType.BUY, price)
        {
            m_stockName = ProgramControl.getGateway().GetMasterCodeName(getStockCode());
            addSchedule(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 1), firstTrial);
            addSchedule(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 40, 1), secondTrial);
            addSchedule(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 30, 1), thirdTrial);
            addSchedule(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 0, 1), forthTrial);
        }


        private void firstTrial(object sender, ElapsedEventArgs e)
        {
            var exeData = new FDDLExecutionData(m_stockName, OrderType.BUY, getQuantity(), getQuantity());
            FDDLContractionEventCallback evcall = new FDDLContractionEventCallback(this, exeData, FDDLUIBinder.getBeforeWrapper());
            ContractionEventManager.addCallback("FDDL-Before", evcall);
            int res = ProgramControl.getGateway().SendOrder("FDDL-Before", Screens.SCREEN_FDDLORDER, SystemInfo.ACCOUNT, 1, getStockCode(), getQuantity(), 0, "61", "");
            if (res != 0)
            {
                //Debug Log -> 리턴코드 값 / 리턴코드표 참고
            }
        }
        private void secondTrial(object sender, ElapsedEventArgs e)
        {
            int orderQuantity = getQuantity() - getAchieved();
            var exeData = new FDDLExecutionData(m_stockName, OrderType.BUY, getQuantity(), orderQuantity);
            FDDLContractionEventCallback evcall = new FDDLContractionEventCallback(this, exeData, FDDLUIBinder.getRegularWrapper());
            ContractionEventManager.addCallback("FDDL-Regular", evcall);
            int res = ProgramControl.getGateway().SendOrder("FDDL-Regular", Screens.SCREEN_FDDLORDER, SystemInfo.ACCOUNT, 1, getStockCode(), orderQuantity, getPrice(), "00", "");
            if (res != 0)
            {
                //Debug Log -> 리턴코드 값 / 리턴코드표 참고
            }
        }

        private void thirdTrial(object sender, ElapsedEventArgs e)
        {
            TrEventManager.addCallback("FDDL-AfterMarket", new FDDLAfterMarketEP(this));
            int res = ProgramControl.getGateway().CommRqData("FDDL-AfterMarket", "opt10001", 0, Screens.SCREEN_FDDLORDER);
            if (res != 0)
            {
                //Debug Log -> 리턴코드 값 / 리턴코드표 참고
            }
        }

        private void forthTrial(object sender, ElapsedEventArgs e)
        {
            int orderQuantity = getQuantity() - getAchieved();
            var exeData = new FDDLExecutionData(m_stockName, OrderType.BUY, getQuantity(), orderQuantity);
            var evcall = new FDDLContractionEventCallback(this, exeData, FDDLUIBinder.getAAfterWrapper());
            ContractionEventManager.addCallback("FDDL-AAfter", evcall);
            int res = ProgramControl.getGateway().SendOrder("FDDL-AAfter", Screens.SCREEN_FDDLORDER, SystemInfo.ACCOUNT, 1, getStockCode(), orderQuantity, getPrice(), "62", "");
            if(res != 0)
            {
                //Debug Log -> 리턴코드 값 / 리턴코드표 참고
            }
        }

        public string getStockName()
        {
            return m_stockName;
        }

    }
}
