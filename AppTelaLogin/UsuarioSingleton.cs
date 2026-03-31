namespace AppTelaLogin
{
    public sealed class UsuarioSingleton
    {
        static UsuarioSingleton _instancia;

        public static UsuarioSingleton Instancia
        {
            get
            {
                return _instancia ??
                    (_instancia = new UsuarioSingleton());
            }
        }

        public UsuarioSingleton() { }

        public Usuario Usuario { get; set; }
    }
}
