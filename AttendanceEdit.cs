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
    public partial class AttendanceEdit : Telerik.WinControls.UI.RadForm
    {
        public AttendanceEdit()
        {
            InitializeComponent();
            //dtpPunchIn.Format = DateTimePickerFormat.Custom;
            //dtpPunchIn.CustomFormat = "hh:mm tt";

            dtpPunchIn.Format = DateTimePickerFormat.Custom;
            dtpPunchIn.CustomFormat = " ";

            dtpPunchOut.Format = DateTimePickerFormat.Custom;
            dtpPunchOut.CustomFormat = " ";

            dtpBreakIn.Format = DateTimePickerFormat.Custom;
            dtpBreakIn.CustomFormat = " ";

            dtpBreakOut.Format = DateTimePickerFormat.Custom;
            dtpBreakOut.CustomFormat = " ";

            dtpOvertimeIn.Format = DateTimePickerFormat.Custom;
            dtpOvertimeIn.CustomFormat = " ";

            dtpOvertimeOut.Format = DateTimePickerFormat.Custom;
            dtpOvertimeOut.CustomFormat = " ";
            
        }

        private void AttendanceInserts()
        {

            try
            {

                AttendanceLog_Controller AttNew = new AttendanceLog_Controller();
                Double IDS = AttNew.AttendanceInsert(Convert.ToDouble(txtEmployeeIDS.Text),
                                            Convert.ToDateTime(dtpDate.Value ),
                                             Convert.ToDateTime(dtpDate.Value.Date + dtpPunchIn.Value.TimeOfDay),
                                             Convert.ToDateTime(dtpDate.Value.Date + dtpBreakOut.Value.TimeOfDay),
                                             Convert.ToDateTime(dtpDate.Value.Date + dtpBreakIn.Value.TimeOfDay),
                                             Convert.ToDateTime(dtpDate.Value.Date + dtpPunchOut.Value.TimeOfDay),
                                             Convert.ToDateTime(dtpDate.Value.Date + dtpOvertimeIn.Value.TimeOfDay),
                                             Convert.ToDateTime(dtpDate.Value.Date + dtpOvertimeOut.Value.TimeOfDay),
                                             Convert.ToInt32(chkPI.CheckState),
                                             Convert.ToInt32(chkBO.CheckState),
                                             Convert.ToInt32(chkBI.CheckState),
                                             Convert.ToInt32(chkPO.CheckState),
                                             Convert.ToInt32(chkOI.CheckState),
                                             Convert.ToInt32(chkOO.CheckState));
                MessageBox.Show("Save Successfull");

                AttendanceGet(IDS);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void AttendanceUpdates()
        {
            try
            {

                AttendanceLog_Controller AttUpdate = new AttendanceLog_Controller();
                AttUpdate.AttendanceUpdate  (Convert.ToDouble(txtIDS.Text),
                                             Convert.ToDateTime(dtpDate.Value),
                                             Convert.ToDateTime(dtpDate.Value.Date+dtpPunchIn.Value.TimeOfDay),
                                             Convert.ToDateTime(dtpDate.Value.Date + dtpBreakOut.Value.TimeOfDay ),
                                             Convert.ToDateTime(dtpDate.Value.Date + dtpBreakIn.Value.TimeOfDay ),
                                             Convert.ToDateTime(dtpDate.Value.Date + dtpPunchOut.Value.TimeOfDay ),
                                             Convert.ToDateTime(dtpDate.Value.Date + dtpOvertimeIn.Value.TimeOfDay),
                                             Convert.ToDateTime(dtpDate.Value.Date + dtpOvertimeOut.Value.TimeOfDay ),
                                             Convert.ToInt32(chkPI.CheckState),
                                             Convert.ToInt32(chkBO.CheckState),
                                             Convert.ToInt32(chkBI.CheckState),
                                             Convert.ToInt32(chkPO.CheckState),
                                             Convert.ToInt32(chkOI.CheckState),
                                             Convert.ToInt32(chkOO.CheckState) );

                MessageBox.Show("Update Successfull");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        public void AttendanceGet(double ids)
        {
            try
            {

                AttendanceLog_Controller Att = new AttendanceLog_Controller();

                foreach (DataRow row in Att.AttendanceEditSelect(ids).Rows)
                {
                    txtIDS.Text = row["IDS"].ToString();
                    dtpDate.Value = Convert.ToDateTime(row["AttendanceDate"].ToString());

                    if (row["PunchIn"].ToString() != null) 
                    {
                        dtpPunchIn.Format = DateTimePickerFormat.Custom;
                        dtpPunchIn.CustomFormat = "hh:mm tt";
                        chkPI.Checked = true;
                        dtpPunchIn.Value = Convert.ToDateTime(row["PunchIn"].ToString());
                    }
                    if (row["BreakOut"].ToString()!= "" )
                    {
                        dtpBreakOut.Format = DateTimePickerFormat.Custom;
                        dtpBreakOut.CustomFormat = "hh:mm tt";
                        chkBO.Checked = true;
                        dtpBreakOut.Value = Convert.ToDateTime(row["BreakOut"].ToString());
                    }
                    if (row["BreakIn"].ToString() != "")
                    {
                        dtpBreakIn.Format = DateTimePickerFormat.Custom;
                        dtpBreakIn.CustomFormat = "hh:mm tt";
                        chkBI.Checked = true;
                        dtpBreakIn.Value = Convert.ToDateTime(row["BreakIn"].ToString());
                    }

                    if (row["PunchOut"].ToString() != "")
                    {
                        dtpPunchOut.Format = DateTimePickerFormat.Custom;
                        dtpPunchOut.CustomFormat = "hh:mm tt";
                        chkPO.Checked = true;
                        dtpPunchOut.Value = Convert.ToDateTime(row["PunchOut"].ToString());
                    }

                    if (row["OTIn"].ToString() != "")
                    {
                        dtpOvertimeIn.Format = DateTimePickerFormat.Custom;
                        dtpOvertimeIn.CustomFormat = "hh:mm tt";
                        chkOI.Checked = true;
                        dtpOvertimeIn.Value = Convert.ToDateTime(row["OTIn"].ToString());
                    }

                    if (row["OTOut"].ToString() != "")
                    {
                        dtpOvertimeOut.Format = DateTimePickerFormat.Custom;
                        dtpOvertimeOut.CustomFormat = "hh:mm tt";
                        chkOO.Checked = true;
                        dtpOvertimeOut.Value = Convert.ToDateTime(row["OTOut"].ToString());
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void AttendanceEdit_Load(object sender, EventArgs e)
        {

        }

        private void chkPI_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPI.Checked ==true)
            {
     
                dtpPunchIn.Format = DateTimePickerFormat.Custom;
                dtpPunchIn.CustomFormat = "hh:mm tt";
                DateTime time = Convert.ToDateTime("08:00 AM");
                dtpPunchIn.Value = dtpDate.Value.Date + time.TimeOfDay;


            }
            else
            {
                dtpPunchIn.Format = DateTimePickerFormat.Custom;
                dtpPunchIn.CustomFormat = " ";
            }
        }

        private void chkBO_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBO.Checked == true)
            {
                dtpBreakOut.Format = DateTimePickerFormat.Custom;
                dtpBreakOut.CustomFormat = "hh:mm tt";
                DateTime time = Convert.ToDateTime("12:00 PM");
                dtpBreakOut.Value = dtpDate.Value.Date + time.TimeOfDay;

            }
            else
            {
                dtpBreakOut.Format = DateTimePickerFormat.Custom;
                dtpBreakOut.CustomFormat = " ";
            }
        }

        private void chkBI_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBI.Checked == true)
            {
                dtpBreakIn.Format = DateTimePickerFormat.Custom;
                dtpBreakIn.CustomFormat = "hh:mm tt";

                DateTime time = Convert.ToDateTime("01:00 PM");
                dtpBreakIn.Value = dtpDate.Value.Date + time.TimeOfDay;
            }
            else
            {
                dtpBreakIn.Format = DateTimePickerFormat.Custom;
                dtpBreakIn.CustomFormat = " ";
            }
        }

        private void chkPO_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPO.Checked == true)
            {
                dtpPunchOut.Format = DateTimePickerFormat.Custom;
                dtpPunchOut.CustomFormat = "hh:mm tt";

                DateTime time = Convert.ToDateTime("05:00 PM");
                dtpPunchOut.Value = dtpDate.Value.Date + time.TimeOfDay;
            }
            else
            {
                dtpPunchOut.Format = DateTimePickerFormat.Custom;
                dtpPunchOut.CustomFormat = " ";
            }

        }

        private void chkOI_CheckedChanged(object sender, EventArgs e)
        {

            if (chkOI.Checked == true)
            {
                dtpOvertimeIn.Format = DateTimePickerFormat.Custom;
                dtpOvertimeIn.CustomFormat = "hh:mm tt";
                DateTime time = Convert.ToDateTime("05:30 PM");
                dtpOvertimeIn.Value = dtpDate.Value.Date + time.TimeOfDay;
            }
            else
            {
                dtpOvertimeIn.Format = DateTimePickerFormat.Custom;
                dtpOvertimeIn.CustomFormat = " ";
            }
        }

        private void chkOO_CheckedChanged(object sender, EventArgs e)
        {

            if (chkOO.Checked == true)
            {
                dtpOvertimeOut.Format = DateTimePickerFormat.Custom;
                dtpOvertimeOut.CustomFormat = "hh:mm tt";
                DateTime time = Convert.ToDateTime("09:30 PM");
                dtpOvertimeOut.Value = dtpDate.Value.Date + time.TimeOfDay;
            }
            else
            {
                dtpOvertimeOut.Format = DateTimePickerFormat.Custom;
                dtpOvertimeOut.CustomFormat = " ";
            }

        }

        private void tsbSaveAdnClose_Click(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToDouble(txtIDS.Text) == 0)
                {
                    AttendanceInserts();
                }
                else
                {
                    AttendanceUpdates();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void tlsAttendanceRuleSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToDouble(txtIDS.Text) == 0)
                {
                    AttendanceInserts();
                }
                else
                {
                    AttendanceUpdates();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

    }
}
