using Acr.UserDialogs;
using FuncionariosApp.Data;
using Xamarin.Forms;

namespace FuncionariosApp
{
    public partial class App : Application
    {
        public static FuncionarioManager FuncionariosManager { get; private set; }
        public App()
        {
            InitializeComponent();

            FuncionariosManager = new FuncionarioManager(new RestService());
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
