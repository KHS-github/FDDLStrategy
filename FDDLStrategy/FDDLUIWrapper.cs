using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FDDLStrategy
{
    class FDDLUIWrapper
    {
        private Dictionary<string, FDDLExecutionData> m_rawData = new Dictionary<string, FDDLExecutionData>();
        private ListView m_mainList = null;
        private ListView m_subList = null;

        public FDDLUIWrapper()
        {
        }

        public void openedSummaryWindow(ListView mainList, ListView subList)
        {
            m_mainList = mainList;
            m_subList = subList;

            if(m_mainList != null)
            {
                foreach (var raw in m_rawData)
                {
                    addToMainList(raw.Value);
                }
            }
            if(m_subList != null)
            {
                foreach(var raw in m_rawData)
                {
                    foreach(var sub in raw.Value.getContractions())
                    {
                        addToSubList(sub.price, sub.quantity);
                    }
                }
            }
        }

        public void closedSummaryWindow()
        {
            m_mainList = null;
            m_subList = null;
        }

        public void addNewOrder(string orderId, FDDLExecutionData exeData)
        {
            m_rawData[orderId] = exeData;
            if(m_mainList != null)
            {
                addToMainList(exeData);
            }
        }

        private void addToMainList(FDDLExecutionData exeData)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = exeData.getStockName();
            string orderTypeStr = exeData.getOrderType() == OrderType.BUY ? "매수" : "매도";
            lvi.SubItems.Add(orderTypeStr);
            lvi.SubItems.Add(exeData.getQuantity().ToString());
            lvi.SubItems.Add(exeData.getOrderedQuantity().ToString());
            lvi.SubItems.Add(exeData.getAchieved().ToString());
            m_mainList.Items.Add(lvi);
        }

        public void addNewContracted(string orderId, int price, int quantity)
        {
            m_rawData[orderId].addContracted(price, quantity);

            FDDLExecutionData data = m_rawData[orderId];

            if(m_mainList != null)
            {
                updateMainList(data.getStockName(), data.getAchieved());
            }
            if(m_subList != null)
            {
                addToSubList(price, quantity);
            }
        }

        private void updateMainList(string stockName, int achieved)
        {
            ListViewItem item = m_mainList.Items.Find(stockName, false)[0];
            item.SubItems[3].Text = achieved.ToString();
        }

        private void addToSubList(int price, int quantity)
        {
            ListViewItem item = new ListViewItem();
            item.Text = price.ToString();
            item.SubItems.Add(quantity.ToString());

            m_subList.Items.Add(item);
        }
    }
}
