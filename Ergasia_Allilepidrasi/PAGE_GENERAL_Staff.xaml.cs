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
    public sealed partial class PAGE_GENERAL_Staff : Page
    {
        MainWindow x;

        public PAGE_GENERAL_Staff()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                x = e.Parameter as MainWindow;
            }
        }

        private void nvSample_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                //contentFrame.Navigate(typeof(Page_Settings), x);
            }
            else if (args.SelectedItem != null)
            {

                NavigationViewItem item = args.SelectedItem as NavigationViewItem;


                if (item != null && item.Tag != null)
                {
                    string selectedTag = item.Tag.ToString();
                    switch (selectedTag)
                    {
                        case "Page4":
                            contentFrame.Navigate(typeof(Page_Customer_4), x);
                            break;
                        case "Page5":
                            contentFrame.Navigate(typeof(Page_Staff_DJ), x);
                            break;
                        case "Page6":
                            contentFrame.Navigate(typeof(Page_Customer_6));
                            break;
                        case "Page7":
                            contentFrame.Navigate(typeof(Page_Customer_7));
                            break;
                        case "Settings":
                            contentFrame.Navigate(typeof(Page_Settings), x);
                            break;

                    }
                }
            }
        }
    }
}
