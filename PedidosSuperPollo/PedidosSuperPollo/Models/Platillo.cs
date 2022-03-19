using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PedidosSuperPollo.Models
{
    class Platillo:INotifyPropertyChanged
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; Actualizar(); }
        }


        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; Actualizar(); }
        }


        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; Actualizar(); }
        }


        private decimal precio_unitario;

        public decimal Precio_Unitario
        {
            get { return precio_unitario; }
            set { precio_unitario = value; Actualizar(); }
        }


        private byte[] foto;

        public byte[] Foto
        {
            get { return foto; }
            set { foto = value; Actualizar(); }
        }


        public void Actualizar(string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
