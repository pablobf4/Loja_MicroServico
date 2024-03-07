using System;

namespace E_Commerce.PB.Web.Models
{
    public class CarrinhoCabecalhoViewModel
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string CuponCode { get; set; }
        public decimal ValorCompra { get; set; }
        public string Titulo { get; set; }
        public decimal ValorDesconto { get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Data { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string NumeroCarrinho { get; set; }
        public string CVV { get; set; }
        public string ExpiracaoMesAno { get; set; }
    }
}
