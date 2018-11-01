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
    public partial class AttendanceRuleList : Form
    {
        public AttendanceRuleList()
        {
            InitializeComponent();
         //   EmployeeListGet();
        }


        //private void EmployeeListGet()
        //{
        //    try
        //    {

        //        AttendanceRule_Controller AttGet = new AttendanceRule_Controller();
        //        dgvShiftList.DataSource = AttGet.AttendanceRuleListSelect();
        //        this.dgvShiftList.Columns[0].Visible = false;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

        private void dgvShiftList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
