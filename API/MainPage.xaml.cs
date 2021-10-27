using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using API.model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace API
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

        }

        private async void GetWeather_Click(object sender, RoutedEventArgs e)
        {
            var str = TextBoxCity.Text;

            RootObject myWeather = await OpenWeatherMapProxy.getWeather(str.Trim());
            CityName.Text = myWeather.name;
            ResultTextBlock.Text =
                ((int)myWeather.main.temp).ToString()
                + " - "
                + myWeather.weather[0].description;
        }

        private void TextBoxCity_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
