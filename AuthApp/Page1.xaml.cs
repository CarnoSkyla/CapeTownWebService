using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherServiceLibrary;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuthApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var sliderValue = Slider.Value;
            SliderLabel.Text = sliderValue.ToString();

            

            if(sliderValue > 0.5)
            {
                WeatherPage.BackgroundImageSource = "NightSky.jpg";
            } else
            {
                WeatherPage.BackgroundImageSource = "SunnyMorning";
            }

        }

     

        private async void Button_Clicked(object sender, EventArgs e)
        {



            var weather = await CTWeatherWebService.GetWeather();
            
            var celsius = TempConverter(weather.Temperature);

            temp.Text = celsius.ToString() + "F";
            temp.TextColor = Color.White;
            temp.FontSize = 20;
            sunny.Source = "sunny.png";
          

        }

        public double TempConverter(double temp)
        {
            var tempInCelsius = Math.Round((temp - 32) / 1.80000);

            return tempInCelsius;
        }

        private void switch_Toggled(object sender, ToggledEventArgs e)
        {

            temp.Text = "Meh";

        }
    }
}