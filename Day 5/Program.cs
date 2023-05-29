//Input text
var input = File.ReadAllText("C:\\Users\\emil.jonsson8\\source\\repos\\AoC\\C# 2022\\Input\\Day 5.txt");

#region Rows
//All the crate stacks
var stacks = new List<Stack<char>>()
{
    new Stack<char>(new[] { 'D', 'M', 'S', 'Z', 'R', 'F', 'W', 'N' }),
    new Stack<char>(new[] { 'W', 'P', 'Q', 'G', 'S'}),
    new Stack<char>(new[] { 'W', 'R', 'V', 'Q', 'F', 'N', 'J', 'C' }),
    new Stack<char>(new[] { 'F', 'Z', 'P', 'C', 'G', 'D', 'L' }),
    new Stack<char>(new[] { 'T', 'P', 'S' }),
    new Stack<char>(new[] { 'H', 'D', 'F', 'W', 'R', 'L' }),
    new Stack<char>(new[] { 'Z', 'N', 'D', 'C' }),
    new Stack<char>(new[] { 'W', 'N', 'R', 'F', 'V', 'S', 'J', 'Q' }),
    new Stack<char>(new[] { 'R', 'M', 'S', 'G', 'Z', 'W', 'V' })
};
#endregion

//Input text without newlines
var Split = input.Split("\n").ToArray();

//Change this to true if you want the answer to part 1
bool Part1 = false;

//Part 1
if (Part1 == true)
{
    foreach (var x in Split)
    {
        //Splits the text again on spaces
        var formatting = x.Split(" ").ToArray();

        //How many crates to move
        int ColumnMove = Int32.Parse(formatting[1]);

        //The rows to move to and from
        int ColumnFrom = Int32.Parse(formatting[3]);
        int ColumnTo = Int32.Parse(formatting[5]);

        //Moves all the crates
        while (ColumnMove-- > 0)
        {
            stacks[ColumnTo - 1].Push(stacks[ColumnFrom - 1].Pop());
        }
    }
    //Prints the answer
    Console.WriteLine(string.Join("", stacks.Select(x => x.Peek())));
}

//Part 2
if (Part1 == false)
{
    foreach (var x in Split)
    {
        //Splits the text again on spaces
        var formatting = x.Split(" ").ToArray();

        //How many crates to move
        int ColumnMove = Int32.Parse(formatting[1]);

        //The rows to move to and from
        int ColumnFrom = Int32.Parse(formatting[3]);
        int ColumnTo = Int32.Parse(formatting[5]);

        //Temporary stack for the moved items
        var MoveStack = new Stack<char>();

        //Moves the crates into the temporary stack
        while (ColumnMove-- > 0)
        {
            MoveStack.Push(stacks[ColumnFrom - 1].Pop());
        }

        //Moves the crates from the temporary stack back into the destination column
        while (MoveStack.Count > 0)
        {
            stacks[ColumnTo - 1].Push(MoveStack.Pop());
        }
    }
    //Prints the answer
    Console.WriteLine(string.Join("", stacks.Select(x => x.Peek())));
}