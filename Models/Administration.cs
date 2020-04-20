using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coreProject.Models
{
    public class Administration
    {
        [Key]
        public string codeAdministration {get; set;}
        public string Id {get ; set;} 
        [Required]
        [ForeignKey("Id")]
        public User User {get ;set;}
    }
}