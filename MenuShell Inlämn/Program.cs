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
            
            IEnumerable<User> foundusers;
            //var userListView = new UserListView(users);

            if (loggedInUser.Role == "Administrator")
                {
                    var sysadminMainView = new SysadminMainView();
                    var choice = sysadminMainView.Display();

                    if (choice.Key == ConsoleKey.D1)
                    {
                        AddUserView.AddUser(users);
                    }
                    else if (choice.Key == ConsoleKey.D2)
                    {
                        ListUsersView.ListUsers(users);
                    }
                    else if (choice.Key == ConsoleKey.D3)
                    {
                        foundusers = UserSearchView.Display(users);
                        var userListView = new UserListView(users);
                        userListView.ListUsers(foundusers);
                    }
                    else if (choice.Key == ConsoleKey.D4)               //Delete
                    {
                        var deleteUserView = new DeleteUserView(users);
                        deleteUserView.DeleteOfUser(users);
                    }
                    else if (choice.Key == ConsoleKey.D5)
                    {
                        Environment.Exit(0);
                    }
                }
             }

                     


           

        }
    }
}
