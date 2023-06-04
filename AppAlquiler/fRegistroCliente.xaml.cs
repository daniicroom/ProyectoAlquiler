using System.Web;

namespace AppAlquiler;

public partial class fRegistroCliente : ContentPage, IQueryAttributable
{
	public fRegistroCliente()
	{
		InitializeComponent();
	}

   

    private void btnRegistrar_Clicked(object sender, EventArgs e)
    {

    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.Any())
        {
            string Documento = HttpUtility.UrlDecode((string)query["Documento"]);
         
            lblMensaje.Text = "No se encontr� el cliente con N� de documento '" + Documento + "' debe diligenciar el formulario de registro.";
            txtDocumento.Text = Documento;
        }
    }

    private async void btnAtras_Clicked(object sender, EventArgs e)
    {
        // Navega a la pag�na de inicio
        await Shell.Current.GoToAsync($"fValidacionCliente");
    }
}