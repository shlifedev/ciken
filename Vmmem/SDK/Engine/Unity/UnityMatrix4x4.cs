using System.Runtime.InteropServices;

namespace DefaultNamespace;

[StructLayout(LayoutKind.Explicit)]
public struct WhUnityMatrix4x4 
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

         public WhUnityMatrix4x4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23, float m30, float m31, float m32, float m33)
         {
             this.m00 = m00;
             this.m10 = m10;
             this.m20 = m20;
             this.m30 = m30;
             this.m01 = m01;
             this.m11 = m11;
             this.m21 = m21;
             this.m31 = m31;
             this.m02 = m02;
             this.m12 = m12;
             this.m22 = m22;
             this.m32 = m32;
             this.m03 = m03;
             this.m13 = m13;
             this.m23 = m23;
             this.m33 = m33;
         }
         
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