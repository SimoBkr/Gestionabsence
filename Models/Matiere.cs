using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coreProject.Models
{
    public class Matiere
    {
        [Key]
        public string codeMatiere {get ;set;}
        [Required]
        public string nomMatiere {get ;set;}
        public int codeProf {get ; set;} 
        [Required]
        [ForeignKey("codeProf")]
        public Professeur Professeur {get ;set;}
    }
}