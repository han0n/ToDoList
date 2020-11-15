using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ToDoList.Modelo
{
    class ModeloTarea : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] String titulo = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(titulo));
        }

        private String titulo;

        public String Titulo
        {
            get { return titulo; }
            set 
            { 
                titulo = value;
                OnPropertyChanged();
            }
        }

        private String comentario;

        

        public String Comentario
        {
            get { return comentario; }
            set 
            { 
                comentario = value;
                OnPropertyChanged();
            }
        }


    }
}
