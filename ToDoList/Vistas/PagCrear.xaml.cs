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
            SetColorPrioridad();
            
        }

        public PagCrear(List<ModeloTarea> lista_recibida, ModeloTarea tarea_recibida)
        {
            InitializeComponent();
            btnCancelar.Clicked += BtnCancelar_Clicked;
            btnGuardar.Clicked += BtnGuardar_Clicked;

            this.obj_recibido = tarea_recibida; // Porque en el método de Guardar refiere a obj_tarea
            this.obj_tarea = tarea_recibida.ObtenerCopia(); // Para que se guarde por si cancela
            
            this.listaTareas = lista_recibida; // Se necesita porque la clase no guarda el ObservableCollection<ModeloTarea> listaTareas
            
            BindingContext = obj_tarea; //Parece el mismo, pero los valores de obj_tarea son los de tarea_recibida
        }

        #region Btn_Clicked
        private void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            if(obj_recibido != null)
            {
                this.listaTareas.Remove(obj_recibido);
                listaTareas.Add(obj_tarea);
            }
            else
            {
                listaTareas.Add(obj_tarea);
            }
            // Si no se da un Titulo a la tarea, esta no se crea y salta Mensaje por pantalla
            if(obj_tarea.Titulo != null && obj_tarea.Titulo.Trim() != "")
            {
                Navigation.PushModalAsync(new PagTareas(listaTareas));
            }
            else
            {
                listaTareas.Remove(obj_tarea);
                Navigation.PopModalAsync();
                DisplayAlert("", "No se ha creado ninguna tarea", "Aceptar");
            }
                
        }

        private void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }

        #endregion

        #region Elemento_ValueChanged

        // Asignación de un color para la Prioridade de un elemento ModeloTarea
        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double valor = e.NewValue;

            if (valor == 3)
            {
                obj_tarea.Color = "LightCoral";
                obj_tarea.Prioridad = "Alta";
            }
            else
            {
                if (valor == 2)
                {
                    obj_tarea.Color = "LightSalmon";
                    obj_tarea.Prioridad = "Media";
                }
                else
                {
                    if (valor == 1)
                    {
                        obj_tarea.Color = "LightGreen";
                        obj_tarea.Prioridad = "Baja";
                    }
                    else
                    {
                        if (valor == 0)
                        {
                            obj_tarea.Color = "LightYellow";
                            obj_tarea.Prioridad = "Ninguna";
                        }
                    }
                }
            }


        }
        
        // Límite de caracteres aplicados a los Entry
        private void Comentario_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            entry.MaxLength = 33;

            if (entry.Text.Length > entry.MaxLength)
            {
                entry.Text = entry.Text.Remove(5);
            }
        }

        private void Titulo_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            entry.MaxLength = 26;

            if (entry.Text.Length > entry.MaxLength)
            {
                entry.Text = entry.Text.Remove(5);
            }
        }

        #endregion

        #region ValueSet
        private void SetColorPrioridad()
        {
            //Si el usuario no toca el Stepper, no cambia el valor
            obj_tarea.Color = "LightYellow";// Por ello, será el seleccionado por defecto
            obj_tarea.Prioridad = "Ninguna";// Aquí también
        }

        #endregion

    }
}