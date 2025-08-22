

using INCHE.Application.Database.Client.Dto.Auth;

namespace INCHE.Application.External.GetTokenJwt
{
    public interface IGetTokenJwtService
    {
		string Execute(AuthUserModel model);
	}
}
