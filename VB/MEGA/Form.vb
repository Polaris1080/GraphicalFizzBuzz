Public Class Form
    'Class
    Private NowTime As New DateTime_Wrapper  :  Private Counter(3) As Counter_Wrapper  :  Private Graph(3) As Graph_Wrapper

    'Event
    Private Sub FormLoad    (sender As Object, e As EventArgs)      Handles MyBase.Load         'フォームが呼び出されたとき
        'クラスの初期化
        Counter(0) = new Counter_Wrapper : Graph(0) = New Graph_Wrapper With {.Brush = Brushes.LightPink,  .Y =  0}'FizzBuzz
        Counter(1) = new Counter_Wrapper : Graph(1) = New Graph_Wrapper With {.Brush = Brushes.LightGreen, .Y = 25}'Fizz
        Counter(2) = new Counter_Wrapper : Graph(2) = New Graph_Wrapper With {.Brush = Brushes.LightBlue,  .Y = 50}'Buzz
        Counter(3) = new Counter_Wrapper : Graph(3) = New Graph_Wrapper With {.Brush = Brushes.LightGray,  .Y = 75}'Other

        Timer_1s.Start()  'タイマーを起動する
    End Sub
    Private Sub TimerRefresh(sender As Object, e As EventArgs)      Handles Timer_1s.Tick       'タイマー[Timer_1s.Start()]から呼び出される
        NowTime.Now  '最新の時間に更新する

        '時計の色・表示を変更する
        NowTime.GetColor(Watch_MonthDay.ForeColor, True , False, False) : NowTime.GetText(Watch_MonthDay.Text, "MD")
        NowTime.GetColor(Watch_Hour    .ForeColor, False, True , False) : NowTime.GetText(Watch_Hour    .Text, "H" )
        NowTime.GetColor(Watch_Minite  .ForeColor, False, False, True ) : NowTime.GetText(Watch_Minite  .Text, "M" )
        NowTime.GetColor(Watch_Second  .ForeColor, True , True , True ) : NowTime.GetText(Watch_Second  .Text, "S" )

        FizzBuzz  (NowTime.GetSecond)  'FizzBuzz
        Me.Refresh()                   '棒グラフを描画する
    End Sub
    Private Sub FormPaint   (sender As Object, e As PaintEventArgs) Handles MyBase.Paint        '描画コマンド[Me.Refresh()]から呼び出される
        For i = 0 To 3 : Graph(i).SetWidth(Counter(i).GetRatio) : Next  'Widthを求める

        'Xを求める
        Graph(0).SetX()                                    :  Graph(1).SetX(Graph(0).GetWidth())
        Graph(2).SetX(Graph(1).GetX, Graph(1).GetWidth())  :  Graph(3).SetX(Graph(2).GetX, Graph(2).GetWidth())

        For i = 0 To 3 : e.Graphics.FillRectangle(Graph(i).Brush, Graph(i).GetX, Graph(i).Y, Graph(i).GetWidth(), Graph(i).Height) : Next  '棒グラフを描画
    End Sub
    Private Sub CounterReset(sender As Object, e As EventArgs)      Handles Watch_Second.Click  '秒[Label_Second]がクリックされたとき
        'カウンターのリセット
        COUNTER(0).Reset(Counter_FizzBuzz.Text)  :  COUNTER(1).Reset(Counter_Fizz .Text      )
        COUNTER(2).Reset(Counter_Buzz    .Text)  :  COUNTER(3).Reset(Counter_Other.Text, True)
    End Sub

    'Function/Sub
    Private Sub FizzBuzz(ByVal Second As Integer) 'Fizzbuzz
        If     (Second Mod 3 = 0) Then  'Fizz or FizzBuzz
            Indicator_Fizz.Visible = True
            If (Second Mod 5 = 0) Then
                Indicator_Buzz.Visible = True   :  Counter(0).Increment(Counter_FizzBuzz.Text)  'FizzBuzz
            Else
                Indicator_Buzz.Visible = False  :  Counter(1).Increment(Counter_Fizz.Text)      'Fizz
            End If
        Else                            'Buzz or Other
            Indicator_Fizz.Visible = False
            If (Second Mod 5 = 0) Then
                Indicator_Buzz.Visible = True   :  Counter(2).Increment(Counter_Buzz.Text)      'Buzz
            Else
                Indicator_Buzz.Visible = False  :  Counter(3).Increment(Counter_Other.Text)     'Other
            End If
        End If
    End Sub
End Class