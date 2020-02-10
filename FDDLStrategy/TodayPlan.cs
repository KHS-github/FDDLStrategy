using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDDLStrategy
{
    public enum OrderType
    {
        BUY,
        SELL
    }

    abstract class TodayPlan
    {
        private string m_id;
        private string m_planName;
        private string m_stockCode;
        private int m_quantity;
        private OrderType m_orderType;
        private int m_price;
        private int m_achieved;

        public TodayPlan(string id, string planName, string stockCode, int quantity, OrderType orderType, int price)
        {
            m_id = id;
            m_planName = planName;
            m_stockCode = stockCode;
            m_quantity = quantity;
            m_orderType = orderType;
            m_price = price;
            m_achieved = 0;
        }

        public abstract void run();

        public void updateAchievement(int quantity)
        {
            m_achieved += quantity;
        }

        public string getID()
        {
            return m_id;
        }

        public string getPlanName()
        {
            return m_planName;
        }

        public string getStockCode()
        {
            return m_stockCode;
        }

        public int getQuantity()
        {
            return m_quantity;
        }

        public int getPrice()
        {
            return m_price;
        }

        public int getAchieved()
        {
            return m_achieved;
        }
    }
}
