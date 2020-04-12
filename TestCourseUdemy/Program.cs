using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCourseUdemy.Data;
using TestCourseUdemy.Work;

namespace TestCourseUdemy
{
    class Program
    {

        private static readonly FileReader _fileReader = new FileReader();

        private static readonly WordMatcher _wordMatcher = new WordMatcher();





        static void Main(string[] args)
        {

            try {
                bool continuExecution = true;


                do
                {
                    Console.WriteLine(Constants.OptionsOnHowToEnterScrambledWords);
                    string choice = Console.ReadLine() ?? string.Empty;



                    switch (choice.ToUpper())
                    {

                        case Constants.File:

                            Console.Write(Constants.EnterScrambledWordsViaFile);
                            ExecuteUnscrambleWordsFromFile();
                            break;


                        case Constants.Manuel:

                            Console.Write(Constants.EnterScrambledWordsManually);
                            ExecuteUnscrambleWordsManually();
                            break;

                        default:

                            Console.Write(Constants.EnterScrabledWordsOptionNotRecognized);
                            break;

                    }

                    var continueorLeave = string.Empty;
                    do
                    {

                        Console.Write(Constants.OptionsOnContinuingTheProgram);
                        continueorLeave = Console.ReadLine() ?? string.Empty;



                    } while (!continueorLeave.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) && !continueorLeave.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));

                    continuExecution = continueorLeave.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase);




                } while (continuExecution);
            }
            catch (Exception e)
            {

                Console.WriteLine(Constants.ErrorProgramWillBeTerminated + e.Message);

            }
        }



            

        private static void ExecuteUnscrambleWordsManually()
        {

            var manualInput = Console.ReadLine() ?? string.Empty;

            string[] scrambleWords = manualInput.Split(',');

            DisplayMatchedUnscrambleWords(scrambleWords);

            
        }

      

        private static void ExecuteUnscrambleWordsFromFile()
        {
            try
            {
                var filename = Console.ReadLine() ?? string.Empty;

                string[] scrambleWords = _fileReader.Read(filename);

                DisplayMatchedUnscrambleWords(scrambleWords);
            }
            catch(Exception e)
            {
                Console.WriteLine(Constants.ErrorScrambledWordsCannotBeLoaded + e.Message);
            }
           

        }


        private static void DisplayMatchedUnscrambleWords(string[] scrambleWords)
        {


            string[] wordList = _fileReader.Read(Constants.wordListFileName);


            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambleWords, wordList);

            if(matchedWords.Any())
            {

                foreach(var matchedWord in matchedWords)
                {
                    Console.WriteLine(Constants.MatchFound, matchedWord.ScrambledWord, matchedWord.Word);
                }

            }else
            {

                Console.WriteLine(Constants.MatchNotFound);

            }

        }
    }

    
}
