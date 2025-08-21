
namespace INCHE.Domain.Entities
{
    public static class MovimientoTipos
    {
        public const char Credito = 'C';
        public const char Debito = 'D';
    }

    public class MovimientoEntity
    {
        public int MovimientoId { get; private set; }
        public string NumeroCuenta { get; private set; } = null!;
        public DateTime Fecha { get; private set; }
        public char TipoMovimiento { get; private set; } // 'C' o 'D'
        public decimal Valor { get; private set; }
        public decimal SaldoDisponible { get; private set; }

        public CuentaEntity? Cuenta { get; private set; }

        protected MovimientoEntity() { }

        public MovimientoEntity(string numeroCuenta, DateTime fecha, char tipoMovimiento,
            decimal valor, decimal saldoDisponible)
        {
            if (string.IsNullOrWhiteSpace(numeroCuenta))
                throw new ArgumentException("Número de cuenta requerido.", nameof(numeroCuenta));
            if (valor <= 0) throw new ArgumentOutOfRangeException(nameof(valor));
            if (saldoDisponible < 0) throw new ArgumentOutOfRangeException(nameof(saldoDisponible));
            if (tipoMovimiento != MovimientoTipos.Credito && tipoMovimiento != MovimientoTipos.Debito)
                throw new ArgumentOutOfRangeException(nameof(tipoMovimiento), "Tipo inválido.");

            NumeroCuenta = numeroCuenta;
            Fecha = fecha;
            TipoMovimiento = tipoMovimiento;
            Valor = valor;
            SaldoDisponible = saldoDisponible;
        }
    }
}
