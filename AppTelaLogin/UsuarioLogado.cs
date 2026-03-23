namespace AppTelaLogin
{
    //Teremos aqui uma classe Singleton
    //Responsavel por armazenar os dados
    //utilizandos durante o login

    //Um classe Singleton é um classe
    //de uma unica instancia
    //portante eu não consigo instanciar
    //pu criar novos objetos dessa classe
    //sempre irei utilizar a instancia
    //criada automaticamente
    //portante os dados nela armazenado
    //podem ser recuperados e alterados de
    //qualquer parte do código
    
    //Para trasnforma uma classe em singleton
    //é preciso adicionar o termo sealed
    //que significa classe selada
    public sealed class UsuarioLogado
    {
        //Para o funcionando é preciso
        //criar uma variavel para armazenar 
        //a unica instancia
        //sempre que a classe for chamada
        //sera utilizado a instancia armazenada

        //A variavel criada sera do tipo static
        //para ser chamada internamente na classe
        //é preciso ser do tipo static
        //devido a classe ser sealed

        //vamos utilizar o underline(_) para identificar
        //que é uma classe privada
        //static tido de variavel
        //UsuarioLogado tipo de dados
        //_instancia nome da variavel
        static UsuarioLogado _instancia;

        //Criar o método para gerenciamento
        //da instancia
        //ou seja ao executar a aplicação a instancia
        //sera criada automaticamente
        //e quando a classe for usada, ira retornar
        //a instancia ja criada
        //O método tambem precisa ser do tipo static

        public static UsuarioLogado Instancia
        {
            //utilizar o um get para 
            //retorna a instancia
            get
            {
                //Iremos retornar o apontamento
                //da instancia em memoria
                //se não existir (primeira execução)
                //sera criada, caso exista
                //a retornaremos
                //?? é utilizada para validar
                //se a instancia esta nula
                //se sim executamos a criação
                return _instancia ??
                    (_instancia = new UsuarioLogado());

                //Como seria se fosse um if normal
                //Ex:
                //if(_instancia == null)
                //  return _instancia = new UsuarioLogado();
                //else
                //  return _instancia; 

                //todo codigo utilizado até aqui
                //faz parte da documentação do C#
            }            
        }

        //Daqui para baixo será os
        //dados personalizados

        //Construtor da classe
        public UsuarioLogado() { }

        //E agora definimos os atributos

        //para criar atributos(propriedades)
        //prop e parter tab 2 vezes
        public string Login { get; set; }
        //Podemos criar os dados que desejar
        //ex:
        //public string Nome { get; set; }
        //Posso definir quantos atributos
        //forem nescessarios
    }
}
