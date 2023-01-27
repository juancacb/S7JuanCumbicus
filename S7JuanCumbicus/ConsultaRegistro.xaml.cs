using S7JuanCumbicus.models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S7JuanCumbicus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private ObservableCollection<Estudiante> _TablaEstudiante;
        public ConsultaRegistro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
        }

        protected async override void OnAppearing()
        {
            var resultado = await _conn.Table<Estudiante>().ToListAsync();
            _TablaEstudiante = new ObservableCollection<Estudiante>(resultado);
            ListaUsuarios.ItemsSource = _TablaEstudiante;
            base.OnAppearing();
        }

        private void ListaUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var Obj = (Estudiante)e.SelectedItem;
            int id = Convert.ToInt32(Obj.Id.ToString());
            try
            {
                Navigation.PushAsync(new Editar(id));


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}