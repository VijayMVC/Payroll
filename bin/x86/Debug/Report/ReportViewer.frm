VERSION 5.00
Object = "{F62B9FA4-455F-4FE3-8A2D-205E4F0BCAFB}#11.5#0"; "CRViewer.dll"
Object = "{A8E5842E-102B-4289-9D57-3B3F5B5E15D3}#11.2#0"; "Codejock.Controls.Unicode.v11.2.0.ocx"
Begin VB.Form ReportViewer 
   Caption         =   "Report Viewer"
   ClientHeight    =   6720
   ClientLeft      =   120
   ClientTop       =   450
   ClientWidth     =   10500
   Icon            =   "ReportViewer.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   6720
   ScaleWidth      =   10500
   StartUpPosition =   3  'Windows Default
   Begin XtremeSuiteControls.Resizer Resizer1 
      Height          =   6720
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   10500
      _Version        =   720898
      _ExtentX        =   18521
      _ExtentY        =   11853
      _StockProps     =   1
      AutoSize        =   -1  'True
      ControlCount    =   1
      Control(0).Caption=   "crvPayroll"
      Control(0).Width=   100
      Control(0).Height=   100
      Begin CrystalActiveXReportViewerLib11_5Ctl.CrystalActiveXReportViewer crvPayroll 
         Height          =   6720
         Left            =   -15
         TabIndex        =   1
         Top             =   -15
         Width           =   10500
         _cx             =   18521
         _cy             =   11853
         DisplayGroupTree=   0   'False
         DisplayToolbar  =   -1  'True
         EnableGroupTree =   -1  'True
         EnableNavigationControls=   -1  'True
         EnableStopButton=   -1  'True
         EnablePrintButton=   -1  'True
         EnableZoomControl=   -1  'True
         EnableCloseButton=   -1  'True
         EnableProgressControl=   0   'False
         EnableSearchControl=   -1  'True
         EnableRefreshButton=   -1  'True
         EnableDrillDown =   -1  'True
         EnableAnimationControl=   -1  'True
         EnableSelectExpertButton=   0   'False
         EnableToolbar   =   -1  'True
         DisplayBorder   =   -1  'True
         DisplayTabs     =   -1  'True
         DisplayBackgroundEdge=   0   'False
         SelectionFormula=   ""
         EnablePopupMenu =   -1  'True
         EnableExportButton=   -1  'True
         EnableSearchExpertButton=   0   'False
         EnableHelpButton=   0   'False
         LaunchHTTPHyperlinksInNewBrowser=   -1  'True
         EnableLogonPrompts=   -1  'True
         LocaleID        =   13321
         EnableInteractiveParameterPrompting=   0   'False
      End
   End
End
Attribute VB_Name = "ReportViewer"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Public Sub PrintPayroll(IDS As Double, pServerName As String, pID_DATABASE As String, pusername As String, pUserPassword As String)

On Error GoTo errHandler

Dim crxApp As New CRAXDDRT.Application
Dim crxReport As CRAXDDRT.Report
Dim crxDatabaseTable As CRAXDDRT.DatabaseTable
Dim crxSubReport As CRAXDDRT.Report

Dim ReportName As String

     ReportName = App.Path & "\\Report\PayrollRpt.rpt"
      Set crxReport = crxApp.OpenReport(ReportName)
      crxReport.DiscardSavedData
      crxReport.Database.Tables(1).SetLogOnInfo ServerName, ID_DATABASE, username, UserPassword
    ' crxReport.Database.SetDataSource "SERVER"
    
      crxReport.ParameterFields.GetItemByName("@IDS").ClearCurrentValueAndRange
      crxReport.ParameterFields.GetItemByName("@IDS").AddCurrentValue IDS  '<-- Variable
     
      crxReport.DisplayProgressDialog = True
     ' crxReport.PrintOut True, 1
            
     
    With crvPayroll '<- CR Control Name
    '.Connect = ConnectStrings
    .ReportSource = crxReport
    .ViewReport
    While .IsBusy
    DoEvents
    Wend
    .Zoom "100"
    '.Visible = False
    End With

errHandler:
       If Err <> 0 Then
          MsgBox Err.Description
      End If

End Sub


Public Sub PrintPaySlip(IDS As Double, pServerName As String, pID_DATABASE As String, pusername As String, pUserPassword As String)

On Error GoTo errHandler

Dim crxApp As New CRAXDDRT.Application
Dim crxReport As CRAXDDRT.Report
Dim crxDatabaseTable As CRAXDDRT.DatabaseTable
Dim crxSubReport As CRAXDDRT.Report

Dim ReportName As String

     ReportName = App.Path & "\\Report\PaySlipRpt.rpt"
      Set crxReport = crxApp.OpenReport(ReportName)
      crxReport.DiscardSavedData
      crxReport.Database.Tables(1).SetLogOnInfo ServerName, ID_DATABASE, username, UserPassword
    ' crxReport.Database.SetDataSource "SERVER"
      crxReport.ParameterFields.GetItemByName("@IDS").ClearCurrentValueAndRange
      crxReport.ParameterFields.GetItemByName("@IDS").AddCurrentValue IDS  '<-- Variable
     
      'crxReport.DisplayProgressDialog = True
     ' crxReport.PrintOut True, 1
            
     
    With crvPayroll '<- CR Control Name
    '.Connect = ConnectStrings
    .ReportSource = crxReport
    .ViewReport
    While .IsBusy
    DoEvents
    Wend
    .Zoom "100"
    '.Visible = False
    End With

errHandler:
       If Err <> 0 Then
          MsgBox Err.Description
      End If

End Sub



Public Sub PrintAttendance(IDS As Double, DateFrom As Date, DateTo As Date, pServerName As String, pID_DATABASE As String, pusername As String, pUserPassword As String)

On Error GoTo errHandler

Dim crxApp As New CRAXDDRT.Application
Dim crxReport As CRAXDDRT.Report
Dim crxDatabaseTable As CRAXDDRT.DatabaseTable
Dim crxSubReport As CRAXDDRT.Report
Dim ReportName As String

      ReportName = App.Path & "\\Report\TimeSheet.rpt"
      Set crxReport = crxApp.OpenReport(ReportName)
      crxReport.DiscardSavedData
      crxReport.Database.Tables(1).SetLogOnInfo ServerName, ID_DATABASE, username, UserPassword
      
    ' crxReport.Database.SetDataSource "SERVER"
      crxReport.ParameterFields.GetItemByName("@IDS").ClearCurrentValueAndRange
      crxReport.ParameterFields.GetItemByName("@IDS").AddCurrentValue IDS  '<-- Variable
      crxReport.ParameterFields.GetItemByName("@DateFrom").ClearCurrentValueAndRange
      crxReport.ParameterFields.GetItemByName("@DateFrom").AddCurrentValue DateFrom  '<-- Variable
      crxReport.ParameterFields.GetItemByName("@DateTo").ClearCurrentValueAndRange
      crxReport.ParameterFields.GetItemByName("@DateTo").AddCurrentValue DateTo  '<-- Variable
      
     ' crxReport.PrintOut True, 1

    With crvPayroll '<- CR Control Name
    '.Connect = ConnectStrings
    .ReportSource = crxReport
    .ViewReport
    While .IsBusy
    DoEvents
    Wend
    .Zoom "100"
    '.Visible = False
    End With

errHandler:
       If Err <> 0 Then
          MsgBox Err.Description
      End If

End Sub
