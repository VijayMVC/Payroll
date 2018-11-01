using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new mdiPayroll2());
            Application.Run(new Login());
        }
    }

    class Variables
    {


        //    public static string ConStringOleDB = "Provider=SQLOLEDB.1;Password=" + Password + ";Persist Security Info=True;User ID=" + UserName + ";Initial Catalog=" + DBName + ";Data Source= " + ServerName;


        //string _ServerName ;
        //string _UserName;
        //string _Password;
        //string _DBName;

        //public String ServerName
        //{
        //    get { return this._ServerName;  }
        //    set { this._ServerName = value; }
        //}


        //public String UserName
        //{
        //    get { return this._UserName; }
        //    set { this._UserName = value; }
        //}


        //public String Password
        //{
        //    get { return this._Password; }
        //    set { this._Password = value; }
        //}


        //public String DBName
        //{
        //    get { return this._DBName; }
        //    set { this._DBName = value; }
        //}

        public static string ServerName;
        public static string UserName;
        public static string Password;
        public static string DBName;

        public string ConString()
        {
            string strCon;
            strCon = "Data Source=" + ServerName + ";Initial Catalog=" + DBName + ";Persist Security Info=True;User ID=" + UserName + ";Password=" + Password + ";MultipleActiveResultSets=True";
            return strCon;
        }


        public string ConStringOleDB()
        {
            string strCon;

            strCon = "Provider=SQLOLEDB.1;Password=" + Password + ";Persist Security Info=True;User ID=" + UserName + ";Initial Catalog=" + DBName + ";Data Source= " + ServerName;
            return strCon;
        }


        //public string EntityConnectionString()
        //{

        //    // Initialize the connection string builder for the
        //    // underlying provider.
        //    SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();

        //    // Set the properties for the data source.
        //    sqlBuilder.DataSource = ServerName;
        //    sqlBuilder.IntegratedSecurity = false;
        //    sqlBuilder.UserID = UserName;
        //    sqlBuilder.Password = Password;
        //    sqlBuilder.InitialCatalog = DBName;
        //    sqlBuilder.MultipleActiveResultSets = true;

        //    // Initialize the EntityConnectionStringBuilder.
        //    EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();

        //    //Set the provider name.
        //    entityBuilder.Provider = "System.Data.SqlClient";

        //    // Set the provider-specific connection string.
        //    entityBuilder.ProviderConnectionString = sqlBuilder.ToString();

        //    // Set the Metadata location.
        //    entityBuilder.Metadata = @"res://*/Barangay.csdl|res://*/Barangay.ssdl|res://*/Barangay.msl";

        //    // entityBuilder.Metadata = @"res://*/DatabaseModel.csdl|res://*/DatabaseModel.ssdl|res://*/DatabaseModel.msl";

        //    return entityBuilder.ToString();

        //}




    }

}
