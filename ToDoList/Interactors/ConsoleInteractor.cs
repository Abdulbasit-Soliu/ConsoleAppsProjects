public class ConsoleInteractor : IApplicationInteractor
{
    public string GetInput()
    {
        return Console.ReadLine();
    }

    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }
}