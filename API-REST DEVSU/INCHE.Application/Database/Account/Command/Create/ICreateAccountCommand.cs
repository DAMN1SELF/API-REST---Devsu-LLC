using INCHE.Application.Database.Account.Dto.Create;
using INCHE.Application.Database.Account.Dto.Response;

namespace INCHE.Application.Database.Account.Command.Create
{
    public interface ICreateAccountCommand
    {
        Task<ResponseAccountDTO> Execute(CreateAccountDTO create);
    }
}