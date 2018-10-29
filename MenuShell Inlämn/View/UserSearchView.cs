using MenuShell_Inlämn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuShell_Inlämn.View
{
    class UserSearchView
    {
        public static IEnumerable<User> Display(List<User> users)
        {
            Console.Clear();
            Console.Write("Search by username: ");
            string searchTerm = Console.ReadLine();

            var foundUsers = users.Where(x => x.Username.StartsWith(searchTerm));
            
            
            if (!foundUsers.Any())
            {
                Console.WriteLine($"No users found matching the search term: {searchTerm}");
                Console.ReadKey();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                return foundUsers;
            }
            return foundUsers;
        }
    }
}
