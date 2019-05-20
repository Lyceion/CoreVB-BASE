Imports System.Deployment
Public Class Globals
    'MODULES
    Public Shared ClientDLL As Integer
    Public Shared EngineDLL As Integer

    'GAME STATS
    Public Shared GameName As String = "null"
    Public Shared GameHandle As Integer
    Public Shared GameProcess As Process

    'APP STATS
    Public Shared AppLocation As String = AppDomain.CurrentDomain.BaseDirectory
    Public Shared Version As String = My.Application.Info.Version.ToString
    Public Shared AppName As String = My.Application.Info.AssemblyName

    'AUTHOR
    Public Shared Author As String = "CYLOPS"
    Public Shared GitHub As String = "https://github.com/MrCylops"
End Class
