using System.ComponentModel.DataAnnotations;

namespace coreProject.Models
{
    public class Filiere
    {
        [Key]
        public int codeFiliere {get ;set;}
        [Required] 
        public string nomFilier {get ;set ;}
    }
}