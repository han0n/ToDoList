using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToDoList.Modelo;

namespace ToDoList.Servicio
{
    class ServicioTarea
    {
        public ObservableCollection<ModeloTarea> tareas { get; set; }

        public ServicioTarea()
        {//Para que no esté creando un objeto cada vez que sea invocado, sino cuando sea nulo
            if(tareas == null)
            {
                tareas = new ObservableCollection<ModeloTarea>();
            }
        }

        //Método encargado de retornar las tareas
        public ObservableCollection<ModeloTarea> Consultar()
        {
            return tareas;
        }

        public void Guardar(ModeloTarea modelo)
        {
            tareas.Add(modelo);
        }
    }
}
