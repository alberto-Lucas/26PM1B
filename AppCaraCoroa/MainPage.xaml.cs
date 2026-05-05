using SQLite;
using PCLExt.FileStorage.Folders;

namespace AppCaraCoroa
{
    public partial class MainPage : ContentPage
    {
        //utilizado o _ para identificar
        //que a variavel é do tipo private
        SQLiteConnection _connection;

        //Variavel que ira armazenar a pontual Atual
        int _pontuacaoAtual = 0;

        SQLiteConnection GetConnection()
        {
            //Acesso a pasta onde o aplicativo está 
            //sendo executado;
            var pastaRaiz = new LocalRootFolder();

            //Recupero o arquivo do banco de dados
            //o mesmo será criado quase não exista
            var arquivoDB =
                pastaRaiz.CreateFile("flip",
                    PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);

            //Retorno a conexão com o arquivo
            return new SQLiteConnection(arquivoDB.Path);
        }

        //EXTRA
        //Método para girar a imagem da moeda
        public MainPage()
        {
            InitializeComponent();
            //Abro a conexão com o banco
            _connection = GetConnection();
            //Atualizo a tabela do banco de acordo com a classe
            _connection.CreateTable<Jogada>();
            //Resetamos a tela
            Reset();
            //Atualizar a grade
            AtualizarLista();

            Animation();
        }

        async Task Animation()
        {
            while (true)
            {
                // reseta a posição
                imgCoin.RotationY = 0;
                //Realiza um giro vertical em 360 graus 
                //com duranção de 500 milisegundos
                await imgCoin.RotateYTo(360, 5000);
            }
        }

        //Método para atualizar a lista com base no bd
        void AtualizarLista()
        {
            lsvLista.ItemsSource =
                _connection.Table<Jogada>().ToList();
        }

        //Método Reset
        void Reset()
        {
            _pontuacaoAtual = 10;

            txtJogador.Text = string.Empty;
            lblResultadoMoeda.Text = "";
            lblResultadoAposta.Text = "";
            lblPontuacao.Text = _pontuacaoAtual.ToString();

            ckbCara.IsChecked = true;
        }

        //Método JogarMoeda
        bool JogarMoeda(bool Aposta)
        {
            //Utilizando o tipo de dado Randon
            //para sorte um valor entre 1 e 2
            Random moeda = new Random();
            //Retorno o resultado convertido para bool
            //0 - Coroa -> False
            //1 - Cara -> True
            return moeda.Next(0, 2) == 1;
        }

        //Método salvar
        Jogada Salvar(
            string Nome, bool Aposta, bool Resultado, int Pontuacao)
        {
            Jogada jogada = new Jogada();

            jogada.Jogador = Nome;
            //Grava a data e hora atual
            jogada.DtHora = DateTime.Now;
            jogada.Aposta = Aposta;
            jogada.Resultado = Resultado;
            jogada.Pontuacao = Pontuacao;

            //Insere no banco de dados
            _connection.Insert(jogada);
            //Atualizamos a ListView
            AtualizarLista();
            //Retorna o objeto
            return jogada;
        }

        //Método ExibirResultado
        void ExibirResultado(Jogada RJogada)
        {
            lblResultadoMoeda.Text = RJogada.ResultadoMoeda;
            lblResultadoAposta.Text = RJogada.ResultadoApostaTexto;
            lblPontuacao.Text = RJogada.Pontuacao.ToString();

            lblResultadoAposta.TextColor =
                RJogada.ResultadoAposta ? Colors.Green : Colors.Red;
        }

        //Método Jogar
        void Jogar(string Jogador, bool Aposta)
        {
            //Iniciamos jogando a moeda
            bool resultado = JogarMoeda(Aposta);

            if (Aposta == resultado)
                _pontuacaoAtual++;
            else
                _pontuacaoAtual--;

            //Salvamos os dados e recuperamos o objeto
            var jogada =
                Salvar(Jogador, Aposta, resultado, _pontuacaoAtual);

            //Atualizo a exibição do resultado
            ExibirResultado(jogada);
        }

        private void ckbCara_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            ckbCoroa.IsChecked = !ckbCara.IsChecked;
        }

        private void ckbCoroa_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            ckbCara.IsChecked = !ckbCoroa.IsChecked;
        }

        private void btnJogar_Clicked(object sender, EventArgs e)
        {
            Jogar(txtJogador.Text, ckbCara.IsChecked);
        }

        private void btnReiniciar_Clicked(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
