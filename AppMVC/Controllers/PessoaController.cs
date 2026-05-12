using SQLite;
using AppMVC.Models;
using AppMVC.Services;

namespace AppMVC.Controllers
{
    //Importar o using SQLite;
    //Importar o using NomeProjeto.Models;
    //Importar o using NomeProjeto.Services;
    public class PessoaController
    {
        //Criar as variaveis globais
        //Variaivel da camada de serviço
        //para conexão com o BD
        //obs: _ é usado para identificar
        //uma variavel privada
        DataBaseService _dataBaseService;
        //Vara para a conexão em si
        SQLiteConnection _connection;

        //Método construtor
        //Executado automaticamente ao instanciar a classe
        public PessoaController()
        {
            //Iremos carregar as variaiveis
            //Intancia camada de serviço
            _dataBaseService = new DataBaseService();
            //Instancia do banco de dados
            _connection = _dataBaseService.GetConnection();

            //Mapear a classe Pessoa para criação
            //da tabela Pessoa
            _connection.CreateTable<Pessoa>();
        }

        //Agora iremos implementar os métodos
        //de manipulação Insert, Update, Delete

        //Método Insert, que retorna um verdadeiro
        //ou falso sobre a execução
        public bool Insert(Pessoa value)
        {
            //é retornado a quantidade de linhas afetadas
            //0 - Nenhuma linha
            //1 - Uma linha
            //Maior q 1 - mais de uma linha afetada
            //Neste caso como estamos inserido apenas
            //um unico registro por vez
            //então sempre será 0 ou  1
            return _connection.Insert(value) > 0;
        }

        public bool Update(Pessoa value)
        {
            return _connection.Update(value) > 0;
        }

        public bool Delete(Pessoa value)
        {
            return _connection.Delete(value) > 0;
        }

        //Método de consultas (SELECT)

        //Método para consultar todos os registros
        public List<Pessoa> GetAll()
        {
            //Realizar semelhate ao SELECT * FROM Pessoa
            //Lendo de tras pra frente
            //quero a lista com todos os registros
            //da tabela pessoa
            //que está na conexão
            return _connection.Table<Pessoa>().ToList();
        }

        //Método de consulta filtrando pelo Nome
        public List<Pessoa> GetByNome(string value)
        {
            //Neste iremos aplicar um filtro Where na listagem
            //Aplicar o filtro LIKE dentro do método Where
            //Para aplicar o filtro, é preciso definir
            //o campo a ser filtrando
            //como filtro é sendo aplicar via código
            //o banco de dados retornar todos o registro
            //e depois aplicar o filtro registro a registro
            //O filtr será aplica item a item da lista
            //onde o x é o item atual, o campo é o filtro
            //x sendo uma varial q representa o registro atual
            //=> é o lambda do c# que faz referencia ao registro
            //o utilizar o lambd eu converto o registroatual
            //em objeto (semelhante ao as do listView)
            return _connection.Table<Pessoa>().
                Where(registroAtual => 
                        registroAtual.Nome.Contains(value)).ToList();
        }

        //Método filtrando por Id possuindo apenas um retorno
        public Pessoa GetById(int value)
        {
            //O ID é mais facil, poís é chave primaria da tabela
            //possuimos um método proprioa apra filtrar chave primaria
            //SELECT * FROM Pesoa WHEHERE Id = value
            //Find exclusivo para chave primaria
            return _connection.Find<Pessoa>(value);

            //Exemplo usando lambida
            //_connection.Table<Pessoa>().
            //    Where(x => x.Id = value);
        }
    }
}
