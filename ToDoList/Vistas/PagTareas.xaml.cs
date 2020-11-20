using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagTareas : ContentPage
    {
        // Cambiado a List para que pueda ordenar y al borrar borre
        List<ModeloTarea> listaTareas = new List<ModeloTarea>();
        
        public PagTareas(List<ModeloTarea> lista_pasada)
        {
            InitializeComponent();
            MuestraFecha();

            this.listaTareas = lista_pasada;
            //this.listaTareas.Add(obj_binding);
            //LvTareas.ItemsSource = this.listaTareas;
            Ordenar();

            btnCrear.Clicked += BtnCrear_Clicked;
        }
        public PagTareas()
        {
            InitializeComponent();
            MuestraFecha();

            btnCrear.Clicked += BtnCrear_Clicked;
            listaTareas.Add(new ModeloTarea() 
            { 
                Titulo = "Ejemplo", 
                Comentario = "Esto es un ejemplo de tarea",
                Prioridad = "Ninguna",
                Color = "LightYellow",
                ValorStpr = 0

            });
            //LvTareas.ItemsSource = this.listaTareas;
            Ordenar();
        }

        private void BtnCrear_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PagCrear(this.listaTareas));
        }

        public void MuestraFecha()
        {
            var idioma = new System.Globalization.CultureInfo("es-ES");
            var dia = idioma.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek);
            var fechaDia = DateTime.Now.Day.ToString();
            var mes = idioma.DateTimeFormat.GetMonthName(DateTime.Now.Month);

            lblDiaHoy.Text += dia.ToString() + ", " + fechaDia + " de " + mes;
        }

        async private void BtnBorrar_Clicked(object sender, EventArgs e)
        {
            var boton = sender as Button;
            var tarea = boton.BindingContext as ModeloTarea;

            bool respuesta = await DisplayAlert("Atención:", 
                "¿Seguro que quiere borrar la tarea?", "Sí", "No");

            if (respuesta == true)
            {
                listaTareas.Remove(tarea);
                Ordenar();
            }
        }

        private void BtnEditar_Clicked(object sender, EventArgs e)
        {
            var boton = sender as Button;
            var tarea = boton.BindingContext as ModeloTarea;
            // listaTareas.Remove(tarea);
            Navigation.PushModalAsync(new PagCrear(this.listaTareas, tarea));
        }

        /* Método que ordena listaTareas y asigna la 
        List<ModeloTarea> listaOrdenada como ItemsSource de LvTareas */
        public void Ordenar()
        {
            //Ordena las Tareas según su Titulo
            var listaOrdenada = listaTareas.OrderBy(x => x.Titulo)
                                  .ToList();

            // Se asigna la nueva fuente de elementos listados
            LvTareas.ItemsSource = listaOrdenada;
        }
    }
}