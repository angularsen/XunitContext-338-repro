namespace XunitContext_338_repro;

public class UnitTest2 : XunitContextBase
{
    public UnitTest2(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public async Task Test1()
    {
        await Task.Delay(Random.Shared.Next(500, 1500));
    }
}