namespace Payroll
{
    partial class AttendanceRule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendanceRule));
            this.dtpPunchIn = new Telerik.WinControls.UI.RadTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpBreakOut = new Telerik.WinControls.UI.RadTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpBreakIn = new Telerik.WinControls.UI.RadTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpPunchOut = new Telerik.WinControls.UI.RadTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpOvertimeIn = new Telerik.WinControls.UI.RadTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpOvertimeOut = new Telerik.WinControls.UI.RadTimePicker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPenalty = new System.Windows.Forms.TextBox();
            this.txtIDS = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboDayOfTheWeek = new System.Windows.Forms.ComboBox();
            this.cboShiftName = new System.Windows.Forms.ComboBox();
            this.tlsAttendanceRuleSave = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveAdnClose = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPunchIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBreakOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBreakIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPunchOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOvertimeIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOvertimeOut)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpPunchIn
            // 
            this.dtpPunchIn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPunchIn.Location = new System.Drawing.Point(192, 143);
            this.dtpPunchIn.Name = "dtpPunchIn";
            this.dtpPunchIn.Size = new System.Drawing.Size(174, 21);
            this.dtpPunchIn.TabIndex = 0;
            this.dtpPunchIn.TabStop = false;
            this.dtpPunchIn.Value = new System.DateTime(2015, 7, 16, 21, 44, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Punch-In Time :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Break-Out Time :";
            // 
            // dtpBreakOut
            // 
            this.dtpBreakOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBreakOut.Location = new System.Drawing.Point(192, 174);
            this.dtpBreakOut.Name = "dtpBreakOut";
            this.dtpBreakOut.Size = new System.Drawing.Size(174, 21);
            this.dtpBreakOut.TabIndex = 2;
            this.dtpBreakOut.TabStop = false;
            this.dtpBreakOut.Value = new System.DateTime(2015, 7, 16, 21, 44, 0, 0);
            this.dtpBreakOut.Click += new System.EventHandler(this.dtpBreakOut_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Break-In Time :";
            // 
            // dtpBreakIn
            // 
            this.dtpBreakIn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBreakIn.Location = new System.Drawing.Point(192, 207);
            this.dtpBreakIn.Name = "dtpBreakIn";
            this.dtpBreakIn.Size = new System.Drawing.Size(174, 21);
            this.dtpBreakIn.TabIndex = 4;
            this.dtpBreakIn.TabStop = false;
            this.dtpBreakIn.Value = new System.DateTime(2015, 7, 16, 21, 44, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Punch-Out Time :";
            // 
            // dtpPunchOut
            // 
            this.dtpPunchOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPunchOut.Location = new System.Drawing.Point(192, 244);
            this.dtpPunchOut.Name = "dtpPunchOut";
            this.dtpPunchOut.Size = new System.Drawing.Size(174, 21);
            this.dtpPunchOut.TabIndex = 6;
            this.dtpPunchOut.TabStop = false;
            this.dtpPunchOut.Value = new System.DateTime(2015, 7, 16, 21, 44, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Overtime In :";
            // 
            // dtpOvertimeIn
            // 
            this.dtpOvertimeIn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOvertimeIn.Location = new System.Drawing.Point(192, 284);
            this.dtpOvertimeIn.Name = "dtpOvertimeIn";
            this.dtpOvertimeIn.Size = new System.Drawing.Size(174, 21);
            this.dtpOvertimeIn.TabIndex = 8;
            this.dtpOvertimeIn.TabStop = false;
            this.dtpOvertimeIn.Value = new System.DateTime(2015, 7, 16, 21, 44, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(36, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Overtime Out:";
            // 
            // dtpOvertimeOut
            // 
            this.dtpOvertimeOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOvertimeOut.Location = new System.Drawing.Point(192, 318);
            this.dtpOvertimeOut.Name = "dtpOvertimeOut";
            this.dtpOvertimeOut.Size = new System.Drawing.Size(174, 21);
            this.dtpOvertimeOut.TabIndex = 10;
            this.dtpOvertimeOut.TabStop = false;
            this.dtpOvertimeOut.Value = new System.DateTime(2015, 7, 16, 21, 44, 0, 0);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsAttendanceRuleSave,
            this.tsbSaveAdnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(413, 25);
            this.toolStrip1.TabIndex = 31;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(36, 357);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 15);
            this.label7.TabIndex = 32;
            this.label7.Text = "Late per minute penalty :";
            // 
            // txtPenalty
            // 
            this.txtPenalty.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPenalty.Location = new System.Drawing.Point(192, 352);
            this.txtPenalty.Name = "txtPenalty";
            this.txtPenalty.Size = new System.Drawing.Size(174, 23);
            this.txtPenalty.TabIndex = 33;
            this.txtPenalty.Text = "0";
            // 
            // txtIDS
            // 
            this.txtIDS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDS.Location = new System.Drawing.Point(192, 40);
            this.txtIDS.Name = "txtIDS";
            this.txtIDS.Size = new System.Drawing.Size(174, 23);
            this.txtIDS.TabIndex = 34;
            this.txtIDS.Text = "0";
            this.txtIDS.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(36, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 15);
            this.label8.TabIndex = 35;
            this.label8.Text = "Shift Name :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(36, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 15);
            this.label9.TabIndex = 37;
            this.label9.Text = "Day of the week :";
            // 
            // cboDayOfTheWeek
            // 
            this.cboDayOfTheWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDayOfTheWeek.FormattingEnabled = true;
            this.cboDayOfTheWeek.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wenesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.cboDayOfTheWeek.Location = new System.Drawing.Point(192, 111);
            this.cboDayOfTheWeek.Name = "cboDayOfTheWeek";
            this.cboDayOfTheWeek.Size = new System.Drawing.Size(173, 21);
            this.cboDayOfTheWeek.TabIndex = 38;
            // 
            // cboShiftName
            // 
            this.cboShiftName.FormattingEnabled = true;
            this.cboShiftName.Location = new System.Drawing.Point(192, 79);
            this.cboShiftName.Name = "cboShiftName";
            this.cboShiftName.Size = new System.Drawing.Size(173, 21);
            this.cboShiftName.TabIndex = 39;
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
            // AttendanceRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 412);
            this.Controls.Add(this.cboShiftName);
            this.Controls.Add(this.cboDayOfTheWeek);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtIDS);
            this.Controls.Add(this.txtPenalty);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpOvertimeOut);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpOvertimeIn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpPunchOut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpBreakIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpBreakOut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpPunchIn);
            this.Name = "AttendanceRule";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shift ";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.dtpPunchIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBreakOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBreakIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPunchOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOvertimeIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOvertimeOut)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTimePicker dtpPunchIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadTimePicker dtpBreakOut;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadTimePicker dtpBreakIn;
        private System.Windows.Forms.Label label4;
        private Telerik.WinControls.UI.RadTimePicker dtpPunchOut;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadTimePicker dtpOvertimeIn;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadTimePicker dtpOvertimeOut;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tlsAttendanceRuleSave;
        private System.Windows.Forms.ToolStripButton tsbSaveAdnClose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPenalty;
        private System.Windows.Forms.TextBox txtIDS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboDayOfTheWeek;
        private System.Windows.Forms.ComboBox cboShiftName;
    }
}
