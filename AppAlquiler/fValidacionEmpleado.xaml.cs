using AppAlquiler.Broker;
using AppAlquiler.Models;

namespace AppAlquiler;

public partial class fValidacionEmpleado : ContentPage
{
	public fValidacionEmpleado()
	{
		InitializeComponent();
	}

    private async void btnSiguiente_Clicked(object sender, EventArgs e)
    {
        //Consulta el servicio para validar si el empleado existe
        string Documento = txtDocumento.Text;

        bEmpleado empleado = new bEmpleado();
        empleado.Documento = Documento;

        Empleado _empleado = empleado.Consultar(Documento);

        if (_empleado == null)
        {
            lblMensaje.Text = "No existe un empleado registrado con el número de documento " + Documento;
        }
        else
        {
            
            //Navegar a la pagina de Gestionar Devolucion
            await Shell.Current.GoToAsync($"fGestionarDevolucion?Documento={_empleado.Documento}");
           
        }
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        // Navega a la pagina de inicio
        Shell.Current.GoToAsync("fIndex");
    }
}