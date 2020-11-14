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
    public partial class pagCrear : ContentPage
    {
        public pagCrear()
        {
            InitializeComponent();

            btnCancelar.Clicked += BtnCancelar_Clicked;
        }

        private void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            this.Navigation.PopModalAsync();
        }
    }
}