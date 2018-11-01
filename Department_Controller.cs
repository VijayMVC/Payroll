using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Payroll
{
    class Department_Controller
    {

        public double DepartmentInsert(double IDS
                          , string Department)
        {
            SqlConnection conn = null;

            try
            {
                // create and open a connection object
                Variables var = new Variables();
                conn = new SqlConnection(var.ConString());
                conn.Open();

                // 1. create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("DepartmentInsert", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@IDS", IDS));
                cmd.Parameters.Add(new SqlParameter("@Department", Department));
   

                //Add the output parameter to the command object
                SqlParameter outPutParameter = new SqlParameter();
                outPutParameter.ParameterName = "@IDSOut";
                outPutParameter.SqlDbType = System.Data.SqlDbType.BigInt;
                outPutParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outPutParameter);
                // execute the command
                //cmd.ExecuteReader();
                cmd.ExecuteNonQuery();

                return Convert.ToDouble(outPutParameter.Value);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return 0;
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public void DepartmentUpdate(double IDS
                                  , string Department)
        {
            SqlConnection conn = null;

            try
            {
                // create and open a connection object
                Variables var = new Variables();
                conn = new SqlConnection(var.ConString());
                conn.Open();

                // 1. create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("DepartmentUpdate", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@IDS", IDS));
                cmd.Parameters.Add(new SqlParameter("@Department", Department));


                //  cmd.Parameters.Add(new SqlParameter("@PersonImage", null));
                // execute the command
                //cmd.ExecuteReader();
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public DataTable DepartmentSelect(double IDS)
        {
            SqlConnection conn = null;
            SqlDataAdapter adpt = null;

            try
            {
                // create and open a connection object
                Variables var = new Variables();
                conn = new SqlConnection(var.ConString());
                conn.Open();

                // 1. create a command object identifying the stored procedure

                SqlCommand cmd = new SqlCommand("DepartmentSelect", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@IDS", IDS));

                // execute the command
                // cmd.ExecuteReader();
                adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return null;
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();

                }

            }
        }

        public DataTable DepartmentSelectAll()
        {
            SqlConnection conn = null;
            SqlDataAdapter adpt = null;

            try
            {
                // create and open a connection object
                Variables var = new Variables();
                conn = new SqlConnection(var.ConString());
                conn.Open();

                // 1. create a command object identifying the stored procedure

                SqlCommand cmd = new SqlCommand("DepartmentSelectAll", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                //cmd.Parameters.Add(new SqlParameter("@IDS", IDS));

                // execute the command
                // cmd.ExecuteReader();
                adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return null;
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();

                }

            }
        }

    }
}
