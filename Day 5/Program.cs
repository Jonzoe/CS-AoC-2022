var input = File.ReadAllText("C:\\Users\\emil.jonsson8\\source\\repos\\AoC\\C# 2022\\Input\\Day 5.txt");

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

var Split = input.Split("\n").ToArray();

bool Part1 = false;

// Part 1
if (Part1 == true)
{
    foreach (var x in Split)
    {
        var formatting = x.Split(" ").ToArray();

        int ColumnMove = Int32.Parse(formatting[1]);
        int ColumnFrom = Int32.Parse(formatting[3]);
        int ColumnTo = Int32.Parse(formatting[5]);

        while (ColumnMove-- > 0)
        {
            stacks[ColumnTo - 1].Push(stacks[ColumnFrom - 1].Pop());
        }
    }
    Console.WriteLine(string.Join("", stacks.Select(x => x.Peek())));
}

// Part 2
if (Part1 == false)
{
    foreach (var x in Split)
    {
        var formatting = x.Split(" ").ToArray();

        int ColumnMove = Int32.Parse(formatting[1]);
        int ColumnFrom = Int32.Parse(formatting[3]);
        int ColumnTo = Int32.Parse(formatting[5]);

        var MoveStack = new Stack<char>();

        while (ColumnMove-- > 0)
        {
            MoveStack.Push(stacks[ColumnFrom - 1].Pop());
        }

        while (MoveStack.Count > 0)
        {
            stacks[ColumnTo - 1].Push(MoveStack.Pop());
        }
    }
    Console.WriteLine(string.Join("", stacks.Select(x => x.Peek())));
}