using System.Numerics;
using System.Runtime.InteropServices;

namespace Vmmsharp.SDK.Unreal;

[StructLayout(LayoutKind.Explicit)]
public struct UnrealMatrix4x4
{
    [FieldOffset(0)]
    public float m00;
    [FieldOffset(4)]
    public float m01;
    [FieldOffset(8)]
    public float m02;
    [FieldOffset(12)]
    public float m03;

    [FieldOffset(16)]
    public float m10;
    [FieldOffset(20)]
    public float m11;
    [FieldOffset(24)]
    public float m12;
    [FieldOffset(28)]
    public float m13;

    [FieldOffset(32)]
    public float m20;
    [FieldOffset(36)]
    public float m21;
    [FieldOffset(40)]
    public float m22;
    [FieldOffset(44)]
    public float m23;

    [FieldOffset(48)]
    public float m30;
    [FieldOffset(52)]
    public float m31;
    [FieldOffset(56)]
    public float m32;
    [FieldOffset(60)]
    public float m33;
    
    /// <summary>
    /// 유니티 좌표계 기준으로 변환합니다. 
    /// </summary>
    /// <returns></returns>
    public System.Numerics.Matrix4x4 ToMatrix4x4()
    {
        return new System.Numerics.Matrix4x4
        (
            m00, m10, m20, m30,
            m01, m11, m21, m31,
            m02, m12, m22, m32,
            m03, m13, m23, m33
        );
    }
}