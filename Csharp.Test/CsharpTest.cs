using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Csharp.Test
{
    [TestClass]
    public class Test_TextGen_Color
    {
        TextGen_Watch Target_Watch = new TextGen_Watch(ConsoleColor.White, ConsoleColor.White);
        TextGen_FizzBuzz Target_FizzBuzz = new TextGen_FizzBuzz(ConsoleColor.White, ConsoleColor.White, "FiBu");
        TextGen_Counter Target_Counter = new TextGen_Counter(ConsoleColor.White, ConsoleColor.White, "FizzBuzz");

        //色
        [TestMethod]
        public void Color_Watch()
        {
            Assert.AreEqual(Target_Watch.ForegroundColor, ConsoleColor.White);
            Assert.AreEqual(Target_Watch.BackgroundColor, ConsoleColor.White);
        }
        [TestMethod]
        public void Color_FizzBuzz()
        {
            Assert.AreEqual(Target_FizzBuzz.ForegroundColor, ConsoleColor.White);
            Assert.AreEqual(Target_FizzBuzz.BackgroundColor, ConsoleColor.White);
        }
        [TestMethod]
        public void Color_Counter()
        {
            Assert.AreEqual(Target_Watch.ForegroundColor, ConsoleColor.White);
            Assert.AreEqual(Target_Watch.BackgroundColor, ConsoleColor.White);
        }
    }
    [TestClass]
    public class Test_TextGen
    {
        TextGen_Watch Target_Watch = new TextGen_Watch(ConsoleColor.White, ConsoleColor.White);
        TextGen_FizzBuzz Target_FizzBuzz = new TextGen_FizzBuzz(ConsoleColor.White, ConsoleColor.White, "FiBu");
        TextGen_Counter Target_Counter = new TextGen_Counter(ConsoleColor.White, ConsoleColor.White, "FizzBuzz");
        //テキスト
        [TestMethod]
        public void Text_Watch()
        {
            DateTime datetime = new DateTime(1, 1, 1, 1, 1, 1);

            Target_Watch.WriteBuffer(datetime);
            Assert.AreEqual(" 01/01    01:01:01 ", Target_Watch.BufferText);
        }
        [TestMethod]
        public void Text_FizzBuzz()
        {
            Target_FizzBuzz.WriteBuffer(true);
            Assert.AreEqual(" [FiBu] ", Target_FizzBuzz.BufferText);
            Target_FizzBuzz.WriteBuffer(false);
            Assert.AreEqual("        ", Target_FizzBuzz.BufferText);
        }
        [TestMethod]
        public void Text_Counter()
        {
            for (int i = 1; i < 3; i++)
            {
                Target_Counter.Count();
                Target_Counter.WriteBuffer();
                Assert.AreEqual($" FizzBuzz:000{i}[1.000] ", Target_Counter.BufferText);
            }
        }
    }
}