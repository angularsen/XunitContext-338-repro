namespace XunitContext_338_repro;

public class UnitTest1 : XunitContextBase
{
    public UnitTest1(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public async Task Test1()
    {
        await Task.Delay(Random.Shared.Next(500, 1500));
    }
}