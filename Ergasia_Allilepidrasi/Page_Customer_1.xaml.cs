using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
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
    public sealed partial class Page_Customer_1 : Page
    {
        int mediacheck = 0;
        ContentDialog dialog;
        public Page_Customer_1()
        {
            this.InitializeComponent();
        }

        private async void ShowDialog_Click(object sender, RoutedEventArgs e)
        {

            dialog.Content = new Page_Customer_Special_1();

            var result = await dialog.ShowAsync();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            dialog.Content = new Page_Customer_Special_2();

            var result = await dialog.ShowAsync();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {

            dialog.Content = new Page_Customer_Special_3();

            var result = await dialog.ShowAsync();
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {

            dialog.Content = new Page_Customer_Special_4();

            var result = await dialog.ShowAsync();
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            dialog.Content = new Page_Customer_Special_5();

            var result = await dialog.ShowAsync();
        }

        private async void Button_Click_4(object sender, RoutedEventArgs e)
        {
            dialog.Content = new Page_Customer_Special_6();

            var result = await dialog.ShowAsync();
        }

        private async void Button_Click_5(object sender, RoutedEventArgs e)
        {

            dialog.Content = new Page_Customer_Special_7();

            var result = await dialog.ShowAsync();
        }

        private async void Button_Click_6(object sender, RoutedEventArgs e)
        {
            dialog.Content = new Page_Customer_Special_8();

            var result = await dialog.ShowAsync();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            dialog = new ContentDialog();
            dialog.XamlRoot = this.XamlRoot;
            dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
            dialog.Title = "Καλλιτέχνης";
            dialog.CloseButtonText = "Κλείσιμο";
            dialog.UseSystemFocusVisuals = true;
        }
    }
}
