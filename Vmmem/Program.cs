using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using Simple3DRendering;

public class Program2
{
    [STAThread]
    public static void Main()
    {
        var gameWindowSettings = GameWindowSettings.Default;
        var nativeWindowSettings = new NativeWindowSettings()
        {
            Size = new Vector2i(800, 600),
            Title = "Simple 3D Rendering"
        };

        using (var program = new Renderer(gameWindowSettings, nativeWindowSettings))
        {
            program.Run();
        }
    }
}