using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosSuperPollo.Models
{
    class Platillo
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio_Unitario { get; set; }

        public byte[] Foto { get; set; }
    }
}
