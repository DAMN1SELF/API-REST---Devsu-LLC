
using INCHE.Application.Database.Client.Dto.Auth;

namespace INCHE.Producto.Application.DataBase.User.Commands.AuthUser
{
    public interface IAuthUserCommand
    {
        Task<ResponseAuthUserModel> Execute(AuthUserModel model);
    }
}
