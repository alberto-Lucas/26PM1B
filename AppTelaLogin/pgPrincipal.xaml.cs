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
	}

    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
		//Para voltar precisamos remover
		//a pagina atual da pilha
		//ou seja aplicar um POP
		Application.Current.MainPage.
			Navigation.PopAsync();
    }
}