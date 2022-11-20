using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace XunitContext_338_repro;

public class MyTestBase : XunitContextBase
{
    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
    public MyTestBase(ITestOutputHelper output, [CallerFilePath] string sourceFile = "")
        : base(Delayed(output), sourceFile)
    {
    }

    public override void Dispose()
    {
        base.Dispose();
        if (TestException != null)
        {
            Output.WriteLine("TEST EXCEPTION: " + TestException);
        }
    }

    private static ITestOutputHelper Delayed(ITestOutputHelper output)
    {
        Thread.Sleep(Random.Shared.Next(500, 1000));
        return output;
    }
}