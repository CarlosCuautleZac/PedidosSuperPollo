using PedidosSuperPollo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace PedidosSuperPollo.ViewModels
{
    class PedidosViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Pedido> PedidosIncompletos { get; set; }
        public ObservableCollection<Pedido> PedidosCompletos { get; set; }

        ListaPedidos ListaPedidos = new ListaPedidos();


        //Aqui estan las propiedades que vamos a usar 
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

        //Falso es para las citas incomplertas
        private bool estado=false;

        public bool Estado
        {
            get { return estado; }
            set { estado = value; Actualizar(); }
        }


        //Constructor
        public PedidosViewModel()
        {
            PedidosIncompletos = new ObservableCollection<Pedido>();
            PedidosCompletos = new ObservableCollection<Pedido>();

            CargarCitas();
        }


        //Cargamos las citas
        private void CargarCitas()
        {
            //Falso es para las citas incomplertas
            //if (Estado==false)

            PedidosIncompletos.Clear();
            PedidosCompletos.Clear();

            PedidosIncompletos = (ObservableCollection<Pedido>)ListaPedidos.GetPedidosIncompletos();

        }


        //Aqui van a estar los metodos del CRUD, Primero ver la ventana y luego la accion
        public void VerAgregar()
        {
            Error = "";
            Pedido = new Pedido();
            //Falta hacerle pushaysinc la venta de veragregar
        }

        private void Agregar()
        {
            ListaPedidos.INSERT(Pedido);
            CargarCitas();
            Error = "";
            Application.Current.MainPage.Navigation.PopAsync();
        }

        public void VerEditar()
        {
            Error = "";
            Pedido clon = new Pedido()
            {
                Id = Pedido.Id,
                Nombre = Pedido.Nombre,
                Direccion = Pedido.Direccion,
                Cliente = Pedido.Cliente,
                Estado = Pedido.Estado,
                Hora = Pedido.Hora,
                Precio = Pedido.Precio
            };
            Pedido = clon;

            //Falta hacer el pushaysinc a la ventana
        }

        private void Editar()
        {
            ListaPedidos.UPDATE(Pedido);
            CargarCitas();
            Application.Current.MainPage.Navigation.PopAsync();

        }

        

        private void VerDetalles(Pedido pedido)
        {
            Pedido = pedido;
            CargarCitas();
            //Falta hacer el pushaysinc a la ventana 
        }

        public void Actualizar(string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
