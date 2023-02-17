namespace Tests;

public class InputTests
{
    [Theory]
    [InlineData("{}", "", true)]
    [InlineData("}{", "closed bracket can't proceed all open brackets.", false)]
    [InlineData("{{}", "one bracket pair was not closed", false)]
    [InlineData("", "no brackets in the string will return True", true)]
    [InlineData("{abc...xyz}", "non-bracket characters are ignored appropriately", true)]
    [InlineData("{{}}}", "closed too much", false)]
    [InlineData("{{{{{{{{{{{}}}}}}}}}}}", "yeet", true)]
    [InlineData("{a{b{c{d{e{f{g{h{j{k{l}m}n}o}p}q}r}s}t}u}v}", "this wont break it", true)]
    public void Can_Validate_Input_Content(string content, string reason, bool expected)
    {
        var input = new Input(content);
        var isValid = input.IsValid();

        // Console.WriteLine(reason);
        // Assert.Equal(expected, isValid);

        Assert.True(isValid == expected, userMessage: reason);
    }
}