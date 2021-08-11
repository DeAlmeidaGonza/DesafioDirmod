using DesafioDirmod;
using Xunit;

public class UnitTest
{
    [Fact]
    public void ProcessMessageTest()
    {
        Assert.Equal("44 444", Program.ProcessMessage("hi"));
        Assert.Equal("999337777", Program.ProcessMessage("yes"));
        Assert.Equal("333666 666022 2777", Program.ProcessMessage("foo bar"));
        Assert.Equal("4433555 555666096667775553", Program.ProcessMessage("hello world"));
        Assert.Equal(null, Program.ProcessMessage("how are you?"));
        Assert.Equal(null, Program.ProcessMessage("fantastic 4"));
    }

    [Fact]
    public void ProcessCharacterTest()
    {
        Assert.Equal("0", Program.ProcessMessage(" "));
        Assert.Equal("2", Program.ProcessMessage("a"));
        Assert.Equal("333", Program.ProcessMessage("f"));
        Assert.Equal("44", Program.ProcessMessage("h"));
        Assert.Equal("555", Program.ProcessMessage("l"));
        Assert.Equal("6", Program.ProcessMessage("m"));
        Assert.Equal("7777", Program.ProcessMessage("s"));
        Assert.Equal("88", Program.ProcessMessage("u"));
        Assert.Equal("9999", Program.ProcessMessage("z"));
        Assert.Equal(null, Program.ProcessMessage("&"));
        Assert.Equal(null, Program.ProcessMessage("4"));
    }

}