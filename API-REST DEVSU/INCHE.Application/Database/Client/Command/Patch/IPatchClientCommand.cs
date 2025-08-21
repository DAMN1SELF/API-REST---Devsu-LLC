using INCHE.Application.Database.Client.Dto.Patch;
using INCHE.Application.Database.Client.Dto.Response;

namespace INCHE.Application.Database.Client.Command.Patch
{
    public interface IPatchClientCommand
    {
        Task<ResponseClientDTO> Execute(int id, PatchClientDTO patch);
    }
}