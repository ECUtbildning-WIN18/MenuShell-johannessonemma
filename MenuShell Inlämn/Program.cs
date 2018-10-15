using MenuShell_Inlämn.Entities;
using MenuShell_Inlämn.View;
using System;
using System.Collections.Generic;

namespace MenuShell_Inlämn
{
    class Program                                      
    {
        static void Main(string[] args)
        {
            var users = new List<User>
            {
                new User(username: "Admin", password: "secret", role: "Administrator")
            };

            var loginView = new LoginView(users);

            while (true)
            {
                var loggedInUser = loginView.Display();

                var sysadminMainView = new SysadminMainView();
                if (loggedInUser.Role == "Administrator")
                {
                    sysadminMainView.Display();
                }
                //else if = receptionist...do this  OR   else = ..... do this

                if (sysadminMainView.choice == 1)
                {
                    AddUserView.AddUser(users);
                }
                else if (sysadminMainView.choice == 2)
                {
                    ListUsersView.ListUsers(users);
                }
                else if (sysadminMainView.choice == 3)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}