using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ct.Models;

[Table("TC_DirectorioNuevo")]
public class CtItem
{
     
        public string? NOMBRE { get; set; }
        public string? DEPENDENCIA { get; set; }
        public string? COORDINACION { get; set; }
        public string? DIRECCION { get; set; }
        public string? DEPTO { get; set; }
        public string? CARGO { get; set; }
        public string? EXTENSION { get; set; }
        public string? DIRECCION1 { get; set; }
        public string? CORREO { get; set; }

}
