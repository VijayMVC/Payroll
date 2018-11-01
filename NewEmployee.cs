using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;



namespace Payroll
{
    public partial class NewEmployee : Telerik.WinControls.UI.RadForm
    {
        private static NewEmployee  s_oInstance = null;
        public static NewEmployee Instance
        {
            get
            {
                return (s_oInstance);
            }
        }

       // public Mainform MyFirstForm1 { get; set; }
        public NewEmployee()
        {
            InitializeComponent();
            dtpDateOfBirth.Value = DateTime.Now;
            dtpDateOfEmployment.Value = DateTime.Now;
            builDepartmentCbo();
            ShiftNameCbo();

        }
        private void EmployeeInserts( )
        {
            byte[] pic;
        try
            {

                if (picImage.Image != null)
                {
                    MemoryStream stream = new MemoryStream();
                    picImage.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                    pic = stream.ToArray();
                }
                else
                {
                    pic = null;
                }

            Employee_Controller empNew = new Employee_Controller();
            Double IDS=empNew.EmployeeInsert(Convert.ToDouble(txtIDS.Text),
                                  Convert.ToString(txtLastName.Text),
                                  Convert.ToString(txtFirstName.Text),
                                  Convert.ToString(txtMiddleName.Text),
                                  Convert.ToString(txtAddress.Text),
                                  Convert.ToString(txtContactNumber.Text),
                                  Convert.ToDateTime(dtpDateOfBirth.Value),
                                  Convert.ToDateTime(dtpDateOfEmployment.Value),
                                  Convert.ToInt32(cboGender.SelectedIndex),
                                  Convert.ToInt32(cboCivilStatus.SelectedIndex),
                                  Convert.ToString(cboPosition.Text ),
                                  Convert.ToInt32(cboDepartment.SelectedValue), 
                                  Convert.ToInt32(cboUnit.SelectedIndex), 
                                  Convert.ToDecimal(txtSalary.Text),
                                  pic,
                                  Convert.ToInt32(chkStatus.CheckState),
                                  Convert.ToDecimal(txtSSSPrem.Text),
                                  Convert.ToDecimal(txtPHICPrem.Text),
                                  Convert.ToDecimal(txtPagIbigPrem.Text),
                                  Convert.ToDecimal(txtSSSLoan.Text),
                                  Convert.ToDecimal(txtPagIbigLoan.Text),
                                  Convert.ToDecimal(txtSavings.Text),
                                  Convert.ToDecimal(txtOTRate.Text)
                                 );
                    EmployeeGet(IDS);

                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            MessageBox.Show("Save Successfull");
        }
        private void EmployeeUpdates()
        {

            byte[] pic;
            try
            {

                if (picImage.Image != null)
                {
                    MemoryStream stream = new MemoryStream();
                    picImage.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                    pic = stream.ToArray();
                }
                else
                {
                    pic = null;
                }

                Employee_Controller empNew = new Employee_Controller();
                 empNew.EmployeeUpdate(Convert.ToDouble(txtIDS.Text),
                                      Convert.ToString(txtLastName.Text),
                                      Convert.ToString(txtFirstName.Text),
                                      Convert.ToString(txtMiddleName.Text),
                                      Convert.ToString(txtAddress.Text),
                                      Convert.ToString(txtContactNumber.Text),
                                      Convert.ToDateTime(dtpDateOfBirth.Value),
                                      Convert.ToDateTime(dtpDateOfEmployment.Value),
                                      Convert.ToInt32(cboGender.SelectedIndex),
                                      Convert.ToInt32(cboCivilStatus.SelectedIndex),
                                      Convert.ToString(cboPosition.Text),
                                       Convert.ToInt32(cboDepartment.SelectedValue), 
                                      Convert.ToInt32(cboUnit.SelectedIndex),
                                      Convert.ToDecimal(txtSalary.Text),
                                      pic,
                                      Convert.ToInt32(chkStatus.CheckState),
                                     Convert.ToDecimal(txtSSSPrem.Text),
                                  Convert.ToDecimal(txtPHICPrem.Text),
                                  Convert.ToDecimal(txtPagIbigPrem.Text),
                                  Convert.ToDecimal(txtSSSLoan.Text),
                                  Convert.ToDecimal(txtPagIbigLoan.Text),
                                 Convert.ToDecimal(txtSavings.Text),
                                  Convert.ToDecimal(txtOTRate.Text)
                                 // Convert.ToString(cboShiftName.Text )
                                     );

                MessageBox.Show("Update Successfull");
               // EmployeeGet(IDS);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

           
        }
        public void EmployeeGet(double ids)
        {
            try
            {

                Employee_Controller empGet = new Employee_Controller();

                foreach (DataRow row in empGet.EmployeeSelect(ids).Rows)
                {
                    txtIDS.Text = row["IDS"].ToString();
                    txtLastName.Text = row["lname"].ToString();
                    txtFirstName.Text = row["fname"].ToString();
                    txtMiddleName.Text = row["mname"].ToString();
                    txtAddress.Text = row["AddressHome"].ToString();
                    txtContactNumber.Text = row["ContactNo"].ToString();
                    dtpDateOfBirth.Value = Convert.ToDateTime(row["DateOfBirth"].ToString());
                    dtpDateOfEmployment.Value = Convert.ToDateTime(row["DateOfEmployment"].ToString());
                    cboGender.SelectedIndex = Convert.ToInt32(row["CivilStatus"].ToString());
                    cboCivilStatus.SelectedIndex = Convert.ToInt32(row["CivilStatus"].ToString());
                    cboPosition.Text = row["Position"].ToString();
                  //  cboShiftName.Text = row["ShiftName"].ToString();

                      byte[] MyData = new byte[0];
                                    if (row["PersonImage"] != null)
                                    {
                                        ////if (IsValidImage((byte[])row["PersonImage"]) == true)
                                        ////{
                                        MyData = (byte[])row["PersonImage"];
                                        MemoryStream stream = new MemoryStream(MyData);
                                        picImage.Image = Image.FromStream(stream);
                                        // }
                                    }

                    cboDepartment.SelectedValue  = Convert.ToInt32(row["Department"].ToString());
                    cboUnit.SelectedIndex = Convert.ToInt32(row["Unit"].ToString());
                    chkStatus.Checked = Convert.ToBoolean(row["Stat"]);

                    txtSalary.Text = row["Salary"].ToString();
                    txtSSSPrem.Text=row["SSSPrem"].ToString();
                    txtPHICPrem.Text=row["PHICPrem"].ToString();
                    txtPagIbigPrem.Text=row["PagIbigPrem"].ToString();
                    txtSSSLoan.Text=row["SSSLoan"].ToString();
                    txtPagIbigLoan.Text=row["PagIbigLoan"].ToString();
                    txtSavings.Text = row["Savings"].ToString();
                    txtOTRate.Text = row["OTRate"].ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void EmployeeClear()
        { 
          txtIDS.Text="0";
          txtLastName.Text= "";
          txtFirstName.Text="";
          txtMiddleName.Text="";
          txtAddress.Text="";
          txtContactNumber.Text="";
          dtpDateOfBirth.Value=DateTime.Now ;
          dtpDateOfEmployment.Value=DateTime.Now ;
          txtSalary.Text="";

        }
        private void cmdShowCamera_Click(object sender, EventArgs e)
        {

             CameraFrm camera = new CameraFrm(this);
             // camera. = this;
             camera.Show();

        }
        private void tlsEmployee_Click(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToDouble(txtIDS.Text) == 0)
                {
                    EmployeeInserts();
                }
                else
                {
                    EmployeeUpdates();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void txtIDS_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txtIDS.Text) == 0)
                {
                    //    cmdShowCamera.Enabled = false;
                    cmdRegisterFingerprint.Enabled = false;
                }
                else
                {
                    //EmployeeUpdates();
                    cmdRegisterFingerprint.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }
        private void cmdRegisterFingerprint_Click(object sender, EventArgs e)
        {
            OnEnrollMain enrollbio = new OnEnrollMain();
            //enrollbio.Parent = this;
            enrollbio.txtUserID.Text = txtIDS.Text;
            enrollbio.Show();
        }
        private void cmdFromFile_Click(object sender, EventArgs e)
        {

            // Wrap the creation of the OpenFileDialog instance in a using statement,
            // rather than manually calling the Dispose method to ensure proper disposal
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                //dlg.Filter = "bmp files (*.bmp)|*.bmp";
                //dlg.Filter = "Bmp files (*.bmp)|*.bmp|Jpeg files(*.jpg)|*.jpg";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                 //   PictureBox pictureBox1 = new PictureBox();

                    // Create a new Bitmap object from the picture file on disk,
                    // and assign that to the PictureBox.Image property
                    picImage.Image = new Bitmap(dlg.FileName);
                }
            }


        }
        public static bool IsValidImage(byte[] bytes)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                    Image.FromStream(ms);
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }
        private void builDepartmentCbo()
        {
            Department_Controller departmentcboGet = new Department_Controller();
            DataTable dt = departmentcboGet.DepartmentSelectAll();
            cboDepartment.DataSource = dt;
            cboDepartment.DisplayMember = "Department";
            cboDepartment.ValueMember = "IDS";
        }

        private void ShiftNameCbo()
        {
            AttendanceRule_Controller ShiftcboGet = new AttendanceRule_Controller();
            DataTable dt = ShiftcboGet.ShiftNameSelect();
            cboShiftName.DataSource = dt;
            cboShiftName.DisplayMember = "ShiftName";
           // cboShiftName.ValueMember = "IDS";

        }
        private void tsbEmployeeSaveAndClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txtIDS.Text) == 0)
                {
                    EmployeeInserts();
                    this.Close();
                }
                else
                {
                    EmployeeUpdates();
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void NewEmployee_Load(object sender, EventArgs e)
        {

        }



 


    }
}
