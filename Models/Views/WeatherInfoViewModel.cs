using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherApp.Services;

namespace WeatherApp.Models.Views
{
    internal partial class WeatherInfoViewModel : ObservableObject
    {
        private readonly WeatherApiService _apiService;
        public WeatherInfoViewModel()
        {
            _apiService = new WeatherApiService();
        }

        [ObservableProperty]
        private string latitude;

        [ObservableProperty]
        private string longitude;

        [ObservableProperty]
        private string location;

        [ObservableProperty]
        private string temperature;

        [ObservableProperty]
        private string weather;

        [ObservableProperty]
        private string icon;

        [ObservableProperty]
        private int humidity;

        [ObservableProperty]
        private string cloudCoverLevel;

        [ObservableProperty]
        private string isDay;


        [RelayCommand]
        private async Task FetchWeatherInfo()
        {
            var response = await _apiService.GetWeatherInfo(latitude, longitude);
            if (response != null)
            {
                Icon = response.Current.Weather_icons[0];
                Location = $"{response.Location.Name}, {response.Location.Region}, {response.Location.Country}";
                Temperature = $"{response.Current.Temperature}°C";
                CloudCoverLevel = $"{response.Current.Cloudcover}%";
                Humidity = response.Current.Humidity;
                Weather = response.Current.Weather_descriptions[0];
                IsDay = response.Current.Is_day.ToUpper();
            }

        }
    }
}
