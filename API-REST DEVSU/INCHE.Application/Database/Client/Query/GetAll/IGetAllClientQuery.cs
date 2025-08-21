using INCHE.Application.Database.Client.Dto.Response;

namespace INCHE.Application.Database.Client.Query.GetAll
{
    public interface IGetAllClientQuery
    {
        Task<IReadOnlyList<ResponseClientDTO>> Execute();
    }
}