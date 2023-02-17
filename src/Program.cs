// See https://aka.ms/new-console-template for more information

Console.WriteLine("Please input your string:");

var content = Console.ReadLine();
var input = new Input(content);
var isValid = input.IsValid();

Console.WriteLine($"{isValid} - Your content is {(isValid ? "valid" : "invalid")}.");