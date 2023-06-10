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

    public fGestionarReserva()
	{
		InitializeComponent();

        // Se establece la fecha actual como la fecha mínima del DatePicker de fecha inicio
        dtpFechaInicio.MinimumDate = DateTime.Today;
        dtpFechaFin.MinimumDate = DateTime.Today.AddDays(1);
  
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
        TipoVehiculo Valor = (TipoVehiculo)cboTipoVehiculo.SelectedItem;

        int Codigo = Valor.Codigo;
        List<Vehiculo> data = _bVehiculo.GetVehiculosXTipo(Codigo);
        cboVehiculo.ItemsSource = data;

        /*
        cboVehiculo.ItemsSource = null;
        cboVehiculo.ItemsSource = _bVehiculo.GetVehiculosXTipo(Codigo);
        cboVehiculo.ItemsSource = cboVehiculo.GetItemsAsList();*/
    }
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

        Vehiculo vehiculo = (Vehiculo)cboVehiculo.SelectedItem;

        string placa = "";
        if (cboVehiculo.SelectedItem != null)
        {
            placa = vehiculo.Codigo.ToString();

        }

        Reservar reservar = new Reservar();
        reservar.CedulaCliente = documentoCliente;
        reservar.IDEmpleado = empleado;
        reservar.IDTipoVehiculo = tipoVehiculo;
        reservar.PlacaVehiculo = placa;
        reservar.EstadoReserva = "ACTIVO";
        reservar.FechaInicio = fechaInicio;
        reservar.FechaFin = fechaFin;

        string response = await _bReserva.GrabarReservaServicio(reservar);
        var data = response.Split(":");

        if (data.Count() == 1)
        {
            await _bReserva.GrabarReserva(reservar);
            _ = DisplayAlert("Ok !", "Reserva grabada exitosamente en sqlite", "ACEPTAR");
        }
        else
        {
            _ = DisplayAlert("Ok !", response, "ACEPTAR");
        }
        //_ = DisplayAlert("Ok !", "Reserva grabada exitosamente", "ACEPTAR");
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.Any())
        {
            string Documento = HttpUtility.UrlDecode((string)query["Documento"]);
            string Nombres = HttpUtility.UrlDecode((string)query["Nombres"]);
            string Apellidos = HttpUtility.UrlDecode((string)query["Apellidos"]);
            lblMensaje.Text = "Bienvenido(a) "+ Nombres + " por favor gestione su reserva";

            txtDocumentoCliente.Text = Documento;
            txtNombre.Text = Nombres + " " + Apellidos;
            txtEmpleado.Text = "1023525415";
            cboTipoVehiculo.ItemsSource = _bTipoVehiculo.GetTiposVehiculos();
        
        }
    }
    private async void btnAtras_Clicked(object sender, EventArgs e)
    {
        // Navega a la pagína de inicio
        await Shell.Current.GoToAsync($"fValidacionCliente");
    }
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
            // Navega a la pagina de inicio
            Shell.Current.GoToAsync("fIndex");
        
    }

}