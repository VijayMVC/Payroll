namespace Payroll
{
    partial class AttendanceShiftEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendanceShiftEdit));
            this.dtpOvertimeOut = new System.Windows.Forms.DateTimePicker();
            this.txtEmployeeIDS = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.chkOO = new System.Windows.Forms.CheckBox();
            this.chkOI = new System.Windows.Forms.CheckBox();
            this.dtpOvertimeIn = new System.Windows.Forms.DateTimePicker();
            this.chkPO = new System.Windows.Forms.CheckBox();
            this.dtpPunchOut = new System.Windows.Forms.DateTimePicker();
            this.chkBI = new System.Windows.Forms.CheckBox();
            this.dtpBreakIn = new System.Windows.Forms.DateTimePicker();
            this.chkBO = new System.Windows.Forms.CheckBox();
            this.dtpBreakOut = new System.Windows.Forms.DateTimePicker();
            this.chkPI = new System.Windows.Forms.CheckBox();
            this.dtpPunchIn = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIDS = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tlsAttendanceRuleSave = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveAdnClose = new System.Windows.Forms.ToolStripButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpOvertimeOut
            // 
            this.dtpOvertimeOut.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpOvertimeOut.Location = new System.Drawing.Point(170, 274);
            this.dtpOvertimeOut.Name = "dtpOvertimeOut";
            this.dtpOvertimeOut.Size = new System.Drawing.Size(207, 20);
            this.dtpOvertimeOut.TabIndex = 90;
            // 
            // txtEmployeeIDS
            // 
            this.txtEmployeeIDS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeIDS.Location = new System.Drawing.Point(275, 39);
            this.txtEmployeeIDS.Name = "txtEmployeeIDS";
            this.txtEmployeeIDS.Size = new System.Drawing.Size(102, 23);
            this.txtEmployeeIDS.TabIndex = 89;
            this.txtEmployeeIDS.Text = "0";
            this.txtEmployeeIDS.Visible = false;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(170, 73);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(207, 20);
            this.dtpDate.TabIndex = 88;
            // 
            // chkOO
            // 
            this.chkOO.AutoSize = true;
            this.chkOO.Location = new System.Drawing.Point(387, 280);
            this.chkOO.Name = "chkOO";
            this.chkOO.Size = new System.Drawing.Size(15, 14);
            this.chkOO.TabIndex = 87;
            this.chkOO.UseVisualStyleBackColor = true;
            this.chkOO.CheckedChanged += new System.EventHandler(this.chkOO_CheckedChanged);
            // 
            // chkOI
            // 
            this.chkOI.AutoSize = true;
            this.chkOI.Location = new System.Drawing.Point(387, 243);
            this.chkOI.Name = "chkOI";
            this.chkOI.Size = new System.Drawing.Size(15, 14);
            this.chkOI.TabIndex = 86;
            this.chkOI.UseVisualStyleBackColor = true;
            this.chkOI.CheckedChanged += new System.EventHandler(this.chkOI_CheckedChanged);
            // 
            // dtpOvertimeIn
            // 
            this.dtpOvertimeIn.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpOvertimeIn.Location = new System.Drawing.Point(170, 239);
            this.dtpOvertimeIn.Name = "dtpOvertimeIn";
            this.dtpOvertimeIn.Size = new System.Drawing.Size(207, 20);
            this.dtpOvertimeIn.TabIndex = 85;
            // 
            // chkPO
            // 
            this.chkPO.AutoSize = true;
            this.chkPO.Location = new System.Drawing.Point(387, 204);
            this.chkPO.Name = "chkPO";
            this.chkPO.Size = new System.Drawing.Size(15, 14);
            this.chkPO.TabIndex = 84;
            this.chkPO.UseVisualStyleBackColor = true;
            this.chkPO.CheckedChanged += new System.EventHandler(this.chkPO_CheckedChanged);
            // 
            // dtpPunchOut
            // 
            this.dtpPunchOut.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpPunchOut.Location = new System.Drawing.Point(170, 200);
            this.dtpPunchOut.Name = "dtpPunchOut";
            this.dtpPunchOut.Size = new System.Drawing.Size(207, 20);
            this.dtpPunchOut.TabIndex = 83;
            // 
            // chkBI
            // 
            this.chkBI.AutoSize = true;
            this.chkBI.Location = new System.Drawing.Point(387, 169);
            this.chkBI.Name = "chkBI";
            this.chkBI.Size = new System.Drawing.Size(15, 14);
            this.chkBI.TabIndex = 82;
            this.chkBI.UseVisualStyleBackColor = true;
            this.chkBI.CheckedChanged += new System.EventHandler(this.chkBI_CheckedChanged);
            // 
            // dtpBreakIn
            // 
            this.dtpBreakIn.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpBreakIn.Location = new System.Drawing.Point(170, 165);
            this.dtpBreakIn.Name = "dtpBreakIn";
            this.dtpBreakIn.Size = new System.Drawing.Size(207, 20);
            this.dtpBreakIn.TabIndex = 81;
            // 
            // chkBO
            // 
            this.chkBO.AutoSize = true;
            this.chkBO.Location = new System.Drawing.Point(387, 136);
            this.chkBO.Name = "chkBO";
            this.chkBO.Size = new System.Drawing.Size(15, 14);
            this.chkBO.TabIndex = 80;
            this.chkBO.UseVisualStyleBackColor = true;
            this.chkBO.CheckedChanged += new System.EventHandler(this.chkBO_CheckedChanged);
            // 
            // dtpBreakOut
            // 
            this.dtpBreakOut.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpBreakOut.Location = new System.Drawing.Point(170, 132);
            this.dtpBreakOut.Name = "dtpBreakOut";
            this.dtpBreakOut.Size = new System.Drawing.Size(207, 20);
            this.dtpBreakOut.TabIndex = 79;
            // 
            // chkPI
            // 
            this.chkPI.AutoSize = true;
            this.chkPI.Location = new System.Drawing.Point(387, 105);
            this.chkPI.Name = "chkPI";
            this.chkPI.Size = new System.Drawing.Size(15, 14);
            this.chkPI.TabIndex = 78;
            this.chkPI.UseVisualStyleBackColor = true;
            this.chkPI.CheckedChanged += new System.EventHandler(this.chkPI_CheckedChanged);
            // 
            // dtpPunchIn
            // 
            this.dtpPunchIn.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpPunchIn.Location = new System.Drawing.Point(170, 101);
            this.dtpPunchIn.Name = "dtpPunchIn";
            this.dtpPunchIn.Size = new System.Drawing.Size(207, 20);
            this.dtpPunchIn.TabIndex = 77;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 15);
            this.label7.TabIndex = 76;
            this.label7.Text = "Date  :";
            // 
            // txtIDS
            // 
            this.txtIDS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDS.Location = new System.Drawing.Point(170, 39);
            this.txtIDS.Name = "txtIDS";
            this.txtIDS.Size = new System.Drawing.Size(102, 23);
            this.txtIDS.TabIndex = 75;
            this.txtIDS.Text = "0";
            this.txtIDS.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsAttendanceRuleSave,
            this.tsbSaveAdnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(437, 25);
            this.toolStrip1.TabIndex = 74;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tlsAttendanceRuleSave
            // 
            this.tlsAttendanceRuleSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsAttendanceRuleSave.Image = ((System.Drawing.Image)(resources.GetObject("tlsAttendanceRuleSave.Image")));
            this.tlsAttendanceRuleSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsAttendanceRuleSave.Name = "tlsAttendanceRuleSave";
            this.tlsAttendanceRuleSave.Size = new System.Drawing.Size(35, 22);
            this.tlsAttendanceRuleSave.Text = "Save";
            this.tlsAttendanceRuleSave.Click += new System.EventHandler(this.tlsAttendanceRuleSave_Click);
            // 
            // tsbSaveAdnClose
            // 
            this.tsbSaveAdnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSaveAdnClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveAdnClose.Image")));
            this.tsbSaveAdnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveAdnClose.Name = "tsbSaveAdnClose";
            this.tsbSaveAdnClose.Size = new System.Drawing.Size(88, 22);
            this.tsbSaveAdnClose.Text = "Save and close";
            this.tsbSaveAdnClose.Click += new System.EventHandler(this.tsbSaveAdnClose_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 281);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 73;
            this.label6.Text = "Overtime Out:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 72;
            this.label5.Text = "Overtime In :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 15);
            this.label4.TabIndex = 71;
            this.label4.Text = "Punch-Out Time :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 70;
            this.label3.Text = "Break-In Time :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 69;
            this.label2.Text = "Break-Out Time :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 68;
            this.label1.Text = "Punch-In Time :";
            // 
            // AttendanceShiftEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 350);
            this.Controls.Add(this.dtpOvertimeOut);
            this.Controls.Add(this.txtEmployeeIDS);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.chkOO);
            this.Controls.Add(this.chkOI);
            this.Controls.Add(this.dtpOvertimeIn);
            this.Controls.Add(this.chkPO);
            this.Controls.Add(this.dtpPunchOut);
            this.Controls.Add(this.chkBI);
            this.Controls.Add(this.dtpBreakIn);
            this.Controls.Add(this.chkBO);
            this.Controls.Add(this.dtpBreakOut);
            this.Controls.Add(this.chkPI);
            this.Controls.Add(this.dtpPunchIn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtIDS);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AttendanceShiftEdit";
            this.Text = "AttendanceShiftEdit";
            this.Load += new System.EventHandler(this.AttendanceShiftEdit_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpOvertimeOut;
        public System.Windows.Forms.TextBox txtEmployeeIDS;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.CheckBox chkOO;
        private System.Windows.Forms.CheckBox chkOI;
        private System.Windows.Forms.DateTimePicker dtpOvertimeIn;
        private System.Windows.Forms.CheckBox chkPO;
        private System.Windows.Forms.DateTimePicker dtpPunchOut;
        private System.Windows.Forms.CheckBox chkBI;
        private System.Windows.Forms.DateTimePicker dtpBreakIn;
        private System.Windows.Forms.CheckBox chkBO;
        private System.Windows.Forms.DateTimePicker dtpBreakOut;
        private System.Windows.Forms.CheckBox chkPI;
        private System.Windows.Forms.DateTimePicker dtpPunchIn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIDS;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tlsAttendanceRuleSave;
        private System.Windows.Forms.ToolStripButton tsbSaveAdnClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}