using MenuShell_Inlämn.Entities;
using MenuShell_Inlämn.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MenuShell_Inlämn
{
    class Program                   //Inlämning till Datalagring: Inlämning 1
    {
      //private static readonly List<User> user;

        static List<User> LoadUsers()            // load users
        {
            List<User> users = new List<User>();

            string connectionString = "Data Source=(local);Initial Catalog=MenuShell; Integrated Security=true";   //We define the connection string

            string queryString = "SELECT * FROM [User]";

            using (var connection = new SqlConnection(connectionString)) //using: när koden har körts klart så kommer den anropa Dispose nedan 
            {
                //  connection.Dispose();                               // using gör detta automatiskt, dvs dispose-delen

                var sqlCommand = new SqlCommand(queryString, connection);               //skapa en command där vi kör kommandot genom 

                    connection.Open();

                    var reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]} {reader[1]} {reader[2]} "); //läser i filen och skriver ut värdet för resp kolumn

                    var user = new User(reader[0].ToString(), reader[1].ToString(), reader[2].ToString());

                    users.Add(user);
                    
                    }
                    reader.Close();             //den ska släppa minnet, dvs stänga något...
            }
            return users;
        }

        static void Main(string[] args)
        {
            //var users = new List<User>
            //{
            //    new User(username: "Admin", password: "secret", role: "Administrator")
            //};
            
            var users = LoadUsers();

            var loginView = new LoginView(users);

            while (true)
            {
                var loggedInUser = loginView.Display();
            
           // IEnumerable<User> foundusers;
            //var userListView = new UserListView(users);

            //if (loggedInUser.Role == "Administrator")
            //    {
                    var sysadminMainView = new SysadminMainView();
                    var choice = sysadminMainView.Display();

                    if (choice.Key == ConsoleKey.D1)
                    {
                        AddUserView.AddUser();
                    }
                    else if (choice.Key == ConsoleKey.D2)
                    {
                        ListUsersView.ListUsers(users);
                    }
                    else if (choice.Key == ConsoleKey.D3)
                    {
                        //  foundusers = UserSearchView.Display();
                        //var userListView = new UserListView(users);
                        //userListView.ListUsers(foundusers);
                        var userSearchView = new UserSearchView(users);
                        userSearchView.Display();
                    }
                    else if (choice.Key == ConsoleKey.D4)        
                    {
                        var deleteUserView = new DeleteUserView(users);
                        deleteUserView.DeleteOfUser();
                    }
                    else if (choice.Key == ConsoleKey.D5)
                    {
                        Environment.Exit(0);
                    }
                //}
             }
        }  
    }
}
