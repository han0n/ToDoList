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
    public partial class PagCrear : ContentPage
    {
        ModeloTarea obj_tarea = new ModeloTarea();
        ObservableCollection<ModeloTarea> listaTareas = new ObservableCollection<ModeloTarea>();
        public PagCrear(ObservableCollection<ModeloTarea> lista_devuelta)
        {
            InitializeComponent();

            btnCancelar.Clicked += BtnCancelar_Clicked;
            btnGuardar.Clicked += BtnGuardar_Clicked;

            //ModeloTarea obj_tarea = new ModeloTarea();
            BindingContext = this.obj_tarea;
            this.listaTareas = lista_devuelta;
        }

        private void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushModalAsync(new PagTareas(obj_tarea));
            listaTareas.Add(obj_tarea);
            Navigation.PushModalAsync(new PagTareas(listaTareas));
        }

        private void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }
    }
}