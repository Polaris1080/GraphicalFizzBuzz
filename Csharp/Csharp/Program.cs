using System;  using System.Text;

namespace MEGA
{
    class Csharp
    {
        //変数
        static DateTime Clock;               //時刻
        static int[]    Count = new int[4];  //カウンター [FizzBuzz,Fizz.Buzz,Other]
        static int      CountAll;            //カウンターの合計値
        static bool     F_Fizz, F_Buzz;      //FizzBuzzを管理するフラグ

        //クラス
        static SeedText ST_Watch = new SeedText(ConsoleColor.Black  , ConsoleColor.White);        //表示_時計
        static SeedText ST_Fizz  = new SeedText(ConsoleColor.Magenta, ConsoleColor.DarkMagenta);  //表示_Fizz
        static SeedText ST_Buzz  = new SeedText(ConsoleColor.Cyan   , ConsoleColor.DarkCyan);     //表示_Buzz
        static SeedText ST_CountFizzBuzz = new SeedText(ConsoleColor.Red   , ConsoleColor.DarkRed);     //カウンター_FizzBuzz
        static SeedText ST_CountFizz     = new SeedText(ConsoleColor.Green , ConsoleColor.DarkGreen);   //カウンター_Fizz
        static SeedText ST_CountBuzz     = new SeedText(ConsoleColor.Blue  , ConsoleColor.DarkBlue);    //カウンター_Buzz
        static SeedText ST_CountOther    = new SeedText(ConsoleColor.Yellow, ConsoleColor.DarkYellow);  //カウンター_Other

        //イベント
        static void Main()  //メインループ
        {
            //タイマーを設定
            System.Timers.Timer timer1 = new System.Timers.Timer { Interval = 1000.0 };  //1秒ごとに起動
            timer1.Elapsed += Timer1_Elapsed;  //イベントを登録
            timer1.Enabled = true;  //タイマーの起動

            //何かキーを押すと終了
            Console.ReadKey();
        }
        static void Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)  //タイマーからのイベント
        {
            //最新の時間に更新
            Clock = DateTime.Now;

            //FizzBuzz
            {
                int T_Fizz = Clock.Second % 3; int T_Buzz = Clock.Second % 5;  //事前に余剰を計算しておく

                if (T_Fizz == 0)  //run
                {
                    if (T_Buzz == 0) { F_Fizz = true ; F_Buzz = true ; Count[0]++; CountAll++; }  //FizzBuzz
                    else             { F_Fizz = true ; F_Buzz = false; Count[1]++; CountAll++; }  //Fizz
                }
                else
                {
                    if (T_Buzz == 0) { F_Fizz = false; F_Buzz = true ; Count[2]++; CountAll++; }  //Buzz
                    else             { F_Fizz = false; F_Buzz = false; Count[3]++; CountAll++; }  //Other
                }
            }

            //コンソールに表示する内容を準備
            {
                ST_Watch.WriteBuffer(Clock.Month, Clock.Day, Clock.Hour, Clock.Minute, Clock.Second);  //表示_時計
                ST_Fizz .WriteBuffer(F_Fizz, "Fizz");  //表示_Fizz
                ST_Buzz .WriteBuffer(F_Buzz, "Buzz");  //表示_Buzz
                ST_CountFizzBuzz.WriteBuffer("FizzBuzz", Count[0], CountAll);  //カウンター_FizzBuzz
                ST_CountFizz    .WriteBuffer("Fizz"    , Count[1], CountAll);  //カウンター_Fizz
                ST_CountBuzz    .WriteBuffer("Buzz"    , Count[2], CountAll);  //カウンター_Buzz
                ST_CountOther   .WriteBuffer("Other"   , Count[3], CountAll);  //カウンター_Other
            }

            //時刻が０秒の時、画面を初期化してから、終了方法を表示する。
            if (Clock.Second == 0) { Console.Clear();  Console.WriteLine("終了するには、何かキーを押してください。"); };

            //コンソールに表示
            {
                //時刻の表示
                ST_Watch.WriteConsole();  //表示_時計

                //FizzBuzzの表示
                ST_Fizz .WriteConsole();  //表示_Fizz
                ST_Buzz .WriteConsole();  //表示_Buzz

                //累計カウント数の表示
                ST_CountFizzBuzz.WriteConsole();  //カウンター_FizzBuzz
                ST_CountFizz    .WriteConsole();  //カウンター_Fizz
                ST_CountBuzz    .WriteConsole();  //カウンター_Buzz
                ST_CountOther   .WriteConsole();  //カウンター_Other

                //改行
                Console.WriteLine("\n");
            }
        }
    }
    internal class SeedText  //コンソールに表示される文字を管理する
    {
        //変数
        ConsoleColor    ForegroundColor { get; }       //文字の色
        ConsoleColor    BackgroundColor { get; }       //背景の色
        internal string Text            { get; set; }  //表示するテキスト

        //コンストラクター
        public SeedText(ConsoleColor P_ForegroundColor, ConsoleColor P_BackgroundColor)
        { ForegroundColor = P_ForegroundColor;  BackgroundColor = P_BackgroundColor; }

        //メソッド
        internal void WriteConsole()  //コンソールに書き込む
        {
            Console.ForegroundColor = ForegroundColor;  //文字色を設定
            Console.BackgroundColor = BackgroundColor;  //背景色を設定
            Console.Write(Text);                        //テキストをコンソールに書き込む
            Console.ResetColor();                       //設定を戻しておく
        }
        internal void WriteBuffer(int P_Month, int P_Day, int P_Hour, int P_Minute, int P_Second)  //時計用
        {
            StringBuilder @string = new StringBuilder();
            @string.AppendFormat(" {0:00}/{1:00}    {2:00}:{3:00}:{4:00} ", P_Month, P_Day, P_Hour, P_Minute, P_Second);
            Text = @string.ToString();
        }
        internal void WriteBuffer(bool P_Flag, string P_Text)  //FizzBuzz用
        {
            StringBuilder @string = new StringBuilder();
            if (P_Flag == true) {@string.AppendFormat(" [{0}] ", P_Text);} else {@string.Append("        ");}
            Text = @string.ToString();
        }
        internal void WriteBuffer(string P_Text, int P_Count, int P_CountAll)  //カウンター用
        {
            StringBuilder @string = new StringBuilder();
            @string.AppendFormat(" {0}:{1:0000}[{2:0.000}] ", P_Text, P_Count, (double)P_Count / P_CountAll);
            Text = @string.ToString();
        }
    }
}