using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coreProject.Models
{
    public class Absence
    {
        [Key]
         public string codeAbsence {get ;set;}
         
          [Required]
        public string codeMatiere {get ;set;}
        [Required]
        [ForeignKey("codeMatiere")]
        public Matiere Matiere {get ;set;}



          [Required]
         public string codeCart {get; set;}
         [Required]
         [ForeignKey("codeCart")]

        public Etudiant Etudiant {get ;set;}


        [Required]
        [DataType(DataType.Date)]
        public string dateAbsence {get; set;}

    }
}