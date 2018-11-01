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
    public partial class MachineNew : Telerik.WinControls.UI.RadForm
    {
        public MachineNew()
        {
            InitializeComponent();
        }
        private void MachineInserts()
        {

            try
            {

                Machine_Controller machineNew = new Machine_Controller();
                Double IDS = machineNew.MachineInsert(Convert.ToDouble(txtIDS.Text),
                                      Convert.ToString(txtMachineName.Text),
                                      Convert.ToString(txtMachineNumber.Text),
                                      Convert.ToString(txtPortNumber.Text),
                                      Convert.ToString(txtIPAddress.Text),
                                      Convert.ToString(txtBaudRate.Text),
                                      Convert.ToString(cboComType.Text),
                                     Convert.ToInt32(chkStatus.CheckState)
                                     );

                MessageBox.Show("Save Successfull");
                MachineGet(IDS);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void MachineUpdates()
        {
            try
            {

                Machine_Controller machineNew = new Machine_Controller();
                Double IDS = machineNew.MachineUpdate(Convert.ToDouble(txtIDS.Text),
                                      Convert.ToString(txtMachineName.Text),
                                      Convert.ToString(txtMachineNumber.Text),
                                      Convert.ToString(txtPortNumber.Text),
                                      Convert.ToString(txtIPAddress.Text),
                                      Convert.ToString(txtBaudRate.Text),
                                      Convert.ToString(cboComType.Text),
                                     Convert.ToInt32(chkStatus.CheckState)
                                     );

                MessageBox.Show("Update Successfull");
                MachineGet(IDS);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        public void MachineGet(double ids)
        {
            try
            {

                Machine_Controller machineGet = new Machine_Controller();
                
                foreach (DataRow row in machineGet.MachineSelect(ids).Rows)
                {
                    txtIDS.Text = row["IDS"].ToString();
                    txtMachineName.Text = row["MachineName"].ToString();
                    txtMachineNumber.Text = row["MachineNumber"].ToString();
                    txtIPAddress.Text = row["IPAddress"].ToString();
                    txtPortNumber.Text = row["PorNumber"].ToString();
                    txtBaudRate.Text = row["BaudRate"].ToString();
                    cboComType.Text = row["ComType"].ToString();
                    chkStatus.Checked = Convert.ToBoolean(row["Stat"]);
                }

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

                if (Convert.ToDouble(txtIDS.Text) == 0)
                {
                    MachineInserts();
                }
                else
                {
                    MachineUpdates();
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
                    MachineInserts();
                    this.Close();
                }
                else
                {
                    MachineUpdates();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
