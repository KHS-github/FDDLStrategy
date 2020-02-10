namespace FDDLStrategy
{
    partial class FDDLSummary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_before = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_regularUnitCtr = new System.Windows.Forms.ListView();
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.m_regular = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_after = new System.Windows.Forms.ListView();
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.m_nregular = new System.Windows.Forms.ListView();
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_nregularUnitCtr = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "장전단일가";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "장후단일가";
            // 
            // m_before
            // 
            this.m_before.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.m_before.HideSelection = false;
            this.m_before.Location = new System.Drawing.Point(14, 24);
            this.m_before.Name = "m_before";
            this.m_before.Size = new System.Drawing.Size(314, 240);
            this.m_before.TabIndex = 2;
            this.m_before.UseCompatibleStateImageBehavior = false;
            this.m_before.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "종목";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "거래";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "목표량";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "주문량";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "체결량";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "종목정보";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_regularUnitCtr);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.m_regular);
            this.groupBox1.Location = new System.Drawing.Point(338, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 252);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "장중거래";
            // 
            // m_regularUnitCtr
            // 
            this.m_regularUnitCtr.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader18,
            this.columnHeader19});
            this.m_regularUnitCtr.HideSelection = false;
            this.m_regularUnitCtr.Location = new System.Drawing.Point(334, 48);
            this.m_regularUnitCtr.Name = "m_regularUnitCtr";
            this.m_regularUnitCtr.Size = new System.Drawing.Size(131, 198);
            this.m_regularUnitCtr.TabIndex = 3;
            this.m_regularUnitCtr.UseCompatibleStateImageBehavior = false;
            this.m_regularUnitCtr.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "가격";
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "체결량";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "개별체결";
            // 
            // m_regular
            // 
            this.m_regular.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.m_regular.HideSelection = false;
            this.m_regular.Location = new System.Drawing.Point(14, 48);
            this.m_regular.Name = "m_regular";
            this.m_regular.Size = new System.Drawing.Size(314, 198);
            this.m_regular.TabIndex = 2;
            this.m_regular.UseCompatibleStateImageBehavior = false;
            this.m_regular.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "종목";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "거래";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "목표량";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "주문량";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "체결량";
            // 
            // m_after
            // 
            this.m_after.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17});
            this.m_after.HideSelection = false;
            this.m_after.Location = new System.Drawing.Point(12, 309);
            this.m_after.Name = "m_after";
            this.m_after.Size = new System.Drawing.Size(314, 240);
            this.m_after.TabIndex = 2;
            this.m_after.UseCompatibleStateImageBehavior = false;
            this.m_after.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "종목";
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "거래";
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "목표량";
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "주문량";
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "체결량";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "개별체결";
            // 
            // m_nregular
            // 
            this.m_nregular.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24});
            this.m_nregular.HideSelection = false;
            this.m_nregular.Location = new System.Drawing.Point(14, 48);
            this.m_nregular.Name = "m_nregular";
            this.m_nregular.Size = new System.Drawing.Size(314, 198);
            this.m_nregular.TabIndex = 2;
            this.m_nregular.UseCompatibleStateImageBehavior = false;
            this.m_nregular.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "종목";
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "거래";
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "목표량";
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "주문량";
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "체결량";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(349, 330);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "종목정보";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_nregularUnitCtr);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.m_nregular);
            this.groupBox2.Location = new System.Drawing.Point(338, 297);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(481, 252);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "시간외단일가";
            // 
            // m_nregularUnitCtr
            // 
            this.m_nregularUnitCtr.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12});
            this.m_nregularUnitCtr.HideSelection = false;
            this.m_nregularUnitCtr.Location = new System.Drawing.Point(334, 48);
            this.m_nregularUnitCtr.Name = "m_nregularUnitCtr";
            this.m_nregularUnitCtr.Size = new System.Drawing.Size(131, 198);
            this.m_nregularUnitCtr.TabIndex = 3;
            this.m_nregularUnitCtr.UseCompatibleStateImageBehavior = false;
            this.m_nregularUnitCtr.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "가격";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "체결량";
            // 
            // FDDLSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 559);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_after);
            this.Controls.Add(this.m_before);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FDDLSummary";
            this.Text = "FDDLSummary";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FDDLSummary_FormClosing);
            this.Load += new System.EventHandler(this.FDDLSummary_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView m_before;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView m_regular;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ListView m_after;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView m_nregular;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView m_regularUnitCtr;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ListView m_nregularUnitCtr;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
    }
}