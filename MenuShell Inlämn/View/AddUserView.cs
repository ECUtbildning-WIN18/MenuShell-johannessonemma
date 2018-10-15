using MenuShell_Inlämn.Entities;
using System;
using System.Collections.Generic;

namespace MenuShell_Inlämn.View
{
    class AddUserView
    {
        public AddUserView()
        {

        }

        public static void AddUser(List<User> users)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Type in the information below!");
                Console.Write("Username: ");
                string username = Console.ReadLine();

                Console.Write("Password: ");
                string password = Console.ReadLine();

                Console.Write("Role: ");
                string role = Console.ReadLine();

                Console.WriteLine("(S)ave and Log in again!");
                Console.WriteLine("(C)lose!");
                string answer = Console.ReadLine();

                if (answer == "S")
                {
                    users.Add(new User(username, password, role));
                    return;
                }
                else if (answer == "C")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Wrong answer!");
                    Console.ReadKey();
                }
            }
        }
    }
}
