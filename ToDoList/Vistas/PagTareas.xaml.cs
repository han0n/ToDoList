using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagTareas : ContentPage
    {
        //ModeloTarea obj_binding;
        ObservableCollection<ModeloTarea> listaTareas = new ObservableCollection<ModeloTarea>();
        
        public PagTareas(ObservableCollection<ModeloTarea> lista_pasada)
        {
            InitializeComponent();
            MuestraFecha();

            this.listaTareas = lista_pasada;
            //this.listaTareas.Add(obj_binding);
            LvTareas.ItemsSource = this.listaTareas;

            btnCrear.Clicked += BtnCrear_Clicked;
        }
        public PagTareas()
        {
            InitializeComponent();
            MuestraFecha();

            btnCrear.Clicked += BtnCrear_Clicked;
            listaTareas.Add(new ModeloTarea() { Titulo = "Ejemplo ", Comentario = "Esto es un ejemplo de tarea" });
            LvTareas.ItemsSource = this.listaTareas;
        }

        private void BtnCrear_Clicked(object sender, EventArgs e)
        {
            //PagCrear modalPage = new PagCrear();
            Navigation.PushModalAsync(new PagCrear(this.listaTareas));
            //this.Navigation.PushModalAsync(modalPage);
        }

        public void MuestraFecha()
        {
            var idioma = new System.Globalization.CultureInfo("es-ES");
            var dia = idioma.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek);
            var fechaDia = DateTime.Now.Day.ToString();
            var mes = idioma.DateTimeFormat.GetMonthName(DateTime.Now.Month);

            lblDiaHoy.Text += dia.ToString() + ", " + fechaDia + " de " + mes;
        }

    }
}