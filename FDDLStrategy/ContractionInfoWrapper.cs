using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxKHOpenAPILib;


namespace FDDLStrategy
{
    class ContractionInfoWrapper
    {
        private AxKHOpenAPI m_gateway;
        private int[] m_fids;
        private int m_infotype;

        private static Dictionary<string, int> s_fidMapper = new Dictionary<string, int>();

        static ContractionInfoWrapper()
        {
            s_fidMapper["계좌번호"] = 9201;
            s_fidMapper["주문번호"] = 9203;
            s_fidMapper["종목코드"] = 9001;
            s_fidMapper["주문상태"] = 913;
            s_fidMapper["종목명"] = 302;
            s_fidMapper["주문수량"] = 900;
            s_fidMapper["주문가격"] = 901;
            s_fidMapper["미체결수량"] = 902;
            s_fidMapper["체결누계금액"] = 903;
            s_fidMapper["원주문번호"] = 904;
            s_fidMapper["주문구분"] = 905;
            s_fidMapper["매매구분"] = 906;
            s_fidMapper["매도수구분"] = 907;
            s_fidMapper["주문/체결시간"] = 908;
            s_fidMapper["체결번호"] = 909;
            s_fidMapper["체결가"] = 910;
            s_fidMapper["체결량"] = 911;
            s_fidMapper["현재가"] = 10;
            s_fidMapper["(최우선)매도호가"] = 27;
            s_fidMapper["(최우선)매수호가"] = 28;
            s_fidMapper["단위체결가"] = 914;
            s_fidMapper["단위체결량"] = 915;
            s_fidMapper["거부사유"] = 919;
            s_fidMapper["화면번호"] = 920;
            s_fidMapper["신용구분"] = 917;
            s_fidMapper["대출일"] = 916;
            s_fidMapper["보유수량"] = 930;
            s_fidMapper["매입단가"] = 931;
            s_fidMapper["총매입가"] = 932;
            s_fidMapper["주문가능수량"] = 933;
            s_fidMapper["당일순매수수량"] = 945;
            s_fidMapper["매도/매수구분"] = 946;
            s_fidMapper["당일총매도손일"] = 950;
            s_fidMapper["예수금"] = 951;
            s_fidMapper["기준가"] = 307;
            s_fidMapper["손익율"] = 8019;
            s_fidMapper["신용금액"] = 957;
            s_fidMapper["신용이자"] = 958;
            s_fidMapper["만기일"] = 918;
            s_fidMapper["당일실현손익(유가)"] = 990;
            s_fidMapper["당일실현손익률(유가)"] = 991;
            s_fidMapper["당일실현손익(신용)"] = 992;
            s_fidMapper["당일실현손익률(신용)"] = 993;
            s_fidMapper["파생상품거래단위"] = 397;
            s_fidMapper["상한가"] = 305;
            s_fidMapper["하한가"] = 306;
        }

        public ContractionInfoWrapper(AxKHOpenAPI gateway, int[] fids, int infotype)
        {
            m_gateway = gateway;
            m_fids = fids;
            m_infotype = infotype;
        }

        public string getData(string dataName)
        {
            if (s_fidMapper.ContainsKey(dataName) && m_fids.Contains(s_fidMapper[dataName]))
            {
                return m_gateway.GetChejanData(s_fidMapper[dataName]);
            }
            return "Error";
        }

        public int getInfoType()
        {
            return m_infotype;
        }
    }
}
