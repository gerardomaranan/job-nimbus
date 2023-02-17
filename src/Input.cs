public class Input
{
    public Input(string content)
    {
        this.Content = content;
    }

    public string? Content { get; set; }

    public bool IsValid()
    {
        var content = this.Content;

        if (string.IsNullOrEmpty(content))
        {
            return true;
        }

        var openingBrackets = new List<int>();
        var closingBrackets = new List<int>();

        foreach (var character in content.Select((value, index) => new { Index = index, Value = value.ToString() }))
        {
            if (character.Value == Brackets.Opening)
            {
                openingBrackets.Add(character.Index);
            }

            if (character.Value == Brackets.Closing)
            {
                closingBrackets.Add(character.Index);
            }
        }

        // Every bracket should have a pair.
        if (openingBrackets.Count != closingBrackets.Count)
        {
            return false;
        }

        // First In Last Out
        closingBrackets.Reverse();

        for (int index = 0; index < openingBrackets.Count; index++)
        {
            // Track Pairs
            var openingBracket = openingBrackets[index];
            var closingBracket = closingBrackets[index];

            // Opening bracket should come first before the closing bracket.
            if (closingBracket < openingBracket) return false;
        }

        return true;
    }
}
