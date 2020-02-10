using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDDLStrategy
{

    class FDDLContractionEventCallback : ContractionEventCallback
    {
        private ScheduledExecution m_plan;
        private FDDLExecutionData m_exeData;
        private FDDLUIWrapper m_uiWrapper;

        public FDDLContractionEventCallback(ScheduledExecution plan, FDDLExecutionData exeData, FDDLUIWrapper uiWrapper)
        {
            m_plan = plan;
            m_exeData = exeData;
            m_uiWrapper = uiWrapper;
        }
        public void eventTrCallback(string orderId)
        {
            m_uiWrapper.addNewOrder(orderId, m_exeData);
        }

        public void eventContractionCallback(ContractionInfoWrapper wrapper)
        {
            string orderId = wrapper.getData("주문번호");
            int price = int.Parse(wrapper.getData("단위체결가"));
            int quantity = int.Parse(wrapper.getData("단위체결량"));

            m_plan.updateAchievement(quantity);
            m_uiWrapper.addNewContracted(orderId, price, quantity);
            if(m_plan != null)
            {
                m_plan.finalize();
            }
        }

        public void eventMessageCallback(string message)
        {
            //Information Log
            ProgramControl.getLogger().Info(string.Format("FDDLContractionEventCallback : eventMessageCallback(Message : {0})", message));
        }

    }
}
