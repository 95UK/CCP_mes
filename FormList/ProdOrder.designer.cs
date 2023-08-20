namespace FormList
{
    partial class ProdOrder
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
            this.btnOrdUp = new System.Windows.Forms.Button();
            this.cboOrdLineC = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.GrbOrdList = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.cboOrdListItemName = new System.Windows.Forms.ComboBox();
            this.txtOrdListQty = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboOrdListLineC = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboOrdListPlantC = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtOrdListNo = new System.Windows.Forms.TextBox();
            this.txtOrdListMaker = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.DateOrdList = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOrdQty = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DateOrd = new System.Windows.Forms.DateTimePicker();
            this.cboPlantCode = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboItemName = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.GrbOrdList.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.cboItemName);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.cboPlantCode);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.DateOrd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtOrdQty);
            this.groupBox1.Controls.Add(this.btnOrdUp);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboOrdLineC);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox2.Controls.Add(this.Grid);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.GrbOrdList);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            // 
            // btnOrdUp
            // 
            this.btnOrdUp.BackColor = System.Drawing.Color.Azure;
            this.btnOrdUp.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOrdUp.Location = new System.Drawing.Point(1072, 22);
            this.btnOrdUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrdUp.Name = "btnOrdUp";
            this.btnOrdUp.Size = new System.Drawing.Size(90, 75);
            this.btnOrdUp.TabIndex = 7;
            this.btnOrdUp.Text = "등록";
            this.btnOrdUp.UseVisualStyleBackColor = false;
            this.btnOrdUp.Click += new System.EventHandler(this.btnOrdUp_Click);
            // 
            // cboOrdLineC
            // 
            this.cboOrdLineC.FormattingEnabled = true;
            this.cboOrdLineC.Location = new System.Drawing.Point(479, 60);
            this.cboOrdLineC.Name = "cboOrdLineC";
            this.cboOrdLineC.Size = new System.Drawing.Size(121, 28);
            this.cboOrdLineC.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(166, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 24);
            this.label1.TabIndex = 67;
            this.label1.Text = "지시 일자 :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(419, 61);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 24);
            this.label6.TabIndex = 79;
            this.label6.Text = "라인  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(19, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 39);
            this.label2.TabIndex = 70;
            this.label2.Text = "작업 지시";
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid.GridColor = System.Drawing.SystemColors.MenuHighlight;
            this.Grid.Location = new System.Drawing.Point(3, 134);
            this.Grid.Name = "Grid";
            this.Grid.RowHeadersWidth = 53;
            this.Grid.RowTemplate.Height = 23;
            this.Grid.Size = new System.Drawing.Size(1159, 456);
            this.Grid.TabIndex = 1;
            // 
            // GrbOrdList
            // 
            this.GrbOrdList.Controls.Add(this.btnStart);
            this.GrbOrdList.Controls.Add(this.cboOrdListItemName);
            this.GrbOrdList.Controls.Add(this.txtOrdListQty);
            this.GrbOrdList.Controls.Add(this.label11);
            this.GrbOrdList.Controls.Add(this.label4);
            this.GrbOrdList.Controls.Add(this.cboOrdListLineC);
            this.GrbOrdList.Controls.Add(this.label9);
            this.GrbOrdList.Controls.Add(this.cboOrdListPlantC);
            this.GrbOrdList.Controls.Add(this.label14);
            this.GrbOrdList.Controls.Add(this.label10);
            this.GrbOrdList.Controls.Add(this.txtOrdListNo);
            this.GrbOrdList.Controls.Add(this.txtOrdListMaker);
            this.GrbOrdList.Controls.Add(this.label12);
            this.GrbOrdList.Controls.Add(this.label8);
            this.GrbOrdList.Controls.Add(this.DateOrdList);
            this.GrbOrdList.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrbOrdList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GrbOrdList.ForeColor = System.Drawing.SystemColors.Highlight;
            this.GrbOrdList.Location = new System.Drawing.Point(3, 22);
            this.GrbOrdList.Margin = new System.Windows.Forms.Padding(2);
            this.GrbOrdList.Name = "GrbOrdList";
            this.GrbOrdList.Padding = new System.Windows.Forms.Padding(2);
            this.GrbOrdList.Size = new System.Drawing.Size(1159, 112);
            this.GrbOrdList.TabIndex = 2;
            this.GrbOrdList.TabStop = false;
            this.GrbOrdList.Text = "작업 지시 조회";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(910, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(180, 87);
            this.btnStart.TabIndex = 113;
            this.btnStart.Text = "가동 시작";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cboOrdListItemName
            // 
            this.cboOrdListItemName.FormattingEnabled = true;
            this.cboOrdListItemName.Location = new System.Drawing.Point(602, 73);
            this.cboOrdListItemName.Name = "cboOrdListItemName";
            this.cboOrdListItemName.Size = new System.Drawing.Size(121, 28);
            this.cboOrdListItemName.TabIndex = 13;
            // 
            // txtOrdListQty
            // 
            this.txtOrdListQty.Location = new System.Drawing.Point(819, 74);
            this.txtOrdListQty.Name = "txtOrdListQty";
            this.txtOrdListQty.Size = new System.Drawing.Size(122, 26);
            this.txtOrdListQty.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(735, 75);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 24);
            this.label11.TabIndex = 112;
            this.label11.Text = "지시수량 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(532, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 24);
            this.label4.TabIndex = 111;
            this.label4.Text = "품목명 :";
            // 
            // cboOrdListLineC
            // 
            this.cboOrdListLineC.FormattingEnabled = true;
            this.cboOrdListLineC.Location = new System.Drawing.Point(97, 73);
            this.cboOrdListLineC.Name = "cboOrdListLineC";
            this.cboOrdListLineC.Size = new System.Drawing.Size(121, 28);
            this.cboOrdListLineC.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(36, 75);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 24);
            this.label9.TabIndex = 109;
            this.label9.Text = "라인  :";
            // 
            // cboOrdListPlantC
            // 
            this.cboOrdListPlantC.FormattingEnabled = true;
            this.cboOrdListPlantC.Location = new System.Drawing.Point(97, 36);
            this.cboOrdListPlantC.Name = "cboOrdListPlantC";
            this.cboOrdListPlantC.Size = new System.Drawing.Size(121, 28);
            this.cboOrdListPlantC.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label14.Location = new System.Drawing.Point(37, 38);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 24);
            this.label14.TabIndex = 105;
            this.label14.Text = "공장  :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label10.Location = new System.Drawing.Point(952, 75);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 24);
            this.label10.TabIndex = 100;
            this.label10.Text = "등록자 :";
            // 
            // txtOrdListNo
            // 
            this.txtOrdListNo.Location = new System.Drawing.Point(357, 74);
            this.txtOrdListNo.Name = "txtOrdListNo";
            this.txtOrdListNo.Size = new System.Drawing.Size(150, 26);
            this.txtOrdListNo.TabIndex = 10;
            // 
            // txtOrdListMaker
            // 
            this.txtOrdListMaker.Location = new System.Drawing.Point(1021, 74);
            this.txtOrdListMaker.Name = "txtOrdListMaker";
            this.txtOrdListMaker.Size = new System.Drawing.Size(122, 26);
            this.txtOrdListMaker.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label12.Location = new System.Drawing.Point(266, 75);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 24);
            this.label12.TabIndex = 97;
            this.label12.Text = "지시번호 :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label8.Location = new System.Drawing.Point(261, 38);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 24);
            this.label8.TabIndex = 87;
            this.label8.Text = "지시 일자 :";
            // 
            // DateOrdList
            // 
            this.DateOrdList.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateOrdList.Location = new System.Drawing.Point(357, 37);
            this.DateOrdList.Margin = new System.Windows.Forms.Padding(2);
            this.DateOrdList.Name = "DateOrdList";
            this.DateOrdList.Size = new System.Drawing.Size(150, 26);
            this.DateOrdList.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(811, 61);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 24);
            this.label3.TabIndex = 86;
            this.label3.Text = "지시수량 :";
            // 
            // txtOrdQty
            // 
            this.txtOrdQty.Location = new System.Drawing.Point(891, 60);
            this.txtOrdQty.Name = "txtOrdQty";
            this.txtOrdQty.Size = new System.Drawing.Size(122, 26);
            this.txtOrdQty.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1159, 456);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // DateOrd
            // 
            this.DateOrd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateOrd.Location = new System.Drawing.Point(255, 60);
            this.DateOrd.Margin = new System.Windows.Forms.Padding(2);
            this.DateOrd.Name = "DateOrd";
            this.DateOrd.Size = new System.Drawing.Size(150, 26);
            this.DateOrd.TabIndex = 2;
            // 
            // cboPlantCode
            // 
            this.cboPlantCode.FormattingEnabled = true;
            this.cboPlantCode.Location = new System.Drawing.Point(255, 21);
            this.cboPlantCode.Name = "cboPlantCode";
            this.cboPlantCode.Size = new System.Drawing.Size(121, 28);
            this.cboPlantCode.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label13.Location = new System.Drawing.Point(195, 20);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 24);
            this.label13.TabIndex = 103;
            this.label13.Text = "공장  :";
            // 
            // cboItemName
            // 
            this.cboItemName.FormattingEnabled = true;
            this.cboItemName.Location = new System.Drawing.Point(680, 60);
            this.cboItemName.Name = "cboItemName";
            this.cboItemName.Size = new System.Drawing.Size(121, 28);
            this.cboItemName.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label15.Location = new System.Drawing.Point(610, 61);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 24);
            this.label15.TabIndex = 107;
            this.label15.Text = "품목명 :";
            // 
            // ProdOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(1165, 693);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProdOrder";
            this.Load += new System.EventHandler(this.ProdOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.GrbOrdList.ResumeLayout(false);
            this.GrbOrdList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOrdUp;
        private System.Windows.Forms.ComboBox cboOrdLineC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.GroupBox GrbOrdList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOrdQty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker DateOrdList;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtOrdListNo;
        private System.Windows.Forms.TextBox txtOrdListMaker;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker DateOrd;
        private System.Windows.Forms.ComboBox cboPlantCode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboOrdListPlantC;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboItemName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboOrdListItemName;
        private System.Windows.Forms.TextBox txtOrdListQty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboOrdListLineC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnStart;
    }
}
