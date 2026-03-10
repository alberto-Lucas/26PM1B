namespace PrimeiroApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnCliqueAqui_Clicked(object sender, EventArgs e)
        {
            //Utilizar DisplayAlert
            //que é o similar do MessageBox

            //Titulo
            //Texto
            //Botoes

            DisplayAlert(
                "Atenção!", 
                "Texto digitado: " + txtExemplo.Text,
                "Ok");
        }
    }
}
