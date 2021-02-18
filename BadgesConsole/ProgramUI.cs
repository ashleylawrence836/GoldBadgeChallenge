using BadgesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesConsole
{
    class ProgramUI
    {
        private readonly BadgesRepository _repo = new BadgesRepository();
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
                Console.WriteLine("Hello Security Admin. What would you like to do? \n\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        ListAllBadges();
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

        public List<string> AddDoorsToBadge(Badges badge)
        {
            Console.WriteLine("List a door that it needs access to.");
            string newDoor = Console.ReadLine();
            badge.DoorNames.Add(newDoor);

            Console.WriteLine("Any other doors? (y/n)");
            string anotherDoor = Console.ReadLine().ToLower();
            if (anotherDoor == "y")
            {
                AddDoorsToBadge(badge);
            }
            return badge.DoorNames;

        }

        private void AddBadge()
        {
            Badges newBadge = new Badges();

            Console.WriteLine("What is the number on the badge?");
            string stringInput = Console.ReadLine();
            bool input = Int32.TryParse(stringInput, out int result);
            if (input)
            {
                newBadge.BadgeID = result;
                newBadge.DoorNames = AddDoorsToBadge(newBadge);
            }
        }
        private string DoorList(List<string> doors)
        {
            string doorList = "+";
            foreach (string door in doors)
            {
                doorList = doorList + $", {door}";
            }
            return doorList.Replace("+, ", "");
        }

        private void ListAllBadges()
        {
            string output = string.Format("{0,-10}{1,-100}\n",
                "Badge #",
                "Door Access");

            Dictionary<int, List<string>> allBadges = _repo.ShowBadges();
            foreach (var badge in allBadges)
            {
                output += string.Format("{0,-10}{1,-100}\n",
                    badge.Key,
                    (badge.Value));
                //^^^
            }
            Console.WriteLine(output);
        }

        private void UpdateBadge()
        {
            Console.WriteLine("What is the badge number you would like to update?");
            string input = Console.ReadLine();
            Console.Clear();
            if (Int32.TryParse(input, out int result))
            {
                Badges editBadge = _repo.GetBadgeById(result);
                if (editBadge == null)
                {
                    Console.WriteLine("That badge doesn't exist. Press any key to continue.");
                    Console.ReadKey();
                    UpdateBadge();
                }
                DoorAccess(editBadge);
                EditBadge(editBadge);
            }
        }
        private void DoorAccess(Badges badge)
        {
            string doorList = DoorList(badge.DoorNames);
            Console.WriteLine($"{badge.BadgeID} has access to {doorList}\n");
        }

        private void EditBadge(Badges badge)
        {

            Console.WriteLine("What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Which door would you like to remove?");
                string input = Console.ReadLine();
                bool match = _repo.DeleteDoorsFromBadge(badge.BadgeID, input);
                if (match)
                {
                    Console.WriteLine("Door removed.");
                    DoorAccess(badge);
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    ListAllBadges();
                }

                Console.WriteLine("That door isn't associated with this badge.");
                Console.ReadKey();
                ListAllBadges();
            }
            else if (choice == "2")
            {
                Console.WriteLine("Which door would you like to add?");
                string response = Console.ReadLine();
                bool matching = _repo.AddDoors(badge.BadgeID, response);
                if (matching)
                {
                    Console.WriteLine("Door added.");
                    DoorAccess(badge);
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    ListAllBadges();
                }
                Console.WriteLine("Unable to add. Press any key to continue");
            }
            Console.WriteLine("Change your mind? Press any key to return to the main menu.");
            Console.ReadKey();
            ListAllBadges();
        }

        public void SeedMenu()
        {
            List<string> doorOne = new List<string>() { "A7" };
            _repo.AddBadge(new Badges(12345, doorOne));

            List<string> doorTwo = new List<string>() { "A1, A4, B1, B2" };
            _repo.AddBadge(new Badges(22345, doorTwo));

            List<string> doorThree = new List<string>() { "A4, A5" };
            _repo.AddBadge(new Badges(32345, doorThree));
        }
    }

}

