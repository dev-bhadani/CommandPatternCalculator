using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandPatternCalculator.Interfaces;

namespace CommandPatternCalculator.core
{
    public class CalculatorEngine
    {
        public int Result { get; private set; }
        private readonly Stack<ICommand> history = new Stack<ICommand>();

        public CalculatorEngine(int initialResult)
        {
            Result = initialResult;
        }

        public void ExecuteCommand(ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            Result = command.Execute(Result);
            history.Push(command);
        }

        public void Undo()
        {
            if (history.Count == 0)
                throw new InvalidOperationException("No commands to undo.");

            var lastCommand = history.Pop();
            Result = lastCommand.Undo(Result);
        }
    }
}
