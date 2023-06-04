using System.Web;
using System.Windows.Input;


namespace AppAlquiler;

public partial class fGestionarReserva : ContentPage, IQueryAttributable
{
    public ICommand HomeCommand { get; }

    public fGestionarReserva()
	{
		InitializeComponent();

        // Se establece la fecha actual como la fecha mínima del DatePicker de fecha inicio
        dtpFechaInicio.MinimumDate = DateTime.Today;

        // Establecer el BindingContext en la página
        BindingContext = this;

        // Asignar el comando al botón de navegación
        HomeCommand = new Command(HomeCommandExecute);
    }

    private async void HomeCommandExecute()
    {
        //Navegar a la pagina de Inicio
        await Shell.Current.GoToAsync("//fIndex");
    }

    private void dtpFechaInicio_DateSelected(object sender, DateChangedEventArgs e)
    {
        // Una vez seleccionada la fecha inicio se actualiza la fecha mínima del DatePicker de fecha fin
        dtpFechaFin.MinimumDate = dtpFechaInicio.Date.AddDays(1);

    }

    private void dtpFechaFin_DateSelected(object sender, DateChangedEventArgs e)
    {

    }

    private void cboTipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void cboVehiculo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void btnGrabar_Clicked(object sender, EventArgs e)
    {

    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.Any())
        {
            string Documento = HttpUtility.UrlDecode((string)query["Documento"]);
            string Nombres = HttpUtility.UrlDecode((string)query["Nombres"]);
            string Apellidos = HttpUtility.UrlDecode((string)query["Apellidos"]);
            lblMensaje.Text = "Bienvenido(a) por favor gestione su reserva";

            txtDocumentoCliente.Text = Documento;
            txtNombre.Text = Nombres + " " + Apellidos;
            txtEmpleado.Text = "ADMINISTRADOR";
        }
    }

    private void btnConsultar_Clicked(object sender, EventArgs e)
    {

    }

    private void btnCancelar_Clicked(object sender, EventArgs e)
    {

    }
}