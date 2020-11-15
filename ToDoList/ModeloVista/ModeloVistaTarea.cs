using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Modelo;
using ToDoList.Servicio;
using Xamarin.Forms;

namespace ToDoList.ModeloVista
{
    public class ModeloVistaTarea : ModeloTarea
    {
        public ObservableCollection<ModeloTarea> Tareas { get; set; }
        ServicioTarea servicio = new ServicioTarea();
        ModeloTarea modelo;

        public ModeloVistaTarea()
        {
            Tareas = servicio.Consultar();
            GuardarCommand = new Command(async () => await Guardar()); 
        }

        public Command GuardarCommand { get; set; }

        private async Task Guardar()
        {
            modelo = new ModeloTarea()
            {
                Titulo = Titulo,
                Comentario = Comentario
            };
            servicio.Guardar(modelo);
        }

    }
}
