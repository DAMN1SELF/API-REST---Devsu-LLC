

using INCHE.Common.Constants;

namespace INCHE.Domain.Entities
{
    public class PersonEntity
    {
        public int PersonaId { get; protected set; }
        public string Nombres { get; private set; } = null!;
        public string? Genero { get; private set; }
        public byte? Edad { get; private set; }
        public string? Identificacion { get; private set; }
        public string? Direccion { get; private set; }
        public string? Telefono { get; private set; }

        public ClientEntity? Cliente { get; private set; }

        protected PersonEntity() { }


        public PersonEntity(string nombres, string? genero, byte? edad,
            string? identificacion, string? direccion, string? telefono)
        {
            SetNombres(nombres);
            SetGenero(genero);
            SetEdad(edad);
            SetIdentificacion(identificacion);
            SetDireccion(direccion);
            SetTelefono(telefono);
        }

        public void Update(string nombres,  string? genero, byte? edad,
            string? identificacion,string? direccion, string? telefono)
        {
            SetNombres(nombres);
            SetGenero(genero);
            SetEdad(edad);
            SetIdentificacion(identificacion);
            SetDireccion(direccion);
            SetTelefono(telefono);
        }

        #region Setters protegidos
        protected void SetNombres(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre es obligatorio.", nameof(value));

            var trimmed = value.Trim();
            if (trimmed.Length > 100)
                throw new ArgumentException("Longitud máxima excedida (100).", nameof(value));

            Nombres = trimmed;
        }

        protected void SetGenero(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Genero = null;
                return;
            }

            var v = value.Trim().ToUpperInvariant();
            if (v is not ("M" or "F"))
                throw new ArgumentException("Género inválido (use M/F).", nameof(value));

            Genero = v;
        }

        protected void SetEdad(byte? value)
        {
            if (value.HasValue && value.Value > 120)
                throw new ArgumentOutOfRangeException(nameof(value), "Edad inválida (0..120).");

            Edad = value;
        }

        protected void SetIdentificacion(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Identificacion = null;
                return;
            }

            var v = value.Trim();
            if (v.Length > 30)
                throw new ArgumentException("Identificación demasiado larga (≤30).", nameof(value));

            Identificacion = v;
        }

        protected void SetDireccion(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Direccion = null;
                return;
            }

            var v = value.Trim();
            if (v.Length > 200)
                throw new ArgumentException("Dirección demasiado larga (≤200).", nameof(value));

            Direccion = v;
        }

        protected void SetTelefono(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Telefono = null;
                return;
            }

            var digits = new string(value.Where(char.IsDigit).ToArray());
            if (digits.Length < 6 || digits.Length > 20)
                throw new ArgumentException("Teléfono inválido (6..20 dígitos).", nameof(value));

            Telefono = digits;
        }

        #endregion
    }
}