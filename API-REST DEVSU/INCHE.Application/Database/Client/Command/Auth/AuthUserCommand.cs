using AutoMapper;
using INCHE.Application.DataBase;
using INCHE.Application.Database.Client.Dto.Auth;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Producto.Application.DataBase.User.Commands.AuthUser
{
    public class AuthUserCommand: IAuthUserCommand
    {
        private readonly IDataBaseService _db;
        private readonly IMapper _mapper;

        public AuthUserCommand(IDataBaseService databaseService, IMapper mapper)
        {
            _db = databaseService;
            _mapper = mapper;
        }

        public async Task<ResponseAuthUserModel> Execute(AuthUserModel model)
        {

            var user = await _db.Cliente
                .Include(c => c.Person)
                .FirstOrDefaultAsync(c => c.Person.Identificacion == model.Identificacion);

            if (user == null) throw new Exception("Usuario o contraseña incorrectos");

			bool passwordOk = BCrypt.Net.BCrypt.Verify(model.Clave, user.ContrasenaHash);

			if (!passwordOk) throw new Exception("Usuario o contraseña incorrectos");

			var result = _mapper.Map<ResponseAuthUserModel>(user);

			return result;
		}
    }
}
