using MenuShell_Inlämn.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuShell_Inlämn.View
{
    class UserSearchView
    {
        private readonly List<User> _users;

        public UserSearchView(List<User> users)
        {
            _users = users;
        }

        public /*IEnumerable<User>*/ void Display()     //Display(List<User> users)
        {
            Console.Clear();
            Console.Write("Search by username: ");
            string searchTerm = Console.ReadLine();
            
            //var foundUsers = users.Where(x => x.Username.StartsWith(searchTerm));
 
            string connectionString = "Data Source=(local);Initial Catalog = MenuShell;Integrated Security = true ";

            //Create the SQL query for inserting a user
            string queryString = ($"SELECT * FROM [User] WHERE [UserName] = '{searchTerm}' ");

            //Create and open a connection to SQL server
            using (var connection = new SqlConnection(connectionString))
            {
                //  connection.Dispose();                               // using gör detta automatiskt, dvs dispose-delen

                //Create a command object
                var sqlCommand = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();

                    var reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.Clear();
                        Console.WriteLine("Your searchresult:");
                        Console.WriteLine($"{reader[0]} {reader[1]} {reader[2]} "); //läser i filen och skriver ut värdet för resp kolumn
                        Console.ReadKey();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            //SEARCH-funktion (UTAN SQL)
            //if (!foundUsers.Any())
            //{
            //    Console.WriteLine($"No users found matching the search term: {searchTerm}");
            //    Console.ReadKey();
            //    Console.WriteLine("Press any key to continue...");
            //    Console.ReadKey();
            //}
            //else
            //{
            //    return foundUsers;
            //}
            //return foundUsers;
        }
    }
}
