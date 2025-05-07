using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandPatternCalculator.Interfaces;

namespace CommandPatternCalculator.Commands
{
    public class RandAddCommand : ICommand
    {
        private readonly int randomOffset;
        private static readonly Random random = new Random(); 

        public RandAddCommand(int baseValue)
        {
            int range = (int)Math.Round(baseValue * 0.2);
            randomOffset = random.Next(-range, range + 1);
        }

        public int Execute(int value) => value + randomOffset;
        public int Undo(int value) => value - randomOffset;
    }
}
