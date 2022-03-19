using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PedidosSuperPollo.Models
{
    
    public class Pedido:INotifyPropertyChanged
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; Actualizar(); }
        }


        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; Actualizar(); }
        }


        private DateTime? horaentregado;

        public DateTime? HoraEntregado
        {
            get { return horaentregado; }
            set { horaentregado = value; Actualizar(); }
        }


        private DateTime horasolicitado;

        public DateTime HoraSolicitado
        {
            get { return horasolicitado; }
            set { horasolicitado = value; Actualizar(); }
        }


        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; Actualizar(); }
        }


        public void Actualizar(string nombre="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
