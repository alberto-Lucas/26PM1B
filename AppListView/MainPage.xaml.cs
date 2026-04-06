using PCLExt.FileStorage.Folders;
using SQLite;
using System.ComponentModel.DataAnnotations;

namespace AppListView
{
    public partial class MainPage : ContentPage
    {
        //Para utilização de sqlLite
        //é nescessario 2 biblioteca
        //1 - O Proprio SQLite o banco de dados
        //2 - PCL Gerenciador de arquivo

        //Instalamos os bibliotecas pelo Nuget
        //Instalar Nuget sqlite-net-pcl (icone da pena)
        //Instalar Nuget pclext.filestorage (icone do sushi)

        //Ferramentas > Gerenciador de pacotes do Nuget >
        //Gerenciar pacote do Nuget na Solução

        //Adicionar a chamada dos pacotes
        //using PCLExt.FileStorage.Folders;
        //using SQLite;

        //Proximo passo é criar a nossa classe de objeto
        //Pois o banco de dados é criado com base no objeto
        //qualquer alteração no objeto é feito
        //automaticamente no banco de dados

        //Criar a classe pessoa
        //para armazenar o nosso cadastro de Pessoa
        //com seus atributos
        public class Pessoa
        {
            //Definir através de TAG's a configuração
            //dos campos para a tabela do banco

            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Idade { get; set; }
        }

        //Agora vamos para a parte de banco de dados

        //Iniciamos com a variavel que ira armazenar
        //a conexão com o banco (No caso do sqlite
        //o carregamento do arquivo do banco)
        SQLiteConnection conexao;

        //Função responsavel por retornar a conexão do BD
        public SQLiteConnection GetConnection()
        {
            //Carregar a pasta da aplicação
            //a onde o BD será salvo
            //a onde a aplicação está instalada
            var pastaRaiz = new LocalRootFolder();

            //Configurar a manipulação do arquivo do BD
            //Definir o nome do banco de dados
            //Configurar para criar o arquivo caso
            //ele não exista
            //Caso o arquivo exista, ele seja atualizado
            var arquivoBD = pastaRaiz.CreateFile(
                "oraculo", PCLExt.FileStorage. //Nome do banco
                    CreationCollisionOption.OpenIfExists); //Crio se não existir

            //Retornar a conexão com o arquivo
            //Path rotarno o diretorio do arquivo
            return new SQLiteConnection(arquivoBD.Path);
        }

        public MainPage()
        {
            InitializeComponent();
            //Ao abrir o aplicativo
            //iremos conectar no banco de dados
            //e exibir os registro na listView

            //Abriar a conexão
            conexao = GetConnection();

            //Mapear a classe para criar a tabela
            conexao.CreateTable<Pessoa>();

            //Atualizar a List View
            AtualizarListView();
        }

        //Método para atualizar a listView
        //de acordo com o BD
        void AtualizarListView()
        {
            //Realizar um select na tabela Pessoa
            //Semelhante a query
            //SELECT * FROM Pessoa
            lsvDados.ItemsSource =
                conexao.Table<Pessoa>().ToList();
        }

        private void btnAdicionar_Clicked(object sender, EventArgs e)
        {
            //Iremos adicionar o registro
            //no banco de dados

            string nome = txtNome.Text;
            string idade = txtIdade.Text;

            //Validar se os campos foram preenchidos
            if(string.IsNullOrEmpty(nome) ||
                string.IsNullOrEmpty(idade))
            {
                DisplayAlert("Atençao", 
                    "Pro favor, preencha o campos corretamente.", "Ok");
                return; //Abortar a execução
            }

            //Precisamos popular o objeto Pessoa
            Pessoa pessoa = new Pessoa(); 
            pessoa.Nome = nome; //ou passar o txt.Text direto
            pessoa.Idade = idade;

            //Inserir o registro no BD
            conexao.Insert(pessoa);

            //Atualizar a lista
            AtualizarListView();

            //Limpar os campos da tela
            txtNome.Text = "";
            txtIdade.Text = "";
        }
    }
}
