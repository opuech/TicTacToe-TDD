using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.UIConsole.Wrapper
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public void WriteLine(string txt)
        {
            Console.WriteLine(txt);
        }
        public void Write(string txt)
        {
            Console.Write(txt);
        }
        public string ReadLine()
        {
            return Console.ReadLine();
        }

    }
}
