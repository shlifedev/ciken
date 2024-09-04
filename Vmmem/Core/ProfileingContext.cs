using System.Diagnostics;

namespace Vmmem;
public class ProfileingContext : IDisposable
{
    private static Stopwatch _stopwatch = new Stopwatch();
    string swName;
    public ProfileingContext(string swName)
    {
        _stopwatch.Reset();
        this.swName = swName; 
        _stopwatch.Start();
    }

    public void Print()
    {
        Console.WriteLine($"{swName} Elasped Time: {_stopwatch.ElapsedMilliseconds}ms ({_stopwatch.ElapsedMilliseconds / 1000.0}s)");
    }
 
    public void Dispose()
    {
        _stopwatch.Reset();
    }
}