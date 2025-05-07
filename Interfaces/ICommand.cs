using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternCalculator.Interfaces
{
    public interface ICommand
    {
        int Execute(int value);
        int Undo(int value);
    }
}
