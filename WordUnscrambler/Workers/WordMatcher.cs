using System;
using System.Collections.Generic;
using WordUnscrambler.Data;

namespace WordUnscrambler.Workers
{
    public class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList) //for every scrambled word look at word list, if matched return it.
        {
            var matchedWords = new List<MatchedWord>();
            foreach (var scrambledWord in scrambledWords)
            {
                foreach (var word in wordList)
                {
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWord(scrambledWord, word));//characters AND order of characters match
                    }
                    else
                    {
                        var scrambledWordArray = scrambledWord.ToCharArray();//breaks string into array of characters
                        var wordArray = word.ToCharArray();//now have character array for both parts of foreach loop

                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);

                        var sortedScrambledWord = new string(scrambledWordArray); //how to turn character array into a string
                        var sortedWord = new string(wordArray);

                        if(sortedScrambledWord.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                        }

                    }

                }
            }

            return matchedWords;
        }
        private MatchedWord BuildMatchedWord(string scrambledWord, string word)//made Private. Helper method for Match above.
        {
            MatchedWord matchedWord = new MatchedWord
            {
                ScrambledWord = scrambledWord,
                Word = word
            };
            return matchedWord;

            
        }
    }
}
