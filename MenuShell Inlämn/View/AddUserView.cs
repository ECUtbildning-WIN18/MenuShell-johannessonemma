using MenuShell_Inlämn.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MenuShell_Inlämn.View
{
    class AddUserView
    {
        public AddUserView()
        {

        }

        public static void AddUser()
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
                User user = new User(username, password, role);

                string connectionString = "Data Source=(local);Initial Catalog = MenuShell;Integrated Security = true ";

                //Create the SQL query for inserting a user
                string queryString = ($"Insert into [User] (Username, [Password], [Role]) Values('{user.Username}', '{user.Password}', '{user.Role}')");

                //Create and open a connection to SQL server
                using (var connection = new SqlConnection(connectionString))
                {
                    //  connection.Dispose();                               // using gör detta automatiskt, dvs dispose-delen

                    //Create a command object
                    var sqlCommand = new SqlCommand(queryString, connection);
                    try
                    {
                        connection.Open();
                        int rows = sqlCommand.ExecuteNonQuery();  //kan returnera antalet påverkade rader
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
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