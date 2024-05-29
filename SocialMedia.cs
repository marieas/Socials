using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SovialMedia
{
    internal class SocialMedia
    {
        List<UserProfile> Users {  get; set; }
        UserProfile CurrentUser { get; set; }
        public SocialMedia()
        {
            Users = new List<UserProfile>()
            {
                new UserProfile("Bjarne Kråkerød", new List<string>{"Gaming","TV"}),
                new UserProfile("Kåre Bjarteland", new List<string>{"Hiking","Eating"}),
                new UserProfile("Kåre HigeLand", new List<string>{"Hiking","Eating"}),
                new UserProfile("Kåre SuperLand", new List<string>{"Hiking","Eating"}),
                new UserProfile("Kåre TommelLand", new List<string>{"Hiking","Eating"})
            };
            CurrentUser = Users[0];
            MainMenu();
        }

        private void MainMenu()
        {
            while (true)
            {
                Console.WriteLine($"Welcome to social media {CurrentUser.Name}");
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1. View friends");
                Console.WriteLine("2. Add friend");
                Console.WriteLine("3. Remove friend");
                Console.WriteLine("4. Exit");

                var userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "1":
                        CurrentUser.PrintFriends();
                        break;
                    case "2":
                        AddFriendMenu();
                        break;
                    case "3":
                        RemoveFriendMenu();
                        break;
                    case "4":
                        System.Environment.Exit(0);
                        break;
                }
            }
            void AddFriendMenu()
            {
                Console.WriteLine("Who do you want to add?");
                printUsersOnSM();
                var userName = Console.ReadLine();
                var userToAdd = Users.First(user => user.Name.Contains(userName));
                CurrentUser.AddFriend(userToAdd);
            }
            void RemoveFriendMenu()
            {
                Console.WriteLine("Who do you want to remove?");
                CurrentUser.PrintFriends();
                var userName = Console.ReadLine();               
                CurrentUser.RemoveFriend(userName);
            }
            void printUsersOnSM()
            {
                foreach (var user in Users)
                {
                    user.PrintProfileInfo();
                }
            }
        }
        
    }
}
