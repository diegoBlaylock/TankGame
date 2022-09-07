Imports System.Net.Sockets
Imports System.IO
Imports System.Drawing.Text

Public Class Form1
    Public arr
    Public dir As Integer
    Public SQRT2 As Single = Val(Math.Sqrt(2))
    Public color As Integer = 0
    Public hasShoot = 0
    Public count = 0
    Public walls As HashSet(Of Object) = New HashSet(Of Object)
    Public user As String = Environment.UserName
    Public tank As PictureBox
    Public client As TcpClient
    Public out As StreamWriter
    Public inp As StreamReader
    Public running As Boolean = True
    Public id As Integer
    Public address As String = "10.0.8.172"
    Public tanks As List(Of PictureBox) = New List(Of PictureBox)
    Public balls As Dictionary(Of Integer, fakeBall) = New Dictionary(Of Integer, fakeBall)
    Public nB As Integer = 1

    Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        running = False
        send("end")

        If Not client Is Nothing Then
            client.Close()
            inp.Close()
            out.Close()
        End If
        End
    End Sub



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        JoyStick(Me)

        tanks.Add(tnk1)
        tanks.Add(tnk2)
        tanks.Add(tnk3)
        tanks.Add(tnk4)
        TitleScreen.BringToFront()
        main.Location = New Point(0, -192)
        Me.SetClientSizeCore(512, 560)
        arr = readSheet("ss.png", 512, 512, 3, 3)
        tnk1.Image = arr(0)
        rotate(tnk2, arr(2), 6)
        rotate(tnk3, arr(4), 4)
        rotate(tnk4, arr(6), 0)
        'tmr.Start()
        Bullets.Interval = 1000
        Me.MaximumSize = New Size(Me.Width, Me.Height)
        Me.MinimumSize = New Size(Me.Width, Me.Height)
        For Each hash As Panel In main.Controls.OfType(Of Panel)()
            walls.Add(hash)
        Next
        For Each hash As PictureBox In main.Controls.OfType(Of PictureBox)()
            walls.Add(hash)
        Next
        Randomize()
        Dim arrs As String() = My.Computer.FileSystem.ReadAllText("name.txt").Split(vbCrLf)
        Label3.Text += arrs(Math.Round(Rnd() * 39)).Replace(vbCr, "").Replace(vbLf, "")
        Label3.Left = (TitleScreen.Width \ 2) - (Label3.Width \ 2)
        lblTitle.Left = (TitleScreen.Width \ 2) - (lblTitle.Width \ 2)
        Label1.Left = (TitleScreen.Width \ 2) - (Label1.Width \ 2)
    End Sub

    Public Sub convert(m As Object)
        For Each item In m.Controls
            If TypeOf item Is Label Or TypeOf item Is Button Or TypeOf item Is TextBox Then
                'item.font = pressstart(item)
            End If
            If TypeOf item Is Panel Then
                convert(item)
            End If
        Next
    End Sub

    Public Function readSheet(ByVal loc As String, ByVal width As Integer, ByVal height As Integer, ByVal rows As Integer, ByVal columns As Integer)
        Dim img As New Bitmap(loc)

        Dim sprite((rows * columns) - 1)
        For i As Integer = 0 To ((rows * columns) - 1)
            sprite(i) = New Bitmap(width, height)
            Dim gr As Graphics = Graphics.FromImage(sprite(i))
            Dim leftPos As Integer = 0
            leftPos = width * (i Mod columns)
            gr.DrawImage(img, 0, 0, New RectangleF(leftPos, Int(i / columns) * height, width, height), GraphicsUnit.Pixel)
        Next
        Return sprite
    End Function

    Private Declare Function GetKeyState Lib "user32" (ByVal nVirtKey As Short) As Short

    Private Function RotateImage(ByVal img As Image, ByVal angle As Single) As Bitmap
        ' the calling code is responsible for (and must) 
        ' disposing of the bitmap returned
        Dim im As New Bitmap(img, New Size(img.Width \ SQRT2, img.Height \ SQRT2))
        Dim w As Integer = Int(img.Width)

        Dim h As Integer = Int(img.Height)
        Dim retBMP As Bitmap = New Bitmap(w, h)
        retBMP.SetResolution(img.HorizontalResolution, img.VerticalResolution)

        Using g = Graphics.FromImage(retBMP)
            ' rotate aroung the center of the image
            g.TranslateTransform(im.Width \ 2, im.Height \ 2)

            'rotate
            g.RotateTransform(angle)

            g.TranslateTransform(-im.Width \ 2, -im.Height \ 2)

            'draw image to the bitmap
            g.DrawImage(im, New PointF(0, 0))

            Return retBMP
        End Using
    End Function

    Public Function getX(pct As PictureBox) As Integer
        Return pct.Left + main.Location.X
    End Function
    Public Function getY(pct As PictureBox) As Integer
        Return pct.Top + main.Location.Y
    End Function

    Declare Function GetForegroundWindow Lib "user32" Alias "GetForegroundWindow" () As Long

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr.Tick
        Static picChange = 4
        If GetForegroundWindow = Me.Handle Then
            Dim keynum As Integer = (getBool(GetKeyState(Keys.Up) < 0) + getBool(GetKeyState(Keys.Down) < 0) + getBool(GetKeyState(Keys.Left) < 0) + getBool(GetKeyState(Keys.Right) < 0))
            If Not ((getBool(GetKeyState(Keys.Up) < 0) + getBool(GetKeyState(Keys.Down) < 0) + getBool(GetKeyState(Keys.Left) < 0) + getBool(GetKeyState(Keys.Right) < 0)) >= 3) And Not ((GetKeyState(Keys.Up) < 0 And GetKeyState(Keys.Down) < 0) Or (GetKeyState(Keys.Left) < 0 And GetKeyState(Keys.Right) < 0)) Then
                If keynum = 2 Then
                    tmr.Interval = Int(36 * SQRT2)
                    If (GetKeyState(Keys.Up) < 0 And GetKeyState(Keys.Right) < 0) And (Not hitAnySide(tank, 2) And Not hitAnySide(tank, 3)) Then

                        keyResponse(1)
                        If Not (tank.Top = 0) Then

                            If ((Not main.Location.Y = 0) And (getY(tank) = 216)) Then
                                main.Location = New Point(main.Location.X, main.Location.Y + 2)
                            End If
                            tank.Top -= 2
                        End If
                        If Not tank.Right = 864 Then

                            If (Not main.Location.X = 512 - 864) And (getX(tank) = 232) Then
                                main.Location = New Point(main.Location.X - 2, main.Location.Y)
                            End If
                            tank.Left += 2
                        End If
                        send("mve|" + Str(id) + "|" + Str(1) + "|" + Str(tank.Location.X) + "|" + Str(tank.Location.Y) + "|" + keyResponse(0, 3))
                    End If

                    If (GetKeyState(Keys.Up) < 0 And GetKeyState(Keys.Left) < 0) And (Not hitAnySide(tank, 2) And Not hitAnySide(tank, 1)) Then

                        keyResponse(7)
                        If Not (tank.Top = 0) Then
                            If ((Not main.Location.Y = 0) And (getY(tank) = 216)) Then
                                main.Location = New Point(main.Location.X, main.Location.Y + 2)
                            End If
                            tank.Top -= 2

                        End If
                        If Not tank.Left = 0 Then
                            If (Not main.Location.X = 0) And (getX(tank) = 232) Then
                                main.Location = New Point(main.Location.X + 2, main.Location.Y)
                            End If
                            tank.Left -= 2
                        End If
                        send("mve|" + Str(id) + "|" + Str(7) + "|" + Str(tank.Location.X) + "|" + Str(tank.Location.Y) + "|" + keyResponse(0, 3))
                    End If

                    If (GetKeyState(Keys.Down) < 0 And GetKeyState(Keys.Right) < 0) And (Not hitAnySide(tank, 0) And Not hitAnySide(tank, 3)) Then

                        keyResponse(3)
                        If Not (tank.Bottom = 864) Then
                            If ((Not main.Location.Y = 480 - 864) And (getY(tank) = 216)) Then
                                main.Location = New Point(main.Location.X, main.Location.Y - 2)
                            End If
                            tank.Top += 2
                        End If
                        If Not tank.Right = 864 Then
                            If (Not main.Location.X = 512 - 864) And (getX(tank) = 232) Then
                                main.Location = New Point(main.Location.X - 2, main.Location.Y)
                            End If
                            tank.Left += 2
                        End If
                        send("mve|" + Str(id) + "|" + Str(3) + "|" + Str(tank.Location.X) + "|" + Str(tank.Location.Y) + "|" + keyResponse(0, 3))
                    End If

                    If (GetKeyState(Keys.Down) < 0 And GetKeyState(Keys.Left) < 0) And (Not hitAnySide(tank, 0) And Not hitAnySide(tank, 1)) Then

                        keyResponse(5)
                        If Not (tank.Bottom = 864) Then
                            If ((Not main.Location.Y = 480 - 864) And (getY(tank) = 216)) Then
                                main.Location = New Point(main.Location.X, main.Location.Y - 2)
                            End If
                            tank.Top += 2
                        End If
                        If Not tank.Left = 0 Then
                            If (Not main.Location.X = 0) And (getX(tank) = 232) Then
                                main.Location = New Point(main.Location.X + 2, main.Location.Y)
                            End If
                            tank.Left -= 2
                        End If
                        send("mve|" + Str(id) + "|" + Str(5) + "|" + Str(tank.Location.X) + "|" + Str(tank.Location.Y) + "|" + keyResponse(0, 3))
                    End If

                Else
                    tmr.Interval = 36
                    If GetKeyState(Keys.Up) < 0 And tank.Top <> 0 And Not hitAnySide(tank, 2) Then




                        keyResponse(0)
                        If ((Not main.Location.Y = 0) And (getY(tank) = 216)) Then
                            main.Location = New Point(main.Location.X, main.Location.Y + 2)
                        End If
                        tank.Top -= 2
                        send("mve|" + Str(id) + "|" + Str(0) + "|" + Str(tank.Location.X) + "|" + Str(tank.Location.Y) + "|" + keyResponse(0, 3))
                    End If
                    If GetKeyState(Keys.Down) < 0 And tank.Bottom <> 864 And Not hitAnySide(tank, 0) Then


                        'Dim img = arr(i)
                        'img.RotateFlip(RotateFlipType.Rotate90FlipNone)
                        ''arr(i).rotateflip(RotateFlipType.Rotate90FlipNone)

                        keyResponse(4)
                        If ((Not main.Location.Y = 480 - 864) And (getY(tank) = 216)) Then
                            main.Location = New Point(main.Location.X, main.Location.Y - 2)
                        End If
                        tank.Top += 2



                        send("mve|" + Str(id) + "|" + Str(4) + "|" + Str(tank.Location.X) + "|" + Str(tank.Location.Y) + "|" + keyResponse(0, 3))
                    End If

                    If GetKeyState(Keys.Left) < 0 And tank.Left <> 0 And Not hitAnySide(tank, 1) Then


                        'Dim img = arr(i)
                        'img.RotateFlip(RotateFlipType.Rotate90FlipNone)
                        ''arr(i).rotateflip(RotateFlipType.Rotate90FlipNone)

                        keyResponse(6)
                        If (Not main.Location.X = 0) And (getX(tank) = 232) Then
                            main.Location = New Point(main.Location.X + 2, main.Location.Y)
                        End If
                        tank.Left -= 2
                        send("mve|" + Str(id) + "|" + Str(6) + "|" + Str(tank.Location.X) + "|" + Str(tank.Location.Y) + "|" + keyResponse(0, 3))
                    End If
                    If GetKeyState(Keys.Right) < 0 And tank.Right <> 864 And Not hitAnySide(tank, 3) Then

                        'rotate(tank, arr(i + color), 2)
                        'dir = 2
                        keyResponse(2)
                        If (Not main.Location.X = 512 - 864) And (getX(tank) = 232) Then
                            main.Location = New Point(main.Location.X - 2, main.Location.Y)
                        End If
                        tank.Left += 2
                        'i += 1
                        'i = i Mod 2
                        send("mve|" + Str(id) + "|" + Str(2) + "|" + Str(tank.Location.X) + "|" + Str(tank.Location.Y) + "|" + keyResponse(0, 3))
                    End If
                End If


            End If

            If GetKeyState(Keys.Space) < 0 And Not hasShoot = 2 And count = 0 Then
                Dim b As Ball

                Select Case dir
                    Case 0
                        b = New Ball(dir, New Point(tank.Left + 18, tank.Top - 18), arr(8), Me, (nB * 10) + id)
                    Case 1
                        b = New Ball(dir, New Point(tank.Right + 2, tank.Top - 18), arr(8), Me, (nB * 10) + id)
                    Case 2
                        b = New Ball(dir, New Point(tank.Right + 2, tank.Top + 18), arr(8), Me, (nB * 10) + id)
                    Case 3
                        b = New Ball(dir, New Point(tank.Right + 2, tank.Bottom + 2), arr(8), Me, (nB * 10) + id)
                    Case 4
                        b = New Ball(dir, New Point(tank.Left + 18, tank.Bottom + 2), arr(8), Me, (nB * 10) + id)
                    Case 5
                        b = New Ball(dir, New Point(tank.Left - 18, tank.Bottom + 2), arr(8), Me, (nB * 10) + id)
                    Case 6
                        b = New Ball(dir, New Point(tank.Left - 18, tank.Top + 18), arr(8), Me, (nB * 10) + id)
                    Case 7
                        b = New Ball(dir, New Point(tank.Left - 18, tank.Top - 18), arr(8), Me, (nB * 10) + id)

                End Select

                send("ball|" + Str(nB) + Str(id) + "|" + Str(b.ball.Left) + "|" + Str(b.ball.Top))
                nB += 1
                ' main.Controls.Add(b.ball)
                hasShoot += 1
                count = 1000
                Bullets.Start()
            End If
        End If
    End Sub

    Public Function getBool(ByVal f As Boolean) As Integer
        If f Then
            Return 1
        Else
            Return 0
        End If
    End Function

    Public Sub rotate(ByVal pict As PictureBox, ByVal img As Image, ByVal deruc As Integer)


        Dim new2 As Integer = deruc * 45
        Dim humph As Integer = new2 - 90
        Dim pic As Image = New Bitmap(img)

        Select Case humph
            Case -45, 315
                pic = RotateImage(pic, 315)
            Case 90, -270
                pic.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Case 180, -180
                pic.RotateFlip(RotateFlipType.Rotate180FlipNone)
            Case 270, -90
                pic.RotateFlip(RotateFlipType.Rotate270FlipNone)

            Case 0
                pic.RotateFlip(RotateFlipType.RotateNoneFlipNone)
            Case 225, -135
                pic = RotateImage(pic, 225)

            Case -225, 135
                pic = RotateImage(pic, 135)
            Case 45, -315
                pic = RotateImage(pic, 45)
        End Select
        pict.Image = pic


    End Sub

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

    Public Function hitAnySide(obj As Object, sde As Integer, Optional remove As Object = Nothing)
        Dim bool As Boolean = False


        For Each item In walls
            If item IsNot remove Then
                If hitSide(obj, item, sde) Then
                    bool = True

                    Exit For
                End If
            End If

        Next

        Return bool
    End Function

    Public Function keyResponse(ByVal dei, Optional b = 0)
        Static i As Int32 = 0
        If b = 0 Then
            Static changeQ As Int32 = 1
            rotate(tank, arr(i + color), dei)
            If changeQ = 0 Then

                i += 1
                i = i Mod 2
            End If
            dir = dei
            changeQ += 1
            changeQ = changeQ Mod 6
        End If
        Return Str(i)
    End Function


    Private Sub Bullets_Tick(sender As Object, e As EventArgs) Handles Bullets.Tick
        Do Until count = 0
            count -= 1

        Loop
        Bullets.Stop()
    End Sub


    Private Sub cmdCr_Click(sender As System.Object, e As System.EventArgs) Handles cmdCr.Click
        TitleScreen.SendToBack()
        TitleScreen.Enabled = False
        tmr.Start()
        tank = tnk1
        dir = 2
    End Sub

    Private Sub cmdCr_Leave(sender As Object, e As System.EventArgs) Handles cmdCr.MouseLeave


        cmdCr.Image = My.Resources.ss_3_176x176
    End Sub

    Private Sub cmdCr_MouseEnter(sender As Object, e As System.EventArgs) Handles cmdCr.MouseEnter
        Dim bit As New Bitmap(cmdCr.Image, New Size(160, 160))

        cmdCr.Image = bit
    End Sub

    Public Sub JoyStick(form As Object)
        Dim priv As New PrivateFontCollection
        priv.AddFontFile("prstart.ttf")
        For Each item In form.Controls
            If TypeOf item Is Label Or TypeOf item Is Button Then
                item.font = New Font(priv.Families(0), item.font.size, FontStyle.Regular)
            End If

            If TypeOf item Is Panel Then
                JoyStick(item)
            End If

        Next

    End Sub
    Private Sub cmdJoin_Click(sender As System.Object, e As System.EventArgs) Handles cmdJoin.Click
        TitleScreen.SendToBack()
        TitleScreen.Enabled = False
        client = New TcpClient(address, 7000)
        out = New StreamWriter(client.GetStream)
        inp = New StreamReader(client.GetStream)
        out.AutoFlush = True
        send(user)

        Dim port As String = inp.ReadLine()

        Dim str() As String = port.Split("|")
        client.Client.Close()


        client = New TcpClient(address, Int(str(1)))


        out = New StreamWriter(client.GetStream)
        inp = New StreamReader(client.GetStream)
        id = Int(str(2))

        tank = tanks.Item(id)
        Select Case Int(str(2))

            Case 1
                color = 2
                main.Location = New Point(512 - 864, -192)
                dir = 6

            Case 0
                color = Int(str(2)) * 2

                dir = 2
            Case 2
                color = Int(str(2)) * 2
                main.Location = New Point(-176, 0)
                dir = 4
            Case 3
                color = id * 2
                main.Location = New Point(-176, 480 - 864)
                dir = 0
        End Select
        Dim t As Threading.Thread = New Threading.Thread(AddressOf read)
        tmr.Start()
        t.SetApartmentState(Threading.ApartmentState.STA)
        t.Start()

    End Sub

    Private Sub cmdJoin_MouseEnter(sender As Object, e As System.EventArgs) Handles cmdJoin.MouseEnter
        Dim bit As New Bitmap(cmdJoin.Image, New Size(160, 160))

        cmdJoin.Image = bit
    End Sub

    Private Sub cmdJoin_MouseLeave(sender As Object, e As System.EventArgs) Handles cmdJoin.MouseLeave
        cmdJoin.Image = My.Resources.tnkg
    End Sub

    Public Sub read()
        While running
            Dim stri As String
            Try
                stri = inp.ReadLine
            Catch
            End Try
            If Not stri = vbNullString Then
                Dim strArr = stri.Split("|")
                Select strArr(0)
                    Case "mve"

                        Dim d As Integer = Int(strArr(2))

                        shift(tanks(Int(stri.Split("|")(1))), d, New Point(Int(strArr(3)), Int(strArr(4))), Int(strArr(1)), Int(strArr(5)))
                    Case "ball"
                        Dim b As fakeBall

                        b = New fakeBall(New Point(Int(strArr(2)), Int(strArr(3))), Int(strArr(1).Replace(" ", "")), Me)
                        balls.Add(b.id, b)

                    Case "bm"
                        balls.Item(Int(strArr(1))).move(New Point(Int(strArr(2)), Int(strArr(3))))

                    Case "bd"
                        balls.Item(Int(strArr(1))).distrophy()
                        balls.Remove(Int(strArr(1)))

                    Case "d"

                End Select
            End If

        End While
    End Sub

    Private Sub bTick(sender As System.Object, e As System.EventArgs)

    End Sub

    Public Sub send(ByVal txt As String)
        Try
            out.WriteLine(txt)
            out.Flush()
        Catch
        End Try
    End Sub

    Public Delegate Sub gg(pic As PictureBox, d As Integer, loc As Point, id As Integer, i As Integer)
    Public Sub shift(pic As PictureBox, d As Integer, loc As Point, id As Integer, i As Integer)
        If pic.InvokeRequired Then
            pic.Invoke(New gg(AddressOf shift), New Object() {pic, d, loc, id, i})
        Else
            pic.Location = loc
            rotate(pic, arr((id * 2) + i), d)

        End If

    End Sub





    Public Sub mov(sender As Ball, xv As Integer, yv As Integer)
        sender.ball.Left += xv
        sender.ball.Top += yv
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        e.Handled = True
        e.SuppressKeyPress = True
    End Sub
End Class
