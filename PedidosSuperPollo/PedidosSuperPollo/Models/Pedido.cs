using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosSuperPollo.Models
{
    [Table("pedido")]
    public class Pedido
    {
        [PrimaryKey]
        [AutoIncrement]
        [NotNull]
        public int Id { get; set; }

        [NotNull]
        public string Nombre { get; set; }

        [NotNull]
        public string Direccion { get; set; }

        [NotNull]
        public decimal Precio { get; set; }

        [NotNull]
        public string Hora { get; set; }

        public string Cliente { get; set; }

        [NotNull]
        public int Estado { get; set; }

    }
}
