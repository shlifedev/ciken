namespace Vmmem.Logger;

public interface ILogger
{
    public void Log(string message);
    public void Warning(string message);
    public void Error(string message);
}