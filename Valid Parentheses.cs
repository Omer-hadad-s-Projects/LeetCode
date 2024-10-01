namespace LeetCode;
//https://leetcode.com/problems/valid-parentheses/

public class Valid_Parentheses
{
    private static bool IsValid(string s)
    {
        if (s.Length == 0) return true;
        if (s.Length % 2 == 1) return false;
        var firstChar = s[0];
        var matchingChar = MatchingChars[firstChar];
        var length = s.Length;
        for (int i = length - 1; i > 0; i--)
        {
            if (s[i] != matchingChar) continue;
            var firstStr = s.Substring(1, i);
            var secondStr = i < length - 1 ? s.Substring(i + 1, length - i) : "";
            return IsValid(firstStr) && IsValid(secondStr);
        }

        return false;
    }

    private static Dictionary<char, char> MatchingChars = new Dictionary<char, char>()
    {
        { '{', '}' },
        { '[', ']' },
        { '(', ')' }
    };
}