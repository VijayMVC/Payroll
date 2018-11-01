namespace Payroll
{
    partial class PayrollNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayrollNew));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tlsEmployee = new System.Windows.Forms.ToolStripButton();
            this.tsbEmployeeSaveAndClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrintPayroll = new System.Windows.Forms.ToolStripButton();
            this.tsbPayslipPrint = new System.Windows.Forms.ToolStripButton();
            this.dgvPayroll = new System.Windows.Forms.DataGridView();
            this.dtpFrom = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtpTo = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.radLabel14 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkSavings = new System.Windows.Forms.CheckBox();
            this.chkPagIBIGLoan = new System.Windows.Forms.CheckBox();
            this.chkSSSLoan = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPagIBIGPrem = new System.Windows.Forms.CheckBox();
            this.chkPHICPrem = new System.Windows.Forms.CheckBox();
            this.chkSSSPrem = new System.Windows.Forms.CheckBox();
            this.cmdCompute = new System.Windows.Forms.Button();
            this.txtIDS = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.radStatusStrip1 = new Telerik.WinControls.UI.RadStatusStrip();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsEmployee,
            this.tsbEmployeeSaveAndClose,
            this.toolStripSeparator1,
            this.tsbPrintPayroll,
            this.tsbPayslipPrint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1081, 25);
            this.toolStrip1.TabIndex = 31;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tlsEmployee
            // 
            this.tlsEmployee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsEmployee.Image = ((System.Drawing.Image)(resources.GetObject("tlsEmployee.Image")));
            this.tlsEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsEmployee.Name = "tlsEmployee";
            this.tlsEmployee.Size = new System.Drawing.Size(35, 22);
            this.tlsEmployee.Text = "Save";
            this.tlsEmployee.Click += new System.EventHandler(this.tlsEmployee_Click);
            // 
            // tsbEmployeeSaveAndClose
            // 
            this.tsbEmployeeSaveAndClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbEmployeeSaveAndClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbEmployeeSaveAndClose.Image")));
            this.tsbEmployeeSaveAndClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEmployeeSaveAndClose.Name = "tsbEmployeeSaveAndClose";
            this.tsbEmployeeSaveAndClose.Size = new System.Drawing.Size(88, 22);
            this.tsbEmployeeSaveAndClose.Text = "Save and close";
            this.tsbEmployeeSaveAndClose.Click += new System.EventHandler(this.tsbEmployeeSaveAndClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbPrintPayroll
            // 
            this.tsbPrintPayroll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPrintPayroll.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrintPayroll.Image")));
            this.tsbPrintPayroll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrintPayroll.Name = "tsbPrintPayroll";
            this.tsbPrintPayroll.Size = new System.Drawing.Size(75, 22);
            this.tsbPrintPayroll.Text = "Print Payroll";
            this.tsbPrintPayroll.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // tsbPayslipPrint
            // 
            this.tsbPayslipPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPayslipPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPayslipPrint.Image")));
            this.tsbPayslipPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPayslipPrint.Name = "tsbPayslipPrint";
            this.tsbPayslipPrint.Size = new System.Drawing.Size(80, 22);
            this.tsbPayslipPrint.Text = "Print Pay Slip";
            this.tsbPayslipPrint.Click += new System.EventHandler(this.tsbPayslipPrint_Click);
            // 
            // dgvPayroll
            // 
            this.dgvPayroll.AllowUserToAddRows = false;
            this.dgvPayroll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPayroll.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPayroll.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgvPayroll.BackgroundColor = System.Drawing.Color.White;
            this.dgvPayroll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPayroll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayroll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPayroll.Location = new System.Drawing.Point(5, 182);
            this.dgvPayroll.Name = "dgvPayroll";
            this.dgvPayroll.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPayroll.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPayroll.RowTemplate.Height = 40;
            this.dgvPayroll.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPayroll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPayroll.Size = new System.Drawing.Size(1067, 341);
            this.dgvPayroll.TabIndex = 36;
            this.dgvPayroll.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPayroll_CellContentClick);
            this.dgvPayroll.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPayroll_CellDoubleClick);
            this.dgvPayroll.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvPayroll_KeyUp);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(121, 84);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(170, 23);
            this.dtpFrom.TabIndex = 37;
            this.dtpFrom.TabStop = false;
            this.dtpFrom.Text = "3/1/2020";
            this.dtpFrom.Value = new System.DateTime(2020, 3, 1, 0, 0, 0, 0);
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(121, 113);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(170, 23);
            this.dtpTo.TabIndex = 38;
            this.dtpTo.TabStop = false;
            this.dtpTo.Text = "3/1/2020";
            this.dtpTo.Value = new System.DateTime(2020, 3, 1, 0, 0, 0, 0);
            // 
            // radLabel9
            // 
            this.radLabel9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel9.Location = new System.Drawing.Point(12, 32);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(120, 30);
            this.radLabel9.TabIndex = 23;
            this.radLabel9.Text = "New Payroll";
            // 
            // cboDepartment
            // 
            this.cboDepartment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Items.AddRange(new object[] {
            "Administrative"});
            this.cboDepartment.Location = new System.Drawing.Point(121, 143);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(170, 23);
            this.cboDepartment.TabIndex = 39;
            this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.cboDepartment_SelectedIndexChanged);
            // 
            // radLabel14
            // 
            this.radLabel14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel14.Location = new System.Drawing.Point(19, 143);
            this.radLabel14.Name = "radLabel14";
            this.radLabel14.Size = new System.Drawing.Size(84, 21);
            this.radLabel14.TabIndex = 40;
            this.radLabel14.Text = "Department :";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(19, 86);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(81, 21);
            this.radLabel1.TabIndex = 41;
            this.radLabel1.Text = "Payroll From";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(19, 116);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(72, 21);
            this.radLabel2.TabIndex = 42;
            this.radLabel2.Text = "Payroll To :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkSavings);
            this.groupBox2.Controls.Add(this.chkPagIBIGLoan);
            this.groupBox2.Controls.Add(this.chkSSSLoan);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(699, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 103);
            this.groupBox2.TabIndex = 448;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Deduction";
            // 
            // chkSavings
            // 
            this.chkSavings.AutoSize = true;
            this.chkSavings.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSavings.Location = new System.Drawing.Point(18, 70);
            this.chkSavings.Name = "chkSavings";
            this.chkSavings.Size = new System.Drawing.Size(71, 21);
            this.chkSavings.TabIndex = 455;
            this.chkSavings.Text = "Savings";
            this.chkSavings.UseVisualStyleBackColor = true;
            // 
            // chkPagIBIGLoan
            // 
            this.chkPagIBIGLoan.AutoSize = true;
            this.chkPagIBIGLoan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPagIBIGLoan.Location = new System.Drawing.Point(18, 47);
            this.chkPagIBIGLoan.Name = "chkPagIBIGLoan";
            this.chkPagIBIGLoan.Size = new System.Drawing.Size(108, 21);
            this.chkPagIBIGLoan.TabIndex = 454;
            this.chkPagIBIGLoan.Text = "Pag-IBIG Loan";
            this.chkPagIBIGLoan.UseVisualStyleBackColor = true;
            // 
            // chkSSSLoan
            // 
            this.chkSSSLoan.AutoSize = true;
            this.chkSSSLoan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSSSLoan.Location = new System.Drawing.Point(18, 27);
            this.chkSSSLoan.Name = "chkSSSLoan";
            this.chkSSSLoan.Size = new System.Drawing.Size(80, 21);
            this.chkSSSLoan.TabIndex = 453;
            this.chkSSSLoan.Text = "SSS Loan";
            this.chkSSSLoan.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPagIBIGPrem);
            this.groupBox1.Controls.Add(this.chkPHICPrem);
            this.groupBox1.Controls.Add(this.chkSSSPrem);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(543, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 103);
            this.groupBox1.TabIndex = 447;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contribution Premium";
            // 
            // chkPagIBIGPrem
            // 
            this.chkPagIBIGPrem.AutoSize = true;
            this.chkPagIBIGPrem.Location = new System.Drawing.Point(18, 69);
            this.chkPagIBIGPrem.Name = "chkPagIBIGPrem";
            this.chkPagIBIGPrem.Size = new System.Drawing.Size(131, 21);
            this.chkPagIBIGPrem.TabIndex = 453;
            this.chkPagIBIGPrem.Text = "Pag-IBIG Premium";
            this.chkPagIBIGPrem.UseVisualStyleBackColor = true;
            // 
            // chkPHICPrem
            // 
            this.chkPHICPrem.AutoSize = true;
            this.chkPHICPrem.Location = new System.Drawing.Point(18, 46);
            this.chkPHICPrem.Name = "chkPHICPrem";
            this.chkPHICPrem.Size = new System.Drawing.Size(109, 21);
            this.chkPHICPrem.TabIndex = 452;
            this.chkPHICPrem.Text = "PHIC Premium";
            this.chkPHICPrem.UseVisualStyleBackColor = true;
            // 
            // chkSSSPrem
            // 
            this.chkSSSPrem.AutoSize = true;
            this.chkSSSPrem.Location = new System.Drawing.Point(18, 25);
            this.chkSSSPrem.Name = "chkSSSPrem";
            this.chkSSSPrem.Size = new System.Drawing.Size(103, 21);
            this.chkSSSPrem.TabIndex = 451;
            this.chkSSSPrem.Text = "SSS Premium";
            this.chkSSSPrem.UseVisualStyleBackColor = true;
            // 
            // cmdCompute
            // 
            this.cmdCompute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCompute.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCompute.Location = new System.Drawing.Point(948, 84);
            this.cmdCompute.Name = "cmdCompute";
            this.cmdCompute.Size = new System.Drawing.Size(125, 89);
            this.cmdCompute.TabIndex = 449;
            this.cmdCompute.Text = "Show Time Sheet";
            this.cmdCompute.UseVisualStyleBackColor = true;
            this.cmdCompute.Click += new System.EventHandler(this.cmdCompute_Click);
            // 
            // txtIDS
            // 
            this.txtIDS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDS.Location = new System.Drawing.Point(192, 55);
            this.txtIDS.Name = "txtIDS";
            this.txtIDS.Size = new System.Drawing.Size(99, 23);
            this.txtIDS.TabIndex = 51;
            this.txtIDS.Text = "0";
            this.txtIDS.Visible = false;
            this.txtIDS.TextChanged += new System.EventHandler(this.txtIDS_TextChanged);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(369, 84);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(168, 51);
            this.txtRemarks.TabIndex = 450;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(305, 86);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(64, 21);
            this.radLabel3.TabIndex = 451;
            this.radLabel3.Text = "Remarks :";
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Checked = true;
            this.chkStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStatus.Location = new System.Drawing.Point(369, 149);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(56, 17);
            this.chkStatus.TabIndex = 452;
            this.chkStatus.Text = "Active";
            this.chkStatus.UseVisualStyleBackColor = true;
            // 
            // radStatusStrip1
            // 
            this.radStatusStrip1.Location = new System.Drawing.Point(0, 529);
            this.radStatusStrip1.Name = "radStatusStrip1";
            this.radStatusStrip1.Size = new System.Drawing.Size(1081, 24);
            this.radStatusStrip1.TabIndex = 453;
            this.radStatusStrip1.Text = "radStatusStrip1";
            // 
            // PayrollNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 553);
            this.Controls.Add(this.radStatusStrip1);
            this.Controls.Add(this.chkStatus);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtIDS);
            this.Controls.Add(this.cmdCompute);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.radLabel14);
            this.Controls.Add(this.radLabel9);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.dgvPayroll);
            this.Controls.Add(this.toolStrip1);
            this.Name = "PayrollNew";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PayrollNew";
            this.ThemeName = "ControlDefault";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PayrollNew_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tlsEmployee;
        private System.Windows.Forms.ToolStripButton tsbEmployeeSaveAndClose;
        public System.Windows.Forms.DataGridView dgvPayroll;
        private Telerik.WinControls.UI.RadDateTimePicker dtpFrom;
        private Telerik.WinControls.UI.RadDateTimePicker dtpTo;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private System.Windows.Forms.ComboBox cboDepartment;
        private Telerik.WinControls.UI.RadLabel radLabel14;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkPagIBIGLoan;
        private System.Windows.Forms.CheckBox chkSSSLoan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPagIBIGPrem;
        private System.Windows.Forms.CheckBox chkPHICPrem;
        private System.Windows.Forms.CheckBox chkSSSPrem;
        private System.Windows.Forms.Button cmdCompute;
        private System.Windows.Forms.CheckBox chkSavings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbPrintPayroll;
        private System.Windows.Forms.TextBox txtIDS;
        private System.Windows.Forms.TextBox txtRemarks;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.ToolStripButton tsbPayslipPrint;
        private Telerik.WinControls.UI.RadStatusStrip radStatusStrip1;
    }
}
