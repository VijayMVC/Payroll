Attribute VB_Name = "Module1"
Option Explicit

Public pServerName As String
Public pID_DATABASE As String
Public pusername As String
Public pUserPassword As String
Public pIDS As Double
Public pType As Integer
Public DateFrom As Date
Public DateTo As Date


Public Sub Main()

    Dim sArgs() As String

    Dim iLoop As Integer
    'Assuming that the arguments passed from
    'command line will have space in between,
    'you can also use comma or otehr things...
    sArgs = Split(Command$, ",")
    For iLoop = 0 To UBound(sArgs)
        'this will print the command line
        'arguments that are passed from the command line
        'Debug.Print sArgs(iLoop)
        
        If iLoop = 0 Then
                pIDS = Val(sArgs(iLoop))
           '     MsgBox pIDS
        End If
        If iLoop = 1 Then
            pServerName = sArgs(iLoop)
         '   MsgBox pServerName
        End If
        If iLoop = 2 Then
           pID_DATABASE = sArgs(iLoop)
         '  MsgBox pID_DATABASE
        End If
        If iLoop = 3 Then
           pusername = sArgs(iLoop)
          ' MsgBox pusername
        End If
        If iLoop = 4 Then
           pUserPassword = sArgs(iLoop)
           'MsgBox pUserPassword
        End If
        
        If iLoop = 5 Then
           pType = Val(sArgs(iLoop))
          ' MsgBox pType
        End If
        
        If iLoop = 6 Then
           DateFrom = sArgs(iLoop)
          ' MsgBox iLoop
         '  MsgBox DateFrom
        End If
        
        If iLoop = 7 Then
           DateTo = sArgs(iLoop)
          '  MsgBox iLoop
          ' MsgBox DateTo
        End If
        
    Next
  
  If pType = 0 Then
        ReportViewer.PrintPayroll pIDS, pServerName, pID_DATABASE, pusername, pUserPassword
  End If
  If pType = 1 Then
        ReportViewer.PrintPaySlip pIDS, pServerName, pID_DATABASE, pusername, pUserPassword
  End If
  If pType = 2 Then
          ReportViewer.PrintAttendance pIDS, DateFrom, DateTo, pServerName, pID_DATABASE, pusername, pUserPassword
   
  End If
 
    Load ReportViewer
    ReportViewer.Show
    
    
End Sub

