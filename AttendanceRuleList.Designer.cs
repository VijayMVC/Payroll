namespace Payroll
{
    partial class AttendanceRuleList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendanceRuleList));
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.dgvShiftList = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tlsEmployee = new System.Windows.Forms.ToolStripButton();
            this.tlsRefressList = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShiftList)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radLabel9
            // 
            this.radLabel9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel9.Location = new System.Drawing.Point(12, 33);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(89, 30);
            this.radLabel9.TabIndex = 36;
            this.radLabel9.Text = "Shift List";
            // 
            // dgvShiftList
            // 
            this.dgvShiftList.AllowUserToAddRows = false;
            this.dgvShiftList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShiftList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShiftList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgvShiftList.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvShiftList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShiftList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvShiftList.Location = new System.Drawing.Point(3, 73);
            this.dgvShiftList.Name = "dgvShiftList";
            this.dgvShiftList.ReadOnly = true;
            this.dgvShiftList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShiftList.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShiftList.RowTemplate.Height = 30;
            this.dgvShiftList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShiftList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShiftList.Size = new System.Drawing.Size(740, 292);
            this.dgvShiftList.TabIndex = 35;
            this.dgvShiftList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShiftList_CellContentClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsEmployee,
            this.tlsRefressList});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(745, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 34;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tlsEmployee
            // 
            this.tlsEmployee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsEmployee.Image = ((System.Drawing.Image)(resources.GetObject("tlsEmployee.Image")));
            this.tlsEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsEmployee.Name = "tlsEmployee";
            this.tlsEmployee.Size = new System.Drawing.Size(62, 22);
            this.tlsEmployee.Text = "New Shift";
            // 
            // tlsRefressList
            // 
            this.tlsRefressList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsRefressList.Image = ((System.Drawing.Image)(resources.GetObject("tlsRefressList.Image")));
            this.tlsRefressList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsRefressList.Name = "tlsRefressList";
            this.tlsRefressList.Size = new System.Drawing.Size(71, 22);
            this.tlsRefressList.Text = "Refresh List";
            // 
            // AttendanceRuleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 370);
            this.Controls.Add(this.radLabel9);
            this.Controls.Add(this.dgvShiftList);
            this.Controls.Add(this.toolStrip1);
            this.Name = "AttendanceRuleList";
            this.Text = "AttendanceRuleList";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShiftList)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel9;
        private System.Windows.Forms.DataGridView dgvShiftList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tlsEmployee;
        private System.Windows.Forms.ToolStripButton tlsRefressList;
    }
}