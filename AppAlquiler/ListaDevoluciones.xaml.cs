using AppAlquiler.Broker;
using AppAlquiler.Models;

namespace AppAlquiler;

public partial class ListaDevoluciones : ContentPage
{
    private bDevolucion _bDevolucion = new bDevolucion(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbAppAlquiler2023.db3"));
    public ListaDevoluciones()
	{
		InitializeComponent();
  
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //Cargar los datos del CollectionView con la informacion de todas las devoluciones
        lstDevolucion.ItemsSource = await _bDevolucion.GetAll();
    }


    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        // Navega a la pagina de inicio
        Shell.Current.GoToAsync("fIndex");
    }

 
    private async void btnRegresar_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("fValidacionEmpleado");
    }
}