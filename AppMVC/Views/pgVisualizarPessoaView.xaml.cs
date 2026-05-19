using AppMVC.Models;

namespace AppMVC.Views;

public partial class pgVisualizarPessoaView : ContentPage
{
	//Adiciona no método contrstutor o recebimento
	//do objeto via parametro
	//Para isso precisamos importar a camada Models
	//using NomeProjeto.Models;
	public pgVisualizarPessoaView(Pessoa pessoa)
	{
		InitializeComponent();

		//Mapear a tela com base no objeto
		lblId.Text = pessoa.Id.ToString();
		lblNome.Text = pessoa.Nome;
		lblCPF.Text = pessoa.CPF;
		imgCadastro.Source = pessoa.DirImagem;
    }

    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
		Application.Current.MainPage.Navigation.PopAsync();
    }
}