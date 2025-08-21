using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Domain.Exceptions.Cuenta
{
    public sealed class SaldoNoDisponibleException : DomainException
    {
        public SaldoNoDisponibleException() : base("Saldo no disponible") { }
    }
}
