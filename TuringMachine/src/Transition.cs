namespace TuringMachine;

public class Transition
{
    public readonly char Replace;
    public readonly Move Move;
    public readonly int State;

    public Transition(char replace, Move move, int state)
    {
        Replace = replace;
        Move = move;
        State = state;
    }
}