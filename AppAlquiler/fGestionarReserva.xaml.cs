using AppAlquiler.Broker;
using AppAlquiler.Models;
using Microsoft.Maui.Platform;
using System.ComponentModel;
using System.Web;
using System.Windows.Input;


namespace AppAlquiler;

public partial class fGestionarReserva : ContentPage, IQueryAttributable
{
    private bReserva _bReserva = new bReserva(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbAppAlquiler2023.db3"));

    private bTipoVehiculo _bTipoVehiculo = new bTipoVehiculo();
    private bVehiculo _bVehiculo = new bVehiculo();


    public ICommand HomeCommand { get;  }

    public fGestionarReserva()
	{
		InitializeComponent();

        // Se establece la fecha actual como la fecha mínima del DatePicker de fecha inicio
        dtpFechaInicio.MinimumDate = DateTime.Today;

        // Establecer el BindingContext en la página
        BindingContext = this;

        // Asignar el comando al botón de navegación
        HomeCommand = new Command(HomeCommandExecute);

        ListadoTipoVehiculos();
  
    }

    private async void HomeCommandExecute()
    {
        //Navegar a la pagina de Inicio
        //await Shell.Current.GoToAsync(fIndex);
        await Shell.Current.GoToAsync("///fIndex");

    }
    private void dtpFechaInicio_DateSelected(object sender, DateChangedEventArgs e)
    {
        // Una vez seleccionada la fecha inicio se actualiza la fecha mínima del DatePicker de fecha fin
        dtpFechaFin.MinimumDate = dtpFechaInicio.Date.AddDays(1);

    }

    private void dtpFechaFin_DateSelected(object sender, DateChangedEventArgs e)
    {

    }


    // Llenado de los combos tipo vehiculo y vehiculo
    private void ListadoTipoVehiculos()
    {
        List<TipoVehiculo> lista = new List<TipoVehiculo>();
        cboTipoVehiculo.ItemsSource = _bTipoVehiculo.GetTiposVehiculos();
        cboTipoVehiculo.ItemDisplayBinding = new Binding("Nombre");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        cboTipoVehiculo.ItemsSource = _bTipoVehiculo.GetTiposVehiculos();
    }
    

    private void cboTipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
    {
        TipoVehiculo Valor = (TipoVehiculo)cboTipoVehiculo.SelectedItem;

        int Codigo = Valor.Codigo;
        cboVehiculo.ItemsSource = null;
        cboVehiculo.ItemsSource = _bVehiculo.GetVehiculosXTipo(Codigo);
        cboVehiculo.ItemsSource = cboVehiculo.GetItemsAsList();

    private void cboVehiculo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private async void btnGrabar_Clicked(object sender, EventArgs e)
    {
        string documentoCliente = txtDocumentoCliente.Text;
        string empleado = txtEmpleado.Text;
        string nombre = txtNombre.Text;
        DateTime fechaInicio = dtpFechaInicio.Date;
        DateTime fechaFin = dtpFechaFin.Date;
        int tipoVehiculo = cboTipoVehiculo.SelectedIndex;
        int vehiculo = cboVehiculo.SelectedIndex;
        string placa = "";
        if (cboVehiculo.SelectedItem != null)
        {
            placa = cboVehiculo.SelectedItem.ToString();

        }

        Reservar reservar = new Reservar();
        reservar.CedulaCliente = documentoCliente;
        reservar.IDEmpleado = documentoCliente;
        reservar.IDTipoVehiculo = tipoVehiculo;
        reservar.PlacaVehiculo = placa;
        reservar.EstadoReserva = "ACTIVO";
        reservar.FechaInicio = fechaInicio;
        reservar.FechaFin = fechaFin;

        string response = await _bReserva.GrabarReservaServicio(reservar);
        if (response == null)
        {
            await _bReserva.GrabarReserva(reservar);
        }
        else
        {
            
        }
        lblMensaje.Text = "Se grabó la reserva";
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
            cboTipoVehiculo.ItemsSource = _bTipoVehiculo.GetTiposVehiculos();
        
        }
    }

    private void btnConsultar_Clicked(object sender, EventArgs e)
    {

    }

    private void btnCancelar_Clicked(object sender, EventArgs e)
    {

    }

}