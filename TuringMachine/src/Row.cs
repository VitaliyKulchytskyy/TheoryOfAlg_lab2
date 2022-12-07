using Spectre.Console;

namespace TuringMachine;

public class Row
{
    public readonly char AlphabetChar;
    public List<Transition> Transitions { get; }
    
    public Row(char alphabetChar, List<Transition> transitions)
    {
        AlphabetChar = alphabetChar;
        Transitions = transitions;
    }

    public Markup[] GetColoredData(bool coloredChar = false, int state = -1)
    {
        Markup[] output = new Markup[Transitions.Count + 1];
        output[0] = new Markup(coloredChar ? $"[{Constant.SelectedElementColor}]{AlphabetChar}[/]" : AlphabetChar.ToString());

        for (int i = 1; i < output.Length; i++)
        {
            string data = $"{Transitions[i - 1].Replace}>{Transitions[i - 1].State}";
            output[i] = new Markup((i - 1 == state) ? $"[{Constant.SelectedStateColor}]{data}[/]" : data);
        }

        return output;
    }
    
    public override string ToString()
        => $"{AlphabetChar}:\t{string.Concat(Transitions.Select(getTransData => $"{getTransData.Replace}>{getTransData.State}\t"))}";
}