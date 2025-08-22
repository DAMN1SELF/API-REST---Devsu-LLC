


using INCHE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace INCHE.Application.DataBase
{

	public interface IDataBaseService
    {
        #region Cliente
        DbSet<ClientEntity> Cliente { get; set; }
        #endregion

        #region Cuenta
        DbSet<AccountEntity> Cuenta { get; set; }
		#endregion

		#region Movimiento
		DbSet<TransactionEntity> Movimiento { get; set; }
        #endregion

        DbSet<PersonaEntity> Persona{ get; set; }
        Task<IDbContextTransaction> BeginTransactionAsync();
		Task<bool> SaveAsync();

	}
}
