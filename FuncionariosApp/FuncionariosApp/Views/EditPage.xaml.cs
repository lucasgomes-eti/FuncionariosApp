using Acr.UserDialogs;
using FuncionariosApp;
using FuncionariosApp.Data;
using FuncionariosApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FuncionariosApp
{
    public partial class EditPage : ContentPage
    {
        Funcionarios funcionario = new Funcionarios();
        int valorSalario;
        public EditPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (string.IsNullOrEmpty(lblSalario.Text))
            {
                valorSalario = Convert.ToInt16(stpSalario.Value * 937);
                lblSalario.Text = $"Salário: R$ {valorSalario.ToString()}";
            }
            stpSalario.Value = Convert.ToInt16(lblSalario.Text.Remove(0, 12)) / 937;
        }

        async void OnSalvarClicked(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(lblId.Text))
                {
                    funcionario.Nome = txtNome.Text;
                    funcionario.Sobrenome = txtSobrenome.Text;
                    funcionario.Genero = pkrGenero.SelectedItem.ToString();
                    if (stpSalario.Value == 1)
                    {
                        valorSalario = Convert.ToInt16(stpSalario.Value * 937);
                    }
                    funcionario.Salario = valorSalario.ToString();

                    UserDialogs.Instance.ShowLoading();
                    await App.FuncionariosManager.PostFuncionarioAsync(funcionario);
                    UserDialogs.Instance.HideLoading();
                }
                else
                {
                    funcionario.ID = Convert.ToInt16(lblId.Text);
                    funcionario.Nome = txtNome.Text;
                    funcionario.Sobrenome = txtSobrenome.Text;
                    funcionario.Genero = pkrGenero.SelectedItem.ToString();
                    if (stpSalario.Value == 1)
                    {
                        valorSalario = Convert.ToInt16(stpSalario.Value * 937);
                    }
                    funcionario.Salario = valorSalario.ToString();
                    UserDialogs.Instance.ShowLoading();
                    await App.FuncionariosManager.PutFuncionarioAsync(funcionario);
                    UserDialogs.Instance.HideLoading();
                }
                await UserDialogs.Instance.AlertAsync($"O cadastro de {funcionario.Nome}, foi salvo", "Sucesso!", "OK");
            }
            catch (Exception ex)
            {
                await UserDialogs.Instance.AlertAsync($"{ex.Message}", "Ops!", "OK");
                return;
            }
        }

        void OnSalarioChanged(object sender, EventArgs e)
        {
            valorSalario = Convert.ToInt16(stpSalario.Value * 937);
            lblSalario.Text = $"Salário: R$ {valorSalario.ToString()}";
        }
    }
}
