using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FDDLStrategy
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            m_gateway.CommConnect();
        }


        private void OnReceiveChejanData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveChejanDataEvent e)
        {
            ContractionEventManager.gotContracted(e.sGubun, e.sFIdList);
        }

        private void OnRecceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            ContractionEventManager.gotContracting(e.sTrCode, e.sRQName);
            TrEventManager.gotTrData(e.sTrCode, e.sRQName);
        }

        private void m_gateway_OnReceiveMsg(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveMsgEvent e)
        {
            ContractionEventManager.gotContractionMessage(e.sRQName, e.sMsg);
        }

        private void m_listStrat_DoubleClick(object sender, EventArgs e)
        {
            if(m_listStrat.SelectedItem.ToString().Equals("FDDL"))
            {
                FDDLUIBinder.openWindow();
            }
        }

        private void m_gateway_OnEventConnect(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEvent e)
        { 
            m_listStrat.Items.Add("FDDL");
            ProgramControl.start(m_gateway);
        }
    }
}
