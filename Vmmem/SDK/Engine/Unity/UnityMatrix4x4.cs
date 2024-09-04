using System.Runtime.InteropServices;

namespace DefaultNamespace;

[StructLayout(LayoutKind.Explicit)]
public struct UnityMatrix4x4 
{ 
         [FieldOffset(0x00)] public float m00;
         [FieldOffset(0x04)] public float m10;
         [FieldOffset(0x08)] public float m20;
         [FieldOffset(0x0C)] public float m30;
 
         [FieldOffset(0x10)] public float m01;
         [FieldOffset(0x14)] public float m11;
         [FieldOffset(0x18)] public float m21;
         [FieldOffset(0x1C)] public float m31;
 
         [FieldOffset(0x20)] public float m02;
         [FieldOffset(0x24)] public float m12;
         [FieldOffset(0x28)] public float m22;
         [FieldOffset(0x2C)] public float m32;
 
         [FieldOffset(0x30)] public float m03;
         [FieldOffset(0x34)] public float m13;
         [FieldOffset(0x38)] public float m23;
         [FieldOffset(0x3C)] public float m33;
    
    /// <summary>
    /// 유니티 행렬을 C# 행렬로 변경
    /// </summary> 
    public System.Numerics.Matrix4x4 ToMatrix4X4() =>new System.Numerics.Matrix4x4 (
        m00, m01, m02, m03,
        m10, m11, m12, m13,
        m20, m21, m22, m23,
        m30, m31, m32, m33
    ); 
} 