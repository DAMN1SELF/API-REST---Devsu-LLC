
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
        public void Patch(string? nombres = null,string? genero = null, byte? edad = null,
            string? identificacion = null,string? direccion = null,string? telefono = null, string? contrasenaHash = null,bool? estado = null)
        {
            if (Persona is null)
                throw new InvalidOperationException("No se puede actualizar un Cliente sin Persona asociada.");

            if (nombres is not null) Persona.Update(nombres, Persona.Genero, Persona.Edad, Persona.Identificacion, Persona.Direccion, Persona.Telefono);
            if (genero is not null) Persona.Update(Persona.Nombres, genero, Persona.Edad, Persona.Identificacion, Persona.Direccion, Persona.Telefono);
            if (edad is not null) Persona.Update(Persona.Nombres, Persona.Genero, edad, Persona.Identificacion, Persona.Direccion, Persona.Telefono);
            if (identificacion is not null) Persona.Update(Persona.Nombres, Persona.Genero, Persona.Edad, identificacion, Persona.Direccion, Persona.Telefono);
            if (direccion is not null) Persona.Update(Persona.Nombres, Persona.Genero, Persona.Edad, Persona.Identificacion, direccion, Persona.Telefono);
            if (telefono is not null) Persona.Update(Persona.Nombres, Persona.Genero, Persona.Edad, Persona.Identificacion, Persona.Direccion, telefono);

            if (!string.IsNullOrWhiteSpace(contrasenaHash))
                SetContrasenaHash(contrasenaHash);

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

            //if (hash.Length < 20)
            //    throw new ArgumentException("Hash de contraseña inválido.", nameof(hash));

            ContrasenaHash = hash;
        }

        public void Activar() => Estado = true;
        public void Desactivar() => Estado = false;
    }
}