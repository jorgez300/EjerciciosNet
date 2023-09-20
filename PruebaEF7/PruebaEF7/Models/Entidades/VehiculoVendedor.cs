using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    [PrimaryKey(nameof(VehiculoId), nameof(VendedorId))]
    public class VehiculoVendedor
    {
        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; } = null!;
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; } = null!;


        [Required]
        public int Orden { get; set; }

    }
}
