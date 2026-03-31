namespace AppTelaLogin;

public partial class pgPrincipal : ContentPage
{
	public pgPrincipal()
	{
		InitializeComponent();

		//Iremos recuperar os dados armazenados
		//na classe singleton

		//Sigo o mesmo principio1
		//vaveriavel var para recuperar a instancia
		var usuarioLogado = UsuarioLogado.Instancia;

		//Agora só chamar o atributo desejado

		lblUsuario.Text =
			"Olá " + usuarioLogado.Login +
			", seja bem-vindo!";

		//Carregar os dados do usuário
		var usuarioSingleton = UsuarioSingleton.Instancia;

		lblNome.Text = usuarioSingleton.Usuario.Nome;
		lblEmail.Text = usuarioSingleton.Usuario.Email;
		lblLogin.Text = usuarioSingleton.Usuario.Login;
		lblDtNascimento.Text = usuarioSingleton.Usuario.DtNascimento;

    }

    private void Voltar_Tapped(object sender, TappedEventArgs e)
    {
        //Para voltar precisamos remover
        //a pagina atual da pilha
        //ou seja aplicar um POP
        Application.Current.MainPage.
            Navigation.PopAsync();
    }
}