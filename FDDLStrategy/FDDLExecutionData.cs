using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDDLStrategy
{
    class ContractionResult
    {
        public int price;
        public int quantity;

        public ContractionResult(int price, int quantity)
        {
            this.price = price;
            this.quantity = quantity;
        }
    }

    class FDDLExecutionData
    {
        private string m_stockName;
        private OrderType m_orderType;
        private int m_quantity;
        private int m_orderedQ;
        private int m_achievedQ;
        private List<ContractionResult> m_contractions = new List<ContractionResult>();

        public FDDLExecutionData(string stockName, OrderType orderType, int quantity, int orderedQ)
        {
            m_stockName = stockName;
            m_orderType = orderType;
            m_quantity = quantity;
            m_orderedQ = orderedQ;
            m_achievedQ = 0;
        }

        public void addContracted(int price, int quantity)
        {
            m_achievedQ += quantity;
            m_contractions.Add(new ContractionResult(price, quantity));
        }

        public string getStockName()
        {
            return m_stockName;
        }

        public OrderType getOrderType()
        {
            return m_orderType;
        }

        public int getQuantity()
        {
            return m_quantity;
        }

        public int getOrderedQuantity()
        {
            return m_orderedQ;
        }

        public int getAchieved()
        {
            return m_achievedQ;
        }

        public List<ContractionResult> getContractions()
        {
            return m_contractions;
        }
    }
}
