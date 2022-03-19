using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosSuperPollo.Models
{
    
    public class Pedido
    {
        
        public int Id { get; set; }
       
        public DateTime Fecha { get; set; }
        
        public DateTime? HoraEntregado { get; set; }
   
        public DateTime HoraSolicitado { get; set; }

        public string Direccion { get; set; }
       
    }
}
