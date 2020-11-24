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
        private List<ModeloTarea> listaTareas = new List<ModeloTarea>();
        // No le hago binding desde el XAML, que sería añadiendo los 
        //descriptores de acceso get y set antes de la inicialización 
        //porque si no, no me ordena la lista con Ordenar()

        public PagTareas()
        {
            InitializeComponent();
            MuestraFecha();
            #region Tarea Test

            listaTareas.Add(new ModeloTarea()
            {
                Titulo = "Ejemplo",
                Comentario = "Esto es un ejemplo de tarea",
                Prioridad = "Ninguna",
                Color = "LightYellow",
                ValorStpr = 0,
                Completada = true
            });

            #endregion
            Ordenar();// **Aparte de ordenar, lista las Tareas**
        }

        public PagTareas(List<ModeloTarea> lista_pasada)
        {
            this.listaTareas = lista_pasada;

            InitializeComponent();
            MuestraFecha();
            Ordenar();
        }

        #region Btn_Clicked

        private void BtnCrear_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PagCrear(this.listaTareas));
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

        #endregion

        #region Métodos Propios

        private void MuestraFecha()
        {
            var idioma = new System.Globalization.CultureInfo("es-ES");
            var dia = idioma.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek);
            var fechaDia = DateTime.Now.Day.ToString();
            var mes = idioma.DateTimeFormat.GetMonthName(DateTime.Now.Month);

            lblDiaHoy.Text += dia.ToString() + ", " + fechaDia + " de " + mes;
        }



        /* Método que ordena listaTareas y asigna la 
        List<ModeloTarea> listaOrdenada como ItemsSource de LvTareas */
        private void Ordenar()
        {
            //Ordena las Tareas según su Titulo
            var listaOrdenada = listaTareas.OrderBy(x => x.Titulo).ToList();

            // Se asigna la nueva fuente de elementos listados
            LvTareas.ItemsSource = listaOrdenada;
        }

        #endregion

        #region Lv_ItemTapped

        private void LvTareas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var tarea = e.Item as ModeloTarea;

            if (tarea.Completada != false)
            {
                tarea.Completada = false;
            }
            else
            { tarea.Completada = true; }
        }

        #endregion

    }
}