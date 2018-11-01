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
    public partial class EmployeeList : Telerik.WinControls.UI.RadForm
    {
        public EmployeeList()
        {
            InitializeComponent();
            EmployeeListGet();

        }
        private void EmployeeListGet()
        {
            try
            {

                Employee_Controller empGet = new Employee_Controller();

                dgvEmployeeList.DataSource = empGet.EmployeeSelectAll();
                this.dgvEmployeeList.Columns[0].Visible = false;

               // this.dgvEmployeeList.Columns[1].Visible = false;
              
              
                //foreach (DataRow row in empGet.EmployeeSelectAll().Rows)
                //{
                    //txtIDS.Text = row["IDS"].ToString();
                    //txtLastName.Text = row["lname"].ToString();
                    //txtFirstName.Text = row["fname"].ToString();
                    //txtMiddleName.Text = row["mname"].ToString();
                    //txtAddress.Text = row["AddressHome"].ToString();
                    //txtContactNumber.Text = row["ContactNo"].ToString();
                    //dtpDateOfBirth.Value = Convert.ToDateTime(row["DateOfBirth"].ToString());
                    //dtpDateOfEmployment.Value = Convert.ToDateTime(row["DateOfEmployment"].ToString());
                    //cboGender.SelectedIndex = Convert.ToInt32(row["CivilStatus"].ToString());
                    //cboCivilStatus.SelectedIndex = Convert.ToInt32(row["CivilStatus"].ToString());
                    //cboPosition.SelectedIndex = Convert.ToInt32(row["Position"].ToString());
                    //cboUnit.SelectedIndex = Convert.ToInt32(row["Unit"].ToString());
                    //txtSalary.Text = row["Salary"].ToString();
                    //chkStatus.Checked = Convert.ToBoolean(row["Stat"].ToString());
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void tlsEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                NewEmployee NewEmp = new NewEmployee();
                NewEmp.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void tlsRefressList_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeListGet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private void dgvEmployeeList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvEmployeeList.SelectedRows.Count > 0)
            {

                double id = Convert.ToDouble(dgvEmployeeList.SelectedRows[0].Cells["IDS"].Value.ToString());
                NewEmployee frm = new NewEmployee();

                //if (Application.OpenForms.OfType<NewEmployee>().Any())

                //    foreach (Form frm1 in this.MdiChildren)
                //    {
                //        if (frm1.Name == "NewEmployee")
                //        {
                //            frm1.Activate();
                //            break;
                //        }
                //    }

                //else
                //{

                frm.EmployeeGet(id);
                frm.Show();
                // }


            }
        }

      
  
  
    }
}
