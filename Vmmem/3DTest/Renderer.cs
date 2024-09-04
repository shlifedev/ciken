using System;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Simple3DRendering
{
    public class Renderer : GameWindow
    {
        private Cube _cube;
        private Shader _shader;
        private Matrix4 _projectionMatrix;
        private Camera _camera;
        private Vector2 _lastMousePosition;

        public Renderer(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            _shader = new Shader("/Users/shlifedev/vmemory/Vmmem/3DTest/shader.vert",
                "/Users/shlifedev/vmemory/Vmmem/3DTest/shader.frag");
            _shader.Use();

            _cube = new Cube(_shader);

            _camera = new Camera(new Vector3(0, 0, 3), Vector3.UnitY, -90.0f, 0.0f);
            _projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 16.0f / 9.0f, 0.1f, 100.0f);

            _shader.SetMatrix4("view", _camera.GetViewMatrix());
            _shader.SetMatrix4("projection", _projectionMatrix);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            if (KeyboardState.IsKeyDown(Keys.W))
                _camera.ProcessKeyboard(Vector3.UnitZ, (float)e.Time);
            if (KeyboardState.IsKeyDown(Keys.S))
                _camera.ProcessKeyboard(-Vector3.UnitZ, (float)e.Time);
            if (KeyboardState.IsKeyDown(Keys.A))
                _camera.ProcessKeyboard(-Vector3.UnitX, (float)e.Time);
            if (KeyboardState.IsKeyDown(Keys.D))
                _camera.ProcessKeyboard(Vector3.UnitX, (float)e.Time);

            var mouseState = MouseState;
            var deltaX = mouseState.X - _lastMousePosition.X;
            var deltaY = _lastMousePosition.Y - mouseState.Y;
            _lastMousePosition = new Vector2(mouseState.X, mouseState.Y);

            _camera.ProcessMouseMovement(deltaX, deltaY);

            _shader.SetMatrix4("view", _camera.GetViewMatrix());
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            _cube.Render();

            
            SwapBuffers();
        }
    }
}