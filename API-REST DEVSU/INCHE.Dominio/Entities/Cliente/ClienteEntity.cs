
using INCHE.Common.Constants;

namespace INCHE.Domain.Entities
{
    public class ClienteEntity
    {
        public int ClienteId { get; protected set; } // PK y también FK a Persona
        public PersonaEntity Persona { get; private set; } = null!;

        public string ContrasenaHash { get; private set; } = null!;
        public bool Estado { get; private set; } = true;
        public DateTime FechaRegistro { get; private set; } = DateTime.UtcNow;

        // 🔑 Relación 1:N con Cuenta
        public ICollection<CuentaEntity> Cuentas { get; } = new List<CuentaEntity>();

        protected ClienteEntity() { }

        private ClienteEntity(PersonaEntity persona, string contrasenaHash, bool estado, DateTime fechaRegistro)
        {
            Persona = persona ?? throw new ArgumentNullException(nameof(persona));
            ClienteId = persona.PersonaId; 

            if (string.IsNullOrWhiteSpace(contrasenaHash))
                throw new ArgumentException(Messages.PasswordRequired, nameof(contrasenaHash));

            ContrasenaHash = contrasenaHash;
            Estado = estado;
            FechaRegistro = fechaRegistro;
        }

        public static ClienteEntity Create(
            string nombres, string? genero, byte? edad,
            string? identificacion, string? direccion, string? telefono,
            string contrasenaHash)
        {
            var persona = new PersonaEntity(nombres, genero, edad, identificacion, direccion, telefono);
            return new ClienteEntity(persona, contrasenaHash, true, DateTime.UtcNow);
        }
        public void Update(
            string nombres,string? genero, byte? edad,
            string? identificacion,  string? direccion,string? telefono, string? contrasenaHash = null)
        {

            Persona.Update(nombres, genero, edad, identificacion, direccion, telefono);

            if (!string.IsNullOrWhiteSpace(contrasenaHash))
                SetContrasenaHash(contrasenaHash);

        }
        protected void SetContrasenaHash(string hash)
        {
            if (string.IsNullOrWhiteSpace(hash))
                throw new ArgumentException(Messages.PasswordRequired, nameof(hash));

            //if (hash.Length < 20)
            //    throw new ArgumentException("Hash de contraseña inválido.", nameof(hash));

            ContrasenaHash = hash;
        }

        public void Activar() => Estado = true;
        public void Desactivar() => Estado = false;
    }
}