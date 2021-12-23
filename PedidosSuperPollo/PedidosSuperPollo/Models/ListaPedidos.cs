using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace PedidosSuperPollo.Models
{
    public class ListaPedidos
    {
        public SQLiteConnection conection { get; set; }

        //string rutadb = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/Citas.db3";
        string rutadb = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/pedidos.db3";

        public ListaPedidos()
        {
            if (!File.Exists(rutadb))
            {
                Assembly ensamblado = Assembly.GetExecutingAssembly();
                var stream = ensamblado.GetManifestResourceStream("PedidosSuperPollo.Data.pedidos.db3");
                FileStream file = File.Create(rutadb);
                stream.CopyTo(file);
                stream.Close();
                file.Close();
            }

            conection = new SQLiteConnection(rutadb);
        }

        public DateTime Ahora { get; set; } = DateTime.Now.Date;

        //CRUD

        //CREATE
        public void INSERT(Pedido p)
        {
            if (Validar(p, false))
            {
                conection.Insert(p);
            }
        }

        //READ
        public IEnumerable<Pedido> GetAllPedidos()
        {
            return conection.Table<Pedido>().OrderByDescending(x=>DateTime.Parse(x.Hora));
        }

        //UPDATE
        public void UPDATE(Pedido p)
        {
            if (Validar(p, false))
            {
                conection.Update(p);
            }
        }

        //DELETE 
        public void DELETE(Pedido p)
        {
            if (p != null)
                conection.Delete(p);
        }

        //VALIDAR
        private bool Validar(Pedido p, bool v)
        {
            if (p.Hora == "" || p.Hora == null)
                p.Hora = Ahora.ToString("t");

            if (string.IsNullOrWhiteSpace(p.Nombre))
                throw new ArgumentException("Escriba el nombre del pedido");

            if (string.IsNullOrWhiteSpace(p.Direccion))
                throw new ArgumentException("Escriba la direccion del cliente");

            if (p.Precio < 0)
                throw new ArgumentException("Precio incorrecto");



            //if(DateTime.Parse(p.Hora)<Ahora)        

            return true;
        }



    }
}
