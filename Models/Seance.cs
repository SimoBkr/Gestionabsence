using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coreProject.Models
{
    public class Seance
    {
        [Key]
        public int codeSeance {get;set;}
        [Required]
         public string codeMatiere {get ;set;}
        [Required]
        [ForeignKey("codeMatiere")]
        public Matiere Matiere {get ;set;}
        [Required]
        public int codeProf {get ; set;} 
        [Required]
        [ForeignKey("codeProf")]
        public Professeur Professeur {get ;set;}
         [Required]
        public int codeFiliere{get ; set;} 
         [Required]
        [ForeignKey("codeFiliere")]
        public Filiere Filiere {get ;set;}
    }
}