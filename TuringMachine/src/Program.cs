using Spectre.Console;

namespace TuringMachine;

public static class Program
{
    public static void Main()
    {
        TransitionMatrix transitionMatrix = new TransitionMatrix(new[]
        {
            new Row('0', new List<Transition>(){new Transition('0', Move.Right, 0), new Transition('5', Move.Right, 1), new Transition('1', Move.Right, -1)} ),
            new Row('1', new List<Transition>(){new Transition('1', Move.Right, 0), new Transition('6', Move.Right, 1), new Transition('2', Move.Right, -1)} ),
            new Row('2', new List<Transition>(){new Transition('2', Move.Right, 0), new Transition('7', Move.Right, 1), new Transition('3', Move.Right, -1)} ),
            
            new Row('3', new List<Transition>(){new Transition('3', Move.Right, 0), new Transition('8', Move.Right, 1), new Transition('4', Move.Right, -1)} ),
            new Row('4', new List<Transition>(){new Transition('4', Move.Right, 0), new Transition('9', Move.Right, 1), new Transition('5', Move.Right, -1)} ),
            new Row('5', new List<Transition>(){new Transition('5', Move.Right, 0), new Transition('0', Move.Left, 2),  new Transition('6', Move.Right, -1)} ),
            
            new Row('6', new List<Transition>(){new Transition('6', Move.Right, 0), new Transition('1', Move.Left, 2), new Transition('7', Move.Right, -1)} ),
            new Row('7', new List<Transition>(){new Transition('7', Move.Right, 0), new Transition('2', Move.Left, 2), new Transition('8', Move.Right, -1)} ),
            new Row('8', new List<Transition>(){new Transition('8', Move.Right, 0), new Transition('3', Move.Left, 2), new Transition('9', Move.Right, -1)} ),
            new Row('9', new List<Transition>(){new Transition('9', Move.Right, 0), new Transition('4', Move.Left, 2), new Transition('0', Move.Left, 2)} ), 
            new Row(' ', new List<Transition>(){new Transition('0', Move.Right, -1), new Transition('0', Move.Left, -1), new Transition('1', Move.Hold, -1)} ), 
            
            new Row('_', new List<Transition>(){new Transition('_', Move.Left, 1)}),
        });

        TuringMachine trMachine = new TuringMachine(transitionMatrix, "995_");
        trMachine.Run();

    }
}