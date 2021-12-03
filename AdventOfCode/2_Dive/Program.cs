using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2_Dive
{
    public enum InputCommand
    {
        forward,
        down,
        up
    }

    class Program
    {
        static void Main(string[] args)
        {
            var commands = GetCommands();
            PositionBase currentPosition = new Position_Task02();
            currentPosition.ExecuteCommands(commands);
            currentPosition.PrintPosition();
        }

        private static List<Tuple<InputCommand, int>> GetCommands()
        {
            var commands = new List<Tuple<InputCommand, int>>();
            File.ReadAllLines(@"..\..\input.txt").ToList().ForEach(line => commands.Add(LineToCommandTuple(line)));
            return commands;
        }

        private static Tuple<InputCommand, int> LineToCommandTuple(String line)
        {
            var tokens = line.Split(' ');
            return new Tuple<InputCommand, int>(ToInputCommand(tokens[0]), int.Parse(tokens[1]));
        }

        private static InputCommand ToInputCommand (String commandAsString)
        {
            return Enum.GetValues(typeof(InputCommand)).OfType<InputCommand>().ToList().First(cmd => cmd.ToString() == commandAsString);
        }
    }

    
    public abstract class PositionBase
    {
        protected int depth = 0;
        protected int distance = 0;

        public abstract void Forward(int i);

        public abstract void Up(int i);

        public abstract void Down(int i);

        public void PrintPosition()
        {
            Console.WriteLine("Distance: " + distance + " / Depth: " + depth + " / Product:" + distance * depth);
        }

        public void ExecuteCommands(List<Tuple<InputCommand, int>> inputCommands)
        {
            inputCommands.ForEach(cmd => ExecuteCommand(cmd));
        }

        private void ExecuteCommand(Tuple<InputCommand, int> inputCommand)
        {
            switch (inputCommand.Item1)
            {
                case InputCommand.down:
                    Down(inputCommand.Item2);
                    break;
                case InputCommand.up:
                    Up(inputCommand.Item2);
                    break;
                case InputCommand.forward:
                    Forward(inputCommand.Item2);
                    break;
                default:
                    throw new Exception("unknown command type");
            }
        }
    }

    public class Position_Task01 : PositionBase
    {
        public override void Forward(int i) => distance += i;

        public override void Up(int i) => depth -= i;
        public override void Down(int i) => depth += i;
    }

    public class Position_Task02 : PositionBase
    {
        int aim = 0;

        public override void Forward(int i)
        {
            distance += i;
            depth += aim * i;
        }

        public override void Up(int i) => aim -= i;
        public override void Down(int i) => aim += i;
    }
}
