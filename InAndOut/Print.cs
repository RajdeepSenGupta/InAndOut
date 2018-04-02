using System;
using System.Collections.Generic;

namespace InAndOut
{
    public static class Print
    {
        /// <summary>
        /// Print Introduction
        /// </summary>
        public static void PrintIntroduction()
        {
            Console.WriteLine("Welcome to In And Out!");
            Console.WriteLine("This is a game to test your intelligence!");
            Console.WriteLine("We will generate a number that you need to guess.");
            Console.WriteLine();
            Console.WriteLine("With each guess, we will tell you two things: ");
            Console.WriteLine("1. 'In' -> How many digits are correct and are in place");
            Console.WriteLine("2. 'Out' -> How many digits are correct but not in place");
            Console.WriteLine();
            Console.WriteLine("So, are you ready? Press any key to begin..");
            Console.ReadLine();
        }

        /// <summary>
        /// Print Ins and Outs
        /// </summary>
        /// <param name="ins"></param>
        /// <param name="outs"></param>
        public static void PrintInAndOut(List<InOutModel> inOutModelList)
        {
            int step = 0;
            Console.Clear();
            Console.WriteLine("Step\tGuess\tIn\tOut");
            Console.WriteLine("_____\t____\t____\t____");
            foreach (InOutModel inOutModel in inOutModelList)
            {
                Console.Write(++step + "\t");
                Console.Write(inOutModel.GuessedNumber + "\t");
                Console.Write(inOutModel.Ins + "\t");
                Console.WriteLine(inOutModel.Outs);
            }
            Console.WriteLine("\n");
        }

        /// <summary>
        /// Print success message
        /// </summary>
        /// <param name="playingWith"></param>
        public static void PrintSuccess(int playingWith, int steps, TimeSpan timeElapsed)
        {
            Console.WriteLine();
            Console.WriteLine("Congratulations!");
            Console.WriteLine("You have successfully guessed the number " + playingWith + "!!");
            Console.WriteLine("Steps taken: " + steps);
            Console.WriteLine("Time taken: " + timeElapsed);
        }

        /// <summary>
        /// Ask for play again
        /// </summary>
        /// <returns></returns>
        public static string PlayAgain()
        {
            Console.WriteLine();
            Console.Write("Would you like to play again (Y/N)? ");
            return Console.ReadLine();
        }
    }
}
