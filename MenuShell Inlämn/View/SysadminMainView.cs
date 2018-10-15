using System;

namespace MenuShell_Inlämn.View
{
    class SysadminMainView
    {
        public SysadminMainView()
        {

        }

        public int choice;

        public void Display()
        {
            Console.WriteLine("(1) Add user");
            Console.WriteLine("(2) List users");
            Console.WriteLine("(3) Exit");
            choice = int.Parse(Console.ReadLine());
        }
    }
}
