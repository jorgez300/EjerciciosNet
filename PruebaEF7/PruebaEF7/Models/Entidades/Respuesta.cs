using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Respuesta
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Contenido { get; set; } = null!;
        public DateTime Fecha { get; set; }

        public int PreguntaId { get; set; }
        public Pregunta Pregunta { get; set; } = null!;

    }
}
