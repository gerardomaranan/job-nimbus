namespace Tests;

public class InputTests
{
    [Theory]
    [InlineData("{}", "", true)]
    [InlineData("}{", "closed bracket can't proceed all open brackets.", false)]
    [InlineData("{{}", "one bracket pair was not closed", false)]
    [InlineData("", "no brackets in the string will return True", true)]
    [InlineData("{abc...xyz}", "non-bracket characters are ignored appropriately", true)]
    public void Can_Validate_Input_Content(string content, string reason, bool expected)
    {
        var input = new Input(content);
        var isValid = input.IsValid();

        // Console.WriteLine(reason);
        // Assert.Equal(expected, isValid);

        Assert.True(isValid == expected, userMessage: reason);
    }
}