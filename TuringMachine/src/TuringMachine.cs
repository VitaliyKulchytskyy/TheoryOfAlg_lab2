namespace TuringMachine;

public class TuringMachine
{
    private readonly Tape _machineTape;
    private readonly TransitionMatrix _transitions;
    private readonly TapeAnimation _tapeAnimation;

    public TuringMachine(TransitionMatrix transitions, string originTape)
    {
        _transitions = transitions;
        _tapeAnimation = new TapeAnimation(_transitions);
        _machineTape = new Tape(originTape);
    }

    public void Run()
    {
        int state = 0, head = 0;
        Tape originTape = new Tape(_machineTape);
        while (state != -1)
        {
            Tape prevTape = new Tape(_machineTape);
            Transition transition = _transitions.GetTapeStatement(_machineTape[head], state)!;
            _machineTape[head] = transition.Replace;
            _tapeAnimation.RunAnimation(prevTape, _machineTape, head, state);

            head = transition.Move switch
            { 
                Move.Left  => head -= 1,
                Move.Right => head += 1,
                Move.Hold  => head += 0,
                _ => throw new ArgumentException()
            };
            
            if (head < 0)
            {
                head = 0;
                _machineTape.ScrollTapeRight();
            }
            state = transition.State;
        }
        _tapeAnimation.PrintSummaryReport(originTape, _machineTape);
    }
}