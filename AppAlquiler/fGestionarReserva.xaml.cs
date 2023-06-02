using System.Web;

namespace AppAlquiler;

public partial class fGestionarReserva : ContentPage, IQueryAttributable
{
	public fGestionarReserva()
	{
		InitializeComponent();
	}

    private void dtpFechaInicio_DateSelected(object sender, DateChangedEventArgs e)
    {

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
        }
    }

    private void btnConsultar_Clicked(object sender, EventArgs e)
    {

    }

    private void btnCancelar_Clicked(object sender, EventArgs e)
    {

    }
}