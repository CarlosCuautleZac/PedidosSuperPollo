using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PedidosSuperPollo.Models
{
    class DetallePedido:INotifyPropertyChanged
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; Actualizar(); }
        }


        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; Actualizar(); }
        }


        private decimal montoapagar;

        public decimal MontoAPagar
        {
            get { return montoapagar; }
            set { montoapagar = value; Actualizar(); }
        }


        private int idpedido;

        public int IdPedido
        {
            get { return idpedido; }
            set { idpedido = value; Actualizar(); }
        }


        private int idplatillo;

        public int IdPlatillo
        {
            get { return idplatillo; }
            set { idplatillo = value;Actualizar();}
        }


        public void Actualizar(string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
