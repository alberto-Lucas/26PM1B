using AppMVC.Models;
using AppMVC.Controllers;
using AppMVC.Services;

namespace AppMVC.Views;

public partial class pgCadPessoaView : ContentPage
{
    //Importar as camadas Models, Controller e Services

    //using AppMVC.Models;
    //using AppMVC.Controllers;
    //using AppMVC.Services;

    //Criar a instancia para a camada de controle
    //usamos o underline (_) para identificar 
    //variaveis privadas
    PessoaController _controller;

    //Variavel global para armazenar a imagem selecionada
    string _imgSelecionada = "";

	public pgCadPessoaView()
	{
		InitializeComponent();
        //Intanciar a camada de controle
        _controller = new PessoaController();
    }

    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PopAsync();
    }

    private async void btnAddImagem_Clicked(object sender, EventArgs e)
    {
        //Chamar a nossa rotina de seleção de imagem
        //na camada de serviço
        //como a classe de imagem é estatica
        //não é preciso realizar a instancia da mesma
        //apenas chamar as funções diretamente
        //Como a seleção de imagem ocorre em segundo 
        //plano é preciso adicionar o awai e o async
        _imgSelecionada = await ImageService.SelecionarImagem();
        //Atualizar a imagem na tela
        imgCadastro.Source = _imgSelecionada;
        //Exibir o botão remover imagem
        btnRemoverImagem.IsVisible = true;
    }

    //Método para remover a imagem
    //pois ele sera usado tanto no botão remover
    //quanto no botão salvar
    void RemoverImagem()
    {
        //Limpar a imagem da tela
        imgCadastro.Source = "";
        //Limpar a variavel
        _imgSelecionada = "";
        //Ocultar o botão Remover Imagem
        btnRemoverImagem.IsVisible = false;
    }

    private void btnRemoverImagem_Clicked(object sender, EventArgs e)
    {
        RemoverImagem();
    }

    private void btnSalvar_Clicked(object sender, EventArgs e)
    {
        //Iremos recupar as informações digitadas
        string nome = txtNome.Text;
        string cpf = txtCPF.Text;

        //Validamos se o campos foram preenchidos
        if(string.IsNullOrEmpty(nome) ||
            string.IsNullOrEmpty(cpf))
        {
            //Se um dos dois estiver vazio
            //notificamos o usuario
            DisplayAlert("Atenção", "Prencha os campos corretamente.", "OK");
            return; //abortamos a execução
        }

        //Instancia o nosso objeto pessoa
        Pessoa pessoa = new Pessoa();

        //Mapear o op objeto com os dados
        pessoa.Nome = nome;
        pessoa.CPF = cpf;

        //Neste momento realizamos a chama da função copiar imagem
        //Pois se tiver imagem para copiar ira retornar o novo diretorio
        //se não ira retornar vazio, então não precisamos
        //realizar nenhuma validação
        pessoa.DirImagem = ImageService.CopiarImagem(_imgSelecionada);

        //Agora podemos salvar o objeto no banco de dados
        //E validar se foi inserido com sucesso
        if (_controller.Insert(pessoa))
        {
            //Se retorno positivo
            //notificamos o usuario e limpamos a tela
            DisplayAlert("Informação", "Registro salvo com sucesso!", "OK");
            //Limpamos a tela
            txtNome.Text = "";
            txtCPF.Text = "";
            //Limpar a imagem
            RemoverImagem();
        }
        else
            DisplayAlert("Atenção", "Falha ao salvar o cadastro.", "OK");
    }
}