using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    
    public class Vendedor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = null!;

        public List<VehiculoVendedor> VendedoresVehiculos { get; set; } = new List<VehiculoVendedor>();
    }
}
