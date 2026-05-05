using SQLite;

namespace AppCaraCoroa
{
    public class Jogada
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Jogador { get; set; }
        public DateTime DtHora { get; set; }
        //True: Cara
        //False: Coroa
        public bool Aposta { get; set; }
        public bool Resultado { get; set; }
        public int Pontuacao { get; set; }

        [Ignore] //Usado para não vincular ao banco de dados
        public string MoedaAposta 
        { 
            get
            {
                //If ternario para retorna a conversão do campo Aposta 
                return Aposta ? "Cara" : "Coroa";
            }
        }

        [Ignore]
        public string   ResultadoMoeda
        {
            get
            {
                //If ternario para retorna a conversão do campo Resultado 
                return Resultado ? "Cara" : "Coroa";
            }
        }

        [Ignore]
        public bool ResultadoAposta
        {
            get
            {
                //If ternario para retorna o resultado da aposta
                return Aposta == Resultado;
            }
        }

        [Ignore]
        public string ResultadoApostaTexto
        {
            get
            {
                //If ternario para retorna a conversão do campo ResultadoAposta 
                return ResultadoAposta ? "Ganhou" : "Perdeu";
            }
        }
    }
}
