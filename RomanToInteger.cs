namespace LeetCode;

//https://leetcode.com/problems/roman-to-integer/description/
public static class RomanToInteger
{
    public static void Run()
    {
        Console.WriteLine(Solution("III"));
        Console.WriteLine(Solution("LVIII"));
        Console.WriteLine(Solution("MCMXCIV"));
    }
    
    private static int Solution(string s)
    {
        var charValues = new Dictionary<char, int>()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        var sum = 0;
        
        for (int i = 0; i < s.Length; i++)
        {
            var value = charValues[s[i]];
            if (i == s.Length - 1)
            {
                sum += value;
                continue;
            }
            var nextValue = charValues[s[i + 1]];
            if (value >= nextValue)
            {
                sum += value;
            }
            else
            {
                sum += nextValue - value;
                i++;
            }
        }

        return sum;

    }
}