using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tp.Models
{
    [Table("TiposJuego")]
    public class TipoJuego
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Nombre { get; set; }
    }
}
