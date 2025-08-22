
using INCHE.Domain.Entities.Transaction;

namespace INCHE.Domain.Entities
{
    public class TransactionEntity
    {
        public int MovimientoId { get; private set; }
        public Guid NumeroCuenta { get; private set; } 
        public DateTime Fecha { get; private set; }
        public TransactionType TipoMovimiento { get; private set; } 
        public decimal Valor { get; private set; }
        public decimal SaldoDisponible { get; private set; }
        public AccountEntity? Cuenta { get; private set; }

        protected TransactionEntity() { }

        public TransactionEntity(Guid numeroCuenta, DateTime fecha, TransactionType tipoMovimiento,
            decimal valor, decimal saldoDisponible)
        {

            NumeroCuenta = numeroCuenta;
            Fecha = fecha;
            TipoMovimiento = tipoMovimiento;
            Valor = valor;
            SaldoDisponible = saldoDisponible;
        }
    }
}
