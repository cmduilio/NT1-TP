using System.ComponentModel.DataAnnotations;

namespace tp.Models
{
    public class Rol
    {
        public int Id { get; set; }
        
        [Required]
        public string Nombre { get; set; }
    }
}
