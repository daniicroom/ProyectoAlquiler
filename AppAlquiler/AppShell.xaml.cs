namespace AppAlquiler
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(fPaginaInicio), typeof(fPaginaInicio));
            Routing.RegisterRoute(nameof(fIndex), typeof(fIndex));
            Routing.RegisterRoute(nameof(fRegistroCliente), typeof(fRegistroCliente));
            Routing.RegisterRoute(nameof(fGestionarReserva), typeof(fGestionarReserva));
            Routing.RegisterRoute(nameof(fValidacionCliente), typeof(fValidacionCliente));
            Routing.RegisterRoute(nameof(fValidacionEmpleado), typeof(fValidacionEmpleado));
            Routing.RegisterRoute(nameof(fGestionarDevolucion), typeof(fGestionarDevolucion));

        }
 
    }
}