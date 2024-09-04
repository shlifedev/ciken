public record VMemConfig
{
    public VMemConfig(string processName, string moduleName)
    {
        ProcessName = processName;
        ModuleName = moduleName;
    }

    public string ProcessName { get; }
    public string ModuleName { get; }
}