using INCHE.Application.Database.Account.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Application.Database.Account.Query.GetbyNumberAccount
{
    public interface IGetAccountByNumberQuery
    {
        Task<ResponseAccountDTO?> Execute(Guid numeroCuenta);
    }
}