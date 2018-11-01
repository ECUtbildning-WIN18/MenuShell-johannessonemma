using MenuShell_Inlämn.Entities;
using System;
using System.Collections.Generic;

namespace MenuShell_Inlämn.View
{
    class ListUsersView
    {
        public static void ListUsers(List<User> users)
        {
            Console.Clear();
            foreach (User user in users)
            {
                Console.WriteLine(user.Username);
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
