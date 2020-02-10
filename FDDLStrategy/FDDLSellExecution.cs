using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FDDLStrategy
{
    class FDDLSellExecution : ScheduledExecution
    {

        private string m_stockName;
        public FDDLSellExecution(string id, string stockCode, int quantity, int price) : base(id, "FDDL", stockCode, quantity, OrderType.SELL, price)
        {
            m_stockName = ProgramControl.getGateway().GetMasterCodeName(getStockCode());
            addSchedule(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 20, 30), firstTrial);
            addSchedule(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 30, 10), secondTrial);
            addSchedule(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 0, 10), thirdTrial);
        }


        private void firstTrial(object sender, ElapsedEventArgs e)
        {
            var exeData = new FDDLExecutionData(m_stockName, OrderType.SELL, getQuantity(), getQuantity());
            FDDLContractionEventCallback evcall = new FDDLContractionEventCallback(null, exeData, FDDLUIBinder.getBeforeWrapper());
            ContractionEventManager.addCallback("FDDL-FirstSell", evcall);
            int res = ProgramControl.getGateway().SendOrder("FDDL-FirstSell", Screens.SCREEN_FDDLORDER, SystemInfo.ACCOUNT, 2, getStockCode(), getQuantity(), 0, "03", "");
            if (res != 0)
            {
                //Debug Log -> 리턴코드 값 / 리턴코드표 참고
            }
        }

        private void secondTrial(object sender, ElapsedEventArgs e)
        {
            var exeData = new FDDLExecutionData(m_stockName, OrderType.SELL, getQuantity(), getQuantity()-getAchieved());
            FDDLContractionEventCallback evcall = new FDDLContractionEventCallback(null, exeData, FDDLUIBinder.getAfterWrapper());
            ContractionEventManager.addCallback("FDDL-SecondSell", evcall);
            int res = ProgramControl.getGateway().SendOrder("FDDL-SecondSell", Screens.SCREEN_FDDLORDER, SystemInfo.ACCOUNT, 2, getStockCode(), getQuantity(), 0, "81", "");
            if (res != 0)
            {
                //Debug Log -> 리턴코드 값 / 리턴코드표 참고
            }
        }

        private void thirdTrial(object sender, ElapsedEventArgs e)
        {
            var exeData = new FDDLExecutionData(m_stockName, OrderType.SELL, getQuantity(), getQuantity()-getAchieved());
            FDDLContractionEventCallback evcall = new FDDLContractionEventCallback(null, exeData, FDDLUIBinder.getAAfterWrapper());
            ContractionEventManager.addCallback("FDDL-ThirdSell", evcall);
            int res = ProgramControl.getGateway().SendOrder("FDDL-ThirdSell", Screens.SCREEN_FDDLORDER, SystemInfo.ACCOUNT, 2, getStockCode(), getQuantity(), getPrice(), "62", "");
            if (res != 0)
            {
                //Debug Log -> 리턴코드 값 / 리턴코드표 참고
            }
        }
    }
}
