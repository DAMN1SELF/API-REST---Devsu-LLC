using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Application.Database.Transaction.Dto.Patch
{
    public class PatchTransactionDTO
    {
        public Guid? Numero_Cuenta { get; set; }
        public byte? Tipo_Movimiento { get; set; }
        public decimal? Valor_Movimiento { get; set; }
        public DateTime? Fecha_Movimiento { get; set; }
    }
}
