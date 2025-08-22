
namespace INCHE.Domain.Exceptions.Account
{
    public sealed class SaldoNoDisponibleException : DomainException
    {
        public SaldoNoDisponibleException() : base("Saldo no disponible") { }
    }
}
