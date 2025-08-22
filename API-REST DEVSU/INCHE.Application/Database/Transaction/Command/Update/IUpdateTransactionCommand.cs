using INCHE.Application.Database.Transaction.Dto.Response;
using INCHE.Application.Database.Transaction.Dto.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Application.Database.Transaction.Command.Update
{
    public interface IUpdateTransactionCommand
    {
        Task<ResponseTransactionDTO> Execute(int id, UpdateTransactionDTO model);
    }
}