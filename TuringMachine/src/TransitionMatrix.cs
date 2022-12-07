namespace TuringMachine;

public class TransitionMatrix: IAnimateable<Row[]>
{
    private readonly Row[] _rows;
    private readonly int _maxStates;

    public TransitionMatrix(Row[] rows)
    {
        _rows = rows;
        _maxStates = CalcMaxStates();
    }

    public int GetMaxStates() => _maxStates;
    
    public Transition? GetTapeStatement(char c, int state)
        => (from row in _rows 
            where row.AlphabetChar == c 
            select row.Transitions[state]).FirstOrDefault();

    public Row[] GetAnimateableList()
        => _rows;

    private int CalcMaxStates()
        => _rows.Max(maxLength => maxLength.Transitions.Count);
}