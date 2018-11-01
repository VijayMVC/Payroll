Attribute VB_Name = "Module1"
Option Explicit

Public pServerName As String
Public pID_DATABASE As String
Public pusername As String
Public pUserPassword As String
Public pIDS As Double

Public Sub Main()

    Dim sArgs() As String
    
    Dim iLoop As Integer
    'Assuming that the arguments passed from
    'command line will have space in between,
    'you can also use comma or otehr things...
    sArgs = Split(Command$, "")
    For iLoop = 0 To UBound(sArgs)
        'this will print the command line
        'arguments that are passed from the command line
        'Debug.Print sArgs(iLoop)
        If iLoop = 0 Then
                pIDS = Val(sArgs(iLoop))
        End If
        If iLoop = 1 Then
            pServerName = sArgs(iLoop)
        End If
        If iLoop = 2 Then
           pID_DATABASE = sArgs(iLoop)
        End If
        If iLoop = 3 Then
           pusername = sArgs(iLoop)
        End If
        If iLoop = 4 Then
           pUserPassword = sArgs(iLoop)
        End If
    Next
    
    ReportViewer.PrintPayroll pIDS, pServerName, pID_DATABASE, pusername, pUserPassword
    Load ReportViewer
    ReportViewer.Show
End Sub

