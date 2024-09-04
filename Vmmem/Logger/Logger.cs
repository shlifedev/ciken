namespace Vmmem.Logger;

public class Logger : ILogger
{
    public void Log(string message) => Console.WriteLine(message);

    public void Warning(string message)=> Console.WriteLine(message);

    public void Error(string message)=> Console.WriteLine(message);
}