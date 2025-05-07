using CommandPatternCalculator.Commands;
using CommandPatternCalculator.core;
using CommandPatternCalculator.Interfaces;
using System;

namespace CommandPatternCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var initialResult = ParseInitialResult(args);
                var calculator = new CalculatorEngine(initialResult);
                RunCommandLoop(calculator);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static int ParseInitialResult(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No starting value provided. Defaulting to 1.");
                return 1;
            }
            if (!int.TryParse(args[0], out int result))
                throw new ArgumentException("Invalid number provided as the initial result value.");

            return result;
        }

        private static void RunCommandLoop(CalculatorEngine calculator)
        {
            while (true)
            {
                Console.WriteLine($"\nCurrent result: {calculator.Result}");
                Console.Write("Enter command (increment, decrement, double, randadd, undo): ");
                string input = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: Command cannot be empty.");
                    continue;
                }
                try
                {
                    ProcessCommand(calculator, input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private static void ProcessCommand(CalculatorEngine calculator, string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new InvalidOperationException("Command cannot be empty.");
            if (input == "undo")
            {
                calculator.Undo();
                return;
            }
            var command = CreateCommand(input);
            if (command == null)
                throw new InvalidOperationException($"Unknown command '{input}'.");
            calculator.ExecuteCommand(command);
        }

        private static ICommand CreateCommand(string input)
        {
            switch (input)
            {
                case "increment":
                    return new IncrementCommand();
                case "decrement":
                    return new DecrementCommand();
                case "double":
                    return new DoubleCommand();
                case "randadd":
                    return new RandAddCommand(new Random().Next(1, 101));
                default:
                    throw new InvalidOperationException($"Unknown command '{input}'.");
            }
        }
    }
}
