namespace XunitContext_338_repro;

public class UnitTest4 : MyTestBase
{
    public UnitTest4(ITestOutputHelper output) : base(output)
    {
        Thread.Sleep(Random.Shared.Next(500, 1000));
    }

    [Fact]
    public async Task Test1()
    {
        await Task.Delay(Random.Shared.Next(500, 1500)).ConfigureAwait(false);
        // throw new InvalidOperationException("My exception");
    }
}