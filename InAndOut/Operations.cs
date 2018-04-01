using System;
using System.Collections.Generic;
using System.Linq;

namespace InAndOut
{
    public static class Operations
    {
        /// <summary>
        /// Takes input
        /// </summary>
        public static List<int> TakeInput()
        {
            int noOfDigits = 0;
            bool valid = false;

            #region Number related

            while (!valid)
            {
                Console.WriteLine();
                Console.Write("Enter the number of digits you want to play with: ");
                try
                {
                    noOfDigits = Convert.ToInt32(Console.ReadLine());
                    valid = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a valid numerical input!");
                    valid = false;
                }
            }

            int minNumber = MinNumber(noOfDigits);
            int maxNumber = MaxNumber(noOfDigits);

            #endregion

            #region Duplicate related

            Console.WriteLine();
            Console.WriteLine("Do you want to use duplicate digits (y/n)? ");
            string duplicateAllowance = Console.ReadLine();
            bool isDuplicateAllowed = (duplicateAllowance.ToLower().Equals("y"));

            #endregion

            #region Generate random number

            Random random = new Random();

            while (true)
            {
                int generatedNumber = random.Next(minNumber, maxNumber);
                List<int> playingWith = SplitDigits(generatedNumber);

                if (isDuplicateAllowed ||
                    (!isDuplicateAllowed && playingWith.Distinct().ToList().Count == playingWith.Count))
                {
                    return playingWith;
                }
            }

            #endregion
        }

        /// <summary>
        /// Takes guessed number
        /// </summary>
        /// <returns></returns>
        public static List<int> InputGuess()
        {
            int guess = 0;
            bool valid = false;
            while (!valid)
            {
                Console.WriteLine();
                Console.Write("Enter your guess: ");
                try
                {
                    guess = Convert.ToInt32(Console.ReadLine());
                    valid = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a valid numerical input!");
                    valid = false;
                }
            }

            return SplitDigits(guess);
        }

        /// <summary>
        /// Calculate Ins and Outs
        /// </summary>
        /// <param name="playingWith"></param>
        /// <param name="guessList"></param>
        public static Tuple<bool, List<InOutModel>> CalculateInAndOut(List<int> playingWith, List<int> guessList, List<InOutModel> modelList)
        {
            int ins = 0, outs = 0;

            foreach (int o in guessList)
            {
                if (playingWith.Contains(o) && guessList.IndexOf(o) != playingWith.IndexOf(o))
                    outs++;
                if (playingWith.Contains(o) && guessList.IndexOf(o) == playingWith.IndexOf(o))
                    ins++;
            }

            int guessedNumber = JoinNumbers(guessList);
            int realNumber = JoinNumbers(playingWith);
            modelList.Add(new InOutModel { GuessedNumber = guessedNumber, Ins = ins, Outs = outs });

            Print.PrintInAndOut(modelList);

            return Tuple.Create((realNumber == guessedNumber), modelList);
        }

        /// <summary>
        /// Joins a list of digits into a single integer
        /// </summary>
        /// <param name="numbersList"></param>
        /// <returns></returns>
        public static int JoinNumbers(List<int> numbersList)
        {
            return Convert.ToInt32(string.Join("", numbersList.ConvertAll(x => x.ToString())));
        }

        /// <summary>
        /// Generates minimum number of the specified length
        /// </summary>
        /// <param name="noOfDigits"></param>
        /// <returns></returns>
        private static int MinNumber(int noOfDigits)
        {
            return (int)Math.Pow(10, noOfDigits - 1);
        }

        /// <summary>
        /// Generates maximum number of the specified length
        /// </summary>
        /// <param name="noOfDigits"></param>
        /// <returns></returns>
        private static int MaxNumber(int noOfDigits)
        {
            int maxNumber = 0;
            for (int i = 0; i < noOfDigits; i++)
            {
                maxNumber += 9 * (int)Math.Pow(10, i);
            }
            return maxNumber;
        }

        /// <summary>
        /// Splits the number into digits
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static List<int> SplitDigits(int number)
        {
            return number.ToString().Select(i => int.Parse(i.ToString())).ToList();
        }
    }
}
