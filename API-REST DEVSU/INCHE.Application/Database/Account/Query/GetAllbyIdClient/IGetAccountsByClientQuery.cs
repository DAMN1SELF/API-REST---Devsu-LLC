using INCHE.Application.Database.Account.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Application.Database.Account.Query.GetbyIdClient
{
    public interface IGetAccountsByClientQuery
    {
        Task<IReadOnlyList<ResponseAccountDTO>> Execute(int CodigoCliente);
    }
}