using INCHE.Application.Database.Client.Dto.Response;
using INCHE.Application.Database.Client.Dto.Update;

namespace INCHE.Application.Database.Client.Command.Update
{
    public interface IUpdateClientCommand
    {
        Task<ResponseClientDTO> Execute(int id, UpdateClientDTO update);
    }
}

