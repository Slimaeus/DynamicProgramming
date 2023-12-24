static int[]? BestSum(int target, int[] list, Dictionary<int, int[]?>? memo = null)
{
    memo ??= [];
    var hasValueInMemo = memo.TryGetValue(target, out var result);
    if (hasValueInMemo) return result;
    if (target == 0) return [];
    if (target < 0) return null;

    int[]? shortestCombination = null;

    foreach (var num in list)
    {
        var remainder = target - num;
        var remainderResult = BestSum(remainder, list, memo);
        if (remainderResult is { })
        {
            int[] combination = [.. remainderResult, num];
            if (shortestCombination is null || combination.Length < shortestCombination.Length)
            {
                shortestCombination = combination;
            }
        }
    }
    memo[target] = shortestCombination;
    return shortestCombination;
}

static void PrintList(int[]? list)
{
    if (list is null)
    {
        Console.WriteLine("Null");
        return;
    }
    Console.WriteLine("List: ");
    foreach (var num in list)
    {
        Console.Write("- ");
        Console.WriteLine(num);
    }
}

PrintList(BestSum(7, [2, 3]));
PrintList(BestSum(7, [5, 3, 4, 7]));
PrintList(BestSum(7, [2, 4]));
PrintList(BestSum(8, [2, 3, 5]));
PrintList(BestSum(300, [7, 14]));