Imports System.Runtime.InteropServices
Imports System.Text
Imports CoreBasic_Reload.Globals
Public Class Memory
#Region "WINDOWS API"
    <DllImport("kernel32.dll", SetLastError:=True)>
    Public Shared Function ReadProcessMemory(
    ByVal hProcess As Integer,
    ByVal lpBaseAddress As Integer,
    <Out()> ByVal lpBuffer As Byte(),
    ByVal dwSize As Integer,
    ByRef lpNumberOfBytesRead As Integer) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Public Shared Function WriteProcessMemory(
    ByVal hProcess As Integer,
    ByVal lpBaseAddress As Integer,
    ByVal lpBuffer As Byte(),
    ByVal nSize As Int32,
    <Out()> ByRef lpNumberOfBytesWritten As Integer) As Boolean
    End Function
#End Region

    Public Function rdMem(Offset As Integer, Size As Integer) As Byte()
        Dim buffer As Byte() = New Byte(Size - 1) {}
        ReadProcessMemory(GameHandle, Offset, buffer, Size, 0)
        Return buffer
    End Function
    Public Sub WrtMem(pOffset As Integer, pBytes As Byte())
        WriteProcessMemory(GameHandle, pOffset, pBytes, pBytes.Length, 0)
    End Sub
    Public Function ReadInteger(pOffset As Integer) As Integer
        Return BitConverter.ToInt32(rdMem(pOffset, 4), 0)
    End Function
    Public Sub WriteInteger(pOffset As Integer, pBytes As Integer)
        WrtMem(pOffset, BitConverter.GetBytes(pBytes))
    End Sub
    Public Function ReadShort(pOffset As Integer) As Short
        Return BitConverter.ToInt16(rdMem(pOffset, 4), 0)
    End Function
    Public Sub WriteShort(pOffset As Integer, pBytes As Short)
        WrtMem(pOffset, BitConverter.GetBytes(pBytes))
    End Sub
    Public Function ReadFloat(pOffset As Integer) As Single
        Return BitConverter.ToSingle(rdMem(pOffset, 4), 0)
    End Function
    Public Sub WriteFloat(pOffset As Integer, pBytes As Single)
        WrtMem(pOffset, BitConverter.GetBytes(pBytes))
    End Sub
    Public Sub WriteByte(pOffset As Integer, pBytes As Byte)
        WrtMem(pOffset, BitConverter.GetBytes(CShort(pBytes)))
    End Sub
    Public Function ReadMemory(Of T)(address As Integer) As T
        Dim buffer As Byte()
        Dim length As Integer = Marshal.SizeOf(GetType(T))

        If GetType(T) Is GetType(Byte()) Then
            buffer = New Byte(length - 1) {}
        Else
            buffer = New Byte(Marshal.SizeOf(GetType(T)) - 1) {}
        End If

        If Not ReadProcessMemory(GameHandle, New IntPtr(address), buffer, New IntPtr(buffer.Length), IntPtr.Zero) Then Return Nothing

        If GetType(T) Is GetType(Byte()) Then Return CType(CType(buffer, Object), T)

        Dim gcHandle As GCHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned)
        Dim returnObject As T
        returnObject = CType(Marshal.PtrToStructure(gcHandle.AddrOfPinnedObject, GetType(T)), T)
        gcHandle.Free()
        Return returnObject
    End Function
    Public Function ReadStringUnicode(address As Integer) As String
        Dim buffer As Byte() = New Byte(27) {}
        ReadProcessMemory(GameHandle, address, buffer, buffer.Length, 0)
        Return Encoding.Unicode.GetString(buffer).Trim
    End Function

    Public Function ReadStringASCII(address As Integer) As String
        Dim buffer As Byte() = New Byte(27) {}
        ReadProcessMemory(GameHandle, address, buffer, buffer.Length, 0)
        Return Encoding.ASCII.GetString(buffer).Trim
    End Function

    Public Sub WriteStruct(Of T)(address As Integer, mystruct As T)
        Dim Ptr As IntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(mystruct))
        Dim ByteArray(Marshal.SizeOf(mystruct) - 1) As Byte

        Marshal.StructureToPtr(mystruct, Ptr, False)

        Marshal.Copy(Ptr, ByteArray, 0, Marshal.SizeOf(mystruct))
        Marshal.FreeHGlobal(Ptr)

        WrtMem(address, ByteArray)
    End Sub
End Class
