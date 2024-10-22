using Xunit;

namespace FoleySolution
{
    public class ConcordanceTests
    {
        [Fact(DisplayName = "Should return correct word counts and sentences")]
        public void ShouldReturnCorrectWordCountsAndSentences()
        {
            // Arrange - specify text for testing purpose
            var testText = "There is a sample text. It is just for testing purpose. Text";

            // Act - execute code
            var actual = Concordance.GenerateConcordance(testText);

            //Expected result
            var expected = new Dictionary<string, WordInfo>
            {
                { "there", new WordInfo { Total = 1, SentenceNumbers = new HashSet<int> { 1 } } },
                { "is", new WordInfo { Total = 2, SentenceNumbers = new HashSet<int> { 1, 2 } } },
                { "a", new WordInfo { Total = 1, SentenceNumbers = new HashSet<int> { 1 } } },
                { "sample", new WordInfo { Total = 1, SentenceNumbers = new HashSet<int> { 1 } } },
                { "text", new WordInfo { Total = 2, SentenceNumbers = new HashSet<int> { 1, 3 } } },
                { "it", new WordInfo { Total = 1, SentenceNumbers = new HashSet<int> { 2 } } },
                { "just", new WordInfo { Total = 1, SentenceNumbers = new HashSet<int> { 2 } } },
                { "for", new WordInfo { Total = 1, SentenceNumbers = new HashSet<int> { 2 } } },
                { "testing", new WordInfo { Total = 1, SentenceNumbers = new HashSet<int> { 2 } } },
                { "purpose", new WordInfo { Total = 1, SentenceNumbers = new HashSet<int> { 2 } } }
            };


            // Assert - verify expected and actual result
            Assert.Equivalent(expected, actual);
        }

        [Fact(DisplayName = "Text is empty")]
        public void EmptyText()
        {
            var testText = "";

            var result = Concordance.GenerateConcordance(testText);

            Assert.Empty(result);
        }

        [Fact(DisplayName = "Text is null")]
        public void GenerateConcordance_TextNull()
        {
            string testText = null;

            var result = Concordance.GenerateConcordance(testText);

            Assert.Empty(result);
        }

        [Fact(DisplayName = "Text contains only spaces")]
        public void TextWithOnlySpaces()
        {
            string testText = "   ";

            var result = Concordance.GenerateConcordance(testText);

            Assert.Empty(result);
        }


        [Fact(DisplayName = "Text contains special symbols")]
        public void TextWithSpecialSymbols()
        {
            string testText = "My name is \"Anna\". \'My email is test@gmail.com. Anna is beautiful name";

            var result = Concordance.GenerateConcordance(testText);

            var expected = new Dictionary<string, WordInfo>
            {
                { "my", new WordInfo { Total = 2, SentenceNumbers = new HashSet<int> { 1, 2 } } },
                { "name", new WordInfo { Total = 2, SentenceNumbers = new HashSet<int> { 1, 3 } } },
                { "is", new WordInfo { Total = 3, SentenceNumbers = new HashSet<int> { 1, 2, 3 } } },
                { "anna", new WordInfo { Total = 2, SentenceNumbers = new HashSet<int> { 1, 3 } } },
                { "email", new WordInfo { Total = 1, SentenceNumbers = new HashSet<int> { 2 } } },
                { "test@gmail.com", new WordInfo { Total = 1, SentenceNumbers = new HashSet<int> { 2 } } },
                { "beautiful", new WordInfo { Total = 1, SentenceNumbers = new HashSet<int> { 3 } } }
            };

            Assert.Equivalent(expected, result);
        }

        [Fact(DisplayName = "Test case insensitivity")]
        public void TextTestCaseInsensitivity()
        {
            var testText = "Hello hello HeLLo.";

            var result = Concordance.GenerateConcordance(testText);

            var expected = new Dictionary<string, WordInfo>
            {
                { "hello", new WordInfo { Total = 3, SentenceNumbers = new HashSet<int> { 1 } } }
            };

            Assert.Equivalent(expected, result);
        }

        [Fact(DisplayName = "Single word repeated several times")]
        public void TestSingleWordRepeated()
        {
            var testText = "test test test. test. test";

            var result = Concordance.GenerateConcordance(testText);

            var expected = new Dictionary<string, WordInfo>
            {
                { "test", new WordInfo { Total = 5, SentenceNumbers = new HashSet<int> { 1, 2, 3 } } }
            };

            Assert.Equivalent(expected, result);
        }

        [Fact(DisplayName = "Text contains encoding symbols")]
        public void TextWithEncodedSymbols()
        {
            var testText = "The bird\r\n has a head\r\n";

            var result = Concordance.GenerateConcordance(testText);

            var expected = new Dictionary<string, WordInfo>
            {
                { "the", new WordInfo { Total = 1, SentenceNumbers = new HashSet<int> { 1 } } },
                { "bird", new WordInfo { Total = 1, SentenceNumbers = new HashSet<int> { 1 } } },
                { "has", new WordInfo { Total = 1, SentenceNumbers = new HashSet<int> { 1 } } },
                { "a", new WordInfo { Total = 1, SentenceNumbers = new HashSet<int> { 1 } } },
                { "head", new WordInfo { Total = 1, SentenceNumbers = new HashSet<int> { 1 } } },
            };

            Assert.Equivalent(expected, result);
        }
    }
}