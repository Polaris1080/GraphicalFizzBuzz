''' <summary>カウンター機能のラッパー</summary>
Public Structure CounterWrapper
    'Value/Property
    ''' <summary>カウンター</summary>
    Private Counter As Integer
    ''' <summary>カウンター（全体での合計）</summary>
    Private Shared Counter_All As Integer = 0

    'Getter/Setter
    ''' <summary>[カウンター]を、Stringで出力</summary>
    Public Function GetString() As String
        Return Counter
    End Function
    ''' <summary>[カウンター／全体での合計]を、Doubleで出力</summary>
    Public Function GetRatio() As Double
        Return Counter / Counter_All
    End Function

    'Function/Sub
    ''' <summary>インクリメント</summary>
    Friend Sub Increment()
        Counter += 1 : Counter_All += 1 '全体での合計も＋１
    End Sub
    ''' <summary>インクリメント</summary><param name="TargetText">Textを書き換える対象</param>
    Friend Sub Increment(ByRef TargetText As String)
        Counter += 1 : Counter_All += 1 : TargetText = CStr(Counter)
    End Sub

    ''' <summary>リセット</summary>
    ''' <param name="Flag_ResetAll">Trueなら、全体での合計もリセット</param>
    Friend Sub Reset(Optional ByVal Flag_ResetAll As Boolean = False)
        Counter = 0 : Counter_All = If(Flag_ResetAll, 0, Counter_All)
    End Sub
    ''' <summary>リセット</summary>
    ''' <param name="TargetText">Textを書き換える対象</param>
    ''' <param name="Flag_ResetAll">Trueなら、全体での合計もリセット</param>
    Friend Sub Reset(ByRef TargetText As String, Optional ByVal Flag_ResetAll As Boolean = False)  'TargetのTextも書き換える
        Counter = 0 : Counter_All = If(Flag_ResetAll, 0, Counter_All) : TargetText = CStr(Counter)
    End Sub
End Structure

''' <summary>DataTime機能のラッパー</summary>
Public Structure DatetimeWrapper
    'Value/Property
    Private Shared Datetime As DateTime

    'Getter/Setter
    ''' <summary>現在の秒数を取得</summary>
    Friend Function GetSecond() As Integer
        Return Datetime.Second
    End Function

    ''' <summary>現在の時間(Datetime)から、色を計算して、Colorプロパティを書換え</summary>
    ''' <param name="Target">Colorプロパティを書換える対象</param>
    ''' <param name="Flag_R">Rチャンネルが必要か?</param>
    ''' <param name="Flag_G">Gチャンネルが必要か?</param>
    ''' <param name="Flag_B">Bチャンネルが必要か?</param>
    Friend Sub GetColor(ByRef Target As Color, ByVal Flag_R As Boolean, ByVal Flag_G As Boolean, ByVal Flag_B As Boolean)
        Dim Color_R As Double = If(Flag_R, ((Datetime.Hour + 1) / 24) * 255, 0)
        Dim Color_G As Double = If(Flag_G, ((Datetime.Minute + 1) / 60) * 255, 0)
        Dim Color_B As Double = If(Flag_B, ((Datetime.Second + 1) / 60) * 255, 0)
        Target = Color.FromArgb(Color_R, Color_G, Color_B)
    End Sub

    ''' <summary>Textプロパティを書換え</summary>
    ''' <param name="Target">Textプロパティを書換える対象</param>
    ''' <param name="Command">種別判定文字列</param>
    Friend Sub GetText(ByRef Target As String, ByVal Command As String)
        Select Case Command
            Case "MD" : Target = $"{Datetime.Month }/{Datetime.Day}"
            Case "H" : Target = $"{Datetime.Hour  }:"
            Case "M" : Target = $"{Datetime.Minute}:"
            Case "S" : Target = $"{Datetime.Second}"
        End Select
    End Sub

    'Function/Sub
    ''' <summary>最新の時間に更新</summary>
    Friend Sub Now()
        Datetime = DateTime.Now
    End Sub
End Structure

''' <summary>グラフ機能のラッパー</summary>
Public Class GraphWrapper
    'Value/Property
    ''' <summary>グラフ全体の始点</summary>
    Private Const GraphStart As Single = 0
    ''' <summary>グラフ全体の長さ</summary>
    Private Const WidthAll As Single = 250
    ''' <summary>グラフの色</summary>
    Friend Property Brush As Brush
    ''' <summary>グラフのＹ座標</summary>
    Friend Property Y As Single
    ''' <summary>グラフの高さ</summary>
    Friend Property Height As Single = 25
    ''' <summary>グラフのＸ座標</summary>
    Private X As Single
    ''' <summary>グラフの長さ</summary>
    Private Width As Single

    'Getter/Setter
    ''' <summary>グラフの長さを取得</summary>
    Friend Function GetWidth() As Single
        Return Width
    End Function
    ''' <summary>グラフの長さを設定</summary>
    Friend Sub SetWidth(ByVal Ratio As Double)
        Width = WidthAll * Ratio
    End Sub

    ''' <summary>グラフのＸ座標を取得(FizzBuzz)</summary>
    Friend Function GetX()
        Return X
    End Function
    ''' <summary>グラフのＸ座標を設定(FizzBuzz)</summary>
    Friend Sub SetX()
        X = GraphStart
    End Sub
    ''' <summary>グラフのＸ座標を設定(Fizz)</summary>
    ''' <param name="P_Width">FizzBuzzの長さ</param>
    Friend Sub SetX(ByVal P_Width As Single)
        X = P_Width
    End Sub
    ''' <summary>グラフのＸ座標を設定(Buzz/Other)</summary>
    ''' <param name="P_X">FizzBuzz/FizzのＸ座標</param>
    ''' <param name="P_Width">Fizz/Buzzの長さ</param>
    Friend Sub SetX(ByVal P_X As Single, ByVal P_Width As Single)
        X = P_X + P_Width
    End Sub
End Class