using System;
using System.IO;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

public class Shader
{
    public int Handle { get; private set; }

    public Shader(string vertexPath, string fragmentPath)
    {
        string vertexShaderSource;
        using (StreamReader reader = new StreamReader(vertexPath, System.Text.Encoding.UTF8))
        {
            vertexShaderSource = reader.ReadToEnd();
        }

        string fragmentShaderSource;
        using (StreamReader reader = new StreamReader(fragmentPath, System.Text.Encoding.UTF8))
        {
            fragmentShaderSource = reader.ReadToEnd();
        }

        int vertexShader = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertexShader, vertexShaderSource);
        GL.CompileShader(vertexShader);

        int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(fragmentShader, fragmentShaderSource);
        GL.CompileShader(fragmentShader);

        Handle = GL.CreateProgram();
        GL.AttachShader(Handle, vertexShader);
        GL.AttachShader(Handle, fragmentShader);
        GL.LinkProgram(Handle);

        GL.DetachShader(Handle, vertexShader);
        GL.DetachShader(Handle, fragmentShader);
        GL.DeleteShader(vertexShader);
        GL.DeleteShader(fragmentShader);
    }

    public void Use()
    {
        GL.UseProgram(Handle);
    }

    public void SetMatrix4(string name, Matrix4 matrix)
    {
        int location = GL.GetUniformLocation(Handle, name);
        GL.UniformMatrix4(location, false, ref matrix);
    }
}