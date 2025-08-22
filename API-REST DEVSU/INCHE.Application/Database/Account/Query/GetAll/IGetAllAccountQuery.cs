using INCHE.Application.Database.Account.Dto.Response;
namespace INCHE.Application.Database.Account.Query.GetAll
{
    
    public interface IGetAllAccountQuery
    {
        Task<IReadOnlyList<ResponseAccountDTO>> Execute();
    }
}
