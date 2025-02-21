using System;

public class StringOperations
{
    private string _string;

    public StringOperations(string str = "")
    {
        _string = str;
    }

    public string Concatenate(string concate)
    {
        string concateString = _string + concate;
        return concateString;
    }

    public (string, string, int, int, string) Substring(string text)
    {
        string index = text.Substring(3);
        string result = text.Substring(0, 4);
        int indexOfChar = text.IndexOf('a');
        int indexOfWord = text.IndexOf("In");
        string lastChar = text.Substring(text.Length-2);

        return (index, result, indexOfChar, indexOfWord, lastChar);
    }

    public bool Contains(string subString)
    {
        return _string.Contains(subString);
    }

    public string ToLower()
    {
        return _string.ToLower();
    }

    public string ToUpper()
    {
        return _string.ToUpper();
    }

    public string Trim()
    {
        return _string.Trim();
    }

    public bool StartsWith(string prefix) => _string.StartsWith(prefix);

    public bool EndsWith(string suffix) => _string.EndsWith(suffix);

    public string Replace(string oldString, string newsString)
    {
        return _string.Replace(oldString, newsString);
    }

    public string[] Split(string sentences) => sentences.Split(' ');

    public string Compare(string compareString)
    {
        int comparisonResult = string.Compare(_string, compareString);
        if (comparisonResult == 0)
            return "Equal";
        else if (comparisonResult < 0)
            return "Less than";
        else
            return "Greater than";
    }

    public (string, string) Join(string[] text)
    {
        string joinText = string.Join("/", text);
        string joinWithIndexText = string.Join("", text, 1, 2);

        return (joinText, joinWithIndexText);
    }

    static void Main()
    {

        StringOperations stringOperations = new StringOperations("Hello, India");

        string concate = " where are you";
        Console.Write("The concatenate strings are: ");
        Console.WriteLine(stringOperations.Concatenate(concate));

        var result = stringOperations.Substring("India");
        Console.WriteLine($"\n\nSubstring from index 3: {result.Item1}");
        Console.WriteLine($"Substring from index 0, length 4: {result.Item2}");
        Console.WriteLine($"Index of 'a': {result.Item3}");
        Console.WriteLine($"Index of 'In': {result.Item4}");
        Console.WriteLine($"Last 2 characters: {result.Item5}");

        Console.Write("\n\nThe contains string is: ");
        Console.WriteLine(stringOperations.Contains("India"));

        Console.Write("\n\nThe lower case string is: \n");
        Console.WriteLine(stringOperations.ToLower());
        Console.Write("\nThe upper case string is: \n");
        Console.WriteLine(stringOperations.ToUpper());

        Console.Write("\nThe trim string is: \n");
        Console.WriteLine(stringOperations.Trim());

        Console.Write("\nThe starts with string is: \n");
        Console.WriteLine(stringOperations.StartsWith("Hello"));
        Console.Write("\nThe ends with string is: \n");
        Console.WriteLine(stringOperations.EndsWith("e"));

        Console.Write("\nThe Replace string is: \n");
        Console.WriteLine(stringOperations.Replace("India", "everyone"));

        Console.Write("\nThe Split string is: \n");
        string[] words = stringOperations.Split("Hi EPAM India");
        foreach (var word in words)
        {
            Console.WriteLine("\nThe splitted words are:" + word);
        }

        Console.Write("\nThe Compare strings are: ");
        Console.WriteLine(stringOperations.Compare("Hello, India"));
        Console.Write("\nThe Compare strings are: ");
        Console.WriteLine(stringOperations.Compare("Goodbye, India"));

        Console.Write("\nThe Join strings are: \n");
        var joinResult = stringOperations.Join(new string[] { "C#", "Java", "C++" });
        Console.WriteLine("Full Join: " + joinResult.Item1);
        Console.WriteLine("Subset Join: " + joinResult.Item2);

        Console.ReadLine();
    }
}