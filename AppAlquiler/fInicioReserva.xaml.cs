using AppAlquiler.Models;
using AppAlquiler.Broker;

namespace AppAlquiler;

public partial class fInicioReserva : ContentPage
{
	public fInicioReserva()
	{
		InitializeComponent();
	}

    private async void btnSiguiente_Clicked(object sender, EventArgs e)
    {
		//Consulta el servicio para validar si el cliente existe
		string Documento = txtDocumento.Text;

		bCliente cliente = new bCliente();
		cliente.Documento = Documento;

		Cliente _cliente = cliente.Consultar(Documento);
		
		if (_cliente == null )
		{
			//Navegar a la pagina de registro Cliente
			//await Shell.Current.GoToAsync($"fRegistroCliente?Documento={_cliente.Documento}");
			await Shell.Current.GoToAsync($"fRegistroCliente?Documento={Documento}");
		}
		else
		{
            //lblMensaje.Text = "Cliente encontrado " + _cliente.Nombres + " " + _cliente.Apellidos;

            //Navegar a la pagina de Gestionar Reserva
            await Shell.Current.GoToAsync($"fGestionarReserva?Documento={_cliente.Documento}&Nombres={_cliente.Nombres}&Apellidos={_cliente.Apellidos}");




        }

    }
}