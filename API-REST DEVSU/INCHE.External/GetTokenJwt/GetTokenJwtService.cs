using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using INCHE.Application.Database.Client.Dto.Auth;
using INCHE.Application.External.GetTokenJwt;

namespace INCHE.External.GetTokenJwt
{
    public class GetTokenJwtService: IGetTokenJwtService
    {
        private readonly IConfiguration _configuration;
        public GetTokenJwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

		public string Execute(AuthUserModel model)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			string key = _configuration["SecretKeyJwt"];
			var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, model.Identificacion)
			};

			if (!string.IsNullOrEmpty(model.Identificacion))
				claims.Add(new Claim(ClaimTypes.Name, model.Identificacion));

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.UtcNow.AddMinutes(30),
				SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256Signature)  ,
                Issuer = _configuration["IssuerJwt"] ,
                Audience = _configuration["AudienceJwt"] 
            };

			var token = tokenHandler.CreateToken(tokenDescriptor);
			var tokenString = tokenHandler.WriteToken(token);
			return tokenString;
		}
	}
}