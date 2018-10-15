using MenuShell_Inlämn.Entities;
using System.Collections.Generic;

namespace MenuShell_Inlämn.Services
{
    interface IAuthenticationService
    {
        User Authenticate(List<User> users, string username, string password);
    }
}
