using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCourseUdemy.Data;

namespace TestCourseUdemy.Work
{
    class WordMatcher
    {
        internal List<MatchedWord> Match(string[] scrambleWords, string[] wordList)
        {

            var matchedWords = new List<MatchedWord>();




            foreach(var scarmbledWord in scrambleWords)
            {
                foreach(var word in wordList)
                {
                    if (scarmbledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWord(scarmbledWord, word));
                    }else
                    {
                        var scrambledWordArray = scarmbledWord.ToCharArray();
                        var wordArray = word.ToCharArray();


                        Array.Sort(scrambledWordArray);

                        Array.Sort(wordArray);


                        var sortedScrambledWord = new string(scrambledWordArray);
                        var sortedWord = new string(wordArray);

                        if (sortedScrambledWord.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchedWord(scarmbledWord, word));
                        }
                        else
                        {

                        }



                    }
                }
            }


            return matchedWords;
        }

        private MatchedWord BuildMatchedWord (string scrambledWord,string word)
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
