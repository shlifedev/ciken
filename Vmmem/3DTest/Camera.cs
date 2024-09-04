using OpenTK.Mathematics;

public class Camera
{
    public Vector3 Position { get; private set; }
    public Vector3 Front { get; private set; }
    public Vector3 Up { get; private set; }
    public Vector3 Right { get; private set; }
    public Vector3 WorldUp { get; private set; }

    private float _yaw;
    private float _pitch;

    public Camera(Vector3 position, Vector3 up, float yaw, float pitch)
    {
        Position = position;
        WorldUp = up;
        _yaw = yaw;
        _pitch = pitch;
        Front = new Vector3(0.0f, 0.0f, -1.0f);
        UpdateCameraVectors();
    }

    public Matrix4 GetViewMatrix()
    {
        return Matrix4.LookAt(Position, Position + Front, Up);
    }

    public void ProcessKeyboard(Vector3 direction, float deltaTime)
    {
        float velocity = 2.5f * deltaTime;
        if (direction == Vector3.UnitZ)
            Position += Front * velocity;
        if (direction == -Vector3.UnitZ)
            Position -= Front * velocity;
        if (direction == -Vector3.UnitX)
            Position -= Right * velocity;
        if (direction == Vector3.UnitX)
            Position += Right * velocity;
    }

    public void ProcessMouseMovement(float xoffset, float yoffset, bool constrainPitch = true)
    {
        xoffset *= 0.1f;
        yoffset *= 0.1f;

        _yaw += xoffset;
        _pitch += yoffset;

        if (constrainPitch)
        {
            if (_pitch > 89.0f)
                _pitch = 89.0f;
            if (_pitch < -89.0f)
                _pitch = -89.0f;
        }

        UpdateCameraVectors();
    }

    private void UpdateCameraVectors()
    {
        Vector3 front;
        front.X = MathF.Cos(MathHelper.DegreesToRadians(_yaw)) * MathF.Cos(MathHelper.DegreesToRadians(_pitch));
        front.Y = MathF.Sin(MathHelper.DegreesToRadians(_pitch));
        front.Z = MathF.Sin(MathHelper.DegreesToRadians(_yaw)) * MathF.Cos(MathHelper.DegreesToRadians(_pitch));
        Front = Vector3.Normalize(front);
        Right = Vector3.Normalize(Vector3.Cross(Front, WorldUp));
        Up = Vector3.Normalize(Vector3.Cross(Right, Front));
    }
}