using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SovialMedia
{
    internal class UserProfile
    {
        public string Name { get; set; }
        public List<string> Hobbies { get; set; }
        public List<UserProfile> FriendsList { get; set; }

        public UserProfile(string name, List<string> hobbies)
        {
            Name = name;
            Hobbies = hobbies;
            FriendsList = new List<UserProfile>();
        }
        public void PrintProfileInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"hobbies:");
            PrintHobbies();
        }

        public void AddHobby(string hobby)
        {
            Hobbies.Add(hobby);
        }
        public void AddFriend(UserProfile friend)
        {
            FriendsList.Add(friend);
        }
        public void RemoveFriend(string name)
        {
            if(FriendsList.Count == 0) { 
                Console.WriteLine("No friend to remove!");
                return;
            }
            var userToDelete = FriendsList.First(friend => friend.Name.Contains(name));
            if(userToDelete != null)
            {
                FriendsList.Remove(userToDelete);
            }
            else
            {
                Console.WriteLine($"{Name} does not have a friend called {name}");
            }
            
        }
        private void PrintHobbies()
        {
            Console.WriteLine($"{Name} has current hobbies:");
            foreach (var hobby in Hobbies) {
                Console.WriteLine(hobby);
            }
        }
        public void PrintFriends()
        {
            if (FriendsList.Count == 0) { 
                Console.WriteLine("you dont have any friends :(");
                Console.WriteLine("check out users to add!");
                return;
            }
            foreach (var friend in FriendsList)
            {                
                friend.PrintProfileInfo();
            }
        }
    }
}
