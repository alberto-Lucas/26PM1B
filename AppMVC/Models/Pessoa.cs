using SQLite;

namespace AppMVC.Models
{
    //Importe o using SQLite;
    public class Pessoa
    {
        //Definir os atributos
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string  CPF { get; set; }
        //Atributo para salvar
        //o diretorio onde a imagem sera salva
        public string DirImagem { get; set; }
    }
}
