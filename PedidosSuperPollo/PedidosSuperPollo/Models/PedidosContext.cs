using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PedidosSuperPollo.Models
{
    class PedidosContext
    {
      SqlCommand comando;
        SqlDataReader lector;
        SqlConnection conexion = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SuperPollo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
 
         public ObservableCollection<Pedido> ListaPedidos { get; set; }

        public ObservableCollection<Platillo> ListaPlatillos{ get; set; }


           public void Conectar()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
        }

           ~PedidosContext()
        {
            if(conexion.State!=ConnectionState.Closed)
            {
                conexion.Close();
            }
        }
    }
}
