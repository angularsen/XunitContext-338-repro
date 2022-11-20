using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace XunitContext_338_repro;

public class MyTestBase : XunitContextBase
{
    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
    public MyTestBase(ITestOutputHelper output, [CallerFilePath] string sourceFile = "") : base(output, sourceFile)
    {
    }

    public override void Dispose()
    {
        base.Dispose();
        Output.WriteLine("TEST EXCEPTION: " + TestException);
    }
}