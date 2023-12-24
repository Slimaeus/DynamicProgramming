static int GridTraveller(int row, int col, Dictionary<string, int>? memo = null)
{
    memo ??= [];
    var key = $"{row}-{col}";
    var hasValueInMemo = memo.TryGetValue(key, out var value);
    if (hasValueInMemo)
        return value;
    if (row == 1 && col == 1) return 1;
    if (row == 0 || col == 0) return 0;
    memo[key] = GridTraveller(row - 1, col, memo) + GridTraveller(row, col - 1, memo);
    return memo[key];
}

Console.WriteLine(GridTraveller(1, 1));
Console.WriteLine(GridTraveller(2, 2));
Console.WriteLine(GridTraveller(3, 3));
Console.WriteLine(GridTraveller(12, 12));
Console.WriteLine(GridTraveller(17, 18));