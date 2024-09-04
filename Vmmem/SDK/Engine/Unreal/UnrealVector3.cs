using System.Runtime.InteropServices;

namespace Vmmsharp.SDK.Unreal;

[StructLayout(LayoutKind.Explicit)]
public struct UnrealVector3
{
    [FieldOffset(0x00)] public float x;
    [FieldOffset(0x04)] public float y;
    [FieldOffset(0x08)] public float z;

    /// <summary>
    /// 언리얼은 z축이 높이다.
    /// </summary>
    public System.Numerics.Vector3 ToVector3() => new System.Numerics.Vector3(x, z, y);
}