using S7JuanCumbicus.models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S7JuanCumbicus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Login()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }

        private async void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registrar());

        }
        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string contrasenia)
        {
            return db.Query<Estudiante>("SELECT * FROM  Estudiante  where Usuario  = ?  and Constrasenia = ?", usuario, contrasenia);

        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");

                var db = new SQLiteConnection(databasePath);

                db.CreateTable<Estudiante>();

                IEnumerable<Estudiante> resultado = SELECT_WHERE(db, usuario.Text, contrasenia.Text);

                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());

                }
                else
                {
                    DisplayAlert("Alerta", "Veriifique el Usurio o Contraseña!", "OK");

                }


            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "OK");
            }
        }
    }
}