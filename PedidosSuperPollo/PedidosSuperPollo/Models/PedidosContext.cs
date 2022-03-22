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
        SqlConnection conexion = new SqlConnection
            ("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SuperPollo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public ObservableCollection<Pedido> ListaPedidos { get; set; }

        public ObservableCollection<Platillo> ListaPlatillos { get; set; }

        public ObservableCollection<DetallePedido> ListaDetallesPedido { get; set; }

        public void Conectar()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
        }

        ~PedidosContext()
        {
            if (conexion.State != ConnectionState.Closed)
            {
                conexion.Close();
            }
        }

        public PedidosContext()
        {
            Conectar();
            GetAllPedidos();
            GetAllDetallesPedido();
            GetAllPlatillos();
        }


        public void GetAllPedidos()
        {
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = "select * from Pedidos;";

            lector = comando.ExecuteReader();
            ListaPedidos = new ObservableCollection<Pedido>();

            while (lector.Read())
            {
                Pedido p = new Pedido()
                {
                    Id = (int)lector["Id"],
                    Fecha = (DateTime)lector["Fecha"],
                    HoraEntregado = Convert.IsDBNull(lector["HoraEntregado"]) ? null : (DateTime?)lector["HoraEntregado"],
                    HoraSolicitado = (DateTime)lector["HoraSolicitado"],
                    Direccion = (string)lector["Direccion"],


                };
                ListaPedidos.Add(p);
            }
            lector.Close();
        }


        public void GetAllDetallesPedido()
        {
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = "select * from DetallesPedido;";
            lector = comando.ExecuteReader();
            ListaDetallesPedido = new ObservableCollection<DetallePedido>();

            while (lector.Read())
            {
                DetallePedido detallepedido = new DetallePedido()
                {
                    Id = (int)lector["Id"],
                    Cantidad = (int)lector["Cantidad"],
                    MontoAPagar = (decimal)lector["MontoAPagar"],
                    IdPedido = (int)lector["IdPedido"],
                    IdPlatillo = (int)lector["IdPlatillo"]

                };
                ListaDetallesPedido.Add(detallepedido);
            }
        }

        public void GetAllPlatillos()
        {
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = "select * from Platillo;";
            lector = comando.ExecuteReader();
            ListaPlatillos = new ObservableCollection<Platillo>();

            while (lector.Read())
            {
                Platillo platillo = new Platillo()
                {
                    Id = (int)lector["Id"],
                    Nombre=(string) lector["Nombre"],
                    Descripcion=(string)lector["Descripcion"],
                    Precio_Unitario = (decimal)lector["Precio_Unitario"],
                    Foto = (byte[])lector["Foto"]
                };

                ListaPlatillos.Add(platillo);
            }
        }




        //public void Agregar(Pedido p)
        //{

        //    var fecha = p.Fecha.ToString("dd-MM-yyyy");

        //        comando.CommandText = string.Format("insert into Pedido(Fecha," + "HoraEntregado,HoraSolicitado,Direccion) " +
        //            "values('{0}','{1}','{2}','{3}')", fecha, p.HoraEntregado, p.HoraSolicitado, p.Direccion);
        //        comando.ExecuteNonQuery();

        //        comando.CommandText = string.Format("select max(Id) from Pedido");
        //        var id = comando.ExecuteScalar();
        //        p.Id = (int)id;
        //        ListaPedidos.Add(p);


        //}
    }
}
