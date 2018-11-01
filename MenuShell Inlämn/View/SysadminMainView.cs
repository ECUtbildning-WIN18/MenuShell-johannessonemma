using System;

namespace MenuShell_Inlämn.View
{
    class SysadminMainView
    {
        public ConsoleKeyInfo Display()
        {
            Console.WriteLine("(1) Add user");
            Console.WriteLine("(2) List users");
            Console.WriteLine("(3) Search users");
            Console.WriteLine("(4) Delete user");
            Console.WriteLine("(5) Exit");
            
            return Console.ReadKey();
        }
    }
}
