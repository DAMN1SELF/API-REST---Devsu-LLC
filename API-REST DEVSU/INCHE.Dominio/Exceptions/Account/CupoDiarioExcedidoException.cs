
namespace INCHE.Domain.Exceptions.Account
{
    public sealed class CupoDiarioExcedidoException : DomainException
    {
        public decimal Limite { get; }
        public CupoDiarioExcedidoException(decimal limite = 1000m)
            : base("Cupo diario Excedido") => Limite = limite;
    }
}
