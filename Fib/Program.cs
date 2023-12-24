static int Fib(int n, Dictionary<int, int>? memo = null)
{
    memo ??= [];
    var hasValueInMemo = memo.TryGetValue(n, out var result);
    if (hasValueInMemo) return result;
    if (n <= 2) return 1;
    memo[n] = Fib(n - 1, memo) + Fib(n - 2, memo);
    return memo[n];
};

Console.WriteLine(Fib(1));
Console.WriteLine(Fib(5));
Console.WriteLine(Fib(7));
Console.WriteLine(Fib(40));