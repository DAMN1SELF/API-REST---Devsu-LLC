

using INCHE.Domain.Exceptions.Cuenta;
using INCHE.Domain.ValueObjects;

namespace INCHE.Domain.Entities
{
    public static class CuentaTipos
    {
        public const int Ahorros = 1;
        public const int Corriente = 2;
    }
    public class CuentaEntity
    {
        public string NumeroCuenta { get; private set; } = null!;
        public int ClienteId { get; private set; }
        public ClienteEntity Cliente { get; private set; } = null!;
        public int TipoCuenta { get; private set; } // Usa CuentaTipos
        public decimal SaldoInicial { get; private set; }
        public decimal SaldoActual { get; private set; }
        public bool Estado { get; private set; } = true;
        public DateTime FechaApertura { get; private set; } = DateTime.UtcNow;

        public ICollection<MovimientoEntity> Movimientos { get; } = new List<MovimientoEntity>();

        protected CuentaEntity() { }

        public CuentaEntity(string numeroCuenta, int clienteId, int tipoCuenta, decimal saldoInicial)
        {
            NumeroCuenta = NumeroCuentaVo.Create(numeroCuenta).Value;
            ClienteId = clienteId;
            if (tipoCuenta != CuentaTipos.Ahorros && tipoCuenta != CuentaTipos.Corriente)
                throw new ArgumentOutOfRangeException(nameof(tipoCuenta), "Tipo de cuenta inválido.");

            TipoCuenta = tipoCuenta;
            if (saldoInicial < 0) throw new ArgumentOutOfRangeException(nameof(saldoInicial));
            SaldoInicial = saldoInicial;
            SaldoActual = saldoInicial;
        }

        public void Cerrar() => Estado = false;

        /// <summary>
        /// Aplica un movimiento cumpliendo reglas de negocio:
        ///  - 'C' (crédito) suma, 'D' (débito) resta.
        ///  - No permite saldo negativo.
        ///  - Límite diario de débitos por cuenta = 1000 por defecto.
        /// </summary>
        public MovimientoEntity AplicarMovimiento(
            char tipo,                  // 'C' o 'D'
            decimal valor,
            DateTime fecha,
            decimal debitosAcumuladosHoy,
            decimal limiteDiario = 1000m)
        {
            if (!Estado) throw new InvalidOperationException("La cuenta está inactiva.");
            if (valor <= 0) throw new ArgumentOutOfRangeException(nameof(valor), "El valor debe ser > 0.");

            decimal nuevoSaldo = SaldoActual;

            if (tipo == MovimientoTipos.Credito)
            {
                nuevoSaldo += valor;
            }
            else if (tipo == MovimientoTipos.Debito)
            {
                if (SaldoActual <= 0 || valor > SaldoActual)
                    throw new SaldoNoDisponibleException();

                if (debitosAcumuladosHoy + valor > limiteDiario)
                    throw new CupoDiarioExcedidoException(limiteDiario);

                nuevoSaldo -= valor;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(tipo), "Tipo de movimiento inválido.");
            }

            SaldoActual = nuevoSaldo;

            var mov = new MovimientoEntity(
                numeroCuenta: NumeroCuenta,
                fecha: fecha,
                tipoMovimiento: tipo,
                valor: valor,
                saldoDisponible: nuevoSaldo);

            Movimientos.Add(mov);
            return mov;
        }
    }
}