using PedidosSuperPollo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace PedidosSuperPollo.ViewModels
{
    class PedidosViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Pedido> PedidosIncompletos { get; set; }
        public ObservableCollection<Pedido> PedidosCompletos { get; set; }

        ListaPedidos ListaPedidos = new ListaPedidos();

        private Pedido pedido;

        public Pedido Pedido
        {
            get { return pedido; }
            set { pedido = value; Actualizar(); }
        }

        private string error;

        public string Error
        {
            get { return error; }
            set { error = value; Actualizar(); }
        }

        private bool estado=false;

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }



        public void Actualizar(string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
