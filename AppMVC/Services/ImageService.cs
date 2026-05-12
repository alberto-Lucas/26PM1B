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
    }
}
