using AppMVC.Models;
using AppMVC.Views;
using AppMVC.Controllers;
using System.Threading.Tasks;

namespace AppMVC
{
    public partial class MainPage : ContentPage
    {
        //Importar as camadas Models, Views e Controllers;
        //using AppMVC.Models;
        //using AppMVC.Views;
        //using AppMVC.Controllers;

        //Criar a instacia com a classe de controle
        PessoaController _controle = new PessoaController();
        public MainPage()
        {
            InitializeComponent();

            //Ao abrir a tela ja carregar os dados
            AtualizarListView();
        }

        void AtualizarListView()
        {
            //Carregar todos oregistro salvos na lista
            lsvRegistros.ItemsSource = _controle.GetAll();
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            //Chamar a tela de cadastro
            //Garantir que a camada views esteja importada
            //using AppMVC.Views;

            Application.Current.MainPage.Navigation.
                PushAsync(new pgCadPessoaView());
        }

        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            AtualizarListView();
        }

        private async void tapVisualizar_Tapped(object sender, TappedEventArgs e)
        {
            //Seguir a ideia do botao deletar
            //q é a recuperação do evento tapped
            TappedEventArgs tapped = (TappedEventArgs)e;
            //Validamos o parametro
            if(tapped.Parameter is Pessoa item)
            {
                //Abrir a tela de visualização
                //passando o bjeto selecionada via parametro
                Application.Current.MainPage.Navigation.
                    PushAsync(new pgVisualizarPessoaView(item));
            }
        }

        private async void tapDeletar_Tapped(object sender, TappedEventArgs e)
        {
            //Seguindo o processo de identificação do item na list views
            //precisamos identificar/extrair os eventos e o item da lista
            //Primeiro vamos acesso o evento tappe
            //A nossa variavel tapped ira receber o evento da imagem
            //usando o (TappedEventArgs)e para recuperar de qual imagem
            //foi clicado, no caso é o icone visualizar
            TappedEventArgs tapped = (TappedEventArgs)e;
            //O ponto importante para extrar o evento tapped
            //é a nescessidade de de recuperar o parametro passado
            //{Binding .} que se refere ao item selecionado
            //Validar se o item selecionado é valido
            //Aqui eu valido se o meu item selecionado
            //é do tipo de dado Pessoa
            //se for ja populo objeto Pessoa na variavel item
            if (tapped.Parameter is Pessoa item)
            {
                //Confirmação de exclusão
                //Sempre que eu utilizar um deisplayalert
                //para retorno de sim ou não
                //sou obrigado a usar await e adicionar
                //o async no método ou função
                bool validacao =
                    await DisplayAlert(
                        "Confirmação",
                        "Deseja realmente excluir este item?",
                        "Sim", "Não");
                //Lembrando que o primeiro bão sempre retorna true
                //ou seja a ordem sempre deve começar pelo SIM
                if (validacao)
                {
                    //Removemos o item do banco de dados
                    _controle.Delete(item);
                    AtualizarListView();
                }
            }
        }
    }
}
