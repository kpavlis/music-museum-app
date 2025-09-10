using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
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
    public sealed partial class Page_Customer_4 : Page
    {

        int count_check = 0;
        int product_counter = 0;
        ContentDialog dialog1;
        List<string> products = new List<string>();
        List<int> products_price = new List<int>();

        public Page_Customer_4()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            welcome.Visibility = Visibility.Collapsed;
            
            Buy.Visibility = Visibility.Visible;

            products_show.IsEnabled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            products.Add("Pizza");
            products_price.Add(3);
            product_counter++;
            project.Text = products.Count.ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            products.Add("Donut");
            products_price.Add(2);
            product_counter++;
            project.Text = products.Count.ToString();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            products.Add("Toast");
            products_price.Add(4);
            product_counter++;
            project.Text = products.Count.ToString();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            products.Add("Water");
            products_price.Add(1);
            product_counter++;
            project.Text = products.Count.ToString();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            products.Add("Cappucino");
            products_price.Add(3);
            product_counter++;
            project.Text = products.Count.ToString();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            products.Add("Hot Chocolate");
            products_price.Add(2);
            product_counter++;
            project.Text = products.Count.ToString();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            products.Add("Espresso");
            products_price.Add(3);
            product_counter++;
            project.Text = products.Count.ToString();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            products.Add("Green Tea");
            products_price.Add(2);
            product_counter++;
            project.Text = products.Count.ToString();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (count_check == 0)
            {
                int total_price = 0;
                count_check++;
                products_show.Visibility = Visibility.Collapsed;
                products_show.IsEnabled = false;
                receipt.Visibility = Visibility.Visible;
                button_con.Content = "Συνέχεια Αγορών";
                show.Text = "";

                for (int i = 0; i < products.Count; i++)
                {
                    String x = $"{products[i]} - {products_price[i]}€ \n";
                    show.Text += x;
                    total_price += products_price[i];
                }
                sum.Text = $"{total_price.ToString()}€";
            }
            else
            {
                count_check--;
                products_show.Visibility = Visibility.Visible;
                products_show.IsEnabled = true;
                receipt.Visibility = Visibility.Collapsed;
                button_con.Content = "Δες το Καλάθι ή/και Πλήρωσε";
            }
        }

        private async void Button_Click_10(object sender, RoutedEventArgs e)
        {
            dialog1 = new ContentDialog();
            dialog1.XamlRoot = this.XamlRoot;
            dialog1.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
            dialog1.Title = "Διαδικασία Πληρωμής";
            dialog1.CloseButtonText = "Κλείσιμο";
            dialog1.PrimaryButtonText = "Πληρωμή";
            dialog1.PrimaryButtonClick += Button_Click_11;
            dialog1.Content = new Page_Customer_Payment();
            dialog1.DefaultButton = ContentDialogButton.Primary;
            dialog1.UseSystemFocusVisuals = true;
            var result = await dialog1.ShowAsync();
        }

        private void Button_Click_11(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            pay_button.Visibility = Visibility.Collapsed;
            pay_confirm.Visibility = Visibility.Visible;
            //sum.TextDecorations
            button_con.IsEnabled = false;
        }

        private void again_Click(object sender, RoutedEventArgs e)
        {
            count_check = 0;
            products_show.Visibility = Visibility.Visible;
            products_show.IsEnabled = false;
            receipt.Visibility = Visibility.Collapsed;
            button_con.Content = "Δες το Καλάθι ή/και Πλήρωσε";
            button_con.IsEnabled = true;
            welcome.Visibility = Visibility.Visible;

            Buy.Visibility = Visibility.Collapsed;

            project.Text = "0";
            products.Clear();
            products_price.Clear();
            pay_button.Visibility = Visibility.Visible;
            pay_confirm.Visibility = Visibility.Collapsed;



        }
    }
}
