using INCHE.Application.Database.Account.Dto.Response;

namespace INCHE.Application.Database.Account.Command.Update
{
    public interface IUpdateAccountCommand
    {
        Task<ResponseAccountDTO> Execute(Guid nroCuenta,bool activar);
    }
}