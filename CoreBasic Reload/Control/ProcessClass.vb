Imports System.Runtime.InteropServices
Imports CoreBasic_Reload.Globals
Public Class ProcessClass

#Region "WINDOWS API"

    <DllImport("kernel32.dll", SetLastError:=True)>
    Public Shared Function OpenProcess(
        ByVal dwDesiredAcces As Integer,
        ByVal bInheritHandle As Boolean,
        ByVal processID As Integer
    ) As Integer
    End Function

#End Region

#Region "Defines"
    'PROCESS ACCESS == 2035711
#End Region


    Public Shared Function TestProcessByName(procName As String) As Boolean
        Dim Game As Process() = Process.GetProcessesByName(procName)
        If Game.Length <= 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Shared Function TestProcessByID(procID As Integer) As Boolean
        Dim Game As Process = Process.GetProcessById(procID)
        If Game Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Shared Function GetModuleAdress(moduleName As String, procName As String) As Integer
        GameProcess = Process.GetProcessById(GetProcessID(procName))
        Dim _temp As Integer
        If (TestProcessByName(procName)) Then
            GameHandle = OpenProcess(2035711, False, GetProcessID(procName))
            If GameHandle > 0 Then
                For Each _module As ProcessModule In GameProcess.Modules
                    If _module.ModuleName = moduleName Then
                        _temp = _module.BaseAddress
                    End If
                Next
            End If
        End If
        Return _temp
    End Function

    Public Shared Function GetProcessID(procName As String) As Integer
        Dim _process = Process.GetProcessesByName(procName)
        Dim _procID As Integer
        For Each proc In _process
            _procID = proc.Id
        Next
        Return _procID
    End Function
End Class
