using AppAlquiler.Broker;
using AppAlquiler.Models;
using System.Web;

namespace AppAlquiler;

public partial class fGestionarDevolucion : ContentPage, IQueryAttributable
{
    private bDevolucion _bDevolucion = new bDevolucion(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbAppAlquiler2023.db3"));
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

    private async void btnGrabar_Clicked(object sender, EventArgs e)
    {
        string documentoEmpleado = txtDocumentoEmpleado.Text;
        int idAlquiler = Convert.ToInt32(txtIdAlquiler.Text);
        int totalPagar = Convert.ToInt32(txtTotalPagar.Text);

        Devolucion devolucion = new Devolucion();
        devolucion.CodigoAlquiler = idAlquiler;
        devolucion.FechaDevolucion = DateTime.Now;
        devolucion.IDEmpleadoRecibe = documentoEmpleado;
        devolucion.TotalPagar = totalPagar;

        await _bDevolucion.GrabarDevolucion(devolucion);
        lblMensaje.Text = "Se grabó la devolucion";
    }

    private void btnConsultar_Clicked(object sender, EventArgs e)
    {

    }
}