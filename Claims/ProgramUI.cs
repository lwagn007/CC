using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    class ProgramUI
    {
        IClaimRepository _claimRepo;
        public ProgramUI()
        {
            _claimRepo = new ClaimRepository();
        }
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
            int intput = VerifyIntput();
            switch (intput)
            {
                case 1:
                    PrintAllClaims();
                    return true;
                case 2:
                    HandleNextClaim();
                    return true;
                case 3:
                    AddNewClaim();
                    return true;
                case 4:
                    return false;
                default:
                    return true;
            }
        }

        private void AddNewClaim()
        {
            throw new NotImplementedException();
        }

        private bool HandleNextClaim()
        {
            Console.WriteLine("Would you like to handle the next claim? Y/N");
            var removeClaim = VerifyBoolInput();
            if (removeClaim)
            {
                var claim = _claimRepo.HandleClaim(removeClaim);
                var success = claim.Item1;
                var claimHandled = claim.Item2;
                claimHandled.ToString();
                return success;
            }
            else
                return true;
        }

        private bool VerifyBoolInput()
        {
            bool successful = true;
            while (!successful)
            {
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid input please try again.");
                    successful = false;
                }
            }
            return successful;
        }

        private void PrintAllClaims()
        {
            throw new NotImplementedException();
        }

        private void MenuPrompt()
        {
            Console.WriteLine("Please select from the following options\n" +
                "1. See All Claims\n" +
                "2. Handle Next Claim\n" +
                "3. Enter a New Claim" +
                "4. Exit");


        }
        private void SeedData()
        {
            throw new NotImplementedException();
        }
        private int VerifyIntput()
        {
            bool success = false;
            int intput = 0;
            while (!success)
            {
                if (int.TryParse(Console.ReadLine(), out intput))
                {
                    success = true;
                }
                else
                {
                    Console.WriteLine("Invalid Input please try again.");
                }
            }
            return intput;
        }
        private decimal VerifyDecimalIntput()
        {
            bool success = false;
            decimal input = 0m;
            while (!success)
            {
                if (decimal.TryParse(Console.ReadLine(), out input))
                {
                    success = true;
                }
                else
                {
                    Console.WriteLine("Invalid Input please try again.");

                }
            }
            return input;
        }
        private static void OperationStatus(bool success)
        {
            Console.Clear();
            if (success)
            {
                Console.WriteLine("\nOperation was successful. Press any key to continue.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nOperation was unsuccessful, please try again. Press any key to continue.");
                Console.ReadKey();
            }
        }
    }
}
