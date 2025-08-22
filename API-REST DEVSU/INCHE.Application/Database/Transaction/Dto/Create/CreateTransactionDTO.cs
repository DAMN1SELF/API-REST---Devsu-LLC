using INCHE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Application.Database.Transaction.Dto.Create
{
    public class CreateTransactionDTO
    {
        public Guid Numero_Cuenta { get; set; } 
        public TransactionType Tipo_Movimiento { get; set; } 
        public decimal Valor_Movimiento { get; set; }
    }
}
