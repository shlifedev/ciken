namespace Vmmem;

public enum VMemResult : uint
{
      SUCCESS = 0x000000,
      
      VM_ALREADY_INITIALIZED = 0x000001,
      
      VM_INIT_FAILED = 0x01001,
      
      VM_PROCESS_NOT_FOUND = 0x020001, // B
      VM_PROCESS_DUPLICATE = 0x020002, //  B
      
      VM_MODULE_NOT_FOUND = 0x030001, 
      
      VM_UNKNOWN = 0x999999,
}
 