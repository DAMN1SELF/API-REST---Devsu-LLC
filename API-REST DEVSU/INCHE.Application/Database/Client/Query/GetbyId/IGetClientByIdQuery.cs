using INCHE.Application.Database.Client.Dto.Response;

namespace INCHE.Application.Database.Client.Query.GetbyId
{
    public interface IGetClientByIdQuery
    {
        Task<ResponseClientDTO> Execute(int id);
    }
}