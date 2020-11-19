using System;
using System.Collections.Generic;
using ToDoList.Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagCrear : ContentPage
    {
        ModeloTarea obj_tarea = new ModeloTarea();
        List<ModeloTarea> listaTareas = new List<ModeloTarea>();
        ModeloTarea obj_recibido = new ModeloTarea();
        
        public PagCrear(List<ModeloTarea> lista_devuelta)
        {
            InitializeComponent();
            btnCancelar.Clicked += BtnCancelar_Clicked;
            btnGuardar.Clicked += BtnGuardar_Clicked;

            BindingContext = this.obj_tarea;
            this.listaTareas = lista_devuelta;
        }

        public PagCrear(List<ModeloTarea> lista_recibida, ModeloTarea tarea_recibida)
        {
            InitializeComponent();
            btnCancelar.Clicked += BtnCancelar_Clicked;
            btnGuardar.Clicked += BtnGuardar_Clicked;

            this.obj_tarea = tarea_recibida; // Porque en el método de Guardar refiere a obj_tarea
            this.obj_recibido = tarea_recibida; // Para que se guarde por si cancela
            
            this.listaTareas = lista_recibida; // Se necesita porque la clase no guarda el ObservableCollection<ModeloTarea> listaTareas
            

            BindingContext = tarea_recibida; //Parece el mismo, pero los valores de obj_tarea son los de tarea_recibida
        }

        private void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            this.listaTareas.Remove(this.obj_recibido);
            listaTareas.Add(obj_tarea);
            Navigation.PushModalAsync(new PagTareas(listaTareas));
        }

        private void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            //this.listaTareas.Remove(this.obj_tarea);
            //listaTareas.Add(obj_recibido);
            this.Navigation.PopModalAsync();
            // Si ha recibido algún objeto (si se han pasado dos parametros a PagCrear en vez de uno)
            /*if (this.obj_recibido != null)
            {
                this.listaTareas.Add(obj_recibido); // Se añade de nuevo a listaTareas
            }*/

        }
    }
}