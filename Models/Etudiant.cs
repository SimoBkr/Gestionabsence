using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coreProject.Models
{
    public class Etudiant
    {
        [Key]
        public string codeCart {get; set;}
        [Required]
        public string nomEtudiant {get ;set ;}
          [Required]
        public string prenomEtudiant {get;set;}
          [Required]
        public string adresseEtudiant {get ;set;}
          [Required]
        public string phoneEtudiant {get ;set ;} 
          [Required]
        public int codeFiliere{get ; set;} 
         [Required]
        [ForeignKey("codeFiliere")]
        public Filiere Filiere {get ;set;}
       

}
}