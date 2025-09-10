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
    public sealed partial class Page_Customer_2 : Page
    {
        int[] Seats1 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] Seats2 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int value = 0;

        public Page_Customer_2()
        {
            this.InitializeComponent();
        }

        private async void SubmitSeat_Click(object sender, RoutedEventArgs e)
        {
            string option;
            if (ConcertRadioButtons.SelectedItem != null)
            {
                option = ConcertRadioButtons.SelectedItem.ToString();
            }
            else
            {
                option = "";
            }
            if (option.Equals("Concert1"))
            {
                ConcertText.Text = "Επιλέξατε την 1η συναυλία";
                for (int x = 1; x <= Seats1.Length; x++)
                {

                    if (x.ToString().Equals(SeatCodeText.Text) && Seats1[x-1] == 0)
                    {

                        ContentDialog dialog = new ContentDialog();

                        // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
                        dialog.XamlRoot = this.XamlRoot;
                        dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
                        dialog.Title = "Διαδικασία Πληρωμής";
                        dialog.PrimaryButtonText = "Πληρωμή";
                        dialog.Content = new Page_Customer_Payment();
                        dialog.SecondaryButtonText = "Κλείσιμο";
                        dialog.DefaultButton = ContentDialogButton.Primary;



                        // CONTENT DIALOG PART1

                        dialog.PrimaryButtonClick += Dialog_PrimaryButtonClick;
                        dialog.SecondaryButtonClick += Dialog_SecondaryButtonClick;

                        

                        var result = await dialog.ShowAsync();

                        Seats1[x - 1] = value;
                        value = 0;

                        break;
                    }
                    else if (x.ToString().Equals(SeatCodeText.Text) && Seats1[x - 1] == 1)
                    {
                        ReservationText.Text = "Αυτή η θέση είναι ήδη κρατημένη!";
                        SubmitCheckIcon.Visibility = Visibility.Collapsed;
                    }
                }


            }
            else if (option.Equals("Concert2"))
            {
                ConcertText.Text = "Επιλέξατε την 1η συναυλία";

                for (int x = 1; x <= Seats2.Length; x++)
                {
                    if (x.ToString().Equals(SeatCodeText.Text) && Seats2[x - 1] == 0)
                    {

                        ContentDialog dialog = new ContentDialog();

                        // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
                        dialog.XamlRoot = this.XamlRoot;
                        dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
                        dialog.Title = "Διαδικασία Πληρωμής";
                        dialog.PrimaryButtonText = "Πληρωμή";
                        dialog.Content = new Page_Customer_Payment();
                        dialog.SecondaryButtonText = "Κλείσιμο";
                        dialog.DefaultButton = ContentDialogButton.Primary;

                        //CONTENDIALOG PART2

                        dialog.PrimaryButtonClick += Dialog_PrimaryButtonClick;
                        dialog.SecondaryButtonClick += Dialog_SecondaryButtonClick;


                        var result = await dialog.ShowAsync();

                        Seats2[x - 1] = value;
                        value = 0;

                        break;
                    }
                    else if (x.ToString().Equals(SeatCodeText.Text) && Seats2[x - 1] == 1)
                    {
                        ReservationText.Text = "Αυτή η θέση είναι ήδη κρατημένη!";
                        SubmitCheckIcon.Visibility = Visibility.Collapsed;
                    }
                }

            }
            else
            {
                ConcertText.Text = "Πρέπει πρώτα να επιλέξετε μία συναυλία !";
            }

        }

        private void Dialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            ReservationText.Text = "Η κράτησή σας ακυρώθηκε";
            value = 0;

        }

        private void Dialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            ReservationText.Text = "Η κράτηση έγινε με επιτυχία !";
            value = 1;
            SubmitCheckIcon.Visibility = Visibility.Visible;
        }

        private void ConcertRadioButtons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReservationText.Text = string.Empty;
            SubmitCheckIcon.Visibility = Visibility.Collapsed;
        }

        
    }
}
