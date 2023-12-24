static bool CanConstruct(string target, string[] wordBank, Dictionary<string, bool>? memo = null)
{
    memo ??= [];
    var hasValueInMemo = memo.TryGetValue(target, out var value);
    if (hasValueInMemo) return value;
    if (string.IsNullOrEmpty(target)) return true;

    foreach (var word in wordBank)
    {
        if (target.StartsWith(word))
        {
            var suffix = target[word.Length..];
            if (CanConstruct(suffix, wordBank, memo))
            {
                memo[suffix] = true;
                return true;
            }
        }
    }
    memo[target] = false;
    return false;
}

Console.WriteLine(CanConstruct("abcdef", ["ab", "abc", "cd", "def", "abcd"])); // True
Console.WriteLine(CanConstruct("skateboard", ["bo", "rd", "ate", "t", "ska", "sk", "boar"])); // False
Console.WriteLine(CanConstruct("enterapotentpot", ["a", "p", "ent", "enter", "ot", "o", "t"])); // True
Console.WriteLine(CanConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", ["e", "ee", "eee", "eeee", "eeeee"])); // True