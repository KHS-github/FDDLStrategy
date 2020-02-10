using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxKHOpenAPILib;


namespace FDDLStrategy
{
    class TrInfoWrapper
    {
        private AxKHOpenAPI m_gateway;
        private string m_trcode;
        private string m_reqName;

        public TrInfoWrapper(AxKHOpenAPI gateway, string trcode, string reqName)
        {
            m_gateway = gateway;
            m_trcode = trcode;
            m_reqName = reqName;
        }

        public string getData(string key, int idx)
        {
            return m_gateway.GetCommData(m_trcode, m_reqName, idx, key);
        }
    }
}
