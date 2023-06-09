using AppAlquiler.Broker;
using AppAlquiler.Models;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace AppAlquiler;

public partial class fRegistroCliente : ContentPage, IQueryAttributable
{
    private bCliente _bCliente = new bCliente(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbAppAlquiler2023.db3"));

    private bTipoDocumento _bTipoDocumento = new bTipoDocumento();
    private bCategoriaLicencia _bCategoriaLicencia = new bCategoriaLicencia();
    public fRegistroCliente()
    {
        InitializeComponent();
    }



    private async void btnRegistrar_Clicked(object sender, EventArgs e)
    {
        string documento;
        if (string.IsNullOrEmpty(txtDocumento.Text)) 
        { 
            documento = ""; 
        }
        else 
        { 
            documento = txtDocumento.Text; 
        }
        ViewCombo categoria = (ViewCombo)cboCategoriaLicencia.SelectedItem;
        int categoriaLicencia = Convert.ToInt32(categoria.Codigo);
        string nombre = txtNombres.Text;
        string apellidos = txtApellidos.Text;
        string direccion = txtDireccion.Text;
        int edad = Convert.ToInt32(txtEdad.Text);
        string numeroLicencia = txtNumeroLicencia.Text;
        ViewCombo tipoDoc = (ViewCombo)cboTipoDocumento.SelectedItem;
        int tipoDocumento = Convert.ToInt32(tipoDoc.Codigo);

        Cliente cliente = new Cliente();
        cliente.Documento = documento;
        cliente.TipoDocumento = tipoDocumento;
        cliente.Nombres = nombre;
        cliente.Apellidos = apellidos;
        cliente.Direccion = direccion;
        cliente.Edad = edad;
        cliente.NumeroLicencia = numeroLicencia;
        cliente.IDLicencia = categoriaLicencia;
        var response = await _bCliente.GrabarClienteServicio(cliente);
        if (response == null || response == "null")
        {
            await _bCliente.GrabarCliente(cliente);
        }
        lblMensaje.Text = "Se grabó el cliente";
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.Any())
        {
            string Documento = HttpUtility.UrlDecode((string)query["Documento"]);

            lblMensaje.Text = "No se encontró el cliente con N° de documento '" + Documento + "' debe diligenciar el formulario de registro.";
            txtDocumento.Text = Documento;
            cboTipoDocumento.ItemsSource = _bTipoDocumento.GetTiposDocumentos();
            cboCategoriaLicencia.ItemsSource = _bCategoriaLicencia.GetCategoriasLicencias();
        }
    }

    private async void btnAtras_Clicked(object sender, EventArgs e)
    {
        // Navega a la pagína de inicio
        await Shell.Current.GoToAsync($"fValidacionCliente");
    }
}