using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Prestamo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Libro")]
        public int LibroId { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
    
        public Libro? Libro { get; set; }
        public Usuario? Usuario { get; set; }

        public DateTime? FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }

        public EstadoPrestamo Estado { get; set; }
    }

    public enum EstadoPrestamo
    {
        Pendiente,
        EnCurso,
        Devuelto,
        Atrasado
    }
}
