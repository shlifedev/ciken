using System.Runtime.InteropServices;

namespace Vmmem.SDK.Engine.Unity;

[StructLayout(LayoutKind.Explicit)]
public struct UnityVector3
{
    [FieldOffset(0x00)] public float x;
    [FieldOffset(0x04)] public float y;
    [FieldOffset(0x08)] public float z;

    /// <summary>
    /// 유니티는 y축이 높이다.
    /// </summary>
    public System.Numerics.Vector3 ToVector3() => new System.Numerics.Vector3(x, y, z);
}