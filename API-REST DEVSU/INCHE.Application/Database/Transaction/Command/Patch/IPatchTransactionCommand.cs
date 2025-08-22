using INCHE.Application.Database.Transaction.Dto.Patch;
using INCHE.Application.Database.Transaction.Dto.Response;

namespace INCHE.Application.Database.Transaction.Command.Patch
{
    public interface IPatchTransactionCommand
    {
        Task<ResponseTransactionDTO> Execute(int id, PatchTransactionDTO model);
    }
}
