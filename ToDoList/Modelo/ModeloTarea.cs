using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ToDoList.Modelo
{
    public class ModeloTarea : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] String titulo = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(titulo));
        }

        #region Respecto a lo Descriptivo

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
        // Comentario de la tarea, observación
        public String Comentario
        {
            get { return comentario; }
            set 
            { 
                comentario = value;
                OnPropertyChanged();
            }
        }
        #endregion

        // Para que al modificar no se quede guardado si se descarta
        public ModeloTarea ObtenerCopia()
        {
            return (ModeloTarea)this.MemberwiseClone();
        }

        #region Respecto a la Prioridad

        // Color según el tipo de prioridad
        private String c_prioridad;
        public String Color
        {
            get { return c_prioridad; }
            set
            {
                c_prioridad = value;
                OnPropertyChanged();
            }
        }

        // Valor numérico del Stepper
        private int v_prioridad;
        public int ValorStpr
        {
            get { return v_prioridad; }
            set
            {
                v_prioridad = value;
                OnPropertyChanged();
            }
        }

        // Nombre de la prioridad: Alta, Media, Baja o Sin categoría
        private String i_prioridad;
        public String Prioridad
        {
            get { return i_prioridad; }
            set
            {
                i_prioridad = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
