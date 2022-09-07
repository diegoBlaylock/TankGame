Public Class fakeBall
    Public loc As Point
    Public id As Integer
    Public ball As PictureBox
    Public fo As Form

    Public Sub New(location As Point, iden As Integer, f As Form)
        loc = location
        id = iden
        fo = f
        f.Invoke(New MethodInvoker(Sub()
                                       ball = New PictureBox
                                       ball.SizeMode = PictureBoxSizeMode.Zoom
                                       ball.Image = Form1.arr(8)
                                       ball.Show()
                                       ball.Location = location
                                       ball.Name = "b"
                                       ball.Parent = Form1.main
                                       ball.Size = New Size(16, 16)
                                       ball.BackColor = Color.Transparent
                                       Form1.main.Controls.Add(Me.ball)
                                   End Sub))
    End Sub

    Public Sub move(loca As Point)
        Me.ball.Invoke(Sub()
                           Me.ball.Location = loca
                       End Sub)
    End Sub

    Public Sub distrophy()
        fo.Invoke(New MethodInvoker(Sub()

                                        Form1.balls.Remove(Me.id)
                                        Me.ball.Dispose()
                                    End Sub))

    End Sub

End Class
