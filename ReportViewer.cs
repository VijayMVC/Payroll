using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Reflection;
using System.IO;

namespace Payroll
{
    public partial class ReportViewer : Form
    {
        public ReportViewer()
        {
            InitializeComponent();
        }


        public void PayrollPrint(decimal IDS)
        {
            //Instantiate variables
            string exePath = Application.StartupPath;
            exePath = exePath + "\\Report\\PayrollRpt.rpt";

            ReportDocument reportDocument = new ReportDocument();
            ParameterField paramField = new ParameterField();
            ParameterFields paramFields = new ParameterFields();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            //Set instances for input parameter 1 -  @vDepartment
            paramField.Name = "@IDS";
            //Below variable can be set to any data 
            //present in SalseData table, Department column
            paramDiscreteValue.Value = IDS;
            paramField.CurrentValues.Add(paramDiscreteValue);
            //Add the paramField to paramFields
            paramFields.Add(paramField);


            crystalReportViewer1.ParameterFieldInfo = paramFields;

            reportDocument.Load(@exePath);

            //set the database loggon information. 
            //**Note that the third parameter is the DSN name 
            //  and not the Database or System name
            //  reportDocument.SetDatabaseLogon("pchitriv", "Windows2000",
            //                             "TestDB_DSN", "testDB", false);

            // reportDocument.SetDatabaseLogon(Variables.UserName, Variables.Password, Variables.ServerName, Variables.DBName, false);

            foreach (CrystalDecisions.Shared.IConnectionInfo connection in reportDocument.DataSourceConnections)
            {
                connection.IntegratedSecurity = true;
                for (int i = 0; i < reportDocument.DataSourceConnections.Count; i++)
                {
                    // reportDocument.DataSourceConnections[i].SetConnection("server8\\sql", "Barangay", "sa", "cadechloe2318");
                    reportDocument.DataSourceConnections[i].SetConnection(Variables.ServerName, Variables.DBName, Variables.UserName, Variables.Password);
                }
            }

            //Load the report by setting the report source


            crystalReportViewer1.ReportSource = reportDocument;
            crystalReportViewer1.PrintReport();

        }

        //public void ClearanceIndividualPrint(decimal IDS,bool Preview)
        //{
        //   string exePath=Application.StartupPath;
        //    exePath=exePath + "\\Reports\\ClearanceRpt.rpt";
        //    //Instantiate variables
        //    ReportDocument reportDocument = new ReportDocument();
        //    ParameterField paramField = new ParameterField();
        //    ParameterFields paramFields = new ParameterFields();
        //    ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

        //    //Set instances for input parameter 1 -  @vDepartment
        //    paramField.Name = "@IDS";
        //    //Below variable can be set to any data 
        //    //present in SalseData table, Department column
        //    paramDiscreteValue.Value = IDS;
        //    paramField.CurrentValues.Add(paramDiscreteValue);
        //    //Add the paramField to paramFields
        //    paramFields.Add(paramField);


        //    crystalReportViewer1.ParameterFieldInfo = paramFields;
            

        //    reportDocument.Load(@exePath);

        //    //set the database loggon information. 
        //    //**Note that the third parameter is the DSN name 
        //    //  and not the Database or System name
        //    //  reportDocument.SetDatabaseLogon("pchitriv", "Windows2000",
        //    //                             "TestDB_DSN", "testDB", false);

        //    // reportDocument.SetDatabaseLogon(Variables.UserName, Variables.Password, Variables.ServerName, Variables.DBName, false);

        //    foreach (CrystalDecisions.Shared.IConnectionInfo connection in reportDocument.DataSourceConnections)
        //    {
        //        connection.IntegratedSecurity = false;
        //        for (int i = 0; i < reportDocument.DataSourceConnections.Count; i++)
        //        {
        //            reportDocument.DataSourceConnections[i].SetConnection(Variables.ServerName, Variables.DBName, Variables.UserName, Variables.Password);
        //        }
        //    }

  
        //    //Load the report by setting the report source

        //    //Load the report by setting the report source
        //    if (Preview == true)
        //    {
        //        crystalReportViewer1.ReportSource = reportDocument;
        //    }
        //    else
        //    {
        //        crystalReportViewer1.ReportSource = reportDocument;
        //        crystalReportViewer1.PrintReport();
        //    }

        //}

        //public void CertificationPrint(decimal IDS, bool Preview)
        //{
        //    string exePath = Application.StartupPath;
        //    exePath = exePath + "\\Reports\\Certification.rpt";
        //    //Instantiate variables
        //    ReportDocument reportDocument = new ReportDocument();
        //    ParameterField paramField = new ParameterField();
        //    ParameterFields paramFields = new ParameterFields();
        //    ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

        //    //Set instances for input parameter 1 -  @vDepartment
        //    paramField.Name = "@IDS";
        //    //Below variable can be set to any data 
        //    //present in SalseData table, Department column
        //    paramDiscreteValue.Value = IDS;
        //    paramField.CurrentValues.Add(paramDiscreteValue);
        //    //Add the paramField to paramFields
        //    paramFields.Add(paramField);


        //    crystalReportViewer1.ParameterFieldInfo = paramFields;


        //    reportDocument.Load(@exePath);

        //    //set the database loggon information. 
        //    //**Note that the third parameter is the DSN name 
        //    //  and not the Database or System name
        //    //  reportDocument.SetDatabaseLogon("pchitriv", "Windows2000",
        //    //                             "TestDB_DSN", "testDB", false);

        //    // reportDocument.SetDatabaseLogon(Variables.UserName, Variables.Password, Variables.ServerName, Variables.DBName, false);

        //    foreach (CrystalDecisions.Shared.IConnectionInfo connection in reportDocument.DataSourceConnections)
        //    {
        //        connection.IntegratedSecurity = false;
        //        for (int i = 0; i < reportDocument.DataSourceConnections.Count; i++)
        //        {
        //            reportDocument.DataSourceConnections[i].SetConnection(Variables.ServerName, Variables.DBName, Variables.UserName, Variables.Password);
        //        }
        //    }


        //    //Load the report by setting the report source

        //    //Load the report by setting the report source
        //    if (Preview == true)
        //    {
        //        crystalReportViewer1.ReportSource = reportDocument;
        //    }
        //    else
        //    {
        //        crystalReportViewer1.ReportSource = reportDocument;
        //        crystalReportViewer1.PrintReport();
        //    }

        //}


        //public void CertificationIndigentPrint(decimal IDS, bool Preview)
        //{
        //    string exePath = Application.StartupPath;
        //    exePath = exePath + "\\Reports\\CertificationIndigent.rpt";
        //    //Instantiate variables
        //    ReportDocument reportDocument = new ReportDocument();
        //    ParameterField paramField = new ParameterField();
        //    ParameterFields paramFields = new ParameterFields();
        //    ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

        //    //Set instances for input parameter 1 -  @vDepartment
        //    paramField.Name = "@IDS";
        //    //Below variable can be set to any data 
        //    //present in SalseData table, Department column
        //    paramDiscreteValue.Value = IDS;
        //    paramField.CurrentValues.Add(paramDiscreteValue);
        //    //Add the paramField to paramFields
        //    paramFields.Add(paramField);


        //    crystalReportViewer1.ParameterFieldInfo = paramFields;


        //    reportDocument.Load(@exePath);

        //    //set the database loggon information. 
        //    //**Note that the third parameter is the DSN name 
        //    //  and not the Database or System name
        //    //  reportDocument.SetDatabaseLogon("pchitriv", "Windows2000",
        //    //                             "TestDB_DSN", "testDB", false);

        //    // reportDocument.SetDatabaseLogon(Variables.UserName, Variables.Password, Variables.ServerName, Variables.DBName, false);

        //    foreach (CrystalDecisions.Shared.IConnectionInfo connection in reportDocument.DataSourceConnections)
        //    {
        //        connection.IntegratedSecurity = false;
        //        for (int i = 0; i < reportDocument.DataSourceConnections.Count; i++)
        //        {
        //            reportDocument.DataSourceConnections[i].SetConnection(Variables.ServerName, Variables.DBName, Variables.UserName, Variables.Password);
        //        }
        //    }


        //    //Load the report by setting the report source

        //    //Load the report by setting the report source
        //    if (Preview == true)
        //    {
        //        crystalReportViewer1.ReportSource = reportDocument;
        //    }
        //    else
        //    {
        //        crystalReportViewer1.ReportSource = reportDocument;
        //        crystalReportViewer1.PrintReport();
        //    }

        //}

        //public void CertificationNoRCPrint(decimal IDS, bool Preview)
        //{
        //    string exePath = Application.StartupPath;
        //    exePath = exePath + "\\Reports\\CertificationNoRC.rpt";
        //    //Instantiate variables
        //    ReportDocument reportDocument = new ReportDocument();
        //    ParameterField paramField = new ParameterField();
        //    ParameterFields paramFields = new ParameterFields();
        //    ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

        //    //Set instances for input parameter 1 -  @vDepartment
        //    paramField.Name = "@IDS";
        //    //Below variable can be set to any data 
        //    //present in SalseData table, Department column
        //    paramDiscreteValue.Value = IDS;
        //    paramField.CurrentValues.Add(paramDiscreteValue);
        //    //Add the paramField to paramFields
        //    paramFields.Add(paramField);


        //    crystalReportViewer1.ParameterFieldInfo = paramFields;


        //    reportDocument.Load(@exePath);

        //    //set the database loggon information. 
        //    //**Note that the third parameter is the DSN name 
        //    //  and not the Database or System name
        //    //  reportDocument.SetDatabaseLogon("pchitriv", "Windows2000",
        //    //                             "TestDB_DSN", "testDB", false);

        //    // reportDocument.SetDatabaseLogon(Variables.UserName, Variables.Password, Variables.ServerName, Variables.DBName, false);

        //    foreach (CrystalDecisions.Shared.IConnectionInfo connection in reportDocument.DataSourceConnections)
        //    {
        //        connection.IntegratedSecurity = false;
        //        for (int i = 0; i < reportDocument.DataSourceConnections.Count; i++)
        //        {
        //            reportDocument.DataSourceConnections[i].SetConnection(Variables.ServerName, Variables.DBName, Variables.UserName, Variables.Password);
        //        }
        //    }


        //    //Load the report by setting the report source

        //    //Load the report by setting the report source
        //    if (Preview == true)
        //    {
        //        crystalReportViewer1.ReportSource = reportDocument;
        //    }
        //    else
        //    {
        //        crystalReportViewer1.ReportSource = reportDocument;
        //        crystalReportViewer1.PrintReport();
        //    }

        //}
   
   
        //public void ClearanceBusinessPrint(decimal IDS, bool Preview)
        //{
        //    string exePath = Application.StartupPath;
        //    exePath = exePath + "\\Reports\\ClearanceBusinessRpt.rpt";
        //    //Instantiate variables
        //    ReportDocument reportDocument = new ReportDocument();
        //    ParameterField paramField = new ParameterField();
        //    ParameterFields paramFields = new ParameterFields();
        //    ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

        //    //Set instances for input parameter 1 -  @vDepartment
        //    paramField.Name = "@IDS";
        //    //Below variable can be set to any data 
        //    //present in SalseData table, Department column
        //    paramDiscreteValue.Value = IDS;
        //    paramField.CurrentValues.Add(paramDiscreteValue);
        //    //Add the paramField to paramFields
        //    paramFields.Add(paramField);


        //    crystalReportViewer1.ParameterFieldInfo = paramFields;


        //    reportDocument.Load(@exePath);

        //    //set the database loggon information. 
        //    //**Note that the third parameter is the DSN name 
        //    //  and not the Database or System name
        //    //  reportDocument.SetDatabaseLogon("pchitriv", "Windows2000",
        //    //                             "TestDB_DSN", "testDB", false);

        //    // reportDocument.SetDatabaseLogon(Variables.UserName, Variables.Password, Variables.ServerName, Variables.DBName, false);

        //    foreach (CrystalDecisions.Shared.IConnectionInfo connection in reportDocument.DataSourceConnections)
        //    {
        //        connection.IntegratedSecurity = false;
        //        for (int i = 0; i < reportDocument.DataSourceConnections.Count; i++)
        //        {
        //            reportDocument.DataSourceConnections[i].SetConnection(Variables.ServerName, Variables.DBName, Variables.UserName, Variables.Password);
        //        }
        //    }

        //    //Load the report by setting the report source

        //    //Load the report by setting the report source
        //    if (Preview == true)
        //    {
        //        crystalReportViewer1.ReportSource = reportDocument;
        //    }
        //    else
        //    {
        //        crystalReportViewer1.ReportSource = reportDocument;
        //        crystalReportViewer1.PrintReport();
        //    }

        //}


        //public void PeronsListPrint(string keyword,int indexselected,int type,bool Preview)
        //{
            
        //   try 
        //   {
        //        //Instantiate variables
        //        string exePath=Application.StartupPath;
        //        exePath=exePath + "\\Reports\\PersonsList.rpt";

        //        ReportDocument reportDocument = new ReportDocument();
        //        ParameterFields paramFields = new ParameterFields();

        //        ParameterField paramkeyword = new ParameterField();
        //        ParameterDiscreteValue paramkeywordDiscreteValue = new ParameterDiscreteValue();

        //        ParameterField paramindexselected = new ParameterField();
        //        ParameterDiscreteValue paramindexselectedDiscreteValue = new ParameterDiscreteValue();

        //        ParameterField paramtype = new ParameterField();
        //        ParameterDiscreteValue paramtypeDiscreteValue = new ParameterDiscreteValue();

        //        //Set instances for input parameter 1 -  @vDepartment
        //        paramkeyword.Name = "@keyword";
        //        paramkeywordDiscreteValue.Value = keyword;
        //        paramkeyword.CurrentValues.Add(paramkeywordDiscreteValue);
        //        paramFields.Add(paramkeyword);

        //        paramindexselected.Name = "@IndexSelected";
        //        paramindexselectedDiscreteValue.Value = indexselected;
        //        paramindexselected.CurrentValues.Add(paramindexselectedDiscreteValue);
        //        paramFields.Add(paramindexselected);


        //        paramtype.Name = "@Type";
        //        paramtypeDiscreteValue.Value = type;
        //        paramtype.CurrentValues.Add(paramtypeDiscreteValue);
        //        paramFields.Add(paramtype);

        //        crystalReportViewer1.ParameterFieldInfo = paramFields;

        //        reportDocument.Load(@exePath);

        //        //set the database loggon information. 


        //        foreach (CrystalDecisions.Shared.IConnectionInfo connection in reportDocument.DataSourceConnections)
        //        {
        //            connection.IntegratedSecurity = false;
        //            for (int i = 0; i < reportDocument.DataSourceConnections.Count; i++)
        //            {
        //                reportDocument.DataSourceConnections[i].SetConnection(Variables.ServerName, Variables.DBName, Variables.UserName, Variables.Password);
        //            }
        //        }

        //        //Load the report by setting the report source
        //        if (Preview == true)
        //        {
        //            crystalReportViewer1.ReportSource = reportDocument;
        //        }
        //        else
        //        {
        //            crystalReportViewer1.ReportSource = reportDocument;
        //            crystalReportViewer1.PrintReport();
        //        }

        //    }

     

        //    catch (ReflectionTypeLoadException ex)
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        foreach (Exception exSub in ex.LoaderExceptions)
        //        {
        //            sb.AppendLine(exSub.Message);
        //            if (exSub is FileNotFoundException)
        //            {
        //                FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
        //                if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
        //                {
        //                    sb.AppendLine("Fusion Log:");
        //                    sb.AppendLine(exFileNotFound.FusionLog);
        //                }
        //            }
        //            sb.AppendLine();
        //        }
        //        string errorMessage = sb.ToString();
        //        //Display or log the error based on your application.
        //        MessageBox.Show(errorMessage);
        //    }

        //}

        //public void SummonPrint(Decimal IDS, bool Preview)
        //{
        //    //Instantiate variables
        //    string exePath = Application.StartupPath;
        //    exePath = exePath + "\\Reports\\SumonRpt.rpt";

        //    ReportDocument reportDocument = new ReportDocument();
        //    ParameterFields paramFields = new ParameterFields();

        //    ParameterField paramkeyword = new ParameterField();
        //    ParameterDiscreteValue paramkeywordDiscreteValue = new ParameterDiscreteValue();

           
        //    //Set instances for input parameter 1 -  @vDepartment
        //    paramkeyword.Name = "@IDS";
        //    paramkeywordDiscreteValue.Value = IDS;
        //    paramkeyword.CurrentValues.Add(paramkeywordDiscreteValue);
        //    paramFields.Add(paramkeyword);

        //    crystalReportViewer1.ParameterFieldInfo = paramFields;

        //    reportDocument.Load(@exePath);

        //    //set the database loggon information. 


        //    foreach (CrystalDecisions.Shared.IConnectionInfo connection in reportDocument.DataSourceConnections)
        //    {
        //        connection.IntegratedSecurity = false;
        //        for (int i = 0; i < reportDocument.DataSourceConnections.Count; i++)
        //        {
        //            reportDocument.DataSourceConnections[i].SetConnection(Variables.ServerName, Variables.DBName, Variables.UserName, Variables.Password);
        //        }
        //    }
        //    //Load the report by setting the report source
        //    if (Preview == true)
        //    {
        //        crystalReportViewer1.ReportSource = reportDocument;
        //    }
        //    else
        //    {
        //        crystalReportViewer1.ReportSource = reportDocument;
        //        crystalReportViewer1.PrintReport();
        //    }

        //}



        //public void ClearanceListPrint(DateTime DateFrom, DateTime DateTo,int Type, bool Preview)
        //{
        //    try
        //    {
        //        //Instantiate variables
        //        string exePath = Application.StartupPath;
        //        exePath = exePath + "\\Reports\\ClearanceList.rpt";

        //        ReportDocument reportDocument = new ReportDocument();
        //        ParameterFields paramFields = new ParameterFields();

        //        ParameterField paramDateTo = new ParameterField();
        //        ParameterDiscreteValue paramDateToDiscreteValue = new ParameterDiscreteValue();

        //        ParameterField paramDateFrom = new ParameterField();
        //        ParameterDiscreteValue paramDateFromDiscreteValue = new ParameterDiscreteValue();

        //        ParameterField paramType = new ParameterField();
        //        ParameterDiscreteValue paramTypeDiscreteValue = new ParameterDiscreteValue();

        //        //Set instances for input parameter 1 -  @vDepartment
        //        paramDateFrom.Name = "@From";
        //        paramDateFromDiscreteValue.Value = DateFrom;
        //        paramDateFrom.CurrentValues.Add(paramDateFromDiscreteValue);
        //        paramFields.Add(paramDateFrom);

        //        paramDateTo.Name = "@To";
        //        paramDateToDiscreteValue.Value = DateTo;
        //        paramDateTo.CurrentValues.Add(paramDateToDiscreteValue);
        //        paramFields.Add(paramDateTo);

        //        paramType.Name = "@TypeOfClearance";
        //        paramTypeDiscreteValue.Value = Type;
        //        paramType.CurrentValues.Add(paramTypeDiscreteValue);
        //        paramFields.Add(paramType);

        //        crystalReportViewer1.ParameterFieldInfo = paramFields;

        //        reportDocument.Load(@exePath);

        //        //set the database loggon information. 


        //        foreach (CrystalDecisions.Shared.IConnectionInfo connection in reportDocument.DataSourceConnections)
        //        {
        //            connection.IntegratedSecurity = false;
        //            for (int i = 0; i < reportDocument.DataSourceConnections.Count; i++)
        //            {
        //                reportDocument.DataSourceConnections[i].SetConnection(Variables.ServerName, Variables.DBName, Variables.UserName, Variables.Password);
        //            }
        //        }

        //        //Load the report by setting the report source

        //        if (Preview == true)
        //        {
        //            crystalReportViewer1.ReportSource = reportDocument;
        //        }
        //        else
        //        {
        //            crystalReportViewer1.ReportSource = reportDocument;
        //            crystalReportViewer1.PrintReport();
        //        }

        //    }



        //    catch (ReflectionTypeLoadException ex)
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        foreach (Exception exSub in ex.LoaderExceptions)
        //        {
        //            sb.AppendLine(exSub.Message);
        //            if (exSub is FileNotFoundException)
        //            {
        //                FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
        //                if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
        //                {
        //                    sb.AppendLine("Fusion Log:");
        //                    sb.AppendLine(exFileNotFound.FusionLog);
        //                }
        //            }
        //            sb.AppendLine();
        //        }
        //        string errorMessage = sb.ToString();
        //        //Display or log the error based on your application.
        //        MessageBox.Show(errorMessage);
        //    }

        //}

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

  
    }
}
