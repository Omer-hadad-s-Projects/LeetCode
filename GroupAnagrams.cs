//https://leetcode.com/problems/group-anagrams/description/
using NUnit.Framework;

namespace LeetCode
{
    [TestFixture]
    public class GroupAnagrams
    {
        public IList<IList<string>> GroupAnagramsSolution(string[] strs)
        {
            var groups = new Dictionary<string, List<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                var sortedStr = SortString(strs[i]);
                if (!groups.ContainsKey(sortedStr))
                {
                    groups[sortedStr] = new List<string>();
                }

                groups[sortedStr].Add(strs[i]);
            }

            var result = new List<IList<string>>();
            foreach (var group in groups.Values)
            {
                result.Add(group);
            }

            return result;
        }

        private string SortString(string str)
        {
            return new string(str.OrderBy(c => c).ToArray());
        }

        [Test]
        public void GroupAnagramsSolution_Test1()
        {
            var input = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            var expected = new List<List<string>>
            {
                new List<string> { "bat" },
                new List<string> { "nat", "tan" },
                new List<string> { "ate", "eat", "tea" }
            };

            var result = GroupAnagramsSolution(input);

            Assert.AreEqual(expected.Count, result.Count);
            foreach (var group in expected)
            {
                Assert.IsTrue(result.Any(r => r.OrderBy(x => x).SequenceEqual(group.OrderBy(x => x))));
            }
        }

        [Test]
        public void GroupAnagramsSolution_Test2()
        {
            var input = new string[] { "" };
            var expected = new List<List<string>>
            {
                new List<string> { "" }
            };

            var result = GroupAnagramsSolution(input);

            Assert.AreEqual(expected.Count, result.Count);
            foreach (var group in expected)
            {
                Assert.IsTrue(result.Any(r => r.OrderBy(x => x).SequenceEqual(group.OrderBy(x => x))));
            }
        }

        [Test]
        public void GroupAnagramsSolution_Test3()
        {
            var input = new string[] { "a" };
            var expected = new List<List<string>>
            {
                new List<string> { "a" }
            };

            var result = GroupAnagramsSolution(input);

            Assert.AreEqual(expected.Count, result.Count);
            foreach (var group in expected)
            {
                Assert.IsTrue(result.Any(r => r.OrderBy(x => x).SequenceEqual(group.OrderBy(x => x))));
            }
        }
    }
}