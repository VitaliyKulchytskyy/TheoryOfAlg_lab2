using System.Text;
using Spectre.Console;

namespace TuringMachine;

public class Tape
{
    private StringBuilder _tapeString;

    public Tape(string originTape)
    {
        _tapeString = new StringBuilder(originTape + Constant.TapeBufferAmount);
    }

    public Tape(Tape other)
    {
        _tapeString = new StringBuilder(other._tapeString.ToString());
    }
    
    public char this[int index]
    {
        get => _tapeString[index];
        set => _tapeString[index] = value;
    }

    public void ScrollTapeRight()
    {
        _tapeString = new StringBuilder(" " + _tapeString);
    }

    public void ScrollTapeLeft()
    {
        _tapeString = new StringBuilder(_tapeString + " ");
    }

    public string GetSelectedTape(int head)
    {
        string separateFromVisualBuffer = " ";
        string output = GetVisualBuffer() + separateFromVisualBuffer;
        
        for (int i = 0; i < _tapeString.Length; i++)
            output += (i == head) ? $"([{Constant.SelectedElementColor}]{_tapeString[i]}[/]) " : $"({_tapeString[i]}) ";

        output += GetVisualBuffer();
        return output;
    }

    public override string ToString()
        => _tapeString.ToString();

    private string GetVisualBuffer()
        => string.Concat(Enumerable.Repeat("()", Constant.VisualBufferAmount));
}