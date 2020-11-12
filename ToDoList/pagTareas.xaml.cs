using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pagTareas : ContentPage
    {
        public pagTareas()
        {
            InitializeComponent();

            lblFechaCorta.Text = DateTime.Now.ToShortDateString();
            var idioma = new System.Globalization.CultureInfo("es-ES");
            var dia = idioma.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek);
            lblDiaHoy.Text = dia.ToString();

            btnCrear.Clicked+=BtnCrear_Clicked;
        }

        private void BtnCrear_Clicked(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            pagCrear modalPage = new pagCrear();

            this.Navigation.PushModalAsync(modalPage);
        }

    }
}