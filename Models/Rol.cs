using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tp.Models
{
    [Table("Roles")]
    public class Rol
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Nombre { get; set; }
    }
}
