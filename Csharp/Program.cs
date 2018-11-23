using System;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Csharp
{
    public class Program
    {
        static TextGen_Watch    TG_Watch         = new TextGen_Watch   (ConsoleColor.Black,   ConsoleColor.White                  );
        static TextGen_FizzBuzz TG_Fizz          = new TextGen_FizzBuzz(ConsoleColor.Magenta, ConsoleColor.DarkMagenta, "Fizz"    );
        static TextGen_FizzBuzz TG_Buzz          = new TextGen_FizzBuzz(ConsoleColor.Cyan,    ConsoleColor.DarkCyan,    "Buzz"    );
        static TextGen_Counter  TG_CountFizzBuzz = new TextGen_Counter (ConsoleColor.Red,     ConsoleColor.DarkRed,     "FizzBuzz");
        static TextGen_Counter  TG_CountFizz     = new TextGen_Counter (ConsoleColor.Green,   ConsoleColor.DarkGreen,   "Fizz"    );
        static TextGen_Counter  TG_CountBuzz     = new TextGen_Counter (ConsoleColor.Blue,    ConsoleColor.DarkBlue,    "Buzz"    );
        static TextGen_Counter  TG_CountOther    = new TextGen_Counter (ConsoleColor.Yellow,  ConsoleColor.DarkYellow,  "Other"   );
        static Clock            clock            = new Clock();

        /// <summary>Main loop</summary>
        static void Main()
        {
            //タイマーを設定
            Timer timer1    = new Timer { Interval = 1000.0 }; //1秒ごとに起動
            timer1.Elapsed += Timer1_Elapsed;                  //イベントを登録
            timer1.Enabled  = true;                            //タイマーの起動

            //何かキーを押すと終了
            Console.ReadKey();
        }
        /// <summary>Event form timer1</summary>
        static async void Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //FizzBuzz
            if (clock.Fizz) { if (clock.Buzz) { TG_CountFizzBuzz.Count(); } else { TG_CountFizz.Count(); } }
            else { if (clock.Buzz) { TG_CountBuzz.Count(); } else { TG_CountOther.Count(); } }

            //コンソールに表示する内容を準備
            Task[] taskA = new Task[7] { Task.Run(() => { TG_Watch        .WriteBuffer(clock.Datetime); }),
                                         Task.Run(() => { TG_Fizz         .WriteBuffer(clock.Fizz);     }),
                                         Task.Run(() => { TG_Buzz         .WriteBuffer(clock.Buzz);     }),
                                         Task.Run(() => { TG_CountFizzBuzz.WriteBuffer();               }),
                                         Task.Run(() => { TG_CountFizz    .WriteBuffer();               }),
                                         Task.Run(() => { TG_CountBuzz    .WriteBuffer();               }),
                                         Task.Run(() => { TG_CountOther   .WriteBuffer();               }) };
            await Task.WhenAll(taskA);
            
            await Task.Run(() => //CUIに書き込み
            {
                //時刻が０秒の時、画面を初期化してから、終了方法を表示する。
                if (clock.Datetime.Second == 0) { Console.Clear(); Console.WriteLine("終了するには、何かキーを押してください。"); };

                //時刻の表示
                TG_Watch.WriteConsole();

                //FizzBuzzの表示
                TG_Fizz.WriteConsole(); TG_Buzz.WriteConsole();

                //累計カウント数の表示
                TG_CountFizzBuzz.WriteConsole(); TG_CountFizz.WriteConsole(); TG_CountBuzz.WriteConsole(); TG_CountOther.WriteConsole();

                //改行
                Console.WriteLine("\n");
            });
        }
    }

    internal class Clock
    {
        internal DateTime Datetime { get; private set; } = DateTime.Now;
        internal bool     Fizz     { get; private set; } = false;
        internal bool     Buzz     { get; private set; } = false;
        private  Timer    DateTimeNowTimer;

        internal Clock()
        { 
            DateTimeNowTimer          = new Timer { Interval = 1000.0 }; //1秒ごとに起動
            DateTimeNowTimer.Elapsed += DateTimeNowTimer_Elapsed;        //イベントを登録
            DateTimeNowTimer.Enabled  = true;                            //タイマーの起動
        }
        private void DateTimeNowTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Datetime = DateTime.Now;
            Fizz = (Datetime.Second % 3 == 0);
            Buzz = (Datetime.Second % 5 == 0);
        }
    }

    /// <summary>テキスト生成（抽象）</summary>
    public abstract class TextGen
    {
        public readonly ConsoleColor ForegroundColor;
        public readonly ConsoleColor BackgroundColor;
        /// <summary>CUI非同期書き込み用テキストバッファー</summary>
        public string BufferText { get; set; }

        internal TextGen(ConsoleColor ForegroundColor, ConsoleColor BackgroundColor)
        {
            this.ForegroundColor = ForegroundColor;
            this.BackgroundColor = BackgroundColor;
        }

        /// <summary>CUI書き込み</summary>
        internal void WriteConsole()
        {
            Console.ForegroundColor = this.ForegroundColor; //文字色を設定
            Console.BackgroundColor = this.BackgroundColor; //背景色を設定
            Console.Write(BufferText); //テキストをコンソールに書き込む
            Console.ResetColor();      //設定を戻しておく
        }
    }

    /// <summary>テキスト生成（時計）</summary>
    public class TextGen_Watch : TextGen
    {
        public TextGen_Watch(ConsoleColor ForegroundColor, ConsoleColor BackgroundColor) : base(ForegroundColor, BackgroundColor) { }

        /// <summary>テキストバッファー書き込み</summary>
        public void WriteBuffer(DateTime Datetime)
        {
            StringBuilder @string = new StringBuilder();
            @string.AppendFormat(" {0:00}/{1:00}    {2:00}:{3:00}:{4:00} ", Datetime.Month, Datetime.Day, Datetime.Hour, Datetime.Minute, Datetime.Second);
            BufferText = @string.ToString();
        }
    }

    /// <summary>テキスト生成（FizzBuzz）</summary>
    public class TextGen_FizzBuzz : TextGen
    {
        private readonly string ShowText;

        public TextGen_FizzBuzz(ConsoleColor ForegroundColor, ConsoleColor BackgroundColor, string ShowText) : base(ForegroundColor, BackgroundColor) { this.ShowText = ShowText; }

        /// <summary>テキストバッファー書き込み</summary>
        public void WriteBuffer(bool Flag)
        {
            StringBuilder @string = new StringBuilder();
            if (Flag == true) { @string.AppendFormat(" [{0}] ", this.ShowText); } else { @string.Append("        "); }
            BufferText = @string.ToString();
        }
    }

    /// <summary>テキスト生成（カウンター）</summary>
    public class TextGen_Counter : TextGen
    {
        private readonly string ShowText;
        private          int    Counter;
        private static   int    CounterAll;

        public TextGen_Counter(ConsoleColor TexColor, ConsoleColor BG_Color, string ShowText) : base(TexColor, BG_Color) { this.ShowText = ShowText; }

        /// <summary>カウンターを+1する</summary>
        public void Count() { Counter++; CounterAll++; }

        /// <summary>テキストバッファー書き込み</summary>
        public void WriteBuffer()
        {
            StringBuilder @string = new StringBuilder();
            @string.AppendFormat(" {0}:{1:0000}[{2:0.000}] ", ShowText, Counter, (double)Counter / CounterAll);
            BufferText = @string.ToString();
        }
    }
}
