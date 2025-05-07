using Xunit;
using CommandPatternCalculator.Commands;
using System;
using CommandPatternCalculator.core;

namespace CommandPatternCalculator.Tests
{
    public class CalculatorEngineIntegrationTests
    {
        [Fact]
        public void SequenceOfCommands_IncrementAndDouble_ProducesCorrectResult()
        {
            var calculator = new CalculatorEngine(1);
            calculator.ExecuteCommand(new IncrementCommand()); 
            calculator.ExecuteCommand(new IncrementCommand());
            calculator.ExecuteCommand(new IncrementCommand()); 
            calculator.ExecuteCommand(new DoubleCommand());    

            Assert.Equal(8, calculator.Result);
        }

        [Fact]
        public void SequenceOfCommands_WithUndo_ProducesCorrectResult()
        {
            var calculator = new CalculatorEngine(1);
            calculator.ExecuteCommand(new IncrementCommand()); 
            calculator.ExecuteCommand(new IncrementCommand()); 
            calculator.ExecuteCommand(new IncrementCommand()); 
            calculator.ExecuteCommand(new DoubleCommand());   

            calculator.Undo(); 
            calculator.Undo(); 

            Assert.Equal(3, calculator.Result);
        }

        [Fact]
        public void Undo_AllCommands_ReturnsToInitialValue()
        {
            var calculator = new CalculatorEngine(5);
            calculator.ExecuteCommand(new IncrementCommand());  
            calculator.ExecuteCommand(new DoubleCommand());    
            calculator.ExecuteCommand(new DecrementCommand()); 

            calculator.Undo();
            calculator.Undo(); 
            calculator.Undo(); 

            Assert.Equal(5, calculator.Result);
        }

        [Fact]
        public void MultipleUndoBeyondHistory_ThrowsAnException()
        {
            var calculator = new CalculatorEngine(2);
            calculator.ExecuteCommand(new IncrementCommand()); 
            calculator.Undo(); 

            Assert.Throws<InvalidOperationException>(() => calculator.Undo());
        }
    }
}
