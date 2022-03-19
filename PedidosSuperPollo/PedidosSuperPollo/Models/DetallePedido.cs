using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosSuperPollo.Models
{
    class DetallePedido
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal MontoPagar { get; set; }
        public int IdPedido { get; set; }
        public int IdPlatillo { get; set; }
    }
}
