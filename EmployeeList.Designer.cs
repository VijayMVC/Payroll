namespace Payroll
{
    partial class EmployeeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tlsEmployee = new System.Windows.Forms.ToolStripButton();
            this.tlsRefressList = new System.Windows.Forms.ToolStripButton();
            this.dgvEmployeeList = new System.Windows.Forms.DataGridView();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtDownloadTmp = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsEmployee,
            this.tlsRefressList,
            this.toolStripSeparator1,
            this.txtDownloadTmp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(779, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 31;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tlsEmployee
            // 
            this.tlsEmployee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsEmployee.Image = ((System.Drawing.Image)(resources.GetObject("tlsEmployee.Image")));
            this.tlsEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsEmployee.Name = "tlsEmployee";
            this.tlsEmployee.Size = new System.Drawing.Size(90, 22);
            this.tlsEmployee.Text = "New Employee";
            this.tlsEmployee.Click += new System.EventHandler(this.tlsEmployee_Click);
            // 
            // tlsRefressList
            // 
            this.tlsRefressList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsRefressList.Image = ((System.Drawing.Image)(resources.GetObject("tlsRefressList.Image")));
            this.tlsRefressList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsRefressList.Name = "tlsRefressList";
            this.tlsRefressList.Size = new System.Drawing.Size(71, 22);
            this.tlsRefressList.Text = "Refresh List";
            this.tlsRefressList.Click += new System.EventHandler(this.tlsRefressList_Click);
            // 
            // dgvEmployeeList
            // 
            this.dgvEmployeeList.AllowUserToAddRows = false;
            this.dgvEmployeeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployeeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployeeList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgvEmployeeList.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvEmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEmployeeList.Location = new System.Drawing.Point(0, 76);
            this.dgvEmployeeList.Name = "dgvEmployeeList";
            this.dgvEmployeeList.ReadOnly = true;
            this.dgvEmployeeList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmployeeList.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmployeeList.RowTemplate.Height = 30;
            this.dgvEmployeeList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmployeeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployeeList.Size = new System.Drawing.Size(779, 308);
            this.dgvEmployeeList.TabIndex = 32;
            this.dgvEmployeeList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEmployeeList_CellMouseDoubleClick);
            // 
            // radLabel9
            // 
            this.radLabel9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel9.Location = new System.Drawing.Point(12, 33);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(136, 30);
            this.radLabel9.TabIndex = 33;
            this.radLabel9.Text = "Employee List";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // txtDownloadTmp
            // 
            this.txtDownloadTmp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.txtDownloadTmp.Image = ((System.Drawing.Image)(resources.GetObject("txtDownloadTmp.Image")));
            this.txtDownloadTmp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.txtDownloadTmp.Name = "txtDownloadTmp";
            this.txtDownloadTmp.Size = new System.Drawing.Size(117, 22);
            this.txtDownloadTmp.Text = "Download Template";

            // 
            // EmployeeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 384);
            this.Controls.Add(this.radLabel9);
            this.Controls.Add(this.dgvEmployeeList);
            this.Controls.Add(this.toolStrip1);
            this.Name = "EmployeeList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Employee List";
            this.ThemeName = "ControlDefault";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tlsEmployee;
        private System.Windows.Forms.ToolStripButton tlsRefressList;
        private System.Windows.Forms.DataGridView dgvEmployeeList;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton txtDownloadTmp;
    }
}
