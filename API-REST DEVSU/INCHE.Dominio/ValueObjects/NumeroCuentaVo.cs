using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace INCHE.Domain.ValueObjects
{
    public sealed record NumeroCuentaVo
    {
        public string Value { get; }

        private NumeroCuentaVo(string value) => Value = value;

        public static NumeroCuentaVo Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El número de cuenta es requerido.", nameof(value));

            // Regla ejemplo: 4 a 20 dígitos
            if (!Regex.IsMatch(value, @"^\d{4,20}$"))
                throw new ArgumentException("Número de cuenta inválido.", nameof(value));

            return new NumeroCuentaVo(value);
        }

        public override string ToString() => Value;
    }
}