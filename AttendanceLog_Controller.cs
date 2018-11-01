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
    class AttendanceLog_Controller
    {

        public double AttendanceInsertUpdate( double IDS
                                   , double EmployeeIDS
                                   , string MachineNumber
                                   , DateTime AttendanceDate
                                   , int idwInOutMode
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
                SqlCommand cmd = new SqlCommand("AttendanceLogInsertUpdate", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
              //  cmd.Parameters.Add(new SqlParameter("@IDS", IDS));
                cmd.Parameters.Add(new SqlParameter("@EmployeeIDS", EmployeeIDS));
                cmd.Parameters.Add(new SqlParameter("@MachineNumber", MachineNumber));
                cmd.Parameters.Add(new SqlParameter("@AttendanceDate", AttendanceDate));
                cmd.Parameters.Add(new SqlParameter("@idwInOutMode", idwInOutMode));

                //  cmd.Parameters.Add(new SqlParameter("@PersonImage", null;


                //Add the output parameter to the command object
                //SqlParameter outPutParameter = new SqlParameter();
                //outPutParameter.ParameterName = "@IDSOut";
                //outPutParameter.SqlDbType = System.Data.SqlDbType.BigInt;
                //outPutParameter.Direction = System.Data.ParameterDirection.Output;
                //cmd.Parameters.Add(outPutParameter);
                // execute the command
                //cmd.ExecuteReader();
                cmd.ExecuteNonQuery();

               // return Convert.ToDouble(outPutParameter.Value);
                return 0;

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

        public DataTable AttendanceSelect(double EmployeeIDS,DateTime DateFrom,DateTime DateTo)
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

                SqlCommand cmd = new SqlCommand("AttendanceLogSelect", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@EmployeeIDS", EmployeeIDS));
                cmd.Parameters.Add(new SqlParameter("@DateFrom", DateFrom));
                cmd.Parameters.Add(new SqlParameter("@DateTo", DateTo));
                // execute the command
                // cmd.ExecuteReader();
                adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                return dt;
            }
            catch
            {
               // LogException(ex);
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

        public DataTable AttendanceSelectAll()
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

                SqlCommand cmd = new SqlCommand("AttendanceLogSelectAll", conn);

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
            catch {
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

        public double AttendanceRuleInsert(
                                 double IDS
                               , DateTime PunchInRule
                               , DateTime BreakOutRule
                               , DateTime BreakInRule
                               , DateTime PunchOutRule
                               , DateTime OvertimeInRule
                               , DateTime OvertimeOutRule
                               , decimal  LatePerMinutePenalty
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
           //     cmd.Parameters.Add(new SqlParameter("@IDS", IDS));

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


      


        public double AttendanceInsert(
                         double EmployeeIDS
                        ,DateTime AttDate
                       , DateTime PunchIn
                       , DateTime BreakOut
                       , DateTime BreakIn
                       , DateTime PunchOut
                       , DateTime OvertimeIn
                       , DateTime OvertimeOut
                       , int PI
                       , int BO
                       , int BI
                       , int PO
                       , int OI
                       , int OO
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
                SqlCommand cmd = new SqlCommand("AttendanceInsert", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@EmployeeIDS", EmployeeIDS));
                cmd.Parameters.Add(new SqlParameter("@AttDate", AttDate));
                cmd.Parameters.Add(new SqlParameter("@PunchIn", PunchIn));
                cmd.Parameters.Add(new SqlParameter("@BreakOut", BreakOut));
                cmd.Parameters.Add(new SqlParameter("@BreakIn", BreakIn));
                cmd.Parameters.Add(new SqlParameter("@PunchOut", PunchOut));
                cmd.Parameters.Add(new SqlParameter("@OTIn", OvertimeIn));
                cmd.Parameters.Add(new SqlParameter("@OTOut", OvertimeOut));
                cmd.Parameters.Add(new SqlParameter("@PI", PI));
                cmd.Parameters.Add(new SqlParameter("@BO", BO));
                cmd.Parameters.Add(new SqlParameter("@BI", BI));
                cmd.Parameters.Add(new SqlParameter("@PO", PO));
                cmd.Parameters.Add(new SqlParameter("@OI", OI));
                cmd.Parameters.Add(new SqlParameter("@OO", OO));


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



        public void AttendanceUpdate(
                         double IDS
                        , DateTime AttDate
                       , DateTime PunchIn
                       , DateTime BreakOut
                       , DateTime BreakIn
                       , DateTime PunchOut
                       , DateTime OvertimeIn
                       , DateTime OvertimeOut
                       , int PI
                       , int BO
                       , int BI
                       , int PO
                       , int OI
                       , int OO
 
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
                SqlCommand cmd = new SqlCommand("AttendanceUpdate", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@IDS", IDS));
                cmd.Parameters.Add(new SqlParameter("@AttDate", AttDate));
                cmd.Parameters.Add(new SqlParameter("@PunchIn", PunchIn));
                cmd.Parameters.Add(new SqlParameter("@BreakOut", BreakOut));
                cmd.Parameters.Add(new SqlParameter("@BreakIn", BreakIn));
                cmd.Parameters.Add(new SqlParameter("@PunchOut", PunchOut));
                cmd.Parameters.Add(new SqlParameter("@OTIn", OvertimeIn));
                cmd.Parameters.Add(new SqlParameter("@OTOut", OvertimeOut));
                cmd.Parameters.Add(new SqlParameter("@PI", PI));
                cmd.Parameters.Add(new SqlParameter("@BO", BO));
                cmd.Parameters.Add(new SqlParameter("@BI", BI));
                cmd.Parameters.Add(new SqlParameter("@PO", PO));
                cmd.Parameters.Add(new SqlParameter("@OI", OI));
                cmd.Parameters.Add(new SqlParameter("@OO", OO));

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

        public DataTable AttendanceEditSelect(double IDS)
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

                SqlCommand cmd = new SqlCommand("AttendanceEditSelect", conn);

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

        public DataTable EmployeeGetWorkedDays(double EmployeeIDS,DateTime DateFrom,DateTime DateTo)
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

                SqlCommand cmd = new SqlCommand("EmployeeGetWorkedDays", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@EmployeeIDS", EmployeeIDS));
                cmd.Parameters.Add(new SqlParameter("@DateFrom", DateFrom));
                cmd.Parameters.Add(new SqlParameter("@DateTo", DateTo));
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


        public DataTable EmployeeGetOTHours(double EmployeeIDS, DateTime DateFrom, DateTime DateTo)
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

                SqlCommand cmd = new SqlCommand("EmployeeGetWorkedDays", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@EmployeeIDS", EmployeeIDS));
                cmd.Parameters.Add(new SqlParameter("@DateFrom", DateFrom));
                cmd.Parameters.Add(new SqlParameter("@DateTo", DateTo));
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


        public DataTable MyAttendanceRuleSelect(double EmployeeIDS)
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

                SqlCommand cmd = new SqlCommand("MyAttendanceRuleList", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@EmployeeIDS", EmployeeIDS));

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




        public DataTable MyAttendanceRuleChange(double EmployeeIDS, DateTime DateFrom, DateTime DateTo)
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

                SqlCommand cmd = new SqlCommand("MyAttendanceRuleChange", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@EmployeeIDS", EmployeeIDS));
                cmd.Parameters.Add(new SqlParameter("@DateFrom", DateFrom));
                cmd.Parameters.Add(new SqlParameter("@DateTo", DateTo));
                // execute the command
                // cmd.ExecuteReader();
                adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                return dt;
            }
            catch 
            {
                // LogException(ex);
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



        public DataTable AttendanceShiftEditSelect(double IDS)
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

                SqlCommand cmd = new SqlCommand("AttendanceShiftEditSelect", conn);

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




        public void AttendanceShiftUpdate(
                      double IDS
                     , DateTime AttDate
                    , DateTime PunchIn
                    , DateTime BreakOut
                    , DateTime BreakIn
                    , DateTime PunchOut
                    , DateTime OvertimeIn
                    , DateTime OvertimeOut
                    , int PI
                    , int BO
                    , int BI
                    , int PO
                    , int OI
                    , int OO

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
                SqlCommand cmd = new SqlCommand("AttendanceShiftUpdate", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@IDS", IDS));
                cmd.Parameters.Add(new SqlParameter("@AttDate", AttDate));
                cmd.Parameters.Add(new SqlParameter("@PunchIn", PunchIn));
                cmd.Parameters.Add(new SqlParameter("@BreakOut", BreakOut));
                cmd.Parameters.Add(new SqlParameter("@BreakIn", BreakIn));
                cmd.Parameters.Add(new SqlParameter("@PunchOut", PunchOut));
                cmd.Parameters.Add(new SqlParameter("@OTIn", OvertimeIn));
                cmd.Parameters.Add(new SqlParameter("@OTOut", OvertimeOut));
                cmd.Parameters.Add(new SqlParameter("@PI", PI));
                cmd.Parameters.Add(new SqlParameter("@BO", BO));
                cmd.Parameters.Add(new SqlParameter("@BI", BI));
                cmd.Parameters.Add(new SqlParameter("@PO", PO));
                cmd.Parameters.Add(new SqlParameter("@OI", OI));
                cmd.Parameters.Add(new SqlParameter("@OO", OO));

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



    }
}
