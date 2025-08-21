
using INCHE.Application.Database.Client.Dto.Response;
using INCHE.Application.Database.Client.Dto.Create;

namespace INCHE.Application.Database.Client.Command.Create
{
    public interface ICreateClientCommand
    {
        Task<ResponseClientDTO> Execute(CreateClientDTO create);
    }
}