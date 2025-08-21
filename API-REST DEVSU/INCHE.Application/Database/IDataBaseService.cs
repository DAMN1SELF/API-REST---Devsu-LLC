


using INCHE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace INCHE.Application.DataBase
{

	public interface IDataBaseService
    {
        #region Cliente
        DbSet<ClienteEntity> Cliente { get; set; }
        #endregion

        #region Cuenta
        DbSet<CuentaEntity> Cuenta { get; set; }
		#endregion

		#region Movimiento
		DbSet<MovimientoEntity> Movimiento { get; set; }
        #endregion

		Task<IDbContextTransaction> BeginTransactionAsync();
		Task<bool> SaveAsync();

	}
}
