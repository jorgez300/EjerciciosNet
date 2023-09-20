using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Placa { get; set; } = null!;

        [Required]
        public int? MarcaId { get; set; }

        public Marca Marca { get; set; } = null!;

        public HashSet<VehiculoVendedor> VendedoresVehiculos { get; set; } = new HashSet<VehiculoVendedor>();
        public HashSet<Pregunta> Preguntas { get; set; } = new HashSet<Pregunta>();

    }
}
