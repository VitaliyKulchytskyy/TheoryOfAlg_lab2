using System.Text;
using Spectre.Console;

namespace TuringMachine;

public class Tape
{
    private readonly StringBuilder _tapeString;

    public Tape(string originTape)
    {
        _tapeString = new StringBuilder(originTape + "    ");
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

    public string GetSelectedTape(int head)
    {
        string output = string.Concat(Enumerable.Repeat("()", Constant.PrintBufferAmount)) + " ";
        
        for (int i = 0; i < _tapeString.Length; i++)
            output += (i == head) ? $"([{Constant.SelectedElementColor}]{_tapeString[i]}[/]) " : $"({_tapeString[i]}) ";

        output += string.Concat(Enumerable.Repeat("()", Constant.PrintBufferAmount));
        return output;
    }

    public override string ToString()
    {
        /*string output = string.Concat(Enumerable.Repeat("()", Constant.PrintBufferAmount)) + " ";
        
        for (int i = 0; i < _tapeString.Length; i++)
            output +=  $"({_tapeString[i]}) ";

        output += string.Concat(Enumerable.Repeat("()", Constant.PrintBufferAmount));*/
        return _tapeString.ToString();
    }
}