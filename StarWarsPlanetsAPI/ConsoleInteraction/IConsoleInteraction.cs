namespace StarWarsPlanetsAPI.ConsoleInteraction;

internal interface IConsoleInteraction
{
    void Show(string message);
    string ReadInput();
    void Exit();
}
