using System.Reflection;
using WeatherApp.Models.Views;

namespace WeatherApp.Pages;

public partial class WeatherInfoPage : ContentPage
{
	public WeatherInfoPage()
	{
		InitializeComponent();
		BindingContext = new WeatherInfoViewModel();
	}
}