using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Application.Database.Client.Dto.Patch
{
    public class PatchClientDTO
    {
        public int CodigoCliente { get; set; }
        public string? NombresCliente { get; set; }
        public string? GeneroCliente { get; set; }
        public byte? EdadCliente { get; set; }
        public string? IdentificacionCliente { get; set; }
        public string? DireccionCliente { get; set; }
        public string? TelefonoCliente { get; set; }
        public string? ContrasenaHashCliente { get; set; }
        public bool? EstadoCliente { get; set; }
    }
}
