using PedidosSuperPollo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PedidosSuperPollo.Repositories
{
    class PedidosRepository
    {
        PedidosContext context = new PedidosContext();

        public ObservableCollection<Pedido> ListaPedidos { get; set; }

        public ObservableCollection<Platillo> ListaPlatillos { get; set; }

        public ObservableCollection<DetallePedido> ListaDetallesPedido { get; set; }


        public PedidosRepository()
        {

        }

        //CRUD

        //CREATE

        //READ

        


        //UPDATE

        //DELETE


    }
}
