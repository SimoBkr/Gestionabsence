using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coreProject.Models
{
    public class Professeur
    {
        [Key]
        public int codeProf {get; set;}
         [Required]
        public string nomProfesseur {get ;set ;}
          [Required]
        public string prenomProfesseur {get;set;}
          [Required]
        public string adresseProfesseur {get ;set;}
          [Required]
        public string phoneProfesseur {get ;set ;} 
        public string Id {get ; set;} 
        
        [ForeignKey("Id")]
        public User User {get ;set;}    
    }
}