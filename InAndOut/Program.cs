using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace InAndOut
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Print.PrintIntroduction();
            Stopwatch sw = new Stopwatch();

            string playAgain;
            do
            {
                Console.Clear();
                List<int> playingWith = Operations.TakeInput();
                List<InOutModel> modelList = new List<InOutModel>();

                bool isSame = false;
                int steps = 0;
                sw.Start();
                while (!isSame)
                {
                    Console.WriteLine();
                    Console.Write("Step #" + (steps + 1) + ": ");
                    List<int> guessList = Operations.InputGuess();
                    Console.WriteLine();
                    var inOutObj = Operations.CalculateInAndOut(playingWith, guessList, modelList);
                    isSame = inOutObj.Item1;
                    modelList = inOutObj.Item2;
                    steps++;
                }
                sw.Stop();
                Print.PrintSuccess(Operations.JoinNumbers(playingWith), steps, sw.Elapsed);
                playAgain = Print.PlayAgain();
            } while (playAgain.ToLower().Equals("y"));

            Console.WriteLine();
            Console.WriteLine("Thank you for playing!!");
            Thread.Sleep(2000);
        }
    }
}
