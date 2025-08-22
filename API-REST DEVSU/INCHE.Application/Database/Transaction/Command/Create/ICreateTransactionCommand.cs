
using INCHE.Application.Database.Transaction.Dto.Create;
using INCHE.Application.Database.Transaction.Dto.Response;

namespace INCHE.Application.Database.Transaction.Command.Create
{
    public interface ICreateTransactionCommand
    {
        Task<ResponseTransactionDTO> Execute(CreateTransactionDTO model);
    }
}
