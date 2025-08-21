
using INCHE.Common.Constants;

namespace INCHE.Domain.Entities
{
    public class ClienteEntity : PersonaEntity
    {

        public string ContrasenaHash { get; private set; } = null!;
        public bool Estado { get; private set; } = true;
        public DateTime FechaRegistro { get; private set; } = DateTime.UtcNow;

        public ICollection<CuentaEntity> Cuentas { get; } = new List<CuentaEntity>();

        protected ClienteEntity() { }

        private ClienteEntity(
            string nombres, string? genero, byte? edad,
            string? identificacion, string? direccion, string? telefono,
            string contrasenaHash, bool estado, DateTime fechaRegistro)
            : base(nombres, genero, edad, identificacion, direccion, telefono)
        {
            if (string.IsNullOrWhiteSpace(contrasenaHash))
                throw new ArgumentException(Messages.PasswordRequired, nameof(contrasenaHash));

            ContrasenaHash = contrasenaHash;
            Estado = estado;
            FechaRegistro = fechaRegistro;
        }


        public static ClienteEntity Create(string nombres, string? genero, byte? edad,string? identificacion,
            string? direccion, string? telefono,string contrasenaHash) 
            => new ClienteEntity(nombres, genero, edad, identificacion, direccion, telefono, contrasenaHash, estado: true, fechaRegistro: DateTime.UtcNow);

        public void Update( string nombres, string? genero, byte? edad,string? identificacion, 
            string? direccion, string? telefono,string? contrasenaHash = null)
        {
            SetNombres(nombres);
            SetGenero(genero);
            SetEdad(edad);
            SetIdentificacion(identificacion);
            SetDireccion(direccion);
            SetTelefono(telefono);
            SetContrasenaHash(contrasenaHash);
        }

        public void Patch( string? nombres = null, string? genero = null, byte? edad = null,  string? identificacion = null,
            string? direccion = null, string? telefono = null, string? contrasenaHash = null, bool? estado = null)
        {
            if (nombres is not null) SetNombres(nombres);
            if (genero is not null) SetGenero(genero);
            if (edad.HasValue) SetEdad(edad);
            if (identificacion is not null) SetIdentificacion(identificacion);
            if (direccion is not null) SetDireccion(direccion);
            if (telefono is not null) SetTelefono(telefono);
            if (!string.IsNullOrWhiteSpace(contrasenaHash)) SetContrasenaHash(contrasenaHash);

            if (estado.HasValue)
            {
                if (estado.Value) Activar();
                else Desactivar();
            }
        }

        protected void SetContrasenaHash(string hash)
        {
            if (string.IsNullOrWhiteSpace(hash))
                throw new ArgumentException(Messages.PasswordRequired, nameof(hash));

            if (hash.Length < 20) 
                throw new ArgumentException("Hash de contraseña inválido.", nameof(hash));

            ContrasenaHash = hash;
        }


        public void Activar() =>
            Estado = true;
        public void Desactivar()
            => Estado = false;
    }
}