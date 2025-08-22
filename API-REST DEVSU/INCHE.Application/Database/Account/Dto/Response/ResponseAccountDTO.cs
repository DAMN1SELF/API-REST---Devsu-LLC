

namespace INCHE.Application.Database.Account.Dto.Response
{
    public class ResponseAccountDTO
    {
        public string Numero_Cuenta { get; set; } = null!;
        public int Cliente_Id { get; set; }
        public byte Tipo_Cuenta { get; set; }
        public decimal Saldo_Inicial { get; set; }
        public decimal Saldo_Actual { get; set; }
        public bool Estado_Cuenta { get; set; }
        public DateTime Fecha_Apertura { get; set; }
        public string Nombres_Cliente { get; set; }


    }
}