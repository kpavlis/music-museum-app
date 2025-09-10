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
    public sealed partial class Page_Customer_3 : Page
    {
        public Page_Customer_3()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            MyWebView2.Source = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Fronalpstock_big.jpg/1599px-Fronalpstock_big.jpg");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyWebView2.Source = new Uri("https://www.youtube.com/");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            MyWebView2.Source = new Uri("https://www.youtube.com/watch?v=xBBggkRoiug&ab_channel=ANT1TV");


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MyWebView2.Source = new Uri("https://www.youtube.com/watch?v=7hiGKbl-iaA&ab_channel=%CE%A4%CE%95%CE%A4-%CE%91-%CE%A4%CE%95%CE%A4%CE%9C%CE%95%CE%A4%CE%9F%CE%9D%CE%A4%CE%91%CE%A3%CE%9F%CE%A4%CE%A1%CE%A5%CE%A6%CE%A9%CE%9D%CE%9F%CE%A3");
        }
    }
}
