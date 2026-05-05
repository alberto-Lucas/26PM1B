namespace AppCaraCoroa
{
    public class Manual
    {
        //Desenvolver um app de cara ou coroa
        //que grava o historico de jogadas

        //Primeiro iniciamos com a instalação do pacotes
        //1 - Pacote para banco de dados
        //sqlite-net-pcl (Icone Pena)
        //2 - Pacote para gerenciamento de arquivo
        //PclExt.FieStorage (Icone Sushi)
        //A instalação ocorre pleo caminho:
        //Ferramentas > Gerenciador de Pacotes do NuGet >
        //Gerenciar Pacotes do NuGet na Solução (unico icone colorido)
        //Após a instalação precisamos chamar as bibliotecas
        //using SQLite;
        //using PCLExt.FileStorage.Folders;
        //A bliblioteca deve ser importada e todo classe
        //que usuara banco de dados 
        //***********************************************************
        //Segundo passo devemos criar a classe objeto de
        //acordo com a solicitação
        //Neste caso teremos a Classe Jogada com os atributos
        //Jogador
        //Data Hora
        //Aposta
        //Resultado
        //Pontuacao
        //Podemos criar essa classe em um arquivo separado
        //ou no mesmo arquivo do projeto
        //Neste caso iremos utilizar em arquivo separado
        //para melhor organização
        //Lembrando que é nescessario deixar a classe publica
        //e importar a biblioteca do SqLite
        //Obs: implementando logica de retorno direto na classe
        //assim gravamos apenas os dados brutos
        //e as conversoes de texto direto na classe
        //***********************************************************
        //Terceiro iremos implementar as rotinas de jogadas na tela
        //Primeiro devemos criar a conexão com o banco de dados
        //iremos criar uma variavel global para armazenar a conexão
        //SQLiteConnection _connection;
        //depois iremos desenvolver o método GetConnection
        //que ira validar o arquivo do banco de dados
        //cria-lo caso não exista, e retorna a conexão com o banco
        //***********************************************************
        //Quarto Abrir a conexão com o banco de dados no
        //construtor da Classe
        //No caso na public MainPage() abaixo do InitializeComponent();
        //Abro a conexão com o banco
        //_connection = GetConnection();
        //Atualizo a tabela do banco de acordo com a classe
        //_connection.CreateTable<Jogada>();
        //Chamo o método AtualizarListView();
        //***********************************************************
        //Iremos desenvolver o app de forma fragmentada
        //quebrando as rotinas em pequenos métodos
        //***********************************************************
        //Método para atualizar a lista com base no bd
        //lsvLista.DataSource = _connection.Table<Jogada>().ToList();
        //***********************************************************
        //Método Reset
        //Irá resetar a tela, definindo o valor da pontuação por padrão
        //com 10 pontos e limpando o campo nome do jogador
        //Obs: não será resetado a listagem
        //***********************************************************
        //Método JogarMoeda irá retornar o Resultado da Moeda jogada
        //True: Cara - False: Coroa
        //Criar uma variavel global para armazenar a pontual atual
        //int _pontuacaoAtual = 0;
        //iniciamos ela com o valor zerado
        //***********************************************************
        //Método salvar ira receber via parametros os dados
        //Nome Jogador, Aposta, Resultado e Pontuacao atual
        //Irá criar o objeto jogada e gravar no banco de dados
        //e retorna o objeto criado
        //***********************************************************
        //Método ExibirResultado
        //Irá popular a tela com o resultado da jogada
        //de acordo com o objeto
        //***********************************************************
        //Método Jogar irá juntar a excução de todos os demais métodos
        //O método principal do app irá receber via parametro
        //o Nome do Jogar e a Aposta
        //***********************************************************
        //Programa o Botao Jogar para recuperar o nome do Jogador
        //e a aposta e chamar o método Jogar
        //***********************************************************
        //Botão Reiniciar irá chamar o método Reset, para reiniciar
        //o jogo
        //***********************************************************
        //Na criação da tela irei usar checkBox por ser o compoenente
        //apresentado em sala de aula, a melhor opção seria um 
        //radioButton mas como não trabalhamos com ele vou de checkBox
        //***********************************************************
        //Criar o demais componentes de forma padrão
        //***********************************************************
        //EXTRA
        //Desenvolvido método para aplicar animação de giro na moeda
        //***********************************************************
        //FIM
    }
}
