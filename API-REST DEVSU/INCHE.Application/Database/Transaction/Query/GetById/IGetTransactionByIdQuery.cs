using INCHE.Application.Database.Transaction.Dto.Response;

namespace INCHE.Application.Database.Transaction.Query.GetbyId
{
    public interface IGetTransactionByIdQuery
    {
        Task<ResponseTransactionDTO?> Execute(int id);
    }
}
