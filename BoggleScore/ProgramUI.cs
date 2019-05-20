using System;

namespace BoggleScore
{
    internal class ProgramUI
    {
        internal void Run()
        {
            Console.WriteLine("Are you ready to score this round! Press any key to continue.");
            Console.ReadKey();
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                isRunning = Menu();
            }
        }

        private bool Menu()
        {
            bool isRunning = true;
            Console.WriteLine("Please enter the word");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                IWord word = new Word(input);
                Console.WriteLine($"Word Score: {word.CalculateScore()}");
                
                Console.WriteLine("Would you like to enter another word? Press Enter else type No");
                string answer = Console.ReadLine();
                if(answer.ToLower() == "no")
                {
                    return false;
                }
            }
            return isRunning;
        }
    }
}