static bool CanSum(int target, int[] list, Dictionary<int, bool>? memo = null)
{
    memo ??= [];
    var hasValueInMemo = memo.TryGetValue(target, out var value);
    if (hasValueInMemo) return value;
    if (target == 0) return true;
    if (target < 0) return false;
    foreach (var num in list)
    {
        var remainder = target - num;
        if (CanSum(remainder, list, memo))
        {
            memo[remainder] = true;
            return true;
        }
    }
    memo[target] = false;
    return false;
}

Console.WriteLine(CanSum(7, [2, 3]));
Console.WriteLine(CanSum(7, [5, 3, 4, 7]));
Console.WriteLine(CanSum(7, [2, 4]));
Console.WriteLine(CanSum(8, [2, 3, 5]));
Console.WriteLine(CanSum(300, [7, 14]));