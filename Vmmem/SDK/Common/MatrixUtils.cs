using System.Numerics;
using DefaultNamespace;

namespace Vmmem.SDK.Common;

public static class MatrixUtils
{
    public static Matrix4x4 CreateMatrix(Vector3 position, Vector3 rotation)
    {
        var matrix = Matrix4x4.CreateTranslation(position);
        matrix *= Matrix4x4.CreateRotationX(rotation.X);
        matrix *= Matrix4x4.CreateRotationY(rotation.Y);
        matrix *= Matrix4x4.CreateRotationZ(rotation.Z);
        return matrix;
    }
     
    public static Matrix4x4 SetScale(Matrix4x4 matrix, Vector3 scale)
    {
        matrix.M11 *= scale.X;
        matrix.M22 *= scale.Y;
        matrix.M33 *= scale.Z;
        return matrix;
    }
    
    public static Vector3 GetPosition(this Matrix4x4 matrix)
    {
        return new Vector3(matrix.M14, matrix.M24, matrix.M34);
    }
      
}