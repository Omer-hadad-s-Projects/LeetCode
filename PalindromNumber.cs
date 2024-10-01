namespace LeetCode;

//https://leetcode.com/problems/palindrome-number/description/
public static class PalindromNumber
{

    public static void Run()
    {
        Console.WriteLine(IsPalindrom(121));
        Console.WriteLine(IsPalindrom(-121));
        Console.WriteLine(IsPalindrom(500));
        Console.WriteLine(IsPalindrom(2222));
    }
    
    private static bool IsPalindrom(int x)
    {
        if (x < 0) return false;
        var original = x;
        var copy = 0;
        var i = 0;
        while(copy < original && x > 0)
        {
            copy *= 10;
            var leftover = x % 10;
            copy += leftover;
            x = (x - leftover) / 10;
        }  
        return copy == original;
    }
}