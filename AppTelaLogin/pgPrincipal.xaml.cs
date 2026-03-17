namespace AppTelaLogin;

public partial class pgPrincipal : ContentPage
{
	public pgPrincipal()
	{
		InitializeComponent();
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