static int[]? HowSum(int target, int[] list, Dictionary<int, int[]?>? memo = null)
{
    memo ??= [];
    var hasValueInMemo = memo.TryGetValue(target, out var result);
    if (hasValueInMemo) return result;
    if (target == 0) return [];
    if (target < 0) return null;

    foreach (var num in list)
    {
        var remainder = target - num;
        var remainderResult = HowSum(remainder, list, memo);
        if (remainderResult is { })
        {
            memo[remainder] = [.. remainderResult, num];
            return memo[remainder];
        }
    }
    memo[target] = null;
    return null;
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

PrintList(HowSum(7, [2, 3]));
PrintList(HowSum(7, [5, 3, 4, 7]));
PrintList(HowSum(7, [2, 4]));
PrintList(HowSum(8, [2, 3, 5]));
PrintList(HowSum(300, [7, 14]));