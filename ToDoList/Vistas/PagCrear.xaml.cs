using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagCrear : ContentPage
    {
        ModeloTarea obj_tarea = new ModeloTarea();
        public PagCrear()
        {
            InitializeComponent();

            btnCancelar.Clicked += BtnCancelar_Clicked;
            btnGuardar.Clicked += BtnGuardar_Clicked;

            //ModeloTarea obj_tarea = new ModeloTarea();
            BindingContext = this.obj_tarea; 
        }

        private void BtnGuardar_Clicked(object sender, EventArgs e)
        { 
            Navigation.PushModalAsync(new PagTareas(obj_tarea));
        }

        private void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }
    }
}