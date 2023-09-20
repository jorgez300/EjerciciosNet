using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Pregunta
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Contenido { get; set; } = null!;
        public DateTime Fecha { get; set; }

        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; } = null!;

        public HashSet<Respuesta> Respuestas { get; set; } = new HashSet<Respuesta>();
    }
}
