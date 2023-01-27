using S7JuanCumbicus.models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S7JuanCumbicus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registrar : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public Registrar()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
        }

        private void BtnRegistar_Clicked(object sender, EventArgs e)
        {
            var DatosRegistro = new Estudiante { Nombre = Nombre.Text, Usuario = Usuario.Text, Constrasenia = Contrasenia.Text };

            _conn.InsertAsync(DatosRegistro);

            LimpiarFormulario();
        }
        void LimpiarFormulario()
        {
            Nombre.Text = string.Empty;
            Usuario.Text = string.Empty;
            Contrasenia.Text = string.Empty;

            DisplayAlert("Alerta", "Estudiante registrado correctamente!", "OK");
        }
    }
}