using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Application.Database.Client.Dto.Auth
{
    public class AuthUserModel
    {
        public string Identificacion { get; set; }
        public string Clave { get; set; }
    }

    public class ResponseAuthUserModel
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}