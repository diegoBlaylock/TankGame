Public Class ThreadBase
    Private t As Threading.Thread = New Threading.Thread(AddressOf Me.run)

    Public Overridable Sub run()

    End Sub

    Public Sub start()
        Me.t.Start()
        RaiseEvent onStart()
    End Sub

    Public Event onStart()

    Public Event onSleep(ms As Integer)

    Public Event onClose()

    Public Sub terminator()
        RaiseEvent onClose()
        Me.t.Abort()
    End Sub

    Public Sub sleep(milliseconds As Integer)
        RaiseEvent onSleep(milliseconds)
        Threading.Thread.Sleep(milliseconds)
    End Sub
End Class
