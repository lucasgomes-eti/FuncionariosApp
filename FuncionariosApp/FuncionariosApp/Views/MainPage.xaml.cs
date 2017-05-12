using Acr.UserDialogs;
using FuncionariosApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FuncionariosApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            lstFuncionarios.IsRefreshing = true;
            lstFuncionarios.ItemsSource = await App.FuncionariosManager.GetFuncionariosAsync();
            lstFuncionarios.IsRefreshing = false;
        }

        async void OnRefreshing(object sender, EventArgs e)
        {
            lstFuncionarios.ItemsSource = await App.FuncionariosManager.GetFuncionariosAsync();
            lstFuncionarios.IsRefreshing = false;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var funcionario = e.SelectedItem as Funcionarios;
            var editPage = new EditPage();
            editPage.BindingContext = funcionario;
            Navigation.PushAsync(editPage);
        }

        async void OnMaisCliked(object sender, EventArgs e)
        {
            var mi = (MenuItem)sender;
            var funcionario = (Funcionarios)mi.CommandParameter;
            await UserDialogs.Instance.AlertAsync($"Genero: {funcionario.Genero}, Salário: {funcionario.Salario}", $"{funcionario.Nome} {funcionario.Sobrenome}", "OK");
        }

        async void OnExcluirClicked(object sender, EventArgs e)
        {
            var mi = (MenuItem)sender;
            var funcionario = (Funcionarios)mi.CommandParameter;
            UserDialogs.Instance.ShowLoading();
            await App.FuncionariosManager.DeleteFuncionarioAsync(funcionario);
            UserDialogs.Instance.HideLoading();
            OnRefreshing(sender, e);
        }

        async void OnAdicionarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditPage());
        }
    }
}
