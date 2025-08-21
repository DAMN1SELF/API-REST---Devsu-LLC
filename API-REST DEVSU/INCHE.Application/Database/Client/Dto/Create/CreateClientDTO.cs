using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Application.Database.Client.Dto.Create
{
    public class CreateClientDTO
    {
        public string NombresCliente { get; set; } = null!;
        public string? GeneroCliente { get; set; }
        public byte? EdadCliente { get; set; }
        public string? IdentificacionCliente { get; set; }
        public string? DireccionCliente { get; set; }
        public string? TelefonoCliente { get; set; }
        public string ContrasenaHashCliente { get; set; } = null!;
    }
}