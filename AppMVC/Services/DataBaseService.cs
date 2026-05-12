using SQLite;
using PCLExt.FileStorage.Folders;

namespace AppMVC.Services
{
    //Classe para gerenciar a conexão
    //com o Banco de Dados

    //Importar as bibiotecas SQLite e PCLExt
    //using SQLite;
    //using PCLExt.FileStorage.Folders;

    public class DataBaseService
    {
        //Método que retorna a conexão com o BD
        public SQLiteConnection GetConnection()
        {
            //Acessar a pasta raiz da aplicação
            var pasta = new LocalRootFolder();

            //Gerenciar o arquivo fisico do BD
            var arquivo =
                pasta.CreateFile("mvc", 
                    PCLExt.FileStorage.
                    CreationCollisionOption.OpenIfExists);

            //Abre e retorna a conexão com BD
            return new SQLiteConnection(arquivo.Path);
        }
    }
}
