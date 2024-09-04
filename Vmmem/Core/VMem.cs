
using System.Runtime.InteropServices;
using Vmmem;
using Vmmem.Logger;
using Vmmsharp;

/// <summary>
/// https://github.com/ufrisk/MemProcFS/blob/master/vmmsharp/example/VmmsharpExample.cs
/// </summary>
public class VMem
{
 
    #region Cfg
    private static readonly List<string> CONFIG_INIT = new List<string>()
    {
        "-device",
        "fpga",
        "-norefresh",
        "-disable-symbols",
        "-disable-symbolserver",
        "-disable-python",
        "-disable-infodb"
    };
    #endregion
    private Dictionary<string, ulong> _sigs;
    private Vmm _vmm;
    private System.Type _pointerType;

    public VMemConfig Config { get; private set; }
    private VmmProcess _procCache;
 
    public VmmProcess VmmGameProcess =>
        _procCache ??= _vmm?.Processes.ToList().FirstOrDefault(x => x.Name == Config.ProcessName);

    public ulong _gameProcessVaBase => VmmGameProcess.GetModuleBase(Config.ModuleName);
    
    

    public ulong Readed{ get; private set; }


    public VMem(bool x86)
    {
        // 대상 아키텍쳐 포인터를 설정
        this._pointerType = x86 ? typeof (uint) : typeof (ulong);
        this._sigs = new Dictionary<string, ulong>(); 
    }

    
    /// <summary>
    /// 메모리 맵을 생성합니다.
    /// </summary>
    private void TryMemoryMapGen()
    {
        using (ProfileingContext ctx = new ProfileingContext("MemoryMapGen"))
        { 
            Vmm vmm = new Vmm(CONFIG_INIT.ToArray());
            string appEnvPath =
                Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "vmmem");
            if (!Directory.Exists(appEnvPath))
                Directory.CreateDirectory(appEnvPath);
            File.WriteAllText(Path.Join(appEnvPath, "memorymap.txt"), vmm.MapMemoryAsString());
            vmm.Close();
            ctx.Print();
        }
    }
    
    
    /// <summary>
    /// 대상 프로세스의 메모리를 읽습니다.
    /// </summary>
    /// <param name="address">읽을 위치입니다. vaBasae에 자동으로 더해지므로 프로세스에서 찾은 포인터를 입력하면 됩니다.</param> 
    /// <typeparam name="T">읽어들일 타입의 구조체 타입입니다. 구조체는 반드시 StructLayout이 설정되어 있어야합니다. </typeparam>
    /// <returns></returns>
    public T? Read<T>(ulong address)  where T : unmanaged
    {
        ++this.Readed;
        T? result = VmmGameProcess.MemReadAs<T>(_gameProcessVaBase + address, Vmm.FLAG_NOCACHE);
        return result;
    }
    
    
    public T[]? ReadArray<T>(ulong address, uint count) where T : unmanaged
    {
        ++this.Readed;
        return this.VmmGameProcess.MemReadArray<T>(_gameProcessVaBase + address, count);
  
    }
    
    private T?[] ReadArray<T> (ulong adress, int count) where T : unmanaged
    {
        T?[] result = new T?[count];
        for (int i = 0; i < count; i++)
        {
            result[i] = Read<T>(adress + (ulong) i * (ulong) Marshal.SizeOf<T>());
        }
        return result;
    }
    
    
    public void Init(VMemConfig config)
    { 
 
        
    }
    
}
 
