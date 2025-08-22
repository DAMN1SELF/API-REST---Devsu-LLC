
using BCrypt.Net;
using INCHE.Common.Constants;
using System.Reflection;

namespace INCHE.Domain.Entities
{
    public class ClientEntity
    {
        public int ClienteId { get; protected set; }
        public PersonEntity Person { get; private set; } = null!;

        public string ContrasenaHash { get; private set; } = null!;
        public bool Estado { get; private set; } = true;
        public DateTime FechaRegistro { get; private set; } = DateTime.UtcNow;
        public ICollection<AccountEntity> Cuentas { get; } = new List<AccountEntity>();

        protected ClientEntity() { }

        private ClientEntity(PersonEntity person, string contrasenaHash, bool estado, DateTime fechaRegistro)
        {
            Person = person ?? throw new ArgumentNullException(nameof(person));
            ClienteId = person.PersonaId; 

            if (string.IsNullOrWhiteSpace(contrasenaHash))
                throw new ArgumentException(Messages.PasswordRequired, nameof(contrasenaHash));

            ContrasenaHash = contrasenaHash;
            Estado = estado;
            FechaRegistro = fechaRegistro;
        }

        public static ClientEntity Create(
            string nombres, string? genero, byte? edad,
            string? identificacion, string? direccion, string? telefono,
            string contrasenaHash)
        {
            var persona = new PersonEntity(nombres, genero, edad, identificacion, direccion, telefono);
            return new ClientEntity(persona, BCrypt.Net.BCrypt.HashPassword(contrasenaHash), true, DateTime.UtcNow);
        }
        public void Update(
            string nombres,string? genero, byte? edad,
            string? identificacion,  string? direccion,string? telefono, string? contrasenaHash = null)
        {

            Person.Update(nombres, genero, edad, identificacion, direccion, telefono);

            if (!string.IsNullOrWhiteSpace(contrasenaHash))
                SetContrasenaHash(contrasenaHash);

        }
        public void Patch(string? nombres = null,string? genero = null, byte? edad = null,
            string? identificacion = null,string? direccion = null,string? telefono = null, string? contrasenaHash = null,bool? estado = null)
        {
            if (Person is null)
                throw new InvalidOperationException("No se puede actualizar un Cliente sin Person asociada.");

            if (nombres is not null) Person.Update(nombres, Person.Genero, Person.Edad, Person.Identificacion, Person.Direccion, Person.Telefono);
            if (genero is not null) Person.Update(Person.Nombres, genero, Person.Edad, Person.Identificacion, Person.Direccion, Person.Telefono);
            if (edad is not null) Person.Update(Person.Nombres, Person.Genero, edad, Person.Identificacion, Person.Direccion, Person.Telefono);
            if (identificacion is not null) Person.Update(Person.Nombres, Person.Genero, Person.Edad, identificacion, Person.Direccion, Person.Telefono);
            if (direccion is not null) Person.Update(Person.Nombres, Person.Genero, Person.Edad, Person.Identificacion, direccion, Person.Telefono);
            if (telefono is not null) Person.Update(Person.Nombres, Person.Genero, Person.Edad, Person.Identificacion, Person.Direccion, telefono);

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