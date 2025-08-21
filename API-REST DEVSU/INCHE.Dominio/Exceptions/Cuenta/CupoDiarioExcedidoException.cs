using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Domain.Exceptions.Cuenta
{
    public sealed class CupoDiarioExcedidoException : DomainException
    {
        public decimal Limite { get; }
        public CupoDiarioExcedidoException(decimal limite = 1000m)
            : base("Cupo diario Excedido") => Limite = limite;
    }
}
