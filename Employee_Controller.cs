using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll
{
    class Employee_Controller
    {
  
        public double EmployeeInsert(double IDS
                                  ,string lName
                                  ,string fName
                                  ,string mName
                                  ,string AddressHome
                                  ,string ContactNo
                                  ,DateTime DateOfBirth
                                  ,DateTime DateOfEmployment
                                  ,int Gender
                                  ,int CivilStatus
                                  ,string Position
                                  ,int Department
                                  ,int Unit
                                  ,decimal Salary
                                  , byte[] pic
                                  ,int Stat
                                  ,decimal SSSPrem
                                  ,decimal PHICPrem
                                  ,decimal PagIbigPrem
                                  ,decimal SSSLoan
                                  , decimal PagIbigLoan
                                , decimal Savings
                                , decimal OTRate
                             //    , string ShiftName
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
                SqlCommand cmd = new SqlCommand("EmployeeInsert", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@IDS", IDS));
                cmd.Parameters.Add(new SqlParameter("@lName", lName));
                cmd.Parameters.Add(new SqlParameter("@fName", fName));
                cmd.Parameters.Add(new SqlParameter("@mName", mName));
                cmd.Parameters.Add(new SqlParameter("@AddressHome", AddressHome));
                cmd.Parameters.Add(new SqlParameter("@ContactNo", ContactNo));
                cmd.Parameters.Add(new SqlParameter("@DateOfBirth", DateOfBirth));
                cmd.Parameters.Add(new SqlParameter("@DateOfEmployment", DateOfEmployment));
                cmd.Parameters.Add(new SqlParameter("@Gender", Gender));
                cmd.Parameters.Add(new SqlParameter("@CivilStatus", CivilStatus));
                cmd.Parameters.Add(new SqlParameter("@Position", Position));
                cmd.Parameters.Add(new SqlParameter("@Department", Department));
                cmd.Parameters.Add(new SqlParameter("@Salary", Salary));
                cmd.Parameters.Add(new SqlParameter("@Unit", Unit));
                cmd.Parameters.Add(new SqlParameter("@PersonImage", pic));
                cmd.Parameters.Add(new SqlParameter("@Stat", Stat));
                cmd.Parameters.Add(new SqlParameter("@SSSPrem", SSSPrem));
                cmd.Parameters.Add(new SqlParameter("@PHICPrem", PHICPrem));
                cmd.Parameters.Add(new SqlParameter("@PagIbigPrem", PagIbigPrem));
                cmd.Parameters.Add(new SqlParameter("@SSSLoan", SSSLoan));
                cmd.Parameters.Add(new SqlParameter("@PagIbigLoan", PagIbigLoan));
                cmd.Parameters.Add(new SqlParameter("@Savings", Savings));
                cmd.Parameters.Add(new SqlParameter("@OTRate", OTRate));
               // cmd.Parameters.Add(new SqlParameter("@ShiftName", ShiftName ));   
   
              //  cmd.Parameters.Add(new SqlParameter("@PersonImage", null));

                //Add the output parameter to the command object
                SqlParameter outPutParameter = new SqlParameter();
                outPutParameter.ParameterName = "@IDSOut";
                outPutParameter.SqlDbType = System.Data.SqlDbType.BigInt;
                outPutParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outPutParameter);
                // execute the command
                //cmd.ExecuteReader();
                cmd.ExecuteNonQuery();

              return  Convert.ToDouble(outPutParameter.Value) ;
        
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


 public double EmployeeTemplateInsert(double IDS
                           , int UserID
                           , int  FingerID
                           , int Template
                           , int TmpLen
                            ,int Flag

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
                SqlCommand cmd = new SqlCommand("EmployeeTemplateInsert", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add      IDS Int IDENTITY(1,1)  NOT NULL PRIMARY KEY,

                cmd.Parameters.Add(new SqlParameter("@UserID", UserID));
                cmd.Parameters.Add(new SqlParameter("@FingerID", FingerID));
                cmd.Parameters.Add(new SqlParameter("@Template", Template));
                cmd.Parameters.Add(new SqlParameter("@TmpLen", TmpLen));
                cmd.Parameters.Add(new SqlParameter("@Flag", Flag));

                //  cmd.Parameters.Add(new SqlParameter("@PersonImage", null));

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


 public void EmployeeTemplateUpdate(double IDS
                           , int UserID
                           , int FingerID
                           , byte[] Template
                           , int TmpLen
                            , int Flag
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
         SqlCommand cmd = new SqlCommand("EmployeeTemplateUpdate", conn);

         // 2. set the command object so it knows to execute a stored procedure
         cmd.CommandType = CommandType.StoredProcedure;

         // 3. add parameter to command, which will be passed to the stored procedure
         cmd.Parameters.Add(new SqlParameter("@UserID", UserID));
         cmd.Parameters.Add(new SqlParameter("@FingerID", FingerID));
         cmd.Parameters.Add(new SqlParameter("@Template", Template));
         cmd.Parameters.Add(new SqlParameter("@TmpLen", TmpLen));
         cmd.Parameters.Add(new SqlParameter("@Flag", Flag));


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


        public void  EmployeeUpdate(double IDS
                                  , string lName
                                  , string fName
                                  , string mName
                                  , string AddressHome
                                  , string ContactNo
                                  , DateTime DateOfBirth
                                  , DateTime DateOfEmployment
                                  , int Gender
                                  , int CivilStatus
                                  , string Position
                                  , int Department
                                  , int Unit
                                  , decimal Salary
                                  , byte[] pic
                                  , int Stat
                                  ,decimal SSSPrem
                                  ,decimal PHICPrem
                                  ,decimal PagIbigPrem
                                  ,decimal SSSLoan
                                  , decimal PagIbigLoan
                                  , decimal Savings
                                  , decimal OTRate
                                //  , string ShiftName
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
                SqlCommand cmd = new SqlCommand("EmployeeUpdate", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@IDS", IDS));
                cmd.Parameters.Add(new SqlParameter("@lName", lName));
                cmd.Parameters.Add(new SqlParameter("@fName", fName));
                cmd.Parameters.Add(new SqlParameter("@mName", mName));
                cmd.Parameters.Add(new SqlParameter("@AddressHome", AddressHome));
                cmd.Parameters.Add(new SqlParameter("@ContactNo", ContactNo));
                cmd.Parameters.Add(new SqlParameter("@DateOfBirth", DateOfBirth));
                cmd.Parameters.Add(new SqlParameter("@DateOfEmployment", DateOfEmployment));
                cmd.Parameters.Add(new SqlParameter("@Gender", Gender));
                cmd.Parameters.Add(new SqlParameter("@CivilStatus", CivilStatus));
                cmd.Parameters.Add(new SqlParameter("@Position", Position));
                cmd.Parameters.Add(new SqlParameter("@Department", Department));
                cmd.Parameters.Add(new SqlParameter("@Salary", Salary));
                cmd.Parameters.Add(new SqlParameter("@Unit", Unit));
                cmd.Parameters.Add(new SqlParameter("@PersonImage", pic));
                cmd.Parameters.Add(new SqlParameter("@Stat", Stat));
                cmd.Parameters.Add(new SqlParameter("@SSSPrem", SSSPrem));
                cmd.Parameters.Add(new SqlParameter("@PHICPrem", PHICPrem));
                cmd.Parameters.Add(new SqlParameter("@PagIbigPrem", PagIbigPrem));
                cmd.Parameters.Add(new SqlParameter("@SSSLoan", SSSLoan));
                cmd.Parameters.Add(new SqlParameter("@PagIbigLoan", PagIbigLoan));
                cmd.Parameters.Add(new SqlParameter("@Savings", Savings));
                cmd.Parameters.Add(new SqlParameter("@OTRate", OTRate));
             //   cmd.Parameters.Add(new SqlParameter("@ShiftName", ShiftName));   
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
 
        public DataTable EmployeeSelect(double  IDS)
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
               
                SqlCommand cmd = new SqlCommand("EmployeeSelect", conn);

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



        public DataTable EmployeeSelectAll()
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

                SqlCommand cmd = new SqlCommand("EmployeeSelectAll", conn);

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

        public DataTable EmployeeSelectAllCbo()
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

                SqlCommand cmd = new SqlCommand("EmployeeSelectAllCbo", conn);

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
