' NOT DONE & WORKING                  : "❌"
' WORKING & COMPLATE                  : "✔️"
' PARTIALLY WORKING & WORK IN PROGRESS: "🕜"
'
'
'TODO LIST
'
'    1-) Write Memory Class
'        -Read/Write Integer      ✔️
'        -Read/Write Boolean      ✔️
'        -Read/Write Bytes        ✔️
'        -Read/Write Floats       ✔️
'
'
'    2-) Write ProcessClass
'        -Process Tests           ✔️
'        -Get Module Adresses     ✔️
'        -Get Process Infos       ✔️
'        -IO Processes            ❌
'        -Process Handler         ✔️
'
'
'    3-) Split Players To Classes ❌
'
'
'    4-) Write Cheats
'        -Wallhack                ❌
'        -NoFlash                 ❌
'        -BunnyHop                ❌
'        -Aimbot(NOT SURE)        ❌
'
'    5-) Loading Screen           ❌
'====================================

Imports System.Threading
Imports CoreBasic_Reload.Globals
Imports CoreBasic_Reload.ProcessClass
Imports CoreBasic_Reload.Functions



Module Main
    Sub Main()
        GameName = "csgo"
        Load()
        SendConsoleLog("Waiting for " + GameName + ".exe ..", False, ConsoleColor.Green)
        Do While (Not TestProcessByName(GameName))
            Thread.Sleep(200)
            Console.Write(".")
        Loop
        Setup()
        Console.WriteLine("")
        SendConsoleLog("client_panorama.dll --->" + ClientDLL.ToString, True, ConsoleColor.Green)
        SendConsoleLog("engine.dll --->" + EngineDLL.ToString, True, ConsoleColor.Green)
        Console.ReadLine()
    End Sub
    Sub Setup()
        ClientDLL = GetModuleAdress("client_panorama.dll", GameName)
        EngineDLL = GetModuleAdress("engine.dll", GameName)
    End Sub
    Sub Load()
        Dim _Titler As New Thread(AddressOf HeaderThread)
        _Titler.Start()
        DisplayHeader()
    End Sub
    Sub DisplayHeader()
        Console.ForegroundColor = ConsoleColor.White
        For Value As Integer = 0 To Console.WindowWidth - 1
            Console.Write("=")
        Next
        Console.ForegroundColor = ConsoleColor.DarkMagenta
        Console.Write("dyyyyyyso/+//::/::::/+osdMMMMM")
        Console.ForegroundColor = ConsoleColor.White
        Console.Write("    Cheat Name-> " + AppName + vbNewLine)
        Console.ForegroundColor = ConsoleColor.DarkMagenta
        Console.Write("hoooo/-..```` ```````..-+hhhhs")
        Console.ForegroundColor = ConsoleColor.White
        Console.Write("    Version   -> v" + Version + vbNewLine)
        Console.ForegroundColor = ConsoleColor.DarkMagenta
        Console.Write("hoo:.````    ` ``````````.:oo-")
        Console.ForegroundColor = ConsoleColor.White
        Console.Write("    Author    -> " + Author + vbNewLine)
        Console.ForegroundColor = ConsoleColor.DarkMagenta
        Console.Write("h+-``          ```  ``````../-")
        Console.ForegroundColor = ConsoleColor.White
        Console.Write("    GitHub    -> " + GitHub + vbNewLine)
        Console.ForegroundColor = ConsoleColor.DarkMagenta
        Console.Write("y.``        ./ooo/`  ``````..`")
        Console.ForegroundColor = ConsoleColor.White
        Console.Write("    Game      -> " + GameName + ".exe" + vbNewLine)
        Console.ForegroundColor = ConsoleColor.DarkMagenta
        Console.WriteLine("s``       .hy/..-/hy`   ``````")
        'Console.ForegroundColor = ConsoleColor.White
        'Console.Write("    Handle    -> " + GameHandle.ToString() + vbNewLine)
        'Console.ForegroundColor = ConsoleColor.DarkMagenta
        Console.WriteLine("+`       `N/       `     `````")
        'Console.ForegroundColor = ConsoleColor.White
        'Console.Write("    ClientDLL -> " + ClientDLL.ToString() + vbNewLine)
        'Console.ForegroundColor = ConsoleColor.DarkMagenta
        Console.WriteLine("+`       :N                 ``")
        'Console.ForegroundColor = ConsoleColor.White
        'Console.Write("    EngineDLL -> " + EngineDLL.ToString() + vbNewLine)
        'Console.ForegroundColor = ConsoleColor.DarkMagenta
        Console.WriteLine("+`       `m+       `        ``")
        Console.WriteLine("+``       .yh/-.-+hs`      ```")
        Console.WriteLine("s.``        `:+++:`       ````")
        Console.WriteLine("yo.``                    ```::")
        Console.WriteLine("MMs:.``                ````.dM")
        Console.WriteLine("MMyo+-.`````       `````.-+/dM")
        Console.Write("MMs////-.`````````````.:yMMMMM")
        Dim Credits As String = "Built In With CoreVB Base w/ Love <3"
        For Value As Integer = 0 To (Console.WindowWidth - (Credits.Length * 2))
            Console.Write(" ")
        Next
        Console.ForegroundColor = ConsoleColor.Red
        Console.Write(Credits + vbNewLine)
        Console.ForegroundColor = ConsoleColor.White
        For Value As Integer = 0 To Console.WindowWidth - 1
            Console.Write("=")
        Next
    End Sub
End Module
