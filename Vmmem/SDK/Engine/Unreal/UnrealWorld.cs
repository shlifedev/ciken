using System.Runtime.InteropServices;

namespace Vmmsharp.SDK.Unreal
[StructLayout(LayoutKind.Explicit)]
public unsafe struct UnrealWorld 
{
    [FieldOffset(0x30)]
    public IntPtr pPersistentLevel;  
 
    [FieldOffset(0x0190)]
    public IntPtr pOwningGameInstance; 
} 