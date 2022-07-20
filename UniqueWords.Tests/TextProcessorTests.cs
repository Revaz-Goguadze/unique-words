using NUnit.Framework;

namespace UniqueWords.Tests
{
    [TestFixture]
    public class TextProcessorTests
    {
        private static readonly object[][] GetUniqueWordsFromArrayData =
        {
            new object[]
            {
                Array.Empty<string>(),
                new List<string> { },
            },
            new object[]
            {
                new string[] { "aaa" },
                new List<string> { "aaa" },
            },
            new object[]
            {
                new string[] { "aaa", "aaa" },
                new List<string> { "aaa" },
            },
            new object[]
            {
                new string[] { "aaa", "aaa", "aaa" },
                new List<string> { "aaa" },
            },
            new object[]
            {
                new string[] { "aaa", "bbb" },
                new List<string> { "aaa", "bbb" },
            },
            new object[]
            {
                new string[] { "aaa", "bbb", "aaa", "bbb" },
                new List<string> { "aaa", "bbb" },
            },
            new object[]
            {
                new string[] { "aaa", "bbb", "aaa", "bbb", "aaa", "bbb" },
                new List<string> { "aaa", "bbb" },
            },
            new object[]
            {
                new string[] { "aaa", "bbb", "ccc", "aaa", "bbb", "ccc", "aaa", "bbb", "ccc" },
                new List<string> { "aaa", "bbb", "ccc" },
            },
        };

        private static readonly object[][] GetUniqueWordsFromEnumerableData =
        {
            new object[]
            {
                Array.Empty<string>(),
                Array.Empty<string>(),
            },
            new object[]
            {
                new string[] { "aaa" },
                new string[] { "aaa" },
            },
            new object[]
            {
                new string[] { "aaa", "aaa" },
                new string[] { "aaa" },
            },
            new object[]
            {
                new string[] { "aaa", "aaa", "aaa" },
                new string[] { "aaa" },
            },
            new object[]
            {
                new string[] { "aaa aaa" },
                new string[] { "aaa" },
            },
            new object[]
            {
                new string[] { "aaa aaa", "aaa aaa" },
                new string[] { "aaa" },
            },
            new object[]
            {
                new string[] { "aaa aaa", "aaa aaa", "aaa aaa" },
                new string[] { "aaa" },
            },
            new object[]
            {
                new string[] { "aaa", "bbb" },
                new string[] { "aaa", "bbb" },
            },
            new object[]
            {
                new string[] { "aaa bbb", "bbb aaa" },
                new string[] { "aaa", "bbb" },
            },
            new object[]
            {
                new string[] { "aaa", "bbb", "aaa", "bbb" },
                new string[] { "aaa", "bbb" },
            },
            new object[]
            {
                new string[] { "aaa", "bbb", "aaa", "bbb", "aaa", "bbb" },
                new string[] { "aaa", "bbb" },
            },
            new object[]
            {
                new string[] { "aaa bbb aaa", "bbb aaa bbb", "aaa aaa bbb", "bbb bbb aaa", "aaa bbb bbb", "bbb aaa aaa" },
                new string[] { "aaa", "bbb" },
            },
            new object[]
            {
                new string[] { "aaa", "bbb", "ccc", "aaa", "bbb", "ccc", "aaa", "bbb", "ccc" },
                new string[] { "aaa", "bbb", "ccc" },
            },
            new object[]
            {
                new string[] { "aaa bbb ccc", "ccc bbb aaa", "aaa ccc bbb", "ccc aaa bbb", "ccc bbb ccc", "ddd ccc ddd", "ddd aaa ccc", "bbb ccc ddd", "eee ccc ddd" },
                new string[] { "aaa", "bbb", "ccc", "ddd", "eee" },
            },
        };

        private static readonly object[][] GetUniqueWordsArrayData =
        {
            new object[]
            {
                Array.Empty<string>(),
                ' ',
                Array.Empty<string[]>(),
            },
            new object[]
            {
                new string[] { "aaa" },
                ' ',
                new string[][] { new string[] { "aaa" } },
            },
            new object[]
            {
                new string[] { "aaa", "aaa" },
                ' ',
                new string[][] { new string[] { "aaa" }, Array.Empty<string>() },
            },
            new object[]
            {
                new string[] { "aaa", "bbb", "ccc" },
                ' ',
                new string[][] { new string[] { "aaa" }, new string[] { "bbb" }, new string[] { "ccc" } },
            },
            new object[]
            {
                new string[] { "aaa:bbb" },
                ':',
                new string[][] { new string[] { "aaa", "bbb" } },
            },
            new object[]
            {
                new string[] { "aaa@bbb", "bbb@ccc" },
                '@',
                new string[][] { new string[] { "aaa", "bbb" }, new string[] { "ccc" } },
            },
            new object[]
            {
                new string[] { "aaa$bbb", "bbb$aaa" },
                '$',
                new string[][] { new string[] { "aaa", "bbb" }, Array.Empty<string>() },
            },
            new object[]
            {
                new string[] { "aaa#bbb#ccc" },
                '#',
                new string[][] { new string[] { "aaa", "bbb", "ccc" } },
            },
            new object[]
            {
                new string[] { "aaa*bbb*ccc", "aaa", "bbb", "ccc" },
                '*',
                new string[][] { new string[] { "aaa", "bbb", "ccc" }, Array.Empty<string>(), Array.Empty<string>(), Array.Empty<string>() },
            },
            new object[]
            {
                new string[] { "aaa^bbb", "aaa^ccc", "ccc^bbb", "aaa^bbb^ccc^eee^fff" },
                '^',
                new string[][] { new string[] { "aaa", "bbb" }, new string[] { "ccc" }, Array.Empty<string>(), new string[] { "eee", "fff" } },
            },
            new object[]
            {
                new string[] { "   aaa  -  bbb       -                          ccc                                            " },
                '-',
                new string[][] { new string[] { "aaa", "bbb", "ccc" } },
            },
        };

        private static readonly object[][] GetUniqueWordsCollectionData =
        {
            new object[]
            {
                "aaa",
                ' ',
                new string[] { "aaa" },
            },
            new object[]
            {
                Environment.NewLine + "aaa" + Environment.NewLine,
                ' ',
                new string[] { "aaa" },
            },
            new object[]
            {
                "aaa" + Environment.NewLine + "bbb",
                ' ',
                new string[] { "aaa", "bbb" },
            },
            new object[]
            {
                Environment.NewLine + "aaa" + Environment.NewLine + "bbb" + Environment.NewLine,
                ' ',
                new string[] { "aaa", "bbb" },
            },
            new object[]
            {
                "aaa" + Environment.NewLine + "bbb" + Environment.NewLine + "ccc",
                ' ',
                new string[] { "aaa", "bbb", "ccc" },
            },
            new object[]
            {
                Environment.NewLine + "aaa" + Environment.NewLine + "bbb" + Environment.NewLine + "ccc" + Environment.NewLine,
                ' ',
                new string[] { "aaa", "bbb", "ccc" },
            },
            new object[]
            {
                "aaa:bbb",
                ':',
                new string[] { "aaa", "bbb" },
            },
            new object[]
            {
                Environment.NewLine + "abc#def" + Environment.NewLine,
                '#',
                new string[] { "abc", "def" },
            },
        };

        [TestCaseSource(nameof(GetUniqueWordsFromArrayData))]
        public void GetUniqueWordsFromArray_ReturnsUniqueWordList(string[] words, List<string> expectedResult)
        {
            List<string> actualResult = TextProcessor.GetUniqueWordsFromArray(words);

            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            Assert.That(actualResult, Is.EquivalentTo(expectedResult));
        }

        [TestCase("", ExpectedResult = 0)]
        [TestCase("          ", ExpectedResult = 0)]
        [TestCase("aaa", ExpectedResult = 1)]
        [TestCase("aaabbb", ExpectedResult = 1)]
        [TestCase("aaa bbb", ExpectedResult = 2)]
        [TestCase("aaa bbb ccc", ExpectedResult = 3)]
        [TestCase("aaa bbb ccc ddd", ExpectedResult = 4)]
        [TestCase("    aaa     bbb          ccc             ddd                   ", ExpectedResult = 4)]
        public int CountUniqueWordsInText_ReturnsUniqueWordsNumber(string text)
        {
            return TextProcessor.CountUniqueWordsInText(text);
        }

        [TestCaseSource(nameof(GetUniqueWordsFromEnumerableData))]
        public void GetUniqueWordsFromEnumerable_ReturnsUniqueWordList(IEnumerable<string> lines, IEnumerable<string> expectedResult)
        {
            IEnumerable<string> actualResult = TextProcessor.GetUniqueWordsFromEnumerable(lines);

            Assert.That(actualResult, Is.EquivalentTo(expectedResult));
        }

        [TestCaseSource(nameof(GetUniqueWordsArrayData))]
        public void GetUniqueWordsArray_ReturnsUniqueWordArray(IEnumerable<string> lines, char separator, string[][] expectedResult)
        {
            string[][] actualResult = TextProcessor.GetUniqueWordsArray(lines, separator);

            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            Assert.That(actualResult, Is.EquivalentTo(expectedResult));
        }

        [TestCaseSource(nameof(GetUniqueWordsCollectionData))]
        public void GetUniqueWordsCollection_ReturnsUniqueWordCollection(string text, char separator, string[] expectedResult)
        {
            ICollection<string> actualResult = TextProcessor.GetUniqueWordsCollection(text, separator);

            Assert.AreEqual(expectedResult.Length, actualResult.Count);
            Assert.That(actualResult, Is.EquivalentTo(expectedResult));
        }

        [TestCase("aaa", ',', new string[] { "aaa" })]
        [TestCase("   aaa   ", ',', new string[] { "aaa" })]
        [TestCase("aaa,bbb", ',', new string[] { "aaa", "bbb" })]
        [TestCase("   aaa   ,   bbb   ", ',', new string[] { "aaa", "bbb" })]
        [TestCase("aaa,bbb,ccc", ',', new string[] { "aaa", "bbb", "ccc" })]
        [TestCase("    aaa    ,    bbb    ,    ccc    ", ',', new string[] { "aaa", "bbb", "ccc" })]
        [TestCase("aaa,bbb,aaa", ',', new string[] { "aaa", "bbb" })]
        [TestCase("aaa,bbb,bbb", ',', new string[] { "aaa", "bbb" })]
        [TestCase("aaa,bbb,ccc,ddd", ',', new string[] { "aaa", "bbb", "ccc", "ddd" })]
        [TestCase("    aaa    ,    bbb    ,    ccc    ,    ddd    ", ',', new string[] { "aaa", "bbb", "ccc", "ddd" })]
        [TestCase("    aaa    ,    aaa    ,    aaa    ,    aaa    ", ',', new string[] { "aaa" })]
        [TestCase("    aaa    ,    bbb    ,    aaa    ,    bbb    ", ',', new string[] { "aaa", "bbb" })]
        [TestCase("    aaa    ,    bbb    ,    bbb    ,    ccc    ", ',', new string[] { "aaa", "bbb", "ccc" })]
        public void GetUniqueWordsInCharCollection_ReturnsUniqueWordsNumber(string text, char separator, ICollection<string> expectedResult)
        {
            char[] collection = text.ToCharArray();
            ICollection<string> actualResult = TextProcessor.GetUniqueWordsInCharCollection(collection, separator);

            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            Assert.That(actualResult, Is.EquivalentTo(expectedResult));
        }
    }
}
