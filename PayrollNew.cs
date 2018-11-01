using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Payroll
{
    public partial class PayrollNew : Telerik.WinControls.UI.RadForm
    {

        
        public PayrollNew()
        {
            InitializeComponent();
           // frm2 = new PayrollUpdate(this);

            DateTime LastSaturdayDate = new DateTime();
            LastSaturdayDate = FirstDayOfWeek(DateTime.Now);

            dtpFrom.Value = LastSaturdayDate.AddDays(-2);
            dtpTo.Value = DateTime.Now;
            builDepartmentCbo();
        }


        private static DateTime FirstDayOfWeek(DateTime dt)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            return dt.AddDays(-diff).Date;
        }



        private void builDepartmentCbo()
        {
            Department_Controller departmentcboGet = new Department_Controller();
            DataTable dt = departmentcboGet.DepartmentSelectAll();
            cboDepartment.DataSource = dt;
            cboDepartment.DisplayMember = "Department";
            cboDepartment.ValueMember = "IDS";

        }

        private void PayrollInserts()
        {
            try
            {
                Payroll_Controller payroll = new Payroll_Controller();
                Double IDS =payroll.PayrollInsert(Convert.ToDouble(txtIDS.Text),DateTime.Today,dtpFrom.Value,dtpTo.Value,Convert.ToDouble(cboDepartment.SelectedValue),txtRemarks.Text);
                  if (IDS > 0)
                  {

                      foreach (DataGridViewRow dr in dgvPayroll.Rows)
                      {
                          Double IDS1 = payroll.PayrollEmployeeInsert( Convert.ToDouble(dValue(dr.Cells["IDS"].Value.ToString()))
                                                                      , Convert.ToDouble(dr.Cells["EmployeeIDS"].Value.ToString())
                                                                      , IDS
                                                                      , Convert.ToDouble(cboDepartment.SelectedValue)
                                                                      , dValue(dr.Cells["Days Worked"].Value.ToString())
                                                                      , dValue(dr.Cells["Rate"].Value.ToString())
                                                                      , dValue(dr.Cells["OT Hour"].Value.ToString())
                                                                      , dValue(dr.Cells["OTRate"].Value.ToString())
                                                                      , dValue(dr.Cells["Adjustment"].Value.ToString())
                                                                      , dValue(dr.Cells["SSSPrem"].Value.ToString())
                                                                      , dValue(dr.Cells["PHICPrem"].Value.ToString())
                                                                      , dValue(dr.Cells["PagIbigPrem"].Value.ToString())
                                                                      , dValue(dr.Cells["SSSLoan"].Value.ToString())
                                                                      , dValue(dr.Cells["PagIbigLoan"].Value.ToString())
                                                                      , dValue(dr.Cells["CashAdvance"].Value.ToString())
                                                                       , dValue(dr.Cells["Savings"].Value.ToString())
                                                                      , dValue(dr.Cells["OtherDeduction"].Value.ToString())
                                                                      , dValue(dr.Cells["Late|EO"].Value.ToString())
                                                                      , dValue(dr.Cells["Penalty"].Value.ToString()));
                      }
                  }

                MessageBox.Show("Save Successfull");
                PayrollGet(IDS);
                PayrollEmployeeGet(IDS);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void PayrollUpdates()
        {
            try
            {
                double IDS = Convert.ToDouble(txtIDS.Text);
                Payroll_Controller payroll = new Payroll_Controller();
                payroll.PayrollUpdate(IDS, DateTime.Today, dtpFrom.Value, dtpTo.Value, Convert.ToDouble(cboDepartment.SelectedValue), txtRemarks.Text);

                    foreach (DataGridViewRow dr in dgvPayroll.Rows)
                    {
                        payroll.PayrollEmployeeUpdate(Convert.ToDouble(dr.Cells["IDS"].Value.ToString())
                                                                    , Convert.ToDouble(dr.Cells["EmployeeIDS"].Value.ToString())
                                                                    , IDS
                                                                    , Convert.ToDouble(cboDepartment.SelectedValue)
                                                                    , dValue(dr.Cells["Days Worked"].Value.ToString())
                                                                    , dValue(dr.Cells["Rate"].Value.ToString())
                                                                    , dValue(dr.Cells["OT Hour"].Value.ToString())
                                                                    , dValue(dr.Cells["OTRate"].Value.ToString())
                                                                    , dValue(dr.Cells["Adjustment"].Value.ToString())
                                                                    , dValue(dr.Cells["SSSPrem"].Value.ToString())
                                                                    , dValue(dr.Cells["PHICPrem"].Value.ToString())
                                                                    , dValue(dr.Cells["PagIbigPrem"].Value.ToString())
                                                                    , dValue(dr.Cells["SSSLoan"].Value.ToString())
                                                                    , dValue(dr.Cells["PagIbigLoan"].Value.ToString())
                                                                    , dValue(dr.Cells["CashAdvance"].Value.ToString())
                                                                    , dValue(dr.Cells["Savings"].Value.ToString())
                                                                    , dValue(dr.Cells["OtherDeduction"].Value.ToString())
                                                                    , dValue(dr.Cells["Late|EO"].Value.ToString())
                                                                    , dValue(dr.Cells["Penalty"].Value.ToString()));
                    }

                    MessageBox.Show("Update Successfull");
                    PayrollGet(IDS);
                    PayrollEmployeeGet(IDS);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        public void PayrollGet(double ids)
        {
            try
            {

                Payroll_Controller payroll = new Payroll_Controller();

                foreach (DataRow row in payroll.PayrollSelect(ids).Rows)
                {
                    txtIDS.Text = row["IDS"].ToString();
                    dtpFrom.Value = Convert.ToDateTime(row["DateFrom"].ToString());
                    dtpTo.Value = Convert.ToDateTime(row["DateTo"].ToString());
                    cboDepartment.SelectedValue  = row["Department"].ToString();
                    txtRemarks.Text = row["Remarks"].ToString();
                }
                
              }

            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public  void PayrollEmployeeGet(double IDS)
        {
            try
            {

                Payroll_Controller payroll = new Payroll_Controller();
                dgvPayroll.DataSource = payroll.PayrollEmployeeSelect(IDS);

                dgvPayroll.Columns[0].Visible = false;
                dgvPayroll.Columns[1].Visible = false;
               
                dgvPayroll.Columns[2].ReadOnly = true;
                dgvPayroll.Columns[3].ReadOnly = true;
                dgvPayroll.Columns[4].ReadOnly = true;
                dgvPayroll.Columns[5].ReadOnly = true;
                dgvPayroll.Columns[6].ReadOnly = true;
                dgvPayroll.Columns[8].ReadOnly = true;
                dgvPayroll.Columns[16].ReadOnly = true;
                dgvPayroll.Columns[17].ReadOnly = true;
                dgvPayroll.Columns[19].ReadOnly = true; 
              //  dgvPayroll.Columns[2].Width = 200;
                dgvPayroll.Columns[3].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[4].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[5].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[6].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[7].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[8].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[9].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[10].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[11].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[12].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[13].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[14].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[15].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[16].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[17].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[18].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[19].DefaultCellStyle.Format = "###,##0.00##";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void PayrollInitalListGet()
        {
            try
            {


                Payroll_Controller payrollGetInitial = new Payroll_Controller();
                dgvPayroll.DataSource = payrollGetInitial.PayrollSelectInitial(dtpFrom.Value, dtpTo.Value,Convert.ToDouble(cboDepartment.SelectedValue),
                                                                              Convert.ToInt32(chkSSSPrem.CheckState),Convert.ToInt32(chkPHICPrem.CheckState),
                                                                              Convert.ToInt32(chkPagIBIGPrem.CheckState),Convert.ToInt32(chkSSSLoan.CheckState),
                                                                              Convert.ToInt32(chkPagIBIGLoan.CheckState),Convert.ToInt32(chkSavings.CheckState));

                dgvPayroll.Columns[0].Visible = false;
                dgvPayroll.Columns[1].Visible = false;
                dgvPayroll.Columns[2].Width = 200;
                dgvPayroll.Columns[2].ReadOnly = true;
                dgvPayroll.Columns[3].ReadOnly = true;
                dgvPayroll.Columns[4].ReadOnly = true;
                dgvPayroll.Columns[5].ReadOnly = true;
                dgvPayroll.Columns[6].ReadOnly = true;
                dgvPayroll.Columns[8].ReadOnly = true;
                dgvPayroll.Columns[16].ReadOnly = true;
                dgvPayroll.Columns[17].ReadOnly = true;
                dgvPayroll.Columns[19].ReadOnly = true;
                dgvPayroll.Columns[3].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[4].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[5].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[6].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[7].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[8].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[9].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[10].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[11].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[12].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[13].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[14].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[15].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[16].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[17].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[18].DefaultCellStyle.Format = "###,##0.00##";
                dgvPayroll.Columns[19].DefaultCellStyle.Format = "###,##0.00##";

                dgvPayroll.Columns[0].ValueType = System.Type.GetType("System.Decimal");
                dgvPayroll.Columns[1].ValueType = System.Type.GetType("System.Decimal");
                dgvPayroll.Columns[2].ValueType = System.Type.GetType("System.Decimal");
                dgvPayroll.Columns[3].ValueType = System.Type.GetType("System.Decimal");
                dgvPayroll.Columns[4].ValueType = System.Type.GetType("System.Decimal");
                dgvPayroll.Columns[5].ValueType = System.Type.GetType("System.Decimal");
                dgvPayroll.Columns[6].ValueType = System.Type.GetType("System.Decimal");
                dgvPayroll.Columns[7].ValueType = System.Type.GetType("System.Decimal");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void PrintPayroll(double IDS, string server,string database,string user,string pass )
        {
            try
            {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents=false;
            proc.StartInfo.FileName= "reportviewer.exe";
            proc.StartInfo.Arguments = IDS + " " + server + " " + database + " " + user + " " + pass + " 0" +  DateTime.Now + " " + DateTime.Now ;
            proc.Start();
          //  proc.WaitForExit();
                        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void PrintPaySlip(double IDS, string server, string database, string user, string pass)
        {
           try
            {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "reportviewer.exe";
            proc.StartInfo.Arguments = IDS + "," + server + "," + database + "," + user + "," + pass + ",1" + DateTime.Now + " " + DateTime.Now;
            proc.Start();
            //  proc.WaitForExit();
            }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message.ToString());
           }


        }
        private void cmdCompute_Click(object sender, EventArgs e)
        {
            PayrollInitalListGet();
        }

        private void tlsEmployee_Click(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToDouble(txtIDS.Text) == 0)
                {
                    PayrollInserts();
                }
                else
                {
                    PayrollUpdates();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void tsbEmployeeSaveAndClose_Click(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToDouble(txtIDS.Text)== 0)
                {
                    PayrollInserts();
                }
                else
                {
                    PayrollUpdates();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private decimal dValue(string t)
        {
            decimal  numvalue;
            decimal.TryParse(t, out numvalue);
            return numvalue;

        }

        private void txtIDS_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtIDS.Text) > 0)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                cmdCompute.Enabled = false;
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
                cboDepartment.Enabled = false;
   
            }
            else
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                cmdCompute.Enabled = true;
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
                cboDepartment.Enabled = true;

            }
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {

            Variables var = new Variables();
            PrintPayroll(Convert.ToDouble(txtIDS.Text), Variables.ServerName, Variables.DBName, Variables.UserName,Variables.Password);

        }

        private void PayrollNew_Load(object sender, EventArgs e)
        {
             

        }

        private void tsbPayslipPrint_Click(object sender, EventArgs e)
        {
            Variables var = new Variables();
            PrintPaySlip(Convert.ToDouble(txtIDS.Text), Variables.ServerName, Variables.DBName, Variables.UserName, Variables.Password);

        }

        private void dgvPayroll_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

    

            DataGridViewRow row = dgvPayroll.CurrentCell.OwningRow;


            PayrollUpdate payroll = new PayrollUpdate(this);
            payroll.dtpDateFrom.Value = dtpFrom.Value;
            payroll.dtpDateTo.Value = dtpTo.Value;

            payroll.txtIDS.Text = row.Cells["EmployeeIDS"].Value.ToString();
            payroll.txtWorkDays.Text = row.Cells["Days Worked"].Value.ToString();
            payroll.txtSalaryRate.Text = row.Cells["Rate"].Value.ToString();
            payroll.txtOTHour.Text = row.Cells["OT Hour"].Value.ToString();
            payroll.txtOTRate.Text = row.Cells["OTRate"].Value.ToString();
            payroll.txtLateEO.Text = row.Cells["Late|EO"].Value.ToString();
            payroll.txtPenalty.Text = row.Cells["Penalty"].Value.ToString();
            payroll.txtDepartment.Text = cboDepartment.SelectedValue.ToString();
            payroll.Show();

        }

        private void dgvPayroll_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode & Keys.Delete ) == Keys.Delete )
            {
                // Show the user a message
               DialogResult result = MessageBox.Show("Do you want to Delete?", "Confirmation", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    DataGridViewRow row = dgvPayroll.CurrentCell.OwningRow;
                    Payroll_Controller payrollEmp = new Payroll_Controller();
                    payrollEmp.PayrollEmployeeDelete(Convert.ToDouble(row.Cells["IDS"].Value));
                    PayrollEmployeeGet(Convert.ToDouble(txtIDS.Text));
                    e.Handled = true;
                }

            }

        }

        private void dgvPayroll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


   
        //public static Double Val(string value)
        //{
        //    String result = String.Empty;
        //    foreach (char c in value)
        //    {
        //        if (Char.IsNumber(c) || (c.Equals('.') && result.Count(x => x.Equals('.')) == 0))
        //            result += c;
        //        else if (!c.Equals(' '))
        //            return String.IsNullOrEmpty(result) ? 0 : Convert.ToDouble(result);
        //    }
        //    return String.IsNullOrEmpty(result) ? 0 : Convert.ToDouble(result);
        //}



    }
}
