namespace AppAlquiler
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(fRegistroCliente), typeof(fRegistroCliente));
            Routing.RegisterRoute(nameof(fGestionarReserva), typeof(fGestionarReserva));
            Routing.RegisterRoute(nameof(fInicioReserva), typeof(fInicioReserva));
        }
    }
}