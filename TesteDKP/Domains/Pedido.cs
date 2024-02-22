using System;
using System.Collections.Generic;

namespace TesteDKP.Domains
{
    public partial class Pedido
    {
        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public string? Nome { get; set; }
        public decimal? Valor { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
    }
}
