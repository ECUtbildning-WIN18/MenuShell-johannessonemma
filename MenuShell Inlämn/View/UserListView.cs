using MenuShell_Inlämn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuShell_Inlämn.View
{
    class UserListView
    {
        private readonly List<User> _users;

        public UserListView(List<User> users)
        {
            _users = users;
        }

        public string ListUsers(IEnumerable<User>  foundusers)
        {
            Console.Clear();
            Console.WriteLine($"The foundresults: "); 

            foreach (User user in foundusers)
            {
                Console.WriteLine(user.Username);
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
 
            return "";
        }
    }
}