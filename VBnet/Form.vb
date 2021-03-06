﻿Public Class Form
    'Class
    Private NowTime As DatetimeWrapper : Private Counter(3) As CounterWrapper : Private Graph(3) As GraphWrapper

    'Event
    ''' <summary>フォームが呼び出されたとき</summary>
    Private Sub FormLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        'クラスの初期化
        Counter(0) = New CounterWrapper : Graph(0) = New GraphWrapper With {.Brush = Brushes.LightPink, .Y = 0}   'FizzBuzz
        Counter(1) = New CounterWrapper : Graph(1) = New GraphWrapper With {.Brush = Brushes.LightGreen, .Y = 25} 'Fizz
        Counter(2) = New CounterWrapper : Graph(2) = New GraphWrapper With {.Brush = Brushes.LightBlue, .Y = 50}  'Buzz
        Counter(3) = New CounterWrapper : Graph(3) = New GraphWrapper With {.Brush = Brushes.LightGray, .Y = 75}  'Other

        Timer_1s.Start() 'タイマーを起動する
    End Sub

    ''' <summary>タイマー[Timer_1s.Start()]から呼び出される</summary>
    Private Sub TimerRefresh(sender As Object, e As EventArgs) Handles Timer_1s.Tick
        NowTime.Now() '最新の時間に更新

        '時計の色・表示を変更する
        NowTime.GetColor(Watch_MonthDay.ForeColor, True, False, False) : NowTime.GetText(Watch_MonthDay.Text, "MD")
        NowTime.GetColor(Watch_Hour.ForeColor, False, True, False) : NowTime.GetText(Watch_Hour.Text, "H")
        NowTime.GetColor(Watch_Minite.ForeColor, False, False, True) : NowTime.GetText(Watch_Minite.Text, "M")
        NowTime.GetColor(Watch_Second.ForeColor, True, True, True) : NowTime.GetText(Watch_Second.Text, "S")

        FizzBuzz(NowTime.GetSecond)
        Me.Refresh()
    End Sub

    ''' <summary>描画コマンド[Me.Refresh()]から呼び出される　棒グラフを描画する</summary>
    Private Sub FormPaint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        For i = 0 To 3 : Graph(i).SetWidth(Counter(i).GetRatio) : Next 'Widthを求める

        'Xを求める
        Graph(0).SetX() : Graph(1).SetX(Graph(0).GetWidth())
        Graph(2).SetX(Graph(1).GetX, Graph(1).GetWidth()) : Graph(3).SetX(Graph(2).GetX, Graph(2).GetWidth())

        For i = 0 To 3 : e.Graphics.FillRectangle(Graph(i).Brush, Graph(i).GetX, Graph(i).Y, Graph(i).GetWidth(), Graph(i).Height) : Next  '棒グラフを描画
    End Sub

    ''' <summary>秒[Label_Second]がクリックされたとき、カウンターをリセットする。</summary>
    Private Sub CounterReset(sender As Object, e As EventArgs) Handles Watch_Second.Click
        Counter(0).Reset(Counter_FizzBuzz.Text) : Counter(1).Reset(Counter_Fizz.Text)
        Counter(2).Reset(Counter_Buzz.Text) : Counter(3).Reset(Counter_Other.Text, True)
    End Sub

    'Function/Sub
    ''' <summary>Fizzbuzz</summary><param name="Second">判定基準となる秒数</param>
    Private Sub FizzBuzz(ByVal Second As Integer)
        If (Second Mod 3 = 0) Then 'Fizz or FizzBuzz
            Indicator_Fizz.Visible = True
            If (Second Mod 5 = 0) Then
                Indicator_Buzz.Visible = True : Counter(0).Increment(Counter_FizzBuzz.Text)  'FizzBuzz
            Else
                Indicator_Buzz.Visible = False : Counter(1).Increment(Counter_Fizz.Text)      'Fizz
            End If
        Else 'Buzz or Other
            Indicator_Fizz.Visible = False
            If (Second Mod 5 = 0) Then
                Indicator_Buzz.Visible = True : Counter(2).Increment(Counter_Buzz.Text)      'Buzz
            Else
                Indicator_Buzz.Visible = False : Counter(3).Increment(Counter_Other.Text)     'Other
            End If
        End If
    End Sub
End Class