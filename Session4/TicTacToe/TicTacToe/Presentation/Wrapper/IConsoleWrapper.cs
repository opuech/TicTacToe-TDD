using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.UIConsole.Wrapper
{
    public interface IConsoleWrapper
    {
        void WriteLine(string txt);
        void Write(string txt);
        string ReadLine();
    }
}
