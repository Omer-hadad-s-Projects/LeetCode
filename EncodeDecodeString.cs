//https://neetcode.io/problems/string-encode-and-decode

using NUnit.Framework;


namespace LeetCode
{
    [TestFixture]
    public class EncodeDecodeString
    {
        private const char LetterEnd = ';';
        private const char WordEnd = '|';

        private string Encode(IList<string> strs)
        {
            var result = "";
            foreach (var str in strs)
            {
                foreach (var c in str)
                {
                    result += $"{(int)c}{LetterEnd}";
                }

                if (string.IsNullOrEmpty(str))
                {
                    result += "-1;";
                }

                result += WordEnd;
            }

            return result;
        }

        [Test]
        public void Encode_Test1()
        {
            var input = new List<string> { "neet", "code", "love", "you" };
            var expected = "110;101;101;116;|99;111;100;101;|108;111;118;101;|121;111;117;|";

            var result = Encode(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Encode_Test2()
        {
            var input = new List<string> { "we", "say", ":", "yes" };
            var expected = "119;101;|115;97;121;|58;|121;101;115;|";

            var result = Encode(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Encode_EmptyString_Test()
        {
            var input = new List<string> { "" };
            var expected = "-1;|";

            var result = Encode(input);

            Assert.AreEqual(expected, result);
        }

        private List<string> Decode(string s)
        {
            var encodedWords = s.Split(WordEnd).Where(word => !string.IsNullOrEmpty(word));
            var result = new List<string>();
            foreach (var encodedWord in encodedWords)
            {
                var encodedLetters = encodedWord.Split(LetterEnd).Where(letter => !string.IsNullOrEmpty(letter));
                var decodedWord = "";
                foreach (var encodedLetter in encodedLetters)
                {
                    var numValue = int.Parse(encodedLetter);
                    decodedWord += numValue == -1 ? "" : (char)numValue;
                }

                result.Add(decodedWord);
            }

            return result;
        }

        [Test]
        public void Decode_Test1()
        {
            var input = "110;101;101;116;|99;111;100;101;|108;111;118;101;|121;111;117;|";
            var expected = new List<string> { "neet", "code", "love", "you" };

            var result = Decode(input);

            Assert.AreEqual(expected.Count, result.Count);

            foreach (var word in expected)
            {
                Assert.IsTrue(result.Contains(word));
            }
        }

        [Test]
        public void Decode_Test2()
        {
            var input = "119;101;|115;97;121;|58;|121;101;115;|";
            var expected = new List<string> { "we", "say", ":", "yes" };

            var result = Decode(input);

            Assert.AreEqual(expected.Count, result.Count);

            foreach (var word in expected)
            {
                Assert.IsTrue(result.Contains(word));
            }
        }

        [Test]
        public void Decode_EmptyString_Test()
        {
            var input = "-1;|";
            var expected = new List<string> { "" };

            var result = Decode(input);

            Assert.AreEqual(expected.Count, result.Count);

            foreach (var word in expected)
            {
                Assert.IsTrue(result.Contains(word));
            }
        }
    }
}