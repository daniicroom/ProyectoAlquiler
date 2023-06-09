using AppAlquiler.Models;
using AppAlquiler.Broker;
using Microsoft.Maui.Controls;
using System;

namespace AppAlquiler;

public partial class fPaginaInicio : ContentPage
{
	public fPaginaInicio()
	{
		InitializeComponent();
	}

    private async void btnCliente_Clicked(object sender, EventArgs e)
    {
        //Navegar a la pagina de Validación del documento del Cliente
        await Shell.Current.GoToAsync($"fValidacionCliente");

    }

    private async void btnEmpleado_Clicked(object sender, EventArgs e)
    {
        //Navegar a la pagina de Validación del documento del empleado
        await Shell.Current.GoToAsync($"fValidacionEmpleado");
    }
}