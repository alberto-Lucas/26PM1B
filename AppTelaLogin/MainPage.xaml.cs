namespace AppTelaLogin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnEntrar_Clicked(object sender, EventArgs e)
        {
            //Validação de campo nullo ou vazio
            //devido o default da classe singleton
            if(string.IsNullOrEmpty(txtUsuario.Text) ||
                string.IsNullOrEmpty(txtSenha.Text))
            {
                DisplayAlert(
                    "Atenção!", 
                    "Preencha os dados de login.", "Ok");
                return; //Aborta a execução se um dos campos vazio
            }

            //Ajustar a validação de login
            //para utilizar os dados cadastrados

            //Chamar a classe singleton
            var usuarioSingleton = UsuarioSingleton.Instancia;

            if (txtUsuario.Text == usuarioSingleton.Usuario.Login &&
                txtSenha.Text == usuarioSingleton.Usuario.Senha)
            {
                //Com usuaro e senha corretos
                //Podemos adicionar o login
                //na classe singleton

                //Para isso precisamos 
                //criar uma variavel para
                //referenciar a classe
                //como o tipo da classe podera variar
                //iremos criar uma classe do tipo variavel
                //ela ira se adequar com o valor retornardo
                //ou seja
                //uma variavel var sera moldado
                //pelo dado inserido
                //se for string, ira virar string
                //se for UsuarioLogado ira vira UsuarioLogado
                //ou seja uma variavel coringa
                //atribuir a instancia da singleton a variavel
                var usuarioLogado = UsuarioLogado.Instancia;
                //Agora só atribuir os dados desejados
                //segue o mesmo principio de uma classe normal
                usuarioLogado.Login = txtUsuario.Text;


                //Iremos chamar pgPrincipal
                //Iremos acessar camadas da aplicação
                //para alterar a tela q está sendo exibida

                //Applicatio  = Aplicação
                //Current = é a excuação principal na memoria
                //MainPaga = Pagina em foco (exibida em tela)
                //Navigation = Navegação entre paginas
                //PushAsync = adicionar a pgina a pilha
                //new = instanciar a pagina desejada na memoria
                Application.Current.MainPage.
                    Navigation.PushAsync(new pgPrincipal());
            }
            else
                DisplayAlert(
                    "Atenção!",
                    "Usuário ou Senha inválidos.",
                    "OK");
        }

        private void ckbSenha_Checked(object sender, CheckedChangedEventArgs e)
        {
            //A propriedade IsPassword é resposanvel
            //por ocultar o coneteudo de um componente
            //de texto (Entry)
            //IsPassword = True - Senha está oculta
            //IsPassword = False - Senha está visivel

            //Para funcionar a logica o IsPassword
            //sempre estara ao contrario do checkBox
            //Ou seja o IsPassword irá receber a 
            //negação do checkBox

            //! serve para negar (inverter)

            txtSenha.IsPassword = !ckbSenha.IsChecked; 
        }

        private void lblSenha_Tapped(object sender, TappedEventArgs e)
        {
            //Alterar a marcação do checkBox
            //Sempre que a label for tocada
            //irei inverter o status atual
            //do checkBox
            //ou seja ele vai receber a negação
            //dele mesmo

            ckbSenha.IsChecked = !ckbSenha.IsChecked;
        }

        private void Cadastro_Tapped(object sender, TappedEventArgs e)
        {
            //Chamar a tela de cadastro
            Application.Current.MainPage.
                Navigation.PushAsync(new pgCadastro());
        }
    }
}
