Imports System.Text
Imports System.Threading
Imports CoreBasic_Reload.Globals
Public Class Functions
    Shared Function RandomString(r As Random) As String
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!'^+%&/()=?_>£#$½{[]}\|><.,:;~~¨´'é "
        Dim sb As New StringBuilder
        Dim cnt As Integer = r.Next(15, 33)
        For i As Integer = 1 To cnt
            Dim idx As Integer = r.Next(0, s.Length)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString()
    End Function
    Shared Sub HeaderThread()
        While (True)
            Dim _r As New Random
            Console.Title = "[" + AppName + "]   " + RandomString(_r)
            Thread.Sleep(500)
        End While
    End Sub
    Shared Sub SendConsoleLog(text As String, newLine As Boolean, txtColor As ConsoleColor)
        If (Not newLine) Then
            Console.ForegroundColor = ConsoleColor.Blue
            Console.Write("[" + DateTime.Now.ToString("HH:mm:ss") + "] - ")
            Console.ForegroundColor = txtColor
            Console.Write(text)
        Else
            Console.ForegroundColor = ConsoleColor.Blue
            Console.Write("[" + DateTime.Now.ToString("HH:mm:ss") + "] - ")
            Console.ForegroundColor = txtColor
            Console.Write(text + vbNewLine)
        End If
    End Sub

End Class
