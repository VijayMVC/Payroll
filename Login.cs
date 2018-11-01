using Payroll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Payroll
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            Variables var = new Variables();

            Variables.DBName  = txtDatabase.Text;
            Variables.ServerName = txtServer.Text;
            Variables.UserName = txtUser.Text;
            Variables.Password = txtPassword.Text;

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(var.ConString()))
                {
                    sqlConn.Open();
                    if (sqlConn.State == ConnectionState.Open)
                    {
                        mdiPayrollMenu  parent = new mdiPayrollMenu();
                        parent.Show();
                        this.Hide();
                        
                    }
                    else
                    { MessageBox.Show("Cannot established connection."); }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
