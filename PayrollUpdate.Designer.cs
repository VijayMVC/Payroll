namespace Payroll
{
    partial class PayrollUpdate
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
            this.cmdGetWorkedDays = new System.Windows.Forms.Button();
            this.txtWorkDays = new System.Windows.Forms.TextBox();
            this.txtSalaryRate = new System.Windows.Forms.TextBox();
            this.cmdGetSalaryRate = new System.Windows.Forms.Button();
            this.txtOTHour = new System.Windows.Forms.TextBox();
            this.cmdGetOTHour = new System.Windows.Forms.Button();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.txtOTRate = new System.Windows.Forms.TextBox();
            this.cmdGetOTRate = new System.Windows.Forms.Button();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.txtPenalty = new System.Windows.Forms.TextBox();
            this.GetPenalty = new System.Windows.Forms.Button();
            this.txtLateEO = new System.Windows.Forms.TextBox();
            this.cmdGetLateEO = new System.Windows.Forms.Button();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIDS = new System.Windows.Forms.TextBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdGetWorkedDays
            // 
            this.cmdGetWorkedDays.Location = new System.Drawing.Point(20, 106);
            this.cmdGetWorkedDays.Name = "cmdGetWorkedDays";
            this.cmdGetWorkedDays.Size = new System.Drawing.Size(108, 23);
            this.cmdGetWorkedDays.TabIndex = 0;
            this.cmdGetWorkedDays.Text = "Get Worked Days";
            this.cmdGetWorkedDays.UseVisualStyleBackColor = true;
            this.cmdGetWorkedDays.Click += new System.EventHandler(this.cmdGetWorkedDays_Click);
            // 
            // txtWorkDays
            // 
            this.txtWorkDays.Enabled = false;
            this.txtWorkDays.Location = new System.Drawing.Point(20, 135);
            this.txtWorkDays.Name = "txtWorkDays";
            this.txtWorkDays.Size = new System.Drawing.Size(108, 20);
            this.txtWorkDays.TabIndex = 1;
            this.txtWorkDays.Text = "0";
            // 
            // txtSalaryRate
            // 
            this.txtSalaryRate.Enabled = false;
            this.txtSalaryRate.Location = new System.Drawing.Point(134, 136);
            this.txtSalaryRate.Name = "txtSalaryRate";
            this.txtSalaryRate.Size = new System.Drawing.Size(117, 20);
            this.txtSalaryRate.TabIndex = 3;
            this.txtSalaryRate.Text = "0";
            // 
            // cmdGetSalaryRate
            // 
            this.cmdGetSalaryRate.Location = new System.Drawing.Point(134, 107);
            this.cmdGetSalaryRate.Name = "cmdGetSalaryRate";
            this.cmdGetSalaryRate.Size = new System.Drawing.Size(117, 23);
            this.cmdGetSalaryRate.TabIndex = 2;
            this.cmdGetSalaryRate.Text = "Get Salary Rate";
            this.cmdGetSalaryRate.UseVisualStyleBackColor = true;
            this.cmdGetSalaryRate.Click += new System.EventHandler(this.cmdGetSalaryRate_Click);
            // 
            // txtOTHour
            // 
            this.txtOTHour.Enabled = false;
            this.txtOTHour.Location = new System.Drawing.Point(20, 206);
            this.txtOTHour.Name = "txtOTHour";
            this.txtOTHour.Size = new System.Drawing.Size(107, 20);
            this.txtOTHour.TabIndex = 5;
            this.txtOTHour.Text = "0";
            // 
            // cmdGetOTHour
            // 
            this.cmdGetOTHour.Location = new System.Drawing.Point(19, 177);
            this.cmdGetOTHour.Name = "cmdGetOTHour";
            this.cmdGetOTHour.Size = new System.Drawing.Size(107, 23);
            this.cmdGetOTHour.TabIndex = 4;
            this.cmdGetOTHour.Text = "Get OT Hour";
            this.cmdGetOTHour.UseVisualStyleBackColor = true;
            this.cmdGetOTHour.Click += new System.EventHandler(this.cmdGetOTHour_Click);
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Enabled = false;
            this.dtpDateFrom.Location = new System.Drawing.Point(44, 31);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(207, 20);
            this.dtpDateFrom.TabIndex = 6;
            // 
            // txtOTRate
            // 
            this.txtOTRate.Enabled = false;
            this.txtOTRate.Location = new System.Drawing.Point(133, 206);
            this.txtOTRate.Name = "txtOTRate";
            this.txtOTRate.Size = new System.Drawing.Size(118, 20);
            this.txtOTRate.TabIndex = 8;
            this.txtOTRate.Text = "0";
            // 
            // cmdGetOTRate
            // 
            this.cmdGetOTRate.Location = new System.Drawing.Point(132, 177);
            this.cmdGetOTRate.Name = "cmdGetOTRate";
            this.cmdGetOTRate.Size = new System.Drawing.Size(118, 23);
            this.cmdGetOTRate.TabIndex = 7;
            this.cmdGetOTRate.Text = "Get OT Rate";
            this.cmdGetOTRate.UseVisualStyleBackColor = true;
            this.cmdGetOTRate.Click += new System.EventHandler(this.cmdGetOTRate_Click);
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Enabled = false;
            this.dtpDateTo.Location = new System.Drawing.Point(44, 57);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(207, 20);
            this.dtpDateTo.TabIndex = 9;
            // 
            // txtPenalty
            // 
            this.txtPenalty.Enabled = false;
            this.txtPenalty.Location = new System.Drawing.Point(134, 279);
            this.txtPenalty.Name = "txtPenalty";
            this.txtPenalty.Size = new System.Drawing.Size(118, 20);
            this.txtPenalty.TabIndex = 13;
            this.txtPenalty.Text = "0";
            this.txtPenalty.TextChanged += new System.EventHandler(this.txtPenalty_TextChanged);
            // 
            // GetPenalty
            // 
            this.GetPenalty.Location = new System.Drawing.Point(134, 250);
            this.GetPenalty.Name = "GetPenalty";
            this.GetPenalty.Size = new System.Drawing.Size(118, 23);
            this.GetPenalty.TabIndex = 12;
            this.GetPenalty.Text = "Get Penalty/Minute";
            this.GetPenalty.UseVisualStyleBackColor = true;
            this.GetPenalty.Click += new System.EventHandler(this.GetPenalty_Click);
            // 
            // txtLateEO
            // 
            this.txtLateEO.Enabled = false;
            this.txtLateEO.Location = new System.Drawing.Point(21, 279);
            this.txtLateEO.Name = "txtLateEO";
            this.txtLateEO.Size = new System.Drawing.Size(107, 20);
            this.txtLateEO.TabIndex = 11;
            this.txtLateEO.Text = "0";
            // 
            // cmdGetLateEO
            // 
            this.cmdGetLateEO.Location = new System.Drawing.Point(21, 250);
            this.cmdGetLateEO.Name = "cmdGetLateEO";
            this.cmdGetLateEO.Size = new System.Drawing.Size(107, 23);
            this.cmdGetLateEO.TabIndex = 10;
            this.cmdGetLateEO.Text = "Get Late Minutes";
            this.cmdGetLateEO.UseVisualStyleBackColor = true;
            this.cmdGetLateEO.Click += new System.EventHandler(this.cmdGetLateEO_Click);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Location = new System.Drawing.Point(143, 328);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(108, 27);
            this.cmdUpdate.TabIndex = 14;
            this.cmdUpdate.Text = "Update";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(23, 328);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(103, 27);
            this.cmdCancel.TabIndex = 15;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "From :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "To :";
            // 
            // txtIDS
            // 
            this.txtIDS.Location = new System.Drawing.Point(20, 85);
            this.txtIDS.Name = "txtIDS";
            this.txtIDS.Size = new System.Drawing.Size(89, 20);
            this.txtIDS.TabIndex = 18;
            this.txtIDS.Text = "0";
            this.txtIDS.Visible = false;
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(115, 85);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(89, 20);
            this.txtDepartment.TabIndex = 19;
            this.txtDepartment.Text = "0";
            this.txtDepartment.Visible = false;
            // 
            // PayrollUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 393);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.txtIDS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.txtPenalty);
            this.Controls.Add(this.GetPenalty);
            this.Controls.Add(this.txtLateEO);
            this.Controls.Add(this.cmdGetLateEO);
            this.Controls.Add(this.dtpDateTo);
            this.Controls.Add(this.txtOTRate);
            this.Controls.Add(this.cmdGetOTRate);
            this.Controls.Add(this.dtpDateFrom);
            this.Controls.Add(this.txtOTHour);
            this.Controls.Add(this.cmdGetOTHour);
            this.Controls.Add(this.txtSalaryRate);
            this.Controls.Add(this.cmdGetSalaryRate);
            this.Controls.Add(this.txtWorkDays);
            this.Controls.Add(this.cmdGetWorkedDays);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PayrollUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payroll Update";
            this.Load += new System.EventHandler(this.PayrollUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdGetWorkedDays;
        public System.Windows.Forms.TextBox txtWorkDays;
        public System.Windows.Forms.TextBox txtSalaryRate;
        private System.Windows.Forms.Button cmdGetSalaryRate;
        public System.Windows.Forms.TextBox txtOTHour;
        private System.Windows.Forms.Button cmdGetOTHour;
        public System.Windows.Forms.DateTimePicker dtpDateFrom;
        public System.Windows.Forms.TextBox txtOTRate;
        private System.Windows.Forms.Button cmdGetOTRate;
        public System.Windows.Forms.DateTimePicker dtpDateTo;
        public System.Windows.Forms.TextBox txtPenalty;
        private System.Windows.Forms.Button GetPenalty;
        public System.Windows.Forms.TextBox txtLateEO;
        private System.Windows.Forms.Button cmdGetLateEO;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtIDS;
        public System.Windows.Forms.TextBox txtDepartment;
    }
}