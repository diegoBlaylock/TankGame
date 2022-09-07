<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.tmr = New System.Windows.Forms.Timer(Me.components)
        Me.Bullets = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TitleScreen = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdJoin = New System.Windows.Forms.Button()
        Me.cmdCr = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Screen = New System.Windows.Forms.Panel()
        Me.main = New System.Windows.Forms.Panel()
        Me.tnk4 = New System.Windows.Forms.PictureBox()
        Me.tnk3 = New System.Windows.Forms.PictureBox()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.tnk2 = New System.Windows.Forms.PictureBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tnk1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.TitleScreen.SuspendLayout()
        Me.Screen.SuspendLayout()
        Me.main.SuspendLayout()
        CType(Me.tnk4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnk3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnk2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnk1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmr
        '
        Me.tmr.Interval = 8
        '
        'Bullets
        '
        Me.Bullets.Interval = 400
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.Screen)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(512, 584)
        Me.Panel1.TabIndex = 4
        '
        'TitleScreen
        '
        Me.TitleScreen.BackColor = System.Drawing.Color.SaddleBrown
        Me.TitleScreen.BackgroundImage = Global.Tank.My.Resources.Resources.New_Piskel
        Me.TitleScreen.Controls.Add(Me.Label3)
        Me.TitleScreen.Controls.Add(Me.Label1)
        Me.TitleScreen.Controls.Add(Me.cmdJoin)
        Me.TitleScreen.Controls.Add(Me.cmdCr)
        Me.TitleScreen.Controls.Add(Me.lblTitle)
        Me.TitleScreen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TitleScreen.Location = New System.Drawing.Point(0, 0)
        Me.TitleScreen.Name = "TitleScreen"
        Me.TitleScreen.Size = New System.Drawing.Size(512, 584)
        Me.TitleScreen.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.Label3.Location = New System.Drawing.Point(122, 512)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 29)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "By "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.Label1.Location = New System.Drawing.Point(188, 225)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "V 2.2.1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdJoin
        '
        Me.cmdJoin.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdJoin.BackgroundImage = Global.Tank.My.Resources.Resources.New_Piskel
        Me.cmdJoin.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.cmdJoin.FlatAppearance.BorderSize = 0
        Me.cmdJoin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdJoin.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdJoin.ForeColor = System.Drawing.Color.DarkRed
        Me.cmdJoin.Image = Global.Tank.My.Resources.Resources.tnkg
        Me.cmdJoin.Location = New System.Drawing.Point(295, 291)
        Me.cmdJoin.Name = "cmdJoin"
        Me.cmdJoin.Size = New System.Drawing.Size(176, 176)
        Me.cmdJoin.TabIndex = 2
        Me.cmdJoin.TabStop = False
        Me.cmdJoin.Text = "Join Room"
        Me.cmdJoin.UseVisualStyleBackColor = False
        '
        'cmdCr
        '
        Me.cmdCr.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdCr.BackgroundImage = Global.Tank.My.Resources.Resources.New_Piskel
        Me.cmdCr.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.cmdCr.FlatAppearance.BorderSize = 0
        Me.cmdCr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCr.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.cmdCr.Image = Global.Tank.My.Resources.Resources.ss_3_176x176
        Me.cmdCr.Location = New System.Drawing.Point(31, 291)
        Me.cmdCr.Name = "cmdCr"
        Me.cmdCr.Size = New System.Drawing.Size(176, 176)
        Me.cmdCr.TabIndex = 1
        Me.cmdCr.TabStop = False
        Me.cmdCr.Text = "Create Room"
        Me.cmdCr.UseVisualStyleBackColor = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 56.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.OliveDrab
        Me.lblTitle.Location = New System.Drawing.Point(24, 35)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(300, 170)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "VB" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Combat"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Screen
        '
        Me.Screen.BackColor = System.Drawing.SystemColors.InfoText
        Me.Screen.BackgroundImage = Global.Tank.My.Resources.Resources.New_Piskel
        Me.Screen.Controls.Add(Me.main)
        Me.Screen.Location = New System.Drawing.Point(0, 80)
        Me.Screen.Name = "Screen"
        Me.Screen.Size = New System.Drawing.Size(512, 480)
        Me.Screen.TabIndex = 1
        '
        'main
        '
        Me.main.BackColor = System.Drawing.Color.Black
        Me.main.BackgroundImage = Global.Tank.My.Resources.Resources.New_Piskel1
        Me.main.Controls.Add(Me.tnk4)
        Me.main.Controls.Add(Me.tnk3)
        Me.main.Controls.Add(Me.Panel16)
        Me.main.Controls.Add(Me.Panel15)
        Me.main.Controls.Add(Me.Panel7)
        Me.main.Controls.Add(Me.Panel14)
        Me.main.Controls.Add(Me.Panel13)
        Me.main.Controls.Add(Me.Panel12)
        Me.main.Controls.Add(Me.Panel11)
        Me.main.Controls.Add(Me.Panel9)
        Me.main.Controls.Add(Me.Panel10)
        Me.main.Controls.Add(Me.Panel8)
        Me.main.Controls.Add(Me.Panel6)
        Me.main.Controls.Add(Me.tnk2)
        Me.main.Controls.Add(Me.Panel5)
        Me.main.Controls.Add(Me.Panel4)
        Me.main.Controls.Add(Me.Panel3)
        Me.main.Controls.Add(Me.Panel2)
        Me.main.Controls.Add(Me.tnk1)
        Me.main.Location = New System.Drawing.Point(0, 0)
        Me.main.Name = "main"
        Me.main.Size = New System.Drawing.Size(864, 864)
        Me.main.TabIndex = 0
        '
        'tnk4
        '
        Me.tnk4.BackColor = System.Drawing.Color.Transparent
        Me.tnk4.Location = New System.Drawing.Point(408, 752)
        Me.tnk4.Name = "tnk4"
        Me.tnk4.Size = New System.Drawing.Size(48, 48)
        Me.tnk4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.tnk4.TabIndex = 19
        Me.tnk4.TabStop = False
        '
        'tnk3
        '
        Me.tnk3.BackColor = System.Drawing.Color.Transparent
        Me.tnk3.Location = New System.Drawing.Point(408, 154)
        Me.tnk3.Name = "tnk3"
        Me.tnk3.Size = New System.Drawing.Size(48, 48)
        Me.tnk3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.tnk3.TabIndex = 18
        Me.tnk3.TabStop = False
        '
        'Panel16
        '
        Me.Panel16.BackgroundImage = CType(resources.GetObject("Panel16.BackgroundImage"), System.Drawing.Image)
        Me.Panel16.Location = New System.Drawing.Point(530, 154)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(192, 32)
        Me.Panel16.TabIndex = 17
        '
        'Panel15
        '
        Me.Panel15.BackgroundImage = CType(resources.GetObject("Panel15.BackgroundImage"), System.Drawing.Image)
        Me.Panel15.Location = New System.Drawing.Point(142, 656)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(32, 96)
        Me.Panel15.TabIndex = 16
        '
        'Panel7
        '
        Me.Panel7.BackgroundImage = Global.Tank.My.Resources.Resources.Imported_piskel__2_
        Me.Panel7.Location = New System.Drawing.Point(690, 656)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(32, 96)
        Me.Panel7.TabIndex = 15
        '
        'Panel14
        '
        Me.Panel14.BackgroundImage = Global.Tank.My.Resources.Resources.Imported_piskel__2_
        Me.Panel14.Location = New System.Drawing.Point(142, 154)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(192, 32)
        Me.Panel14.TabIndex = 14
        '
        'Panel13
        '
        Me.Panel13.BackgroundImage = Global.Tank.My.Resources.Resources.Imported_piskel__2_
        Me.Panel13.Location = New System.Drawing.Point(284, 288)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(296, 32)
        Me.Panel13.TabIndex = 13
        '
        'Panel12
        '
        Me.Panel12.BackgroundImage = Global.Tank.My.Resources.Resources.Imported_piskel__2_
        Me.Panel12.Location = New System.Drawing.Point(142, 320)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(32, 240)
        Me.Panel12.TabIndex = 12
        '
        'Panel11
        '
        Me.Panel11.BackgroundImage = Global.Tank.My.Resources.Resources.Imported_piskel__2_
        Me.Panel11.Location = New System.Drawing.Point(690, 320)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(32, 240)
        Me.Panel11.TabIndex = 11
        '
        'Panel9
        '
        Me.Panel9.BackgroundImage = Global.Tank.My.Resources.Resources.Imported_piskel__2_
        Me.Panel9.Location = New System.Drawing.Point(416, 592)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(32, 96)
        Me.Panel9.TabIndex = 10
        '
        'Panel10
        '
        Me.Panel10.BackgroundImage = Global.Tank.My.Resources.Resources.Imported_piskel__2_
        Me.Panel10.Location = New System.Drawing.Point(284, 560)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(296, 32)
        Me.Panel10.TabIndex = 9
        '
        'Panel8
        '
        Me.Panel8.BackgroundImage = Global.Tank.My.Resources.Resources.Imported_piskel__2_
        Me.Panel8.Location = New System.Drawing.Point(416, 320)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(32, 96)
        Me.Panel8.TabIndex = 8
        '
        'Panel6
        '
        Me.Panel6.BackgroundImage = Global.Tank.My.Resources.Resources.Imported_piskel__2_
        Me.Panel6.Location = New System.Drawing.Point(416, 32)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(32, 96)
        Me.Panel6.TabIndex = 6
        '
        'tnk2
        '
        Me.tnk2.BackColor = System.Drawing.Color.Transparent
        Me.tnk2.Location = New System.Drawing.Point(754, 408)
        Me.tnk2.Name = "tnk2"
        Me.tnk2.Size = New System.Drawing.Size(48, 48)
        Me.tnk2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.tnk2.TabIndex = 5
        Me.tnk2.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.BackgroundImage = Global.Tank.My.Resources.Resources.Imported_piskel__2_
        Me.Panel5.Location = New System.Drawing.Point(0, 832)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(864, 32)
        Me.Panel5.TabIndex = 4
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = Global.Tank.My.Resources.Resources.Imported_piskel__2_
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(864, 32)
        Me.Panel4.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = Global.Tank.My.Resources.Resources.Imported_piskel__2_
        Me.Panel3.Location = New System.Drawing.Point(832, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(32, 864)
        Me.Panel3.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.Tank.My.Resources.Resources.Imported_piskel__2_
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(32, 864)
        Me.Panel2.TabIndex = 1
        '
        'tnk1
        '
        Me.tnk1.BackColor = System.Drawing.Color.Transparent
        Me.tnk1.Location = New System.Drawing.Point(64, 408)
        Me.tnk1.Name = "tnk1"
        Me.tnk1.Size = New System.Drawing.Size(48, 48)
        Me.tnk1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.tnk1.TabIndex = 0
        Me.tnk1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuText
        Me.ClientSize = New System.Drawing.Size(512, 584)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TitleScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Combat"
        Me.Panel1.ResumeLayout(False)
        Me.TitleScreen.ResumeLayout(False)
        Me.TitleScreen.PerformLayout()
        Me.Screen.ResumeLayout(False)
        Me.main.ResumeLayout(False)
        CType(Me.tnk4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnk3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnk2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnk1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmr As System.Windows.Forms.Timer
    Friend WithEvents Bullets As System.Windows.Forms.Timer
    Friend WithEvents Screen As System.Windows.Forms.Panel
    Friend WithEvents main As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents TitleScreen As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents cmdCr As System.Windows.Forms.Button
    Friend WithEvents cmdJoin As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Public WithEvents tnk1 As System.Windows.Forms.PictureBox
    Public WithEvents tnk2 As System.Windows.Forms.PictureBox
    Public WithEvents tnk4 As System.Windows.Forms.PictureBox
    Public WithEvents tnk3 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
