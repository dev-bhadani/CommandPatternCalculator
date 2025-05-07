using Xunit;
using CommandPatternCalculator.Commands;
using System;
using CommandPatternCalculator.core;

namespace CommandPatternCalculator.Tests
{
    public class CalculatorEngineTests
    {
        [Fact]
        public void ExecuteCommand_Increment_WorksCorrectly()
        {
            var calculator = new CalculatorEngine(10);
            calculator.ExecuteCommand(new IncrementCommand());
            Assert.Equal(11, calculator.Result);
        }

        [Fact]
        public void ExecuteCommand_Double_WorksCorrectly()
        {
            var calculator = new CalculatorEngine(5);
            calculator.ExecuteCommand(new DoubleCommand());
            Assert.Equal(10, calculator.Result);
        }

        [Fact]
        public void Undo_RevertsLastCommand()
        {
            var calculator = new CalculatorEngine(5);
            calculator.ExecuteCommand(new IncrementCommand());
            calculator.Undo();
            Assert.Equal(5, calculator.Result);
        }

        [Fact]
        public void Undo_WithoutHistory_Throws()
        {
            var calculator = new CalculatorEngine(5);
            Assert.Throws<InvalidOperationException>(() => calculator.Undo());
        }

        [Fact]
        public void ExecuteCommand_NullCommand_Throws()
        {
            var calculator = new CalculatorEngine(0);
            Assert.Throws<ArgumentNullException>(() => calculator.ExecuteCommand(null));
        }

        [Fact]
        public void RandAddCommand_ExecuteAndUndo_OffsetWithinRange()
        {
            var command = new RandAddCommand(10);
            int initial = 50;

            int after = command.Execute(initial);

            Assert.InRange(after, initial - 10, initial + 10);

            int undone = command.Undo(after);
            Assert.Equal(initial, undone);
        }

    }
}
