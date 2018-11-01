using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MenuShell_Inlämn.Entities;

namespace MenuShell_Inlämn.View
{
    class DeleteUserView
    {
        private List<User> _users;

        public DeleteUserView(List<User> users)
        {
            _users = users;
        }

       public void DeleteOfUser()
        {
            Console.Clear();

            string username = null;
            string password = null;
            string role = null;
            User user = new User(username, password, role);

            Console.WriteLine("Which one of the users do you want to delete?");
            string deleteChoice = Console.ReadLine();

            string connectionString = "Data Source=(local);Initial Catalog = MenuShell;Integrated Security = true ";

            //Create the SQL query for inserting a user
            string queryString = ($"DELETE FROM [User] WHERE [UserName] = '{deleteChoice}' ");

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
            Console.WriteLine("The user has been deleted from the table!");
            Thread.Sleep(2000);

            //DELETE-funktion (UTAN SQL):
            //for (int i = 0; i < users.Count; i++)
            //{
            //    Console.WriteLine($" ({ i + 1}) {users[i].Username}");
            //}

            //Console.WriteLine("Which one of the users do you want to delete?");
            //int deleteChoice = int.Parse(Console.ReadLine());

            //Console.WriteLine("You will now delete this user, this handling is irreversible and you have to create the user again if this was wrong!");
            //Thread.Sleep(2000);
            //users.RemoveAt(deleteChoice - 1);
        }
    }
}
