using System.ComponentModel.DataAnnotations;

namespace tp.Models
{
    public class Imagen
    {
        public int Id { get; set; }
        
        [Required]
        public string Url { get; set; }
    }
}
