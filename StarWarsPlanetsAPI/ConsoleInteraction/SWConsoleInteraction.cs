using StarWarsPlanetsAPI.SWPApp;

namespace StarWarsPlanetsAPI.ConsoleInteraction;

internal class SWConsoleInteraction : ISWConsoleInteraction
{
    private IEnumerable<string> _filterOptions;

    public SWConsoleInteraction(IOptionsRegistry optionsRegistry)
    {
        _filterOptions = optionsRegistry;
    }

    public string ReadInput() => Console.ReadLine()!;

    public void Show(string message)
    {
        Console.WriteLine(message);
    }

    public string ReadValidOption()
    {        
        Console.WriteLine("The statistics of which property would you like to see:");
        Console.WriteLine(string.Join(Environment.NewLine, _filterOptions));
        Console.WriteLine();

        while (true)
        {
            var input = Console.ReadLine();

            if(input == null)
            {
                Console.WriteLine("Invalid choice");
                continue;
            }

            input = char.ToUpper(input[0]) + input.Substring(1).ToLower();
            
            return input;
        }

    }

    public void Exit()
    {
        Console.Write("Press any key to exit.");
        Console.ReadKey();
        Environment.Exit(0);
    }
}