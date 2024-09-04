namespace Vmmsharp.SDK.Unreal
[StructLayout(LayoutKind.Explicit)]
public unsafe struct UWorld 
{
    [FieldOffset(0x30)]
    public IntPtr pPersistentLevel;  
 
    [FieldOffset(0x0190)]
    public IntPtr pOwningGameInstance; 
}
[StructLayout(LayoutKind.Explicit)]
public unsafe struct ULevel
{
    [FieldOffset(0xA0)] 
    public TArray<AActor> AActors;
 
}