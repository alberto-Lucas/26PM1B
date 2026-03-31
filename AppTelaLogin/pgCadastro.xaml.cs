namespace AppTelaLogin;

public partial class pgCadastro : ContentPage
{
	public pgCadastro()
	{
		InitializeComponent();
	}

    private void btnSalvar_Clicked(object sender, EventArgs e)
    {
		//Primeiro iremos validar a confirmação
		//da senha, se ambos os campos, foram
		//preenchidos corretamente
		//Ou seja, setão iguais
		//se sim prossegue com o código
		//se não, aborta a execução

		if(txtSenha.Text != txtConfirmarSenha.Text)
		{
			DisplayAlert(
				"Atenção!", "As senha não conferem.", "Ok");
			return; //Abortar a execução
		}

		//Se chegou até aqui, está tudo correto]
		//Criamos o nosso objeto usuario
		//e salvamos na classe singleton

		Usuario usuario = new Usuario();

		usuario.Nome = txtNome.Text;		
        usuario.Email = txtEmail.Text;
        usuario.Login = txtLogin.Text;
        usuario.Senha = txtSenha.Text;
        usuario.DtNascimento = txtDtNascimento.Text;

		//gravar os dados
		var usuarioSingleton = UsuarioSingleton.Instancia;
		usuarioSingleton.Usuario = usuario;

		DisplayAlert(
			"Sucesso!", "Usuário cadastrado com sucesso.", "OK");

		//Retornar para tela anterior
		Application.Current.MainPage.
			Navigation.PopAsync();
    }
}