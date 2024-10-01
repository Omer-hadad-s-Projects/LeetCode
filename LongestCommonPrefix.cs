namespace LeetCode;
using System;

//https://leetcode.com/problems/longest-common-prefix

public class LongestCommonPrefix
{
    public static void Run()
    {
        Console.WriteLine(Solution(new string[] { "flower", "flow", "flight" }));
        Console.WriteLine(Solution(new string[] { "dog","racecar","car" }));
    }
    private static string Solution(string[] strs)
    {
        var firstString = strs[0];

        int i;
        for (i = 0; i < firstString.Length; i++)
        {
            for (int j = 1; j < strs.Length; j++)
            {
                if (i >= strs[j].Length || firstString[i] != strs[j][i])
                {
                    return firstString.Substring(0, i);
                }
            }
        }

        return firstString;
    }
}