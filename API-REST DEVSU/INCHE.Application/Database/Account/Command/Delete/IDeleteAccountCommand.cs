using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Application.Database.Account.Command.Delete
{
    public interface IDeleteAccountCommand
    {
        Task<bool> Execute(Guid numeroCuenta);
    }
}
