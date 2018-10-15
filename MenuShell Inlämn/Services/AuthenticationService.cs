using MenuShell_Inlämn.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MenuShell_Inlämn.Services
{
    class AuthenticationService : IAuthenticationService
    {
        public User Authenticate(List<User> users, string username, string password)          //Metod: kontroll av anvnamn och password
        {
            return users.FirstOrDefault(x => x.Username == username && x.Password == password); //använder LINQ. kollar om det stämmer
        }
    }
}
