namespace FDDLStrategy
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.m_gateway = new AxKHOpenAPILib.AxKHOpenAPI();
            this.label2 = new System.Windows.Forms.Label();
            this.m_plans = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.m_listStrat = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_gateway)).BeginInit();
            this.SuspendLayout();
            // 
            // m_gateway
            // 
            this.m_gateway.Enabled = true;
            this.m_gateway.Location = new System.Drawing.Point(439, 9);
            this.m_gateway.Name = "m_gateway";
            this.m_gateway.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("m_gateway.OcxState")));
            this.m_gateway.Size = new System.Drawing.Size(64, 21);
            this.m_gateway.TabIndex = 0;
            this.m_gateway.Visible = false;
            this.m_gateway.OnReceiveTrData += new AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEventHandler(this.OnRecceiveTrData);
            this.m_gateway.OnReceiveMsg += new AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveMsgEventHandler(this.m_gateway_OnReceiveMsg);
            this.m_gateway.OnReceiveChejanData += new AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveChejanDataEventHandler(this.OnReceiveChejanData);
            this.m_gateway.OnEventConnect += new AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEventHandler(this.m_gateway_OnEventConnect);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "오늘 계획";
            // 
            // m_plans
            // 
            this.m_plans.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.m_plans.HideSelection = false;
            this.m_plans.Location = new System.Drawing.Point(12, 31);
            this.m_plans.Name = "m_plans";
            this.m_plans.Size = new System.Drawing.Size(315, 232);
            this.m_plans.TabIndex = 4;
            this.m_plans.UseCompatibleStateImageBehavior = false;
            this.m_plans.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "계획";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "거래";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "종목";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "수량";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "달성량";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(345, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "전략 요약";
            // 
            // m_listStrat
            // 
            this.m_listStrat.FormattingEnabled = true;
            this.m_listStrat.ItemHeight = 12;
            this.m_listStrat.Location = new System.Drawing.Point(347, 31);
            this.m_listStrat.Name = "m_listStrat";
            this.m_listStrat.Size = new System.Drawing.Size(130, 232);
            this.m_listStrat.TabIndex = 6;
            this.m_listStrat.DoubleClick += new System.EventHandler(this.m_listStrat_DoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 279);
            this.Controls.Add(this.m_listStrat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_plans);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_gateway);
            this.Name = "MainForm";
            this.Text = "이름모름";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_gateway)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxKHOpenAPILib.AxKHOpenAPI m_gateway;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView m_plans;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox m_listStrat;
    }
}

