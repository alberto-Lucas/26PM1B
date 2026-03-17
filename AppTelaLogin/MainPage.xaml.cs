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
            //Validação simples com admin admin

            if (txtUsuario.Text == "admin" &&
                txtSenha.Text == "admin")
            {
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
    }
}
