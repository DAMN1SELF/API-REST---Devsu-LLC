

using INCHE.Domain.Entities;

namespace INCHE.Domain.Entities
{

    public class AccountEntity
    {
        public Guid NumeroCuenta { get; private set; } 
        public int ClienteId { get; private set; }
        public ClientEntity Cliente { get; private set; } = null!;
        public AccountType TipoCuenta { get; set; }
        public decimal SaldoInicial { get; private set; }
        public decimal SaldoActual { get; private set; }
        public bool Estado { get; private set; } = true;
        public DateTime FechaApertura { get; private set; } = DateTime.UtcNow;

        public ICollection<TransactionEntity> Movimientos { get; } = new List<TransactionEntity>();

        protected AccountEntity() { }

        private AccountEntity( int clientId, AccountType tipoCuenta, decimal saldoInicial)
        {
            
            NumeroCuenta =  Guid.NewGuid();
            ClienteId = clientId;
            TipoCuenta = tipoCuenta;
            SaldoInicial = saldoInicial;
            SaldoActual = saldoInicial;
            Estado = true;
            FechaApertura = DateTime.UtcNow;
        }

        public static AccountEntity AperturarCuenta( int clienteId, AccountType tipoCuenta, decimal saldoInicial)
            => new AccountEntity( clienteId, tipoCuenta, saldoInicial);

        public void CerrarCuenta()
        {
            Estado = false;
        }
        public void ActivarCuenta()
        {
            Estado = true;
        }
    }
}