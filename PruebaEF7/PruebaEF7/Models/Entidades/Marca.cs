using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; } = null!;
        public bool Vigente { get; set; } = true;

    }
}
