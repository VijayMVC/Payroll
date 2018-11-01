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
            this.button1 = new System.Windows.Forms.Button();
            this.txtWorkDays = new System.Windows.Forms.TextBox();
            this.txtSalaryRate = new System.Windows.Forms.TextBox();
            this.cmdUpdateRate = new System.Windows.Forms.Button();
            this.txtOTHour = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Worked Days";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtWorkDays
            // 
            this.txtWorkDays.Location = new System.Drawing.Point(12, 74);
            this.txtWorkDays.Name = "txtWorkDays";
            this.txtWorkDays.Size = new System.Drawing.Size(108, 20);
            this.txtWorkDays.TabIndex = 1;
            // 
            // txtSalaryRate
            // 
            this.txtSalaryRate.Location = new System.Drawing.Point(126, 75);
            this.txtSalaryRate.Name = "txtSalaryRate";
            this.txtSalaryRate.Size = new System.Drawing.Size(117, 20);
            this.txtSalaryRate.TabIndex = 3;
            // 
            // cmdUpdateRate
            // 
            this.cmdUpdateRate.Location = new System.Drawing.Point(126, 46);
            this.cmdUpdateRate.Name = "cmdUpdateRate";
            this.cmdUpdateRate.Size = new System.Drawing.Size(117, 23);
            this.cmdUpdateRate.TabIndex = 2;
            this.cmdUpdateRate.Text = "Get Salary Rate";
            this.cmdUpdateRate.UseVisualStyleBackColor = true;
            // 
            // txtOTHour
            // 
            this.txtOTHour.Location = new System.Drawing.Point(249, 74);
            this.txtOTHour.Name = "txtOTHour";
            this.txtOTHour.Size = new System.Drawing.Size(107, 20);
            this.txtOTHour.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(249, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Get OT Hour";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(126, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(156, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // PayrollUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 144);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtOTHour);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtSalaryRate);
            this.Controls.Add(this.cmdUpdateRate);
            this.Controls.Add(this.txtWorkDays);
            this.Controls.Add(this.button1);
            this.Name = "PayrollUpdate";
            this.Text = "Payroll Update";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtWorkDays;
        private System.Windows.Forms.TextBox txtSalaryRate;
        private System.Windows.Forms.Button cmdUpdateRate;
        private System.Windows.Forms.TextBox txtOTHour;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}