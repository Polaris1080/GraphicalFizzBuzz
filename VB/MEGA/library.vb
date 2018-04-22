Public Structure Counter_Wrapper
    'Value/Property
    Private        Counter     As Integer      'カウンター
    Private Shared Counter_All As Integer = 0  'カウンター（全体での合計）
    'Getter/Setter
    Public Function GetString() As String  '[カウンター]を、＿＿＿＿＿＿＿Stringで出力
        Return Counter
    End Function
    Public Function GetRatio() As Double   '[カウンター／全体での合計]を、Doubleで出力
        Return Counter / Counter_All
    End Function
    'Function/Sub
    'インクリメント
    Friend Sub Increment
        Counter += 1  :  Counter_All += 1  '全体での合計も＋１
    End Sub
    Friend Sub Increment(Byref TargetText As String)  'TargetのTextも書き換える
        Counter += 1  :  Counter_All += 1  :  TargetText = CStr(Counter)
    End Sub
    'リセット
    Friend sub Reset(Optional ByVal Flag_ResetAll As Boolean = False)
        Counter = 0  :  Counter_All = If(Flag_ResetAll, 0, Counter_All)  'フラグがTrueなら、全体での合計もリセット
    End sub
    Friend sub Reset(Byref TargetText As String, Optional ByVal Flag_ResetAll As Boolean = False)  'TargetのTextも書き換える
        Counter = 0  :  Counter_All = If(Flag_ResetAll, 0, Counter_All)  :  TargetText = CStr(Counter)
    End sub
End Structure

Public Structure DateTime_Wrapper
    'Value/Property
    Shared Private Datetime As DateTime
    'Getter/Setter
    Friend Function GetSecond As Integer
        Return Datetime.Second
    End Function
    Friend Sub GetColor(ByRef Target As Color,  ByVal Flag_R As Boolean, ByVal Flag_G As Boolean, ByVal Flag_B As Boolean)  'Colorプロパティを書換え
        Dim Color_R As Double = if(Flag_R, ((DateTime.Hour   + 1)/24)*255, 0)
        Dim Color_G As Double = if(Flag_G, ((DateTime.Minute + 1)/60)*255, 0)
        Dim Color_B As Double = if(Flag_B, ((DateTime.Second + 1)/60)*255, 0)
        Target = Color.FromArgb(Color_R, Color_G, Color_B)
    End Sub
    Friend Sub GetText (ByRef Target As String, ByVal Command As String)  'Textプロパティを書換え
        Select Case Command
            Case "MD"  :  Target = $"{DateTime.Month }/{DateTime.Day}"
            Case "H"   :  Target = $"{DateTime.Hour  }:"
            Case "M"   :  Target = $"{DateTime.Minute}:"
            Case "S"   :  Target = $"{DateTime.Second}"
        End Select
    End Sub
    'Function/Sub
    '最新の時間に更新
    Friend Sub Now 
        Datetime = DateTime.Now
    End Sub
End Structure

Public Class Graph_Wrapper
    'Value/Property
    Private Const    GraphStart As Single =   0  'グラフ全体の＿始点
    Private Const    WidthAll   As Single = 250  'グラフ全体の＿長さ
    Friend  Property Brush      As Brush         'グラフ＿＿の＿＿色
    Friend  Property Y          As Single        'グラフ＿＿のＹ座標
    Friend  Property Height     As Single =  25  'グラフ＿＿の＿高さ
    Private          X          As Single        'グラフ＿＿のＸ座標
    Private          Width      As Single        'グラフ全体の＿長さ
    'Getter/Setter
    Friend Function GetWidth() As Single
        Return Width
    End Function
    Friend Sub      SetWidth(ByVal Ratio As Double)
        Width = WidthAll*Ratio 
    End Sub
    Friend Function GetX
        Return X
    End Function
    Friend Sub      SetX()  '１番目(FizzBuzz)
        X = GraphStart
    End Sub
    Friend Sub      SetX(ByVal P_Width As Single)  '２番目(Fizz)
        X = P_Width
    End Sub
    Friend Sub      SetX(ByVal P_X As Single, ByVal P_Width As Single)  '３・４番目(Buzz/Other)
        X = P_X + P_Width
    End Sub
End Class