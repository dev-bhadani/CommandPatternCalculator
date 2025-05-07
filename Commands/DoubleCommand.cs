using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandPatternCalculator.Interfaces;

namespace CommandPatternCalculator.Commands
{
    public class DoubleCommand : ICommand
    {
        public int Execute(int value) => value * 2;
        public int Undo(int value) => value / 2;
    }
}
