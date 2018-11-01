
using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;
using System.Threading;
using UareUSampleCSharp;


namespace Payroll
{

    public partial class mdiPayrollMenu : Telerik.WinControls.UI.RadForm
    {
        public zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();
        private bool bIsConnected = false;//the boolean value identifies whether the device is connected
        private int iMachineNumber = 1;//the serial number of the device.After connecting the device ,this value will be changed.
        private int iCanSaveTmp = 0;

        // public System.Threading.Timer timer;

        #region MDIPayroll

        public mdiPayrollMenu()
        {
            InitializeComponent();
          //  this.radDock1.AutoDetectMdiChildren = true;

            DateTime LastSaturdayDate = new DateTime();
            LastSaturdayDate = FirstDayOfWeek(DateTime.Now);

            dtpFromAtt.Value = LastSaturdayDate.AddDays(-1);
            dtpToAtt.Value = DateTime.Now;


            EmployeeListGet();
            MachineListGet();
            builEmployeeCbo();
            builEmployeeNoShift();
            AttendanceRuleListGet();
            builDepartmentCbo();
            cboEmployeesName.SelectedIndex = -1;
          //  timer = new System.Threading.Timer(new TimerCallback(ConnectToMachine), null, 0, 3000);

            
        }


        private void builDepartmentCbo()
        {
            Department_Controller departmentcboGet = new Department_Controller();
            DataTable dt = departmentcboGet.DepartmentSelectAll();
            cboDepartment.DataSource = dt;
            cboDepartment.DisplayMember = "Department";
            cboDepartment.ValueMember = "IDS";

        }


        private static DateTime FirstDayOfWeek(DateTime dt)
        {
            var culture =System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            return dt.AddDays(-diff).Date;
        }

        private static mdiPayrollMenu s_oInstance = null;
        public static mdiPayrollMenu Instance
        {
            get
            {
                return (s_oInstance);
            }
        }


       // private void ChangeThemeName(Control control, string themeName)

        #endregion

        #region Employee
        
        private void EmployeeListGet()
        {
            try
            {

                DataGridViewRow row = this.dgvEmployeeList.RowTemplate;
                row.DefaultCellStyle.BackColor = Color.Aqua ;
                row.Height = 100;
                row.MinimumHeight = 20;

                Employee_Controller empGet = new Employee_Controller();


                dgvEmployeeList.DataSource = empGet.EmployeeSelectAll();
             //   this.dgvEmployeeList1.Columns[0].Visible = false;
                dgvEmployeeList.Columns[12].DefaultCellStyle.Format = "###,##0.00##";
                dgvEmployeeList.Columns[14].DefaultCellStyle.Format = "###,##0.00##";
                dgvEmployeeList.Columns[15].DefaultCellStyle.Format = "###,##0.00##";
                dgvEmployeeList.Columns[16].DefaultCellStyle.Format = "###,##0.00##";
                dgvEmployeeList.Columns[17].DefaultCellStyle.Format = "###,##0.00##";
                dgvEmployeeList.Columns[18].DefaultCellStyle.Format = "###,##0.00##";
                dgvEmployeeList.Columns[19].DefaultCellStyle.Format = "###,##0.00##";
                dgvEmployeeList.Columns[20].DefaultCellStyle.Format = "###,##0.00##";

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
        private void dgvEmployeeList_MouseDoubleClick(object sender, MouseEventArgs e)
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
        private void tmrAttendance_Tick(object sender, EventArgs e)
        {
           lblTime.Text = DateTime.Now.ToLongDateString () + " " + DateTime.Now.ToLongTimeString();
 
        }

        private void tsbDownloadTemplate_Click(object sender, EventArgs e)
        {
            
        }


        private void DownloadTemplate()
        {
            if (bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }

            if (iCanSaveTmp == 0)//You haven't enrolled the templates.
            {
                MessageBox.Show("Please enroll the fingerprint templates first!", "Error");
                return;
            }

            //String connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\data\Templates.mdb";
            //Variables var = new Variables();
            //conn = new SqlConnection(var.ConStringOleDB());
            //OleDbConnection conn = new OleDbConnection(ConStringOleDB);

            int idwFingerIndex = 0;  // Convert.ToInt32(cbFingerIndex.Text.Trim());
            int iTmpLength = 0;
            string sdwEnrollNumber = dgvEmployeeList.SelectedRows[0].Cells["IDS"].Value.ToString();
            int iFlag = 0;
            byte[] byTmpData = new byte[2000];//modify by darcy on Dec.9 2009
            string sName = "";
            string sPassword = "";
            int iPrivilege = 0;
            bool bEnabled = false;

           

            axCZKEM1.EnableDevice(iMachineNumber, false);
            Cursor = Cursors.WaitCursor;
            axCZKEM1.ReadAllTemplate(iMachineNumber);


            while (axCZKEM1.SSR_GetUserInfo(iMachineNumber, sdwEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))
            {
                if (axCZKEM1.GetUserTmpEx(iMachineNumber, sdwEnrollNumber, idwFingerIndex, out iFlag, out byTmpData[0], out iTmpLength))
                {
                    //If you need to select or delete the data in the database ,you can just define the sql sentences by youself
                    //string sql = "insert into Template(UserID,FingerID,Template,TmpLen,Flag) values('" + sdwEnrollNumber + "','" + idwFingerIndex + "','" + byTmpData + "','" + iTmpLength + "','" + iFlag + "')";//modify by darcy on Dec.9 2009
                    //OleDbCommand cmd = new OleDbCommand(sql, conn);
                    //conn.Open();
                    //cmd.ExecuteNonQuery();

                    Employee_Controller emp = new Employee_Controller();
                  //  emp.EmployeeTemplateInsert(0, Convert.ToInt32(sdwEnrollNumber), Convert.ToInt32(idwFingerIndex), byTmpData[0], iTmpLength, iFlag);
                    double ids= emp.EmployeeTemplateInsert(0, 1,1,0,1, 1);

                    MessageBox.Show("Successfully save templates to database ! ", "Success");

                }
                else
                {
                    MessageBox.Show("Saving templates to database failed !", "Error");
                }
            }
            axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
            axCZKEM1.EnableDevice(iMachineNumber, true);
            Cursor = Cursors.Default;

        }

     #endregion

        #region Machine
          public  void MachineListGet()
            {
                try
                {

                    Machine_Controller machineGet = new Machine_Controller();
                    dgvMachineList.DataSource = machineGet.MachineSelectAll();
                    this.dgvMachineList.Columns[0].Visible = false;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
          private void tsbNewMachine_Click(object sender, EventArgs e)
            {
                try
                {
                    MachineNew machineNew = new MachineNew();
                    machineNew.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }


          private void tsbMachineRefreshList_Click(object sender, EventArgs e)
            {
                try
                {
                    MachineListGet();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }



          private void MachineConnect(string IPAddress,string Port)
          {
             
               int idwErrorCode = 0;
                   // Cursor = Cursors.WaitCursor;
                   
                 try
                  {
                  // axCZKEM1.CommPort = 4370;
                  //axCZKEM1.MachineNumber = 1;  
                  bIsConnected = axCZKEM1.Connect_Net(IPAddress, Convert.ToInt32(Port));
      
                  if (bIsConnected == true)
                    {
                        iMachineNumber = 1;//In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
                        axCZKEM1.RegEvent(iMachineNumber, 65535);//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)

                        if (axCZKEM1.RegEvent(iMachineNumber, 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
                        {

                            this.axCZKEM1.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
                        }
                        MessageBox.Show("Device Connected.");
                        return;
                    }
                    else
                    {
                        axCZKEM1.GetLastError(ref idwErrorCode);
                        MessageBox.Show("Unable to connect the device,ErrorCode=" + idwErrorCode.ToString(), "Error");
                    }
                
              }
              catch(Exception ex)
              {
                  MessageBox.Show(ex.Message.ToString());
              }

                 //Cursor = Cursors.Default;
          }
          private void MachineDisConnect()
          {
              try
               {
                //Cursor = Cursors.WaitCursor;
                 axCZKEM1.Disconnect();
                Cursor = Cursors.Default;
                this.axCZKEM1.OnAttTransactionEx -= new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
                MessageBox.Show("Disconnected");
              }
                      catch(Exception ex)
              {
                  MessageBox.Show(ex.Message.ToString());
              }
          }     
          private void tsbMachineConnect_Click(object sender, EventArgs e)
            {
                DataGridViewSelectedCellCollection DGV = this.dgvMachineList.SelectedCells;
                //for (int i = 0; i <= DGV.Count - 1; i++)
                //{
                //    MessageBox.Show(DGV[i].Value.ToString());
                //}
              MachineConnect(DGV[4].Value.ToString(), DGV[3].Value.ToString());
              //  MachineConnect("192.168.1.201", "4370");

            }
          private void tsbMachineDisconnect_Click(object sender, EventArgs e)
          {
              MachineDisConnect();

          }
 
        #endregion

        #region Attendance

            private void AttendanceLogInsertUpdate()
              {
                  if (bIsConnected == false)
                  {
                      MessageBox.Show("Please connect the device first", "Error");
                      return;
                  }

                  string sdwEnrollNumber = "";
                  //int idwTMachineNumber = 0;
                  //int idwEMachineNumber = 0;
                  int idwVerifyMode = 0;
                  int idwInOutMode = 0;
                  int idwYear = 0;
                  int idwMonth = 0;
                  int idwDay = 0;
                  int idwHour = 0;
                  int idwMinute = 0;
                  int idwSecond = 0;
                  int idwWorkcode = 0;
                  int idwErrorCode = 0;

                  //int iGLCount = 0;
                  //int iIndex = 0;

                  Cursor = Cursors.WaitCursor;
                  //lvLogs.Items.Clear();

                  AttendanceLog_Controller Attendance = new AttendanceLog_Controller();

                  axCZKEM1.EnableDevice(axCZKEM1.MachineNumber, false);//disable the device
                    // if (axCZKEM1.ReadSuperLogData(iMachineNumber))//read all the attendance records to the memory
                  if (axCZKEM1.ReadGeneralLogData(axCZKEM1.MachineNumber))//read all the attendance records to the memory
                  {
                      while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode,
                                 out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
                      {
                          DateTime cDate = Convert.ToDateTime(idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString() + " " + idwHour.ToString() + ":" + idwMinute.ToString() + ":" + idwSecond.ToString());
                         // DateTime cDate1 = Convert.ToDateTime(String.Format("{0:MM/dd/yyyy}", cDate));
                         //DateTime cDateFrom = Convert.ToDateTime(String.Format("{0:MM/dd/yyyy}", dtpFromAtt.Value));
                         // DateTime cDateTo = Convert.ToDateTime(String.Format("{0:MM/dd/yyyy}", dtpToAtt.Value));

                         //     if (cDate1 >= cDateFrom && cDate1 <= cDateTo)
                         //   {

                            Attendance.AttendanceInsertUpdate(0, Convert.ToDouble(sdwEnrollNumber), Convert.ToString(iMachineNumber), cDate, idwInOutMode);
                         
                         //  }

                     }
                  }
                  else
                  {
                      Cursor = Cursors.Default;
                      axCZKEM1.GetLastError(ref idwErrorCode);

                      if (idwErrorCode != 0)
                      {
                          MessageBox.Show("Reading data from terminal failed,ErrorCode: " + idwErrorCode.ToString(), "Error");
                      }
                      else
                      {
                          MessageBox.Show("No data from terminal returns!", "Error");
                      }
                  }
                  axCZKEM1.EnableDevice(iMachineNumber, true);//enable the device
                  Cursor = Cursors.Default;

              }

            public void AttendanceLogShow(double EmployeeIDS,DateTime DateFrom,DateTime DateTo)
            {
                try
                {

                    AttendanceLog_Controller AttendanceGet = new AttendanceLog_Controller();
                    dgvAttendance.DataSource = AttendanceGet.AttendanceSelect(EmployeeIDS, DateFrom, DateTo);


                    foreach (DataRow row in AttendanceGet.EmployeeGetWorkedDays(Convert.ToDouble(EmployeeIDS), DateFrom, DateTo).Rows)
                    {
                        lblCredit.Text = "Credit(Days): " + row["Credit"].ToString();
                        lblLate.Text = "Late|Early Out: " + row["LateEO"].ToString();
                    }


                    //this.dgvAttendance.Columns[0].Visible = false;
                    this.dgvAttendance.Columns[1].Visible = false;
                    this.dgvAttendance.Columns[2].Visible = false;
                    this.dgvAttendance.Columns[3].Width = 300;
                    this.dgvAttendance.Columns[0].Width = 40;
                    this.dgvAttendance.Columns[4].Width = 180;

                }
                catch { }
            }

            public void AttendanceLogShowAll()
            {
                try
                {

                    AttendanceLog_Controller AttendanceGetAll = new AttendanceLog_Controller();
                    dgvAttendance.DataSource = AttendanceGetAll.AttendanceSelectAll();

                    //this.dgvAttendance.Columns[0].Visible = false;
                    this.dgvAttendance.Columns[1].Visible = false;
                    this.dgvAttendance.Columns[2].Visible = false;
                    this.dgvAttendance.Columns[3].Width = 300;
                    this.dgvAttendance.Columns[0].Width = 40;
                    this.dgvAttendance.Columns[4].Width = 180;

                }
                catch { }
            } 

           public void MyAttendanceRuleShow(double  EmployeeIDS)
            {
                try
                {

                    AttendanceLog_Controller AttendanceGetAll = new AttendanceLog_Controller();
                    dgvMyAttendanceRule.DataSource = AttendanceGetAll.MyAttendanceRuleSelect(EmployeeIDS);
                    //this.dgvAttendance.Columns[0].Visible = false;
                    //this.dgvAttendanceRule.Columns[1].Visible = false;
                    //this.dgvAttendanceRule.Columns[2].Visible = false;
                    //this.dgvAttendanceRule.Columns[3].Width = 300;
                    //this.dgvAttendanceRule.Columns[0].Width = 40;
                    //this.dgvAttendanceRule.Columns[4].Width = 180;

                }
                catch { }
            } 
      
            private void builEmployeeCbo()
            {
                Employee_Controller AttendanceGet = new Employee_Controller();
                DataTable dt = AttendanceGet.EmployeeSelectAllCbo();
                cboEmployeesName.DataSource = dt;
                cboEmployeesName.DisplayMember = "FullName";
                cboEmployeesName.ValueMember = "IDS";
              
            }

            private void axCZKEM1_OnAttTransactionEx(string sEnrollNumber, int iIsInValid, int iAttState, int iVerifyMethod, int iYear, int iMonth, int iDay, int iHour, int iMinute, int iSecond, int iWorkCode)
            {
                AttendanceLog_Controller Attendance = new AttendanceLog_Controller();
                DateTime cDate = Convert.ToDateTime(iYear.ToString() + "-" + iMonth.ToString() + "-" + iDay.ToString() + " " + iHour.ToString() + ":" + iMinute.ToString() + ":" + iSecond.ToString());
                Attendance.AttendanceInsertUpdate(0, Convert.ToDouble(sEnrollNumber), Convert.ToString(iMachineNumber), cDate, iAttState);
                AttendanceLogShow(Convert.ToDouble(sEnrollNumber), dtpFromAtt.Value, dtpToAtt.Value);
                EmployeeGetPic(Convert.ToDouble(sEnrollNumber));
                MyAttendanceRuleShow(Convert.ToDouble(sEnrollNumber));
                MyAttendanceRuleChange(Convert.ToDouble(sEnrollNumber), dtpFromAtt.Value, dtpToAtt.Value);

                foreach (DataRow row in Attendance.EmployeeGetWorkedDays(Convert.ToDouble(sEnrollNumber), dtpFromAtt.Value , dtpToAtt.Value ).Rows)
                {
                    lblCredit.Text = "Credit(Days): " + row["Credit"].ToString();
                    lblLate.Text = "Late|Early Out: " + row["LateEO"].ToString();
                }           

            }
         
            private void tsbAttendanceRule_Click(object sender, EventArgs e)
            {
                try
                {
                    double id = Convert.ToDouble(dgvAttendance.SelectedRows[0].Cells["IDS"].Value.ToString());
                    AttendanceShiftEdit attRule = new AttendanceShiftEdit();
                    attRule.Show();
                    attRule.AttendanceGet(id);
                }
                catch 
                { }

            }

            private void tsbShowAllEmpLog_Click(object sender, EventArgs e)
            {
                if (cboEmployeesName.Text=="")
                {
                    AttendanceLogShowAll();
                    EmployeeGetPic(Convert.ToDouble(cboEmployeesName.SelectedValue));
                    picImage.Image = picImage.InitialImage;
                }
                else
                {
                    AttendanceLogShow(Convert.ToDouble(cboEmployeesName.SelectedValue), dtpFromAtt.Value, dtpToAtt.Value);
                    EmployeeGetPic(Convert.ToDouble(cboEmployeesName.SelectedValue));
                    MyAttendanceRuleShow(Convert.ToDouble(cboEmployeesName.SelectedValue));
                    MyAttendanceRuleChange(Convert.ToDouble(cboEmployeesName.SelectedValue), dtpFromAtt.Value, dtpToAtt.Value); 
                }

                    
            }
        
            private void tsbDownloadLog_Click(object sender, EventArgs e)
            {
                AttendanceLogInsertUpdate();
            }

            public void EmployeeGetPic(double ids)
            {
                try
                {

                    Employee_Controller empGet = new Employee_Controller();

                    foreach (DataRow row in empGet.EmployeeSelect(ids).Rows)
                    {
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

                    }

                }
                catch { }
            }

            private void tsbEditLog_Click(object sender, EventArgs e)
            {
                if (Convert.ToDouble(cboEmployeesName.SelectedValue)>0)
                {
                   AttendanceEdit att = new AttendanceEdit();
                   att.txtEmployeeIDS.Text  = Convert.ToString(cboEmployeesName.SelectedValue);
                   att.Show();
                }
                else
                {
                    MessageBox.Show("Please choose employee.");
                }

            }

            public  DataTable EmployeeGetWorkedDays(double employeeIDS, DateTime DateFrom,DateTime DateTo )
            {
                try
                {

                    AttendanceLog_Controller WorkedDays = new AttendanceLog_Controller();
                    return WorkedDays.EmployeeGetWorkedDays(employeeIDS, DateFrom, DateTo);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    return null;
                }
            }

            public void MyAttendanceRuleChange(double EmployeeIDS, DateTime DateFrom, DateTime DateTo)
            {
                try
                {

                    AttendanceLog_Controller AttendanceGet = new AttendanceLog_Controller();
                    dgvChangesInShift.DataSource = AttendanceGet.MyAttendanceRuleChange(EmployeeIDS, DateFrom, DateTo);
                    //this.dgvAttendance.Columns[0].Visible = false;
                    //this.dgvChangesInShift.Columns[1].Visible = false;
                    //this.dgvAttendance.Columns[2].Visible = false;
                    //this.dgvAttendance.Columns[3].Width = 300;
                    //this.dgvAttendance.Columns[0].Width = 40;
                    //this.dgvAttendance.Columns[4].Width = 180;

                }
                catch { }
            }


            private void cmdDepartmentShow_Click(object sender, EventArgs e)
            {
                builDepartmentCbo();
            }

            private void PrintAttendance(double IDS, string From, string  To, string server, string database, string user, string pass)
            {
                try
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = "reportviewer.exe";
                    proc.StartInfo.Arguments = IDS + "," + server + "," + database + "," + user + "," + pass + ",2," + From  + "," + To  ;
                    proc.Start();
                    //  proc.WaitForExit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }


            private void cmdPrintAttendance_Click(object sender, EventArgs e)
            {
                
                Variables var = new Variables();

                string FromStr,  ToStr;

                DateTime To = dtpFromAtt.Value;
  
                 ToStr = Convert.ToString(To.Date);
               

                var From = dtpFromAtt.Value;
                FromStr = Convert.ToString(From.Date);


                PrintAttendance(Convert.ToDouble(cboDepartment.SelectedValue), FromStr, ToStr, Variables.ServerName, Variables.DBName, Variables.UserName, Variables.Password);

            }


        #endregion

        #region Department

            private void DepartmentListGet()
            {
                try
                {


                    Department_Controller departmentGet = new Department_Controller();

                    dgvDepartment.DataSource = departmentGet.DepartmentSelectAll();
                    this.dgvDepartment.Columns[0].Visible = false;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            private void tsbDepartmentNew_Click(object sender, EventArgs e)
            {

                try
                {
                    DepartmentNew departmentNew = new DepartmentNew();
                    departmentNew.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

            private void tsbDepartmentRefresh_Click(object sender, EventArgs e)
            {
                try
                {
                    DepartmentListGet();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

            private void dgvDepartment_DoubleClick(object sender, EventArgs e)
            {
                double id = Convert.ToDouble(dgvDepartment.SelectedRows[0].Cells["IDS"].Value.ToString());
                DepartmentNew frm = new DepartmentNew();
                frm.DepartmentGet(id);
                frm.Show();

            }

        #endregion
 

        #region Payroll
        private void tsbNewPayroll_Click(object sender, EventArgs e)
                    {
                        PayrollNew payroll = new PayrollNew();
                        payroll.Show();
                    }

        private void PayrollList()
        {
            try
            {


                Payroll_Controller payroll = new Payroll_Controller();

                dgvPayroll.DataSource = payroll.PayrollList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region AttendanceRule
        private void AttendanceRuleListGet()
        {
            try
            {


                AttendanceRule_Controller attendanceRuleGet = new AttendanceRule_Controller();

                dgvShiftList.DataSource = attendanceRuleGet.AttendanceRuleSelectList();
                this.dgvShiftList.Columns[0].Visible = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private void EmployeesListByShift()
        {
            try
            {

                string ShiftName = dgvShiftList.SelectedRows[0].Cells["ShiftName"].Value.ToString();

                AttendanceRule_Controller attRule = new AttendanceRule_Controller();
                dgvEmployee.DataSource = attRule.EmployeeSelectByShift(ShiftName);

            }
            catch { }
        }

        
        private void UpdateEmployeeByShift()
        {
            try
            {

                string ShiftName = dgvShiftList.SelectedRows[0].Cells["ShiftName"].Value.ToString();
                double IDS = Convert.ToDouble(cboEmployeesNoShift.SelectedValue);
                AttendanceRule_Controller attRule = new AttendanceRule_Controller();
                double result= attRule.UpdateEmployeeByShift(ShiftName, IDS);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void RemoveEmployeeFromShift()
        {
            try
            {
                double IDS = Convert.ToDouble(dgvEmployee.SelectedRows[0].Cells["IDS"].Value.ToString());
                AttendanceRule_Controller attRule = new AttendanceRule_Controller();
                double result = attRule.RemoveEmployeeFromShift(IDS);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void RemoveAllEmployeeFromShift()
        {
            try
            {
                string  ShiftName =dgvEmployee.SelectedRows[0].Cells["ShiftName"].Value.ToString();
                AttendanceRule_Controller attRule = new AttendanceRule_Controller();
                double result = attRule.RemoveAllEmployeeFromShift(ShiftName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void builEmployeeNoShift()
        {
            AttendanceRule_Controller Emp = new AttendanceRule_Controller();
            DataTable dt = Emp.EmployeeSelectAllNoShift();
            cboEmployeesNoShift.DataSource = dt;
            cboEmployeesNoShift.DisplayMember = "FullName";
            cboEmployeesNoShift.ValueMember = "IDS";

        }
        
        #endregion


        private void mdiPayrollMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tmrConnect_Tick(object sender, EventArgs e)
        {
            //int idwErrorCode = 0;
            //// Cursor = Cursors.WaitCursor;

            //try
            //{

            //    Machine_Controller machineGet = new Machine_Controller();
            //    foreach (DataRow row in machineGet.MachineSelectDefault().Rows)
            //    {
            //        // timer.Change(Timeout.Infinite, Timeout.Infinite); //disable
            //        bIsConnected = axCZKEM1.Connect_Net(row["IPAddress"].ToString(), Convert.ToInt32(row["PortNumber"].ToString()));
            //        //   timer.Change(0, 3000); //enable
            //        if (bIsConnected == true)
            //        {
            //            iMachineNumber = 1;//In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
            //            axCZKEM1.RegEvent(iMachineNumber, 65535);//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)

            //            if (axCZKEM1.RegEvent(iMachineNumber, 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            //            {

            //                this.axCZKEM1.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
            //            }
            //            lblConnectStatus.Text = "Device Connected.";
            //            //   return;
            //        }
            //        else
            //        {
            //            axCZKEM1.GetLastError(ref idwErrorCode);
            //            lblConnectStatus.Text = "Unable to connect the device,ErrorCode=" + idwErrorCode.ToString();

            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    lblConnectStatus.Text = ex.Message.ToString();
            //}

        }



        private void tsbRefreshList_Click(object sender, EventArgs e)
        {
            PayrollList();
        }

        private void dgvPayroll_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            double id = Convert.ToDouble(dgvPayroll.SelectedRows[0].Cells["IDS"].Value.ToString());
            PayrollNew frm = new PayrollNew();
            frm.PayrollGet(id);
            frm.PayrollEmployeeGet(id);
            frm.Show();
        }

        private void tsbRefreshRule_Click(object sender, EventArgs e)
        {
            AttendanceRuleListGet();
        }

        private void tsbNewRule_Click(object sender, EventArgs e)
        {

            try
            {
                AttendanceRule shiftNew = new AttendanceRule();
                shiftNew.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void dgvShiftList_DoubleClick(object sender, EventArgs e)
        {

            double id = Convert.ToDouble(dgvShiftList.SelectedRows[0].Cells["IDS"].Value.ToString());
            AttendanceRule attRule = new AttendanceRule();
            attRule.Show();
            attRule.AttendanceRuleGet(id);
        }

        private void dgvShiftList_SelectionChanged(object sender, EventArgs e)
        {
            EmployeesListByShift();
        }


        private void cmdAdd_Click(object sender, EventArgs e)
        {
            UpdateEmployeeByShift();
            EmployeesListByShift();
            builEmployeeNoShift();
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            RemoveEmployeeFromShift();
            builEmployeeNoShift();
            EmployeesListByShift();
        }

        private void cmdRemoveAll_Click(object sender, EventArgs e)
        {
            RemoveAllEmployeeFromShift();
            builEmployeeNoShift();
            EmployeesListByShift();
        }

        private void dgvAttendance_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            double id = Convert.ToDouble(dgvAttendance.SelectedRows[0].Cells["IDS"].Value.ToString());
            AttendanceEdit frm = new AttendanceEdit();
            frm.AttendanceGet(id);
            frm.Show();

        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            builEmployeeCbo();
        }

        private void dgvChangesInShift_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            try
            {
                double id = Convert.ToDouble(dgvChangesInShift.SelectedRows[0].Cells["IDS"].Value.ToString());
                AttendanceShiftEdit attRule = new AttendanceShiftEdit();
                attRule.Show();
                attRule.AttendanceGet(id);
            }
            catch
            { }

        }

        private void dgvEmployee_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            double id = Convert.ToDouble(dgvEmployee.SelectedRows[0].Cells["IDS"].Value.ToString());
            AttendanceRule attRule = new AttendanceRule();
            attRule.Show();
            attRule.AttendanceRuleGet(id);
        }

        private void tsbLog_Click(object sender, EventArgs e)
        {
            AttLogsMain log = new AttLogsMain();
            log.Show();
        }

        private void dgvAttendance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblLate_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtpFromAtt_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtpToAtt_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cboEmployeesName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }





    }
}
