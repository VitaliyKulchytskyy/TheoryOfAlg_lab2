using Spectre.Console;

namespace TuringMachine;

public static class Program
{
    public static void Main()
    {
        Transition invert_0 = new Transition('1', Move.Right, 0);
        Transition invert_1 = new Transition('0', Move.Right, 0);
        Transition end = new Transition('_', Move.Right, -1);

        TransitionMatrix transitionMatrix = new TransitionMatrix(new[]
        {
            new Row('0', new List<Transition>(){invert_0}),
            new Row('1', new List<Transition>(){invert_1}),
            new Row('_', new List<Transition>(){end}),
        });

        TuringMachine trMachine = new TuringMachine(transitionMatrix, "0110_");
        trMachine.Run();
    }
}