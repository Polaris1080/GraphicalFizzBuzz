<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer_1s = New System.Windows.Forms.Timer(Me.components)
        Me.Watch_MonthDay = New System.Windows.Forms.Label()
        Me.Watch_Second = New System.Windows.Forms.Label()
        Me.Indicator_Buzz = New System.Windows.Forms.Label()
        Me.Indicator_Fizz = New System.Windows.Forms.Label()
        Me.Watch_Hour = New System.Windows.Forms.Label()
        Me.Counter_Other = New System.Windows.Forms.Label()
        Me.Counter_Buzz = New System.Windows.Forms.Label()
        Me.Counter_Fizz = New System.Windows.Forms.Label()
        Me.Counter_FizzBuzz = New System.Windows.Forms.Label()
        Me.Watch_Minite = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'Timer_1s
        '
        Me.Timer_1s.Interval = 1000
        '
        'Watch_MonthDay
        '
        Me.Watch_MonthDay.AutoSize = true
        Me.Watch_MonthDay.BackColor = System.Drawing.Color.Transparent
        Me.Watch_MonthDay.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 36!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Watch_MonthDay.Location = New System.Drawing.Point(0, 0)
        Me.Watch_MonthDay.Name = "Watch_MonthDay"
        Me.Watch_MonthDay.Size = New System.Drawing.Size(140, 48)
        Me.Watch_MonthDay.TabIndex = 8
        Me.Watch_MonthDay.Text = "00/00"
        '
        'Watch_Second
        '
        Me.Watch_Second.AutoSize = true
        Me.Watch_Second.BackColor = System.Drawing.Color.Transparent
        Me.Watch_Second.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 72!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Watch_Second.Location = New System.Drawing.Point(125, 0)
        Me.Watch_Second.Name = "Watch_Second"
        Me.Watch_Second.Size = New System.Drawing.Size(138, 97)
        Me.Watch_Second.TabIndex = 3
        Me.Watch_Second.Text = "00"
        '
        'Indicator_Buzz
        '
        Me.Indicator_Buzz.AutoSize = true
        Me.Indicator_Buzz.BackColor = System.Drawing.Color.Transparent
        Me.Indicator_Buzz.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 24!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Indicator_Buzz.Location = New System.Drawing.Point(257, 60)
        Me.Indicator_Buzz.Name = "Indicator_Buzz"
        Me.Indicator_Buzz.Size = New System.Drawing.Size(81, 33)
        Me.Indicator_Buzz.TabIndex = 2
        Me.Indicator_Buzz.Text = "Buzz"
        Me.Indicator_Buzz.Visible = false
        '
        'Indicator_Fizz
        '
        Me.Indicator_Fizz.AutoSize = true
        Me.Indicator_Fizz.BackColor = System.Drawing.Color.Transparent
        Me.Indicator_Fizz.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 24!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Indicator_Fizz.Location = New System.Drawing.Point(257, 15)
        Me.Indicator_Fizz.Name = "Indicator_Fizz"
        Me.Indicator_Fizz.Size = New System.Drawing.Size(70, 33)
        Me.Indicator_Fizz.TabIndex = 1
        Me.Indicator_Fizz.Text = "Fizz"
        Me.Indicator_Fizz.Visible = false
        '
        'Watch_Hour
        '
        Me.Watch_Hour.AutoSize = true
        Me.Watch_Hour.BackColor = System.Drawing.Color.Transparent
        Me.Watch_Hour.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 36!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Watch_Hour.Location = New System.Drawing.Point(0, 50)
        Me.Watch_Hour.Name = "Watch_Hour"
        Me.Watch_Hour.Size = New System.Drawing.Size(78, 48)
        Me.Watch_Hour.TabIndex = 0
        Me.Watch_Hour.Text = "00:"
        '
        'Counter_Other
        '
        Me.Counter_Other.AutoSize = true
        Me.Counter_Other.BackColor = System.Drawing.Color.Transparent
        Me.Counter_Other.Font = New System.Drawing.Font("MS UI Gothic", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Counter_Other.ForeColor = System.Drawing.Color.Black
        Me.Counter_Other.Location = New System.Drawing.Point(330, 75)
        Me.Counter_Other.Name = "Counter_Other"
        Me.Counter_Other.Size = New System.Drawing.Size(22, 24)
        Me.Counter_Other.TabIndex = 7
        Me.Counter_Other.Text = "0"
        '
        'Counter_Buzz
        '
        Me.Counter_Buzz.AutoSize = true
        Me.Counter_Buzz.BackColor = System.Drawing.Color.Transparent
        Me.Counter_Buzz.Font = New System.Drawing.Font("MS UI Gothic", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Counter_Buzz.ForeColor = System.Drawing.Color.Blue
        Me.Counter_Buzz.Location = New System.Drawing.Point(330, 51)
        Me.Counter_Buzz.Name = "Counter_Buzz"
        Me.Counter_Buzz.Size = New System.Drawing.Size(22, 24)
        Me.Counter_Buzz.TabIndex = 6
        Me.Counter_Buzz.Text = "0"
        '
        'Counter_Fizz
        '
        Me.Counter_Fizz.AutoSize = true
        Me.Counter_Fizz.BackColor = System.Drawing.Color.Transparent
        Me.Counter_Fizz.Font = New System.Drawing.Font("MS UI Gothic", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Counter_Fizz.ForeColor = System.Drawing.Color.Green
        Me.Counter_Fizz.Location = New System.Drawing.Point(330, 26)
        Me.Counter_Fizz.Name = "Counter_Fizz"
        Me.Counter_Fizz.Size = New System.Drawing.Size(22, 24)
        Me.Counter_Fizz.TabIndex = 5
        Me.Counter_Fizz.Text = "0"
        '
        'Counter_FizzBuzz
        '
        Me.Counter_FizzBuzz.AutoSize = true
        Me.Counter_FizzBuzz.BackColor = System.Drawing.Color.Transparent
        Me.Counter_FizzBuzz.Font = New System.Drawing.Font("MS UI Gothic", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Counter_FizzBuzz.ForeColor = System.Drawing.Color.Red
        Me.Counter_FizzBuzz.Location = New System.Drawing.Point(330, 0)
        Me.Counter_FizzBuzz.Name = "Counter_FizzBuzz"
        Me.Counter_FizzBuzz.Size = New System.Drawing.Size(22, 24)
        Me.Counter_FizzBuzz.TabIndex = 4
        Me.Counter_FizzBuzz.Text = "0"
        '
        'Watch_Minite
        '
        Me.Watch_Minite.AutoSize = true
        Me.Watch_Minite.BackColor = System.Drawing.Color.Transparent
        Me.Watch_Minite.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 36!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Watch_Minite.Location = New System.Drawing.Point(65, 50)
        Me.Watch_Minite.Name = "Watch_Minite"
        Me.Watch_Minite.Size = New System.Drawing.Size(78, 48)
        Me.Watch_Minite.TabIndex = 11
        Me.Watch_Minite.Text = "00:"
        '
        'Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 12!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(384, 109)
        Me.ControlBox = false
        Me.Controls.Add(Me.Watch_Minite)
        Me.Controls.Add(Me.Counter_FizzBuzz)
        Me.Controls.Add(Me.Watch_MonthDay)
        Me.Controls.Add(Me.Counter_Buzz)
        Me.Controls.Add(Me.Counter_Fizz)
        Me.Controls.Add(Me.Counter_Other)
        Me.Controls.Add(Me.Watch_Second)
        Me.Controls.Add(Me.Indicator_Buzz)
        Me.Controls.Add(Me.Indicator_Fizz)
        Me.Controls.Add(Me.Watch_Hour)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MaximizeBox = false
        Me.MaximumSize = New System.Drawing.Size(400, 125)
        Me.MinimizeBox = false
        Me.Name = "Form"
        Me.ShowIcon = false
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents Timer_1s As Timer
    Friend WithEvents Watch_Second As Label
    Friend WithEvents Indicator_Buzz As Label
    Friend WithEvents Indicator_Fizz As Label
    Friend WithEvents Watch_Hour As Label
    Friend WithEvents Counter_Other As Label
    Friend WithEvents Counter_Buzz As Label
    Friend WithEvents Counter_Fizz As Label
    Friend WithEvents Counter_FizzBuzz As Label
    Friend WithEvents Watch_MonthDay As Label
    Friend WithEvents Watch_Minite As Label
End Class
