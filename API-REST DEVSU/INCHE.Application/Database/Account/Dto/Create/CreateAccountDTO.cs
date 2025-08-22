using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Application.Database.Account.Dto.Create
{
    public class CreateAccountDTO
    {
       // public string Numero_Cuenta { get; set; } = null!;
        public int Cliente_Id { get; set; }
        public byte Tipo_Cuenta { get; set; }   
        public decimal Saldo_Inicial { get; set; }
    }
}