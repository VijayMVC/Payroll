using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll
{
    public partial class PayrollUpdate : Form
    {
        PayrollNew frm1;
       // public PayrollNew  PayrollNewForm { get; set; }

        public PayrollUpdate(PayrollNew parent)
        {
            InitializeComponent();
            frm1 = parent; 
        }
   

        private void PayrollUpdate_Load(object sender, EventArgs e)
        {
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdGetWorkedDays_Click(object sender, EventArgs e)
        {
            try
            {
                Payroll_Controller emp = new Payroll_Controller();
                DataTable d = emp.PayrollSelectEmployee(Convert.ToDouble(txtIDS.Text), dtpDateFrom.Value, dtpDateTo.Value, Convert.ToDouble(txtDepartment.Text));
                txtWorkDays.Text = d.Rows[0].ItemArray[1].ToString();
            }
            catch { }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = frm1.dgvPayroll.CurrentCell.OwningRow;
            row.Cells["Days Worked"].Value=Convert.ToDouble(txtWorkDays.Text);
            row.Cells["Rate"].Value= Convert.ToDouble(txtSalaryRate.Text);
            row.Cells["OT Hour"].Value=Convert.ToDouble(txtOTHour.Text);
            row.Cells["OTRate"].Value=Convert.ToDouble(txtOTRate.Text );
            row.Cells["Late|EO"].Value =Convert.ToDouble(txtLateEO.Text);
            row.Cells["Penalty"].Value = Convert.ToDouble(txtPenalty.Text);
          
        }

        private void cmdGetSalaryRate_Click(object sender, EventArgs e)
        {
            Payroll_Controller emp = new Payroll_Controller();
            DataTable d = emp.PayrollSelectEmployee(Convert.ToDouble(txtIDS.Text), dtpDateFrom.Value, dtpDateTo.Value, Convert.ToDouble(txtDepartment.Text));
            txtSalaryRate.Text = d.Rows[0].ItemArray[2].ToString();
        }

        private void cmdGetOTHour_Click(object sender, EventArgs e)
        {
            Payroll_Controller emp = new Payroll_Controller();
            DataTable d = emp.PayrollSelectEmployee(Convert.ToDouble(txtIDS.Text), dtpDateFrom.Value, dtpDateTo.Value, Convert.ToDouble(txtDepartment.Text));
            txtOTHour.Text = d.Rows[0].ItemArray[4].ToString(); 
        }

        private void cmdGetOTRate_Click(object sender, EventArgs e)
        {
            Payroll_Controller emp = new Payroll_Controller();
            DataTable d = emp.PayrollSelectEmployee(Convert.ToDouble(txtIDS.Text), dtpDateFrom.Value, dtpDateTo.Value, Convert.ToDouble(txtDepartment.Text));
            txtOTRate.Text = d.Rows[0].ItemArray[3].ToString(); 
        }

        private void cmdGetLateEO_Click(object sender, EventArgs e)
        {
            Payroll_Controller emp = new Payroll_Controller();
            DataTable d = emp.PayrollSelectEmployee(Convert.ToDouble(txtIDS.Text), dtpDateFrom.Value, dtpDateTo.Value, Convert.ToDouble(txtDepartment.Text));
            txtLateEO.Text = d.Rows[0].ItemArray[5].ToString(); 

        }

        private void GetPenalty_Click(object sender, EventArgs e)
        {
            Payroll_Controller emp = new Payroll_Controller();
            DataTable d = emp.PayrollSelectEmployee(Convert.ToDouble(txtIDS.Text), dtpDateFrom.Value, dtpDateTo.Value, Convert.ToDouble(txtDepartment.Text));
            txtPenalty.Text = d.Rows[0].ItemArray[6].ToString();
        }

        private void txtPenalty_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
