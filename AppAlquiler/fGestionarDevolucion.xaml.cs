using System.Web;

namespace AppAlquiler;

public partial class fGestionarDevolucion : ContentPage, IQueryAttributable
{
	public fGestionarDevolucion()
	{
		InitializeComponent();

        // Se establece la fecha actual como la fecha mínima del DatePicker de fecha inicio
        dtpFechaFin.MinimumDate = DateTime.Today;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        string Documento = HttpUtility.UrlDecode((string)query["Documento"]);
        lblMensaje.Text = "Por favor diligencie los datos para finalizar el proceso de alquiler";

        txtDocumentoEmpleado.Text = Documento;

    }

    private void dtpFechaFin_DateSelected(object sender, DateChangedEventArgs e)
    {

    }

    private void btnGrabar_Clicked(object sender, EventArgs e)
    {

    }

    private void btnConsultar_Clicked(object sender, EventArgs e)
    {

    }
}