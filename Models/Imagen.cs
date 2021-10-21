using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tp.Models
{
    [Table("Imagenes")]
    public class Imagen
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Url { get; set; }
    }
}
