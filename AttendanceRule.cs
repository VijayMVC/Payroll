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
    public partial class AttendanceRule : Telerik.WinControls.UI.RadForm
    {
        public AttendanceRule()
        {
            InitializeComponent();
            ShiftNameCbo();
        }

        private void AttendanceRuleInserts()
        {

            try
            {
                AttendanceRule_Controller AttRuleNew = new AttendanceRule_Controller();
                //AttendanceLog_Controller AttRuleNew = new AttendanceLog_Controller();
                Double IDS = AttRuleNew.AttendanceRuleInsert( Convert.ToDouble(txtIDS.Text),
                                      Convert.ToDateTime(dtpPunchIn.Value ),
                                      Convert.ToDateTime(dtpBreakOut.Value),
                                      Convert.ToDateTime(dtpBreakIn.Value),
                                      Convert.ToDateTime(dtpPunchOut.Value),
                                      Convert.ToDateTime(dtpOvertimeIn.Value),
                                      Convert.ToDateTime(dtpOvertimeOut.Value),
                                      Convert.ToString(cboShiftName.Text ),
                                      Convert.ToInt16 (cboDayOfTheWeek.SelectedIndex),
                                     Convert.ToDecimal(txtPenalty.Text)
                                     );

                MessageBox.Show("Save Successfull");
                AttendanceRuleGet(IDS); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void AttendanceRuleUpdates()
        {
            try
            {
                AttendanceRule_Controller AttRuleUpdate = new AttendanceRule_Controller();
              //  AttendanceLog_Controller AttRuleUpdate = new AttendanceLog_Controller();
                 AttRuleUpdate.AttendanceRuleUpdate(Convert.ToDouble(txtIDS.Text),
                                      Convert.ToDateTime(dtpPunchIn.Value),
                                      Convert.ToDateTime(dtpBreakOut.Value),
                                      Convert.ToDateTime(dtpBreakIn.Value),
                                      Convert.ToDateTime(dtpPunchOut.Value),
                                      Convert.ToDateTime(dtpOvertimeIn.Value),
                                      Convert.ToDateTime(dtpOvertimeOut.Value),
                                      Convert.ToString(cboShiftName.Text),
                                      Convert.ToInt16(cboDayOfTheWeek.SelectedIndex),
                                      Convert.ToDecimal(txtPenalty.Text)
                                     );
                MessageBox.Show("Update Successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        public void AttendanceRuleGet(double ids)
        {
            try
            {

                AttendanceRule_Controller AttRule = new AttendanceRule_Controller();

               foreach (DataRow row in AttRule.AttendanceRuleSelect(ids).Rows)
                {
                    txtIDS.Text = row["IDS"].ToString();
                    cboDayOfTheWeek.SelectedIndex= Convert.ToInt16(row["DayOfTheWeek"].ToString());
                    cboShiftName.Text  =row["ShiftName"].ToString();

                    dtpPunchIn.Value = Convert.ToDateTime(row["PunchInRule"].ToString());
                    dtpBreakOut.Value = Convert.ToDateTime(row["BreakOutRule"].ToString());
                    dtpBreakIn.Value = Convert.ToDateTime(row["BreakInRule"].ToString());
                    dtpPunchOut.Value = Convert.ToDateTime(row["PunchOutRule"].ToString());
                    dtpOvertimeIn.Value = Convert.ToDateTime(row["OTInRule"].ToString());
                    dtpOvertimeOut.Value = Convert.ToDateTime(row["OTOutRule"].ToString());

                    txtPenalty.Text = row["LatePerMinutePenalty"].ToString();
                }

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
                    AttendanceRuleInserts();
                }
                else
                {
                    AttendanceRuleUpdates();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void tsbSaveAdnClose_Click(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToDouble(txtIDS.Text) == 0)
                {
                    AttendanceRuleInserts();
                }
                else
                {
                    AttendanceRuleUpdates();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ShiftNameCbo()
        {
            AttendanceRule_Controller ShiftcboGet = new AttendanceRule_Controller();
            DataTable dt = ShiftcboGet.ShiftNameSelect();
            cboShiftName.DataSource = dt;
            cboShiftName.DisplayMember = "ShiftName";
           // cboShiftName.ValueMember = "IDS";

        }

        private void dtpBreakOut_Click(object sender, EventArgs e)
        {

        }

    }
}
