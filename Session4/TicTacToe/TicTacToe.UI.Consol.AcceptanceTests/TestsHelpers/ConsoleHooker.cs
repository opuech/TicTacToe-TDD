using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.AcceptanceTests.TestsHelpers
{
    class ConsoleHooker : IDisposable
    {
        private System.IO.MemoryStream @inMemory;

        public System.IO.StringWriter @out { get; private set; }
        public System.IO.StreamReader @in { get; private set; }
        public System.IO.StreamWriter @inWriter { get; private set; }

        public ConsoleHooker()
            : this(String.Empty)
        { 
        }

        public ConsoleHooker(string TextToRead)
        {
            @out = new System.IO.StringWriter();
            @inMemory = new System.IO.MemoryStream();
            @in = new System.IO.StreamReader(@inMemory);
            @inWriter = new System.IO.StreamWriter(@inMemory);
            System.Console.SetOut(@out);
            System.Console.SetIn(@in);
        }

        public void WriteLineToInBuffer(string s)
        {
            long tmpPosition = @inMemory.Position;
            @inWriter.WriteLine(s);
            @inWriter.Flush();
            @inMemory.Position = tmpPosition;

        }

        public void Dispose()
        {
            @out.Close();
            @in.Close();
            @inWriter.Close();
            @inMemory.Close();
        }
    }
}
