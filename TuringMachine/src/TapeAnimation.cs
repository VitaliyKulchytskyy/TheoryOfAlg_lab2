using System.Text;
using Spectre.Console;

namespace TuringMachine;

public class TapeAnimation
{
    private readonly TransitionMatrix _transitionMatrix;
    private readonly int _delayAnimation;
    private int _iteration;

    public TapeAnimation(TransitionMatrix transitionMatrix, int delay = Constant.DelayAnimation)
    {
        _transitionMatrix = transitionMatrix;
        _delayAnimation = delay;
    }

    public void RunAnimation(Tape prevTape, Tape thisTape, int head, int state)
    {
        Table report = new Table();
        report.AddColumn(_iteration++.ToString());

        report.AddRow($"Before:\n{prevTape.GetSelectedTape(head)}\n")
            .AddRow(PrintTransitionMatrix(prevTape[head], state))
            .AddRow($"\nAfter:\n{thisTape.GetSelectedTape(head)}");
        
        AnsiConsole.Write(report);
        Console.WriteLine();
        Thread.Sleep(_delayAnimation);
    }
    
    public void PrintSummaryReport(Tape prevTape, Tape thisTape)
    {
        Table report = new Table();
        report.AddColumn("Summary");
        
        report.AddRow($"Input:\n{prevTape}")
            .AddRow($"\nOutput:\n{thisTape}");

        AnsiConsole.Write(report);
    }

    private Table PrintTransitionMatrix(char c, int state)
    {
        Table table = new Table
        {
            Border = TableBorder.Ascii
        };
        BuildHeader(table, _transitionMatrix.GetMaxStates());
            
        foreach (var elem in _transitionMatrix.GetAnimateableList())
            table.AddRow(elem.AlphabetChar == c ? elem.GetColoredData(true, state) : elem.GetColoredData());
        
        return table;
    }

    private void BuildHeader(Table table, int statesAmount)
    {
        for (int i = 0; i <= statesAmount; i++)
        {
            string data = (i == 0) ? "a/s" : $"s{i - 1}";
            table.AddColumn(data);
        }
    }
}