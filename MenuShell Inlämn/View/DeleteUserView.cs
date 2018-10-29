using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MenuShell_Inlämn.Entities;

namespace MenuShell_Inlämn.View
{
    class DeleteUserView
    {
        private List<User> users;

        public DeleteUserView(List<User> users)
        {
            this.users = users;
        }


        public void DeleteOfUser(List<User> users)
        {
            Console.Clear();

            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($" ({ i + 1}) {users[i].Username}");
            }

            Console.WriteLine("Which one of the users do you want to delete?");
            int deleteChoice = int.Parse(Console.ReadLine());

            Console.WriteLine("You will now delete this user, this handling is irreversible and you have to create the user again if this was wrong!");
            Thread.Sleep(2000);
            users.RemoveAt(deleteChoice - 1);
        }

    }
}
