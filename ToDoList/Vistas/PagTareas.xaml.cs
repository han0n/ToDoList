using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Modelo;
using ToDoList.Servicio;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagTareas : ContentPage
    {
        public PagTareas()
        {
            InitializeComponent();

            //lblFechaCorta.Text = DateTime.Now.ToShortDateString();
            var idioma = new System.Globalization.CultureInfo("es-ES");
            var dia = idioma.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek);
            var fechaDia = DateTime.Now.Day.ToString();
            var mes = idioma.DateTimeFormat.GetMonthName(DateTime.Now.Month);

            lblDiaHoy.Text += dia.ToString();
            lblDiaHoy.Text += ", ";
            lblDiaHoy.Text += fechaDia;
            lblDiaHoy.Text += " de ";
            lblDiaHoy.Text += mes;


            btnCrear.Clicked += BtnCrear_Clicked;
            
            
            ObservableCollection<ModeloTarea> listaTareas = new ObservableCollection<ModeloTarea>(new ServicioTarea().Consultar());
            LvTareas.ItemsSource = listaTareas;
        }

        private void BtnCrear_Clicked(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            PagCrear modalPage = new PagCrear();

            this.Navigation.PushModalAsync(modalPage);
        }

    }
}