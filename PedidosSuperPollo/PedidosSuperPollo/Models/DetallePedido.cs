using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PedidosSuperPollo.Models
{
    class DetallePedido:INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal MontoPagar { get; set; }
        public int IdPedido { get; set; }
        public int IdPlatillo { get; set; }

        public void Actualizar(string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
