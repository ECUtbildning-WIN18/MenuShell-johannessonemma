using MenuShell_Inlämn.Entities;
using MenuShell_Inlämn.Services;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MenuShell_Inlämn.View
{
    class LoginView
    {
        private readonly List<User> _users;

        public LoginView(List<User> users)
        {
            _users = users;
        }

        public User Display()
        {
            Console.Clear();
            Console.WriteLine("***Welcome!***");

            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            var authenticationService = new AuthenticationService();                

            var user = authenticationService.Authenticate(_users, username, password);

            if (user != null)
            {
                Console.WriteLine("Successfully logged in!");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine($"Role {user.Role}");
                return user;
            }
            else
            {
                Console.WriteLine("Access denied!");
                Thread.Sleep(2000);
                Console.Clear();
                Display();
            }

            Console.ReadKey();

            return user;
        }
    }
}
