using INCHE.Application.Database.Transaction.Dto.Response;

namespace INCHE.Application.Database.Transaction.Query.GetAll
{
    public interface IGetTransactionsByAccountQuery
    {
        Task<IReadOnlyList<ResponseTransactionDTO>> Execute(Guid numeroCuenta);
    }
}
