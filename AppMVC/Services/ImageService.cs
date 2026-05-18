namespace AppMVC.Services
{
    //Classes Normais com manipulação de dados
    //precisam de uma instancia, incluindo classe singleton

    //Classes funcionais, irá executar pontualmente uma função
    //pois não ira armazenar nada em memoria
    //por tanto não possui instancia
    //a instancia serve para acessar os dados em memoria
    //Ou seja esse tipo de classe é chamada de classe estatica

    //Usaremos a classe estatica pois iremos chamar os métodos
    //diretamente sem armazenamento de dados
    //para isso basta adicionar a palavra reservada static
    //OBS: todo método e função dentro de uma classe static
    //tambem precisar ser do tipo static
    public static class ImageService
    {
        //Função para selecionar e retornar o diretorio
        //da imagem selecionada
        //ou seja o diretorio origem
        //Como a seleção de imagem irá abrir uma tela propria
        //do dispositivo, precisamos aplicar a execução
        //assincrona (async) para não travar o aplicativo
        //como está tela ira retornar o diretorio
        //e será executada em segundo plano
        //precisamos sincronizar para recuperar o diretorio
        //Neste iremos usar o Task para sincronia
        public static async Task<string> SelecionarImagem()
        {
            //variavel auxiliar
            string diretorio = "";

            //Chamar o componente de seleção de imagem
            //MediaPicker componente de midia
            //PickPhotoAsync método par selecionar imagem
            //Pick = Selecionar
            //Capture = Tirar/Gravar
            var imgSelecionada =
                await MediaPicker.PickPhotoAsync();

            //Validar o diretorio delecionado
            //Se possuir uma imagem selecionada
            //recupero o diretorio dela
            if (imgSelecionada != null)
                diretorio = imgSelecionada.FullPath;

            return diretorio;
        }

        //Função quer ira realizar uma cópia da imagem
        //ou seja a imagem selecionada
        //iremos realizar uma copia e salvar a copia
        //dentro da pasta do aplicativo
        //assim caso o usuario exclua a foto original
        //o aplicativo não seja impactado
        public static string CopiarImagem(string dirOriginal)
        {
            //Variavel com o Diretorio final
            string dirDestino = "";

            //Validar se o diretorio Original existe
            //Pois se o mesmo estivar vazio
            //não sera possivel realizar a copia da imagem
            if (!string.IsNullOrEmpty(dirOriginal))
            {

                //Primeiro precisamos montar o diretorio 
                //de destino, pois iremos criar uma pasta
                //imagens dentro da pasta do aplicativo
                //Ex: C:/APPMVC/IMAGENS
                //AppContext.BaseDirectory recupera a pasta do applicativo
                var dirNovo =
                    Path.Combine(AppContext.BaseDirectory, "Imagens");

                //Validar a existencia da pasta Imagens
                //pois caso não exista, é preciso cria-la
                //Só vou criar se o diretorio não existir
                if (!Directory.Exists(dirNovo))
                    Directory.CreateDirectory(dirNovo);

                //Montar o diretorio completo novo (Dir + Nome Arquivo)
                //Para isso iremos reutilizar o nome original do arquivo
                //Ex: C:/Download/123456.png
                //a copia fiacaria como 
                //E: C:/AppMVC/Imagens/123456.png

                //Recuperar o nome original da imagem
                string nomeOriginal = Path.GetFileName(dirOriginal);

                //Montar o nodo dir completo
                dirDestino =
                    Path.Combine(dirNovo, nomeOriginal);

                //Agora sim podemos realizar a copia da imagem
                //e apenas por garantia é preciso ativar
                //a sobrescrita de imagem ativa
                //porém não é problema devido o padrão de 
                //nomenclatura da imagem pelo dispositivo
                File.Copy(dirOriginal, dirDestino, overwrite: true);
                //Aqui a copia ja foi feita e salva
            }
            //Retornamos o diretorio de destino
            return dirDestino;
        }
    }
}
