
namespace INCHE.Common.Constants
{
	public static class Messages
	{

		public const string RecordCreated = "El registro se creó correctamente";
		public const string RecordRetrieved = "El registro se obtuvo correctamente";
		public const string RecordsRetrieved = "Los registros se obtuvieron correctamente";
		public const string RecordUpdated = "El registro se actualizó correctamente";
		public const string RecordPatch = "El registro se actualizó parcialmente de forma correcta";
        public const string RecordDeleted = "El registro se eliminó correctamente";

		public const string RecordNotFound = "No se encontró el registro";
		public const string NoRecordsFound = "No se encontraron registros";

		public const string RecordAlreadyDeleted = "El registro ya ha sido eliminado";
		public const string RecordAlreadyExists = "El registro ya existe";

		public const string RecordCreationFailed = "No se pudo crear el registro";
		public const string RecordUpdateFailed = "No se pudo actualizar el registro";
		public const string RecordPatchFailed = "No se pudo actualizar parcialmente los datos del registro";
        public const string RecordDeletedFailed = "No se pudo eliminar el registro";
	
        public const string InvalidRecordId = "El identificador no es válido";
		public const string MissingData = "Faltan datos obligatorios";

		public const string DuplicateKey = "Ya existe un registro con la misma clave";
		public const string PasswordRequired = "La contraseña es obligatoria";

		public const string Unauthorized = "No autorizado";
        public const string RouteIdDoesNotMatchBodyId = "El identificador de la ruta no coincide con el del cuerpo de la solicitud";
		public const string InvalidCredentials = "Credenciales inválidas";
		public const string ClientHasLinkedAccounts = "El cliente tiene cuentas vinculadas y no puede ser eliminado";
    }
}
