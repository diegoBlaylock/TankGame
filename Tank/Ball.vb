Public Class Ball
    Inherits ThreadBase
    Public id As Integer
    Public deric As Integer
    Public running As Boolean = True
    Public ball As PictureBox = New PictureBox()
    Public WithEvents time As New Timer
    Public bounces As Integer = 3
    Private yVel = 0
    Private xVel = 0
    Public tank As PictureBox
    Public d
    Public im As Bitmap
    Public so As Point
    Public WithEvents tim As Timer
    Public Event move(b As Ball, xv As Integer, yv As Integer)



    Public Sub New(ByVal dir As Integer, ByVal s As Point, ByVal img As Bitmap, f0 As Form, di As Integer)



        Me.deric = dir
        so = s
        im = img
        Me.start()
        startTime()
        id = di
    End Sub

    Public Overrides Sub run()

        Select Case Me.deric
            Case 1
                Me.yVel = -2
                Me.xVel = 2
            Case 2
                Me.xVel = 2
            Case 0
                Me.yVel = -2
            Case 3
                Me.yVel = 2
                Me.xVel = 2
            Case 4
                Me.yVel = 2
            Case 5
                Me.yVel = 2
                Me.xVel = -2
            Case 6
                Me.xVel = -2
            Case 7
                Me.yVel = -2
                Me.xVel = -2

        End Select



    End Sub



    Public Sub disposse()
        Me.running = False
        Form1.send(String.Join("|", {"bd", Str(id)}))
        Me.time.Stop()
        Form1.hasShoot -= 1
        Form1.nB -= 1

        Me.ball.Hide()


        Form1.main.Controls.Remove(Me.ball)

        Me.ball.Dispose()
        Me.time.Dispose()

    End Sub

    Public Sub tick(sender As Object, e As EventArgs) Handles time.Tick
        If Me.running Then

            If Me.ball.Name <> "1" Then
                NeBall(im, so)
                add()
            End If
            NewBall()
            If Me.ball.Top <= 0 Or Me.ball.Bottom >= 864 Or Me.hitAnySide(Me.ball, 0) Or Me.hitAnySide(Me.ball, 2) Then
                Me.bounces -= 1
                Me.yVel *= -1

            End If
            If Me.ball.Left <= 0 Or Me.ball.Right >= 864 Or Form1.hitAnySide(Me.ball, 1) Or Form1.hitAnySide(Me.ball, 3) Then
                Me.bounces -= 1
                Me.xVel *= -1

            End If

            If Me.bounces = 0 Then
                Me.disposse()
            End If
            d = hit()
            If d <> -1 Then
                tim = New Timer()
                tim.Interval = 100
                tim.Start()
                Form1.send("d|" + Str(Form1.id) + Str(d))
                Me.disposse()
            End If

        End If
    End Sub

    Public Sub banana() Handles tim.Tick
        Dim tnk As PictureBox = Form1.tanks(d)
        Static j As Integer
        If j = 0 Then
            Form1.tmr.Stop()
            tnk.Width += 48
            tnk.Height += 48
            tnk.Left -= 24
            tnk.Top -= 24
        End If

        tnk.Image = Form1.readSheet("Explosion.png", 96, 96, 1, 12)(j)
        j += 1

        If j = 12 Then

            Form1.tmr.Start()
            tim.Stop()
            tnk.Width -= 48
            tnk.Height -= 48
            Me.tim.Dispose()
        End If
    End Sub

    Public Function hit()
        Dim b As Integer = -1
        For Each p In Form1.tanks
            If Me.ball.Bounds.IntersectsWith(p.Bounds) Then
                b = Form1.tanks.IndexOf(p)

            End If
        Next
        Return b

    End Function

    Public Function hitSide(obj As Object, obj2 As Object, side As Integer)
        Select Case side
            Case 0

                Return obj.bottom = obj2.Location.Y And obj.right > obj2.Location.X And obj.left < obj2.Location.X + obj2.Width
            Case 1
                Return obj.left = obj2.Right And obj.bottom > obj2.Top And obj.top < obj2.Bottom
            Case 2
                Return obj.top = obj2.Bottom And obj.right > obj2.Left And obj.left < obj2.Right
            Case 3
                Return obj.right = obj2.Location.X And obj.bottom > obj2.Location.Y And obj.top < obj2.Location.Y + obj2.Height
            Case Else
                Return False
        End Select
    End Function

    Public Function hitAnySide(obj As Object, sde As Integer)
        Dim bool As Boolean = False


        For Each item In Form1.main.Controls.OfType(Of Panel)()

            If hitSide(obj, item, sde) Then
                bool = True

                Exit For
            End If


        Next

        Return bool
    End Function


    Public Sub NewBall()


        Me.ball.Left += xVel
            Me.ball.Top += yVel
        Form1.send("bm|" + Str(Me.id) + "|" + Str(Me.ball.Left) + "|" + Str(Me.ball.Top))

    End Sub


    Public Sub startTime()

        If Me.deric Mod 2 = 0 Then
            Me.time.Interval = 1
        Else
            Me.time.Interval = 2
        End If

        time.Start()


    End Sub



    Public Sub add()
       

            Form1.main.Controls.Add(Me.ball)



    End Sub


    Public Sub NeBall(b As Bitmap, s As Point)





        Me.ball.Image = b

            Me.ball.SizeMode = PictureBoxSizeMode.Zoom
            Me.ball.Size = New Size(16, 16)
            Me.ball.Location = s
            Me.ball.BackColor = Color.Transparent
           
            Me.ball.Show()
            Me.ball.Name = "1"


    End Sub
End Class
