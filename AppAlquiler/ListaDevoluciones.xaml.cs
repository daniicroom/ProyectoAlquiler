namespace AppAlquiler;

public partial class ListaDevoluciones : ContentPage
{
	public ListaDevoluciones()
	{
		InitializeComponent();
	}

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        // Navega a la pagina de inicio
        Shell.Current.GoToAsync("fIndex");
    }
}