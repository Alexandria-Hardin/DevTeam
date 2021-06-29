using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoRepo;

namespace _00_Komodo_Insurance
{
    class ProgramUI
    {
        protected readonly DeveloperRepo _developerRepo = new DeveloperRepo();
        protected readonly DevTeamRepo _devTeamRepo = new DevTeamRepo();
        public void Run()
        {
            DisplayDirectory();
        }
        private void DisplayDirectory()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "Enter the number of the option you would like to select: \n" +
                    "1. Show all Developers\n" +
                    "2. Show all Developer Teams\n" +
                    "3. Find Developer by Name\n" +
                    "4. Find Developer Team by Team Name\n" +
                    "5. Add Developer\n" +
                    "6. Add Developer Team\n" +
                    "7. Remove Developer\n" +
                    "8. Remove Developer Team\n" +
                    "9. Update Developer\n" +
                    "10. Update Developer Team\n" +
                    "11. Exit\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllDevelopers();
                        break;
                    case "2":
                        ShowAllDeveloperTeams();
                        break;
                    case "3":
                        FindDeveloperByName();
                        break;
                    case "4":
                        FindDeveloperTeamByTeamName();
                        break;
                    case "5":
                        AddDeveloper();
                        break;
                    case "6":
                        AddDevTeam();
                        break;
                    case "7":
                        RemoveDeveloper();
                        break;
                    case "8":
                        RemoveDeveloperTeam();
                        break;
                    case "9":
                        UpdateDeveloper();
                        break;
                    case "10":
                        UpdateDeveloperTeam();
                        break;
                    case "11":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 10");
                        {
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                }
            }
        }
        private void AddDeveloper()
        {
            Console.Clear();
            //StreamingContent content = new StreamingContent();

            Console.Write("Please enter First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Please enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Please enter Developer ID: ");
            int developerid = int.Parse(Console.ReadLine());

            Console.Write("Please enter Team ID: ");
            int teamid = int.Parse(Console.ReadLine());

            Console.Write($"Developer has PluralSight Access? ");
            bool pluralSightAccess = Boolean.Parse(Console.ReadLine());

            Developer developer = new Developer(firstName, lastName, pluralSightAccess, developerid);

            _developerRepo.AddContentToDirectory(developer);
        }
        private void ShowAllDevelopers()
        {
            Console.Clear();

            List<Developer> listOfContent = _developerRepo.GetContents();

            foreach (Developer content in listOfContent)
            {
                Console.WriteLine($"FirstName: {content.FirstName}\n" +
                              $"LastName: {content.LastName}\n" +
                              $"Developer ID: {content.Devid}\n" +
                              $"PluralSight Access: {content.HasPluralSightAccess}\n");
            }
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        private void FindDeveloperByName()
        {
            Console.Clear();
            Console.WriteLine("What Developer are you looking for?");
            string FullName = Console.ReadLine();

            Developer content = _developerRepo.FindDeveloperByName(FullName);
            if (content != null)
            {
                Console.WriteLine($"FirstName: {content.FirstName}\n" +
                             $"LastName: {content.LastName}\n" +
                             $"Developer ID: {content.Devid}\n" +
                             $"PluralSight Access: {content.HasPluralSightAccess}\n");
            }
            else
            {
                Console.WriteLine("Failed to find developer");
            }
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        private void RemoveDeveloper()
        {
            Console.Clear();
            Console.WriteLine("What developer would you like to remove?");

            int count = 0;

            List<Developer> contentList = _developerRepo.GetContents();
            foreach (Developer content in contentList)
            {
                count++;
                Console.WriteLine($"{count}. {content.FullName}");
            }

            int userInput = int.Parse(Console.ReadLine());
            int targetIndex = userInput - 1;

            if (targetIndex >= 0 && targetIndex < contentList.Count())
            {
                Developer targetContent = contentList[targetIndex];
                if (_developerRepo.RemoveDeveloper(targetContent))
                {
                    Console.WriteLine($"{targetContent.FullName} removed from repo");
                }
                else
                {
                    Console.WriteLine("Sorry something went wrong");
                }
            }
            else
            {
                Console.WriteLine("Invalid Selection");
            }
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        private void UpdateDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Which Developer would you like to update?");
            string userInput = Console.ReadLine();

            Developer updatedContent = new Developer();
            Console.Write("What is the new FirstName?:");
            updatedContent.FirstName = Console.ReadLine();
            Console.Write("What is the new LastName?:");
            updatedContent.LastName = Console.ReadLine();
            Console.Write("What is the new Devid?:");
            updatedContent.Devid = int.Parse(Console.ReadLine());
            Console.Write("What is the new status of Pluralsight Access?: ");
            updatedContent.HasPluralSightAccess = bool.Parse(Console.ReadLine());

            _developerRepo.UpdateDeveloper(userInput, updatedContent);
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        private void AddDevTeam()
        {
            Console.Clear();
            Console.Write("Please enter a Developer Team Name: ");
            string teamName = Console.ReadLine();
            Console.Write("Please enter the Team ID: ");
            int teamid = int.Parse(Console.ReadLine());

            DevTeam content = new DevTeam(teamName, teamid);
            _devTeamRepo.AddDevTeam(content);
        }
        private void ShowAllDeveloperTeams()
        {
            Console.Clear();

            List<DevTeam> listOfContent = _devTeamRepo.GetContents();
            foreach (DevTeam content in listOfContent)
            {
                Console.WriteLine($"TeamName: {content.TeamName}\n" +
                              $"Teamid: {content.Teamid}\n");
            }
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        private void FindDeveloperTeamByTeamName()
        {
            Console.Clear();
            Console.WriteLine("What Developer Team are you looking for?");
            string teamName = Console.ReadLine();

            //Get Content
            DevTeam content = _devTeamRepo.FindDeveloperTeamByTeamName(teamName);
            if (content != null)
            {
                Console.WriteLine($"TeamName: {content.TeamName}\n" +
                               $"Teamid: {content.Teamid}\n");
            }
            else
            {
                Console.WriteLine("Failed to find title");
            }
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        private void RemoveDeveloperTeam()
        {
            Console.Clear();
            Console.WriteLine("What Developer Team would you like to remove?");
            int count = 0;

            List<DevTeam> contentList = _devTeamRepo.GetContents();
            foreach (DevTeam content in contentList)
            {
                count++;
                Console.WriteLine($"{count}. {content.TeamName}");
            }

            int userInput = int.Parse(Console.ReadLine());
            int targetIndex = userInput - 1;

            if (targetIndex >= 0 && targetIndex < contentList.Count())
            {
                DevTeam targetContent = contentList[targetIndex];
                if (_devTeamRepo.RemoveDeveloperTeam(targetContent))
                {
                    Console.WriteLine($"{targetContent.TeamName} removed from repo");
                }
                else
                {
                    Console.WriteLine("Sorry something went wrong");
                }
            }
            else
            {
                Console.WriteLine("Invalid Selection");
            }
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            }
            private void UpdateDeveloperTeam()
            {
                Console.Clear();
                Console.WriteLine("Which Developer Team would you like to update?");
                string userInput = Console.ReadLine();

                //New Content (Updated content)
                DevTeam updatedContent = new DevTeam();
                //Title
                Console.Write("What is the new Team Name:");
                updatedContent.TeamName = Console.ReadLine();
                //Description
                Console.Write("What is the new Team ID:");
                updatedContent.Teamid = int.Parse(Console.ReadLine());
                _devTeamRepo.UpdateDeveloperTeam(userInput, updatedContent);
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
        }
    }
}

