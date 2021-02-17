using ClaimsLibrary.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsConsole
{
    class ProgramUI
    {
        ClaimsLibrary.Claims.ClaimsRepository _claimsRepo = new ClaimsLibrary.Claims.ClaimsRepository();
        public void Run()
        {
            SeedMenu();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueRun = true;
            while (continueRun)
            {
                Console.WriteLine("Choose a menu item: \n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        CreateClaim();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        continueRun = false;
                        break;
                    default:
                        Console.WriteLine("That is not a valid option");
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void ViewById(int id)
        {
            Console.Clear();
            Claim item = _claimsRepo.GetById(id);

            if (item != null)
            {
                Console.WriteLine($"ClaimID: {item.ClaimId}\n" +
                $"Type: {item.ClaimType}\n" +
                $"Description: {item.Description}\n" +
                $"Amount: ${item.ClaimAmount}\n" +
                $"DateOfIncident: {item.DateOfIncident}\n" +
                $"DateOfClaim: {item.DateOfClaim}\n" +
                $"IsValid: {item.IsValid}");
            }
        }

        private void ViewClaims()
        {
            Console.Clear();
            Queue<Claim> claimsList = _claimsRepo.GetClaims();

            foreach (Claim item in claimsList)
            {
                Console.WriteLine($"ClaimID: {item.ClaimId}\n" +
                $"Type: {item.ClaimType}\n" +
                $"Description: {item.Description}\n" +
                $"Amount: ${item.ClaimAmount}\n" +
                $"DateOfIncident: {item.DateOfIncident}\n" +
                $"DateOfClaim: {item.DateOfClaim}\n" +
                $"IsValid: {item.IsValid}");
            }
        }

        private void NextClaim()
        {
            Console.WriteLine("Here are the details for the next claim to be handled:");
            Queue<Claim> claimsList = _claimsRepo.GetClaims();
            int id = claimsList.Peek().ClaimId;
            ViewById(id);

            //Console.WriteLine("Do you want to deal with this claim now? (y/n)");
            //string input = Console.ReadLine().ToUpper();
            //if (input == y)
            //{

            //}

        }

        private void SeedMenu()
        {
            Claim claimOne = new Claim(1, ClaimType.Car, "Car accident on 465", 400.00, new DateTime(2018,04,25), new DateTime(2018,04,27));
            Claim claimTwo = new Claim(2, ClaimType.Home, "House fire in kitchen", 4000.00, new DateTime(2018,04,11), new DateTime(2018,04,12));
            Claim claimThree = new Claim(3, ClaimType.Theft, "Stolen pancakes", 4.00, new DateTime(2018,04,27), new DateTime(2018,06,01));

            _claimsRepo.AddClaimToQueue(claimOne);
            _claimsRepo.AddClaimToQueue(claimTwo);
            _claimsRepo.AddClaimToQueue(claimThree);
        }
        private void CreateClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            Console.WriteLine("Enter the claim number");
            string newNum = Console.ReadLine();
            newClaim.ClaimId = Convert.ToInt32(newNum);

            Console.WriteLine("Enter the type of claim.\n" +
                "1 = Car\n" +
                "2 = Home\n" +
                "3 = Theft");
            string stringType = Console.ReadLine();
            int type = Convert.ToInt32(stringType);
            newClaim.ClaimType = (ClaimType)type;

            Console.WriteLine("Please enter the claim description.");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Please enter the claim amount.");
            string stringAmount = Console.ReadLine();
            double amount = double.Parse(stringAmount);
            newClaim.ClaimAmount = amount;

            Console.WriteLine("Please enter the date of the incident. ( YYYY, MM, DD)");
            newClaim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Please enter the date of the claim. ( YYYY, MM, DD)");
            newClaim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            _claimsRepo.AddClaimToQueue(newClaim);
        }
    }
}
