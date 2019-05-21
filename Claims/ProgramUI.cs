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
            //SeedData();
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
            Console.WriteLine("Please fill out the following information.\n" +
                "Claim ID: ");
            int claimId = VerifyIntput();
            bool success = false;
            ClaimType claimType = ClaimType.Car;
            while (!success)
            {
                Console.WriteLine("Claim Type: " +
                    "1. Car\n" +
                    "2. Home\n" +
                    "3. Theft");
                int input = VerifyIntput();
                
                if (input >= 1 && input <= 3)
                {
                    claimType = _claimRepo.GetClaimType(input);
                    success = true;
                }
            }
            Console.WriteLine("Enter Description: ");
            string description = Console.ReadLine();
            Console.WriteLine("Amount Owed: ");
            decimal amount = VerifyDecimalIntput();
            Console.WriteLine("Date of Accident: ");
            DateTime accidentDate = VerifyDateTimeInput();
            DateTime claimDate = VerifyDateTimeInput();
            IClaim claim = new Claim(claimId, claimType, description, amount, accidentDate, claimDate);
            bool wasAdded = _claimRepo.AddClaimToQueue(claim);
            OperationStatus(wasAdded);
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
        private void PrintAllClaims()
        {
            var claims = _claimRepo.GetClaims();
            foreach (IClaim claim in claims)
            {
                claim.ToString();
            }
        }
        private void MenuPrompt()
        {
            Console.WriteLine("Please select from the following options\n" +
                "1. See All Claims\n" +
                "2. Handle Next Claim\n" +
                "3. Enter a New Claim" +
                "4. Exit");
        }
        private bool VerifyBoolInput()
        {
            bool successful = false;
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

        private DateTime VerifyDateTimeInput()
        {
            bool success = false;
            DateTime date = new DateTime(01, 01, 01);
            while (!success)
            {
                if (DateTime.TryParse(Console.ReadLine(), out date))
                {
                    success = true;
                }
                else
                {
                    Console.WriteLine("Invalid Input please try again.");
                }
            }
            return date;
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
        private void OperationStatus(bool success)
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
        //private void SeedData()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
