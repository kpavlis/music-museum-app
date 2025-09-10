using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Ergasia_Allilepidrasi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page_Customer_7 : Page
    {
        public Page_Customer_7()
        {
            this.InitializeComponent();
        }

        private void ColdButton1_Click(object sender, RoutedEventArgs e)
        {

            TemperatureText1.Text = (Int32.Parse(TemperatureText1.Text) - 1).ToString();
            if (Int32.Parse(TemperatureText1.Text) < 11)
            {
                TemperatureText1.Foreground = new SolidColorBrush(Colors.Blue);
                CelciumText1.Foreground = new SolidColorBrush(Colors.Blue);
            }
            else
            {
                TemperatureText1.Foreground = new SolidColorBrush(Colors.Black);
                CelciumText1.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void HeatButton1_Click(object sender, RoutedEventArgs e)
        {
            TemperatureText1.Text = (Int32.Parse(TemperatureText1.Text) + 1).ToString();
            if (Int32.Parse(TemperatureText1.Text) > 34)
            {
                TemperatureText1.Foreground = new SolidColorBrush(Colors.DarkRed);
                CelciumText1.Foreground = new SolidColorBrush(Colors.DarkRed);
            }
            else
            {
                TemperatureText1.Foreground = new SolidColorBrush(Colors.Black);
                CelciumText1.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void ColdButton2_Click(object sender, RoutedEventArgs e)
        {
            TemperatureText2.Text = (Int32.Parse(TemperatureText2.Text) - 1).ToString();

            if (Int32.Parse(TemperatureText2.Text) < 11)
            {
                TemperatureText2.Foreground = new SolidColorBrush(Colors.Blue);
                CelciumText2.Foreground = new SolidColorBrush(Colors.Blue);
            }
            else
            {
                TemperatureText2.Foreground = new SolidColorBrush(Colors.Black);
                CelciumText2.Foreground = new SolidColorBrush(Colors.Black);
            }

        }

        private void HeatButton2_Click(object sender, RoutedEventArgs e)
        {
            TemperatureText2.Text = (Int32.Parse(TemperatureText2.Text) + 1).ToString();
            if (Int32.Parse(TemperatureText2.Text) > 34)
            {
                TemperatureText2.Foreground = new SolidColorBrush(Colors.DarkRed);
                CelciumText2.Foreground = new SolidColorBrush(Colors.DarkRed);
            }
            else
            {
                TemperatureText2.Foreground = new SolidColorBrush(Colors.Black);
                CelciumText2.Foreground = new SolidColorBrush(Colors.Black);
            }

        }

        private void ColdButton3_Click(object sender, RoutedEventArgs e)
        {
            TemperatureText3.Text = (Int32.Parse(TemperatureText3.Text) - 1).ToString();
            if (Int32.Parse(TemperatureText3.Text) < 11)
            {
                TemperatureText3.Foreground = new SolidColorBrush(Colors.Blue);
                CelciumText3.Foreground = new SolidColorBrush(Colors.Blue);
            }
            else
            {
                TemperatureText3.Foreground = new SolidColorBrush(Colors.Black);
                CelciumText3.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void HeatButton3_Click(object sender, RoutedEventArgs e)
        {
            TemperatureText3.Text = (Int32.Parse(TemperatureText3.Text) + 1).ToString();
            if (Int32.Parse(TemperatureText3.Text) > 34)
            {
                TemperatureText3.Foreground = new SolidColorBrush(Colors.DarkRed);
                CelciumText3.Foreground = new SolidColorBrush(Colors.DarkRed);
            }
            else
            {
                TemperatureText3.Foreground = new SolidColorBrush(Colors.Black);
                CelciumText3.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void ColdButton4_Click(object sender, RoutedEventArgs e)
        {
            TemperatureText4.Text = (Int32.Parse(TemperatureText4.Text) - 1).ToString();
            if (Int32.Parse(TemperatureText4.Text) < 11)
            {
                TemperatureText4.Foreground = new SolidColorBrush(Colors.Blue);
                CelciumText4.Foreground = new SolidColorBrush(Colors.Blue);
            }
            else
            {
                TemperatureText4.Foreground = new SolidColorBrush(Colors.Black);
                CelciumText4.Foreground = new SolidColorBrush(Colors.Black);
            }

        }

        private void HeatButton4_Click(object sender, RoutedEventArgs e)
        {
            TemperatureText4.Text = (Int32.Parse(TemperatureText4.Text) + 1).ToString();
            if (Int32.Parse(TemperatureText4.Text) > 34)
            {
                TemperatureText4.Foreground = new SolidColorBrush(Colors.DarkRed);
                CelciumText4.Foreground = new SolidColorBrush(Colors.DarkRed);
            }
            else
            {
                TemperatureText4.Foreground = new SolidColorBrush(Colors.Black);
                CelciumText4.Foreground = new SolidColorBrush(Colors.Black);
            }

        }

        private void LightSwtch1_Toggled(object sender, RoutedEventArgs e)
        {
            if (LightSwtch1.IsOn == true)
            {
                aithousa_synayliwn_fwta.Source = new BitmapImage(new Uri("ms-appx:///Assets/stage-light-with-red-background.jpg"));
            }
            else
            {
                aithousa_synayliwn_fwta.Source = new BitmapImage(new Uri("ms-appx:///Assets/stage-light-with-red-background-Dark.jpg"));
            }
        }

        private void LightSwtch2_Toggled(object sender, RoutedEventArgs e)
        {
            if (LightSwtch2.IsOn == true)
            {
                aithousa_ektheshs_fwta.Source = new BitmapImage(new Uri("ms-appx:///Assets/MicrosoftTeams-image.png"));
            }
            else
            {
                aithousa_ektheshs_fwta.Source = new BitmapImage(new Uri("ms-appx:///Assets/MicrosoftTeams-image-Dark.png"));
            }
        }

        private void LightSwtch3_Toggled(object sender, RoutedEventArgs e)
        {
            if (LightSwtch3.IsOn == true)
            {
                aithousa_kylikeiou_fwta.Source = new BitmapImage(new Uri("ms-appx:///Assets/16277.jpg"));
            }
            else
            {
                aithousa_kylikeiou_fwta.Source = new BitmapImage(new Uri("ms-appx:///Assets/16277-Dark.jpg"));
            }
        }

        private void LightSwtch4_Toggled(object sender, RoutedEventArgs e)
        {
            if (LightSwtch4.IsOn == true)
            {
                aithousa_provolhs_fwta.Source = new BitmapImage(new Uri("ms-appx:///Assets/MicrosoftTeams-image (1).png"));
            }
            else
            {
                aithousa_provolhs_fwta.Source = new BitmapImage(new Uri("ms-appx:///Assets/MicrosoftTeams-image (1)-Dark.png"));
            }
        }
    }
}
