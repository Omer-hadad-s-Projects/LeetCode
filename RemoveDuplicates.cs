//https://leetcode.com/problems/remove-duplicates-from-sorted-array/description/

namespace LeetCode
{
    public class RemoveDuplicates
    {
        public int RemoveDuplicatesSolution(int[] nums)
        {
            int? lastInsertion = null;
            var newArray = new int[nums.Length];
            var count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (lastInsertion.HasValue && lastInsertion.Value == nums[i]) continue;
                newArray[count] = nums[i];
                count++;
                lastInsertion = nums[i];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = newArray[i];
            }

            return count;
        }
    }
}

