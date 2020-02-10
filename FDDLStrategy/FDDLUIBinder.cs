using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDDLStrategy
{
    class FDDLUIBinder
    {
        private static FDDLSummary m_summaryWnd = null;

        private static FDDLUIWrapper m_beforeData = new FDDLUIWrapper();
        private static FDDLUIWrapper m_regularData = new FDDLUIWrapper();
        private static FDDLUIWrapper m_afterData = new FDDLUIWrapper();
        private static FDDLUIWrapper m_aafterData = new FDDLUIWrapper();

        private FDDLUIBinder()
        {
        }

        public static void openWindow()
        {
            m_summaryWnd = new FDDLSummary();
            m_summaryWnd.Show();
        }

        public static bool isOpened()
        {
            return m_summaryWnd != null;
        }

        public static FDDLUIWrapper getBeforeWrapper()
        {
            return m_beforeData;
        }

        public static FDDLUIWrapper getRegularWrapper()
        {
            return m_regularData;
        }

        public static FDDLUIWrapper getAfterWrapper()
        {
            return m_afterData;

        }

        public static FDDLUIWrapper getAAfterWrapper()
        {
            return m_aafterData;
        }
    }
}
