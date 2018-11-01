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
    class Payroll_Controller
    {

         public double PayrollInsert(
                          double IDS
                         ,DateTime PayrollDate
		                 ,DateTime DateFrom 
		                 ,DateTime DateTo 
		                 ,double  Department 
		                 ,string Remarks 
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
                SqlCommand cmd = new SqlCommand("PayrollInsert", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@IDS", IDS));
                cmd.Parameters.Add(new SqlParameter("@PayrollDate", PayrollDate));
                cmd.Parameters.Add(new SqlParameter("@DateFrom", DateFrom));
                cmd.Parameters.Add(new SqlParameter("@DateTo", DateTo));
                cmd.Parameters.Add(new SqlParameter("@Department", Department));
                cmd.Parameters.Add(new SqlParameter("@Remarks", Remarks));

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
        public void PayrollUpdate(double IDS
                         , DateTime PayrollDate
                         , DateTime DateFrom
                         , DateTime DateTo
                         , double Department
                         , string Remarks)
        {
            SqlConnection conn = null;

            try
            {
                // create and open a connection object
                Variables var = new Variables();
                conn = new SqlConnection(var.ConString());
                conn.Open();

                // 1. create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("PayrollUpdate", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@IDS", IDS));
                cmd.Parameters.Add(new SqlParameter("@PayrollDate", PayrollDate));
                cmd.Parameters.Add(new SqlParameter("@DateFrom", DateFrom));
                cmd.Parameters.Add(new SqlParameter("@DateTo", DateTo));
                cmd.Parameters.Add(new SqlParameter("@Department", Department));
                cmd.Parameters.Add(new SqlParameter("@Remarks", Remarks));

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

        public DataTable PayrollSelect(double IDS)
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

                SqlCommand cmd = new SqlCommand("PayrollSelect", conn);

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

        public DataTable PayrollList()
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

                SqlCommand cmd = new SqlCommand("PayrollList", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
               // cmd.Parameters.Add(new SqlParameter("@IDS", IDS));

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


        public double PayrollEmployeeInsert(double IDS
                                    , double  EmployeeIDS
                                    , double PayrollIDS
                                    , double Department
                                    , decimal NoOfDays
                                    , decimal SalaryRate
                                    , decimal OTHours
                                    , decimal OTRate
                                    , decimal Incentives
                                    , decimal SSSPrem
                                    , decimal PHICPrem
                                    , decimal PagIbigPrem
                                    , decimal SSSLoan
                                    , decimal PagIbigLoan
                                    , decimal CashAdvance
                                    , decimal Savings
                                    , decimal OtherDeduction
                                    , decimal LateEO
                                    , decimal LateEORate

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
                SqlCommand cmd = new SqlCommand("PayrollEmployeeInsert", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                   cmd.Parameters.Add(new SqlParameter("@IDS", IDS));
                   cmd.Parameters.Add(new SqlParameter("@EmployeeIDS", EmployeeIDS));
                   cmd.Parameters.Add(new SqlParameter("@PayrollIDS", PayrollIDS));
                   cmd.Parameters.Add(new SqlParameter("@Department", Department));
                   cmd.Parameters.Add(new SqlParameter("@NoOfDays", NoOfDays));
                   cmd.Parameters.Add(new SqlParameter("@SalaryRate", SalaryRate));
                   cmd.Parameters.Add(new SqlParameter("@OTHours", OTHours));
                   cmd.Parameters.Add(new SqlParameter("@OTRate", OTRate));
                   cmd.Parameters.Add(new SqlParameter("@Incentives", Incentives));
                   cmd.Parameters.Add(new SqlParameter("@SSSPrem", SSSPrem));
                   cmd.Parameters.Add(new SqlParameter("@PHICPrem", PHICPrem));
                   cmd.Parameters.Add(new SqlParameter("@PagIbigPrem", PagIbigPrem));
                   cmd.Parameters.Add(new SqlParameter("@SSSLoan", SSSLoan));
                   cmd.Parameters.Add(new SqlParameter("@PagIbigLoan", PagIbigLoan));
                   cmd.Parameters.Add(new SqlParameter("@CashAdvance", CashAdvance));
                   cmd.Parameters.Add(new SqlParameter("@Savings", Savings));
                   cmd.Parameters.Add(new SqlParameter("@OtherDeduction", OtherDeduction));
                   cmd.Parameters.Add(new SqlParameter("@LateEO", LateEO));
                   cmd.Parameters.Add(new SqlParameter("@LateEORate", LateEORate));

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


        public void PayrollEmployeeUpdate(double IDS
                                    , double EmployeeIDS
                                    , double PayrollIDS
                                    , double Department
                                    , decimal NoOfDays
                                    , decimal SalaryRate
                                    , decimal OTHours
                                    , decimal OTRate
                                    , decimal Incentives
                                    , decimal SSSPrem
                                    , decimal PHICPrem
                                    , decimal PagIbigPrem
                                    , decimal SSSLoan
                                    , decimal PagIbigLoan
                                    , decimal CashAdvance
                                    , decimal Savings
                                    , decimal OtherDeduction
                                    , decimal LateEO
                                    , decimal LateEORate

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
                SqlCommand cmd = new SqlCommand("PayrollEmployeeUpdate", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@IDS", IDS));
                cmd.Parameters.Add(new SqlParameter("@EmployeeIDS", EmployeeIDS));
                cmd.Parameters.Add(new SqlParameter("@PayrollIDS", PayrollIDS));
                cmd.Parameters.Add(new SqlParameter("@Department", Department));
                cmd.Parameters.Add(new SqlParameter("@NoOfDays", NoOfDays));
                cmd.Parameters.Add(new SqlParameter("@SalaryRate", SalaryRate));
                cmd.Parameters.Add(new SqlParameter("@OTHours", OTHours));
                cmd.Parameters.Add(new SqlParameter("@OTRate", OTRate));
                cmd.Parameters.Add(new SqlParameter("@Incentives", Incentives));
                cmd.Parameters.Add(new SqlParameter("@SSSPrem", SSSPrem));
                cmd.Parameters.Add(new SqlParameter("@PHICPrem", PHICPrem));
                cmd.Parameters.Add(new SqlParameter("@PagIbigPrem", PagIbigPrem));
                cmd.Parameters.Add(new SqlParameter("@SSSLoan", SSSLoan));
                cmd.Parameters.Add(new SqlParameter("@PagIbigLoan", PagIbigLoan));
                cmd.Parameters.Add(new SqlParameter("@CashAdvance", CashAdvance));
                cmd.Parameters.Add(new SqlParameter("@Savings", Savings));
                cmd.Parameters.Add(new SqlParameter("@OtherDeduction", OtherDeduction));
                cmd.Parameters.Add(new SqlParameter("@LateEO", LateEO));
                cmd.Parameters.Add(new SqlParameter("@LateEORate", LateEORate));

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



        public void PayrollEmployeeDelete(double IDS)
        {
            SqlConnection conn = null;

            try
            {
                // create and open a connection object
                Variables var = new Variables();
                conn = new SqlConnection(var.ConString());
                conn.Open();

                // 1. create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("PayrollEmployeeDelete", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@IDS", IDS));

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





        public DataTable PayrollEmployeeSelect(double IDS)
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

                SqlCommand cmd = new SqlCommand("PayrollEmployeeSelect", conn);

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


        public DataTable PayrollSelectInitial(DateTime DateFrom, DateTime DateTo, double Department, int SSSPrem, int PHICPrem, int PagIbigPrem, int SSSLoan, int PagIbigLoan, int Savings)
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

                SqlCommand cmd = new SqlCommand("GetInitialPayroll", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@DateFrom", DateFrom));
                cmd.Parameters.Add(new SqlParameter("@DateTo", DateTo));
                cmd.Parameters.Add(new SqlParameter("@Department", Department ));

                //int SSSPrem, int PHICPrem, int PagIbigPrem, int SSSLoan, int PagIbigLoan, int Savings
                cmd.Parameters.Add(new SqlParameter("@SSSPrem", SSSPrem));
                cmd.Parameters.Add(new SqlParameter("@PHICPrem", PHICPrem));
                cmd.Parameters.Add(new SqlParameter("@PagIbigPrem", PagIbigPrem));
                cmd.Parameters.Add(new SqlParameter("@SSSLoan", SSSLoan));
                cmd.Parameters.Add(new SqlParameter("@PagIbigLoan", PagIbigLoan));
                cmd.Parameters.Add(new SqlParameter("@Savings", Savings));

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



        public DataTable PayrollSelectEmployee(double IDS,DateTime DateFrom, DateTime DateTo, double Department)
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

                SqlCommand cmd = new SqlCommand("PayrollSelectEmployee", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@DateFrom", DateFrom));
                cmd.Parameters.Add(new SqlParameter("@DateTo", DateTo));
                cmd.Parameters.Add(new SqlParameter("@Department", Department));
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






    }
}
