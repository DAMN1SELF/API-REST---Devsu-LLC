

namespace INCHE.Domain.Entities.Transaction
{
    public enum TransactionType : byte
    {
        Credito = (byte)'C', // 'C' = 67
        Debito = (byte)'D'  // 'D' = 68
    }
}