using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    class ProgramUI
    {
        internal void Run()
        {
            SeedData();
            Console.WriteLine("Welcome to the Claims Handler! Press any key to continue.");
            Console.ReadKey();
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                MenuPrompt();
                isRunning = Menu();
            }
        }

        private bool Menu()
        {
            throw new NotImplementedException();
        }

        private void MenuPrompt()
        {
            throw new NotImplementedException();
        }

        private void SeedData()
        {
            throw new NotImplementedException();
        }
    }
}
