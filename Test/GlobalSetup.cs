using System.Runtime.CompilerServices;

namespace XunitContext_338_repro;

public static class GlobalSetup
{
    [ModuleInitializer]
    public static void Setup()
    {
        XunitContext.EnableExceptionCapture();
    }
}