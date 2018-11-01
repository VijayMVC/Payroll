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
    class AttendanceRule_Controller
    {

        public double AttendanceRuleInsert(
                         double IDS
                       , DateTime PunchInRule
                       , DateTime BreakOutRule
                       , DateTime BreakInRule
                       , DateTime PunchOutRule
                       , DateTime OvertimeInRule
                       , DateTime OvertimeOutRule
                       , string ShiftName
                       , int DayOfTheWeek
                       , decimal LatePerMinutePenalty
                       )
        {
            SqlConnection conn = null;

            try
            {
                // create and open a connection object
                Variables var = new Variables();
                conn = new SqlConnection(var.ConString());
                conn.Open();

                // 1. create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("AttendanceRuleInsert", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@IDS", IDS));
                cmd.Parameters.Add(new SqlParameter("@PunchInRule", PunchInRule));
                cmd.Parameters.Add(new SqlParameter("@BreakOutRule", BreakOutRule));
                cmd.Parameters.Add(new SqlParameter("@BreakInRule", BreakInRule));
                cmd.Parameters.Add(new SqlParameter("@PunchOutRule", PunchOutRule));
                cmd.Parameters.Add(new SqlParameter("@OTInRule", OvertimeInRule));
                cmd.Parameters.Add(new SqlParameter("@OTOutRule", OvertimeOutRule));
                cmd.Parameters.Add(new SqlParameter("@ShiftName", ShiftName));
                cmd.Parameters.Add(new SqlParameter("@DayOfTheWeek", DayOfTheWeek));
                cmd.Parameters.Add(new SqlParameter("@LatePerMinutePenalty", LatePerMinutePenalty));
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

        public void AttendanceRuleUpdate(
                         double IDS
                       , DateTime PunchInRule
                       , DateTime BreakOutRule
                       , DateTime BreakInRule
                       , DateTime PunchOutRule
                       , DateTime OvertimeInRule
                       , DateTime OvertimeOutRule
                       , string ShiftName
                       , int DayOfTheWeek
                       , decimal LatePerMinutePenalty
                       )
        {
            SqlConnection conn = null;

            try
            {
                // create and open a connection object
                Variables var = new Variables();
                conn = new SqlConnection(var.ConString());
                conn.Open();

                // 1. create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("AttendanceRuleUpdate", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@IDS", IDS));
                cmd.Parameters.Add(new SqlParameter("@PunchInRule", PunchInRule));
                cmd.Parameters.Add(new SqlParameter("@BreakOutRule", BreakOutRule));
                cmd.Parameters.Add(new SqlParameter("@BreakInRule", BreakInRule));
                cmd.Parameters.Add(new SqlParameter("@PunchOutRule", PunchOutRule));
                cmd.Parameters.Add(new SqlParameter("@OTInRule", OvertimeInRule));
                cmd.Parameters.Add(new SqlParameter("@OTOutRule", OvertimeOutRule));
                cmd.Parameters.Add(new SqlParameter("@ShiftName", ShiftName));
                cmd.Parameters.Add(new SqlParameter("@DayOfTheWeek", DayOfTheWeek));
                cmd.Parameters.Add(new SqlParameter("@LatePerMinutePenalty", LatePerMinutePenalty));
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

        public DataTable AttendanceRuleSelectList()
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

                SqlCommand cmd = new SqlCommand("AttendanceRuleSelectList", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                  //   cmd.Parameters.Add(new SqlParameter("@IDS", IDS));


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


        public DataTable AttendanceRuleSelect(double IDS)
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

                SqlCommand cmd = new SqlCommand("AttendanceRuleSelect", conn);

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



        public DataTable ShiftNameSelect()
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

                SqlCommand cmd = new SqlCommand("AttendanceRuleCBOSelect", conn);

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



        public DataTable EmployeeSelectAllNoShift()
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

                SqlCommand cmd = new SqlCommand("EmployeeSelectAllNoShift", conn);

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


        public DataTable EmployeeSelectByShift(string ShiftName )
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

                SqlCommand cmd = new SqlCommand("EmployeeSelectByShift", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@ShiftName", ShiftName));

                // execute the command
                // cmd.ExecuteReader();
                adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                return dt;
            }
            catch
            {
              //  MessageBox.Show(ex.Message.ToString());
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


        public double UpdateEmployeeByShift(string ShiftName,double IDS )
        {
            SqlConnection conn = null;

            try
            {
                // create and open a connection object
                Variables var = new Variables();
                conn = new SqlConnection(var.ConString());
                conn.Open();

                // 1. create a command object identifying the stored procedure

                SqlCommand cmd = new SqlCommand("UpdateEmployeeShift", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@ShiftName", ShiftName));
                cmd.Parameters.Add(new SqlParameter("@EmployeeID", IDS));

                // execute the command
                // cmd.ExecuteReader();
                cmd.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return 1;
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();

                }

            }
        }

        public double RemoveEmployeeFromShift( double IDS)
        {
            SqlConnection conn = null;

            try
            {
                // create and open a connection object
                Variables var = new Variables();
                conn = new SqlConnection(var.ConString());
                conn.Open();

                // 1. create a command object identifying the stored procedure

                SqlCommand cmd = new SqlCommand("RemoveByEmployeeFromShift", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure

                cmd.Parameters.Add(new SqlParameter("@EmployeeID", IDS));

                // execute the command
                // cmd.ExecuteReader();
                cmd.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return 1;
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();

                }

            }
        }

        public double RemoveAllEmployeeFromShift(string ShiftName)
        {
            SqlConnection conn = null;

            try
            {
                // create and open a connection object
                Variables var = new Variables();
                conn = new SqlConnection(var.ConString());
                conn.Open();

                // 1. create a command object identifying the stored procedure

                SqlCommand cmd = new SqlCommand("RemoveAllEmployeeFromShift", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure

                cmd.Parameters.Add(new SqlParameter("@ShiftName", ShiftName));

                // execute the command
                // cmd.ExecuteReader();
                cmd.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return 1;
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
