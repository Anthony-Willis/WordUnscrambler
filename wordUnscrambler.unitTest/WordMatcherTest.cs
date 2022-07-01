using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordUnscrambler.Workers;

namespace wordUnscrambler.unitTest
{
    [TestClass]
    public class WordMatcherTest
    {

        private readonly WordMatcher _wordMatcher = new WordMatcher();

        [TestMethod]
        public void ScrambledWordsMatchesGivenWordInTheList()
        {
            string[] words = { "cat", "chair", "more" };
            string[] scrambledWords = { "omre" };

            var matchedWords = _wordMatcher.Match(scrambledWords, words);

            Assert.IsTrue(matchedWords.Count == 1);
            Assert.IsTrue(matchedWords[0].ScrambledWord.Equals("omre"));
            Assert.IsTrue(matchedWords[0].Word.Equals("more"));

        }
        
    }
}
