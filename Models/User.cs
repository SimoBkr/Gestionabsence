using Microsoft.AspNetCore.Identity;

namespace coreProject.Models
{
    public class User:IdentityUser
    {
        public string nom {get ; set;}
        public string prenom {get ;set;}
        public string adresse {get ;set;}
        public string telephone { get ;set;}



        
    }
}