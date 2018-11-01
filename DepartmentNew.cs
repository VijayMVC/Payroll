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
    public partial class DepartmentNew : Telerik.WinControls.UI.RadForm
    {
        public DepartmentNew()
        {
            InitializeComponent();
        }

        private void DepartmentInserts()
        {
            try
            {

                Department_Controller departmentNew = new Department_Controller();
                Double IDS = departmentNew.DepartmentInsert(Convert.ToDouble(txtIDS.Text),
                                      Convert.ToString(txtDepartment.Text)
                                     );

                MessageBox.Show("Save Successfull");
                DepartmentGet(IDS);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void DepartmentUpdates()
        {
            try
            {

                Department_Controller departmentNew = new Department_Controller();
                departmentNew.DepartmentUpdate(Convert.ToDouble(txtIDS.Text), Convert.ToString(txtDepartment.Text));

                MessageBox.Show("Update Successfull");
                //  MachineGet(IDS);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        public void DepartmentGet(double ids)
        {
            try
            {

                Department_Controller departmentGet = new Department_Controller();

                foreach (DataRow row in departmentGet.DepartmentSelect(ids).Rows)
                {
                    txtIDS.Text = row["IDS"].ToString();
                    txtDepartment.Text = row["Department"].ToString();
          
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToDouble(txtIDS.Text) == 0)
                {
                    DepartmentInserts();
                }
                else
                {
                    DepartmentUpdates();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void tsbSaveAndClose_Click(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToDouble(txtIDS.Text) == 0)
                {
                    DepartmentInserts();
                }
                else
                {
                    DepartmentUpdates();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }



 

    }
}
