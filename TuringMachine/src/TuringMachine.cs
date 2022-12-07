namespace TuringMachine;

public class TuringMachine
{
    public Tape MachineTape { get; private set; }
    private int _head;
    private readonly TransitionMatrix _transitions;
    private readonly TapeAnimation _tapeAnimation;

    public TuringMachine(TransitionMatrix transitions, string originTape)
    {
        _transitions = transitions;
        _tapeAnimation = new TapeAnimation(_transitions);
        MachineTape = new Tape(originTape);
    }

    public void Run()
    {
        int state = 0;
        Tape originTape = new Tape(MachineTape);
        while (state != -1)
        {
            if (_head < 0)
            {
                _head = 0;
                MachineTape = new Tape(" " + MachineTape);
            }
            Tape prevTape = new Tape(MachineTape);
            Transition transition = _transitions.GetTapeStatement(MachineTape[_head], state)!;
            MachineTape[_head] = transition.Replace;
            _tapeAnimation.RunAnimation(prevTape, MachineTape, _head, state);

            _head = transition.Move switch
            { 
                Move.Left  => _head -= 1,
                Move.Right => _head += 1,
                Move.Hold => _head += 0,
                _ => throw new ArgumentException()
            }; 
            state = transition.State;
        }
        _tapeAnimation.RunAnimation(originTape, MachineTape);
    }
}