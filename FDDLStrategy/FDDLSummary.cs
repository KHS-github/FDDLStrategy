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
    public partial class FDDLSummary : Form
    {
        public FDDLSummary()
        {
            InitializeComponent();
        }

        private void FDDLSummary_Load(object sender, EventArgs e)
        {
            FDDLUIBinder.getBeforeWrapper().openedSummaryWindow(m_before, null);
            FDDLUIBinder.getRegularWrapper().openedSummaryWindow(m_regular, m_regularUnitCtr);
            FDDLUIBinder.getAfterWrapper().openedSummaryWindow(m_after, null);
            FDDLUIBinder.getAAfterWrapper().openedSummaryWindow(m_nregular, m_nregularUnitCtr);
        }

        private void FDDLSummary_FormClosing(object sender, FormClosingEventArgs e)
        {
            FDDLUIBinder.getBeforeWrapper().closedSummaryWindow();
            FDDLUIBinder.getRegularWrapper().closedSummaryWindow();
            FDDLUIBinder.getAfterWrapper().closedSummaryWindow();
            FDDLUIBinder.getAAfterWrapper().closedSummaryWindow();
        }
    }
}
