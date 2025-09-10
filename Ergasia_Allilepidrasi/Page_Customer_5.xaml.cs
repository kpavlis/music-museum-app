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
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Playback;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Ergasia_Allilepidrasi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page_Customer_5 : Page
    {
        MainWindow x;
        bool dark_mode_check = false;
        bool blue_lights_check = false;
        int SongList = 0;
        int Song_Played = 0;
        private ObservableCollection<Song> _songs;
        private ObservableCollection<Song> _songs_prive;

        public Page_Customer_5()
        {
            this.InitializeComponent();
            _songs = SongManager.Allocator();
            _songs_prive = SongManager.Allocator1();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                x = e.Parameter as MainWindow;
            }

            if (Song_Played == 1)
            {
                _mediaPlayerElement.MediaPlayer.Play();
            }
            else if (Song_Played == 2)
            {
                _mediaPlayerElement2.MediaPlayer.Play();
            }

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ((FrameworkElement)x.Content).RequestedTheme = ElementTheme.Light;
            dark_mode_check = false;

            if (_mediaPlayerElement.MediaPlayer.CurrentState == MediaPlayerState.Playing)
            {
                _mediaPlayerElement.MediaPlayer.Pause();
                Song_Played = 1;
            }
            else if (_mediaPlayerElement2.MediaPlayer.CurrentState == MediaPlayerState.Playing)
            {
                _mediaPlayerElement2.MediaPlayer.Pause();
                Song_Played = 2;
            }
            else
            {
                Song_Played = 0;
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (SongList == 1)
            {
                BaseExample.ItemsSource = _songs;
                SongList = 0;
            }
            else
            {
                BaseExample.ItemsSource = _songs_prive;
                SongList = 1;
            }
        }

        private void BaseExample_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BaseExample.SelectedItem != null)
            {
                Title.Text = ((Song)BaseExample.SelectedItem).Title;
                Artist.Text = ((Song)BaseExample.SelectedItem).Artist;
                if (((Song)BaseExample.SelectedItem).Artist == "Μιχάλης Χαντζηγιάννης" && Image.DataContext.ToString() != "Μιχάλης Χαντζηγιάννης")
                {

                    Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/mihalis.png"));
                    Image.DataContext = "Μιχάλης Χαντζηγιάννης";
                }
                else if (((Song)BaseExample.SelectedItem).Artist == "Άννα Βίσση" && Image.DataContext.ToString() != "Άννα Βίσση")
                {
                    Image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Artists/p2.jpeg"));
                    Image.DataContext = "Άννα Βίσση";
                }

                if (((Song)BaseExample.SelectedItem).SongId == 0)
                {
                    _mediaPlayerElement.Visibility = Visibility.Visible;
                    _mediaPlayerElement2.Visibility = Visibility.Collapsed;
                    _mediaPlayerElement.IsEnabled = true;

                    if (_mediaPlayerElement2.MediaPlayer.CurrentState == MediaPlayerState.Playing)
                    {
                        _mediaPlayerElement2.MediaPlayer.Position = TimeSpan.Zero;
                        _mediaPlayerElement2.MediaPlayer.Pause();
                    }

                }
                else if (((Song)BaseExample.SelectedItem).SongId == 1)
                {
                    _mediaPlayerElement.Visibility = Visibility.Collapsed;
                    _mediaPlayerElement2.Visibility = Visibility.Visible;

                    if (_mediaPlayerElement.MediaPlayer.CurrentState == MediaPlayerState.Playing)
                    {
                        _mediaPlayerElement.MediaPlayer.Position = TimeSpan.Zero;
                        _mediaPlayerElement.MediaPlayer.Pause();
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {



            _mediaPlayerElement.MediaPlayer.Position = TimeSpan.Zero;
            _mediaPlayerElement.MediaPlayer.Pause();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (dark_mode_check == false)
            {
                dark_mode_check = true;
                ((FrameworkElement)x.Content).RequestedTheme = ElementTheme.Dark;
            }
            else
            {
                dark_mode_check = false;
                ((FrameworkElement)x.Content).RequestedTheme = ElementTheme.Light;
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (blue_lights_check == false)
            {
                picture_1.Visibility = Visibility.Collapsed;
                picture_2.Visibility = Visibility.Visible;
                sub_picture.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/DJ_Blue.png"));
                photos.Source = new BitmapImage(new Uri("ms-appx:///Assets/Blue_DJ.jpg"));
                blue_lights_check = true;
            }
            else
            {
                picture_1.Visibility = Visibility.Visible;
                picture_2.Visibility = Visibility.Collapsed;
                photos.Source = new BitmapImage(new Uri("ms-appx:///Assets/DJ.jpg"));
                blue_lights_check = false;
            }
        }


        private void TestButtonClick2(object sender, RoutedEventArgs e)
        {
            ToggleThemeTeachingTip2.IsOpen = true;
        }
    }

    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int SongId { get; set; }

    }

    public class SongManager
    {

        public static ObservableCollection<Song> Allocator()
        {
            var songs = new ObservableCollection<Song>();

            songs.Add(new Song { Title = "Χέρια Ψηλά", Artist = "Μιχάλης Χαντζηγιάννης", SongId = 0 });
            songs.Add(new Song { Title = "Η αγάπη δυναμώνει", Artist = "Μιχάλης Χαντζηγιάννης", SongId = 1 });
            songs.Add(new Song { Title = "Πιο πολύ", Artist = "Μιχάλης Χαντζηγιάννης", SongId = 2 });
            songs.Add(new Song { Title = "Τρεις Ζωές", Artist = "Μιχάλης Χαντζηγιάννης", SongId = 3 });
            songs.Add(new Song { Title = "Το Πάρτυ", Artist = "Μιχάλης Χαντζηγιάννης", SongId = 4 });
            songs.Add(new Song { Title = "Το Καλύτερο Ψέμα", Artist = "Μιχάλης Χαντζηγιάννης", SongId = 5 });
            songs.Add(new Song { Title = "Με πονάει", Artist = "Μιχάλης Χαντζηγιάννης", SongId = 6 });
            songs.Add(new Song { Title = "Εκδρομή", Artist = "Μιχάλης Χαντζηγιάννης", SongId = 7 });
            songs.Add(new Song { Title = "Το πολύ πολύ", Artist = "Άννα Βίσση", SongId = 8 });
            songs.Add(new Song { Title = "Είναι Αστείο", Artist = "Άννα Βίσση", SongId = 9 });
            songs.Add(new Song { Title = "Μεθυσμένη Πολιτεία", Artist = "Άννα Βίσση", SongId = 10 });



            return songs;
        }


        public static ObservableCollection<Song> Allocator1()
        {
            var songs = new ObservableCollection<Song>();

            songs.Add(new Song { Title = "Εκδρόμη", Artist = "Μιχάλης Χαντζηγιάννης", SongId = 11 });
            songs.Add(new Song { Title = "Τρένο", Artist = "Άννα Βίσση", SongId = 12 });
            songs.Add(new Song { Title = "Το πάρτυ", Artist = "Μιχάλης Χαντζηγιάννης", SongId = 13 });
            songs.Add(new Song { Title = "Δεν θέλω να ξέρεις", Artist = "Άννα Βίσση", SongId = 14 });
            songs.Add(new Song { Title = "Δώδεκα", Artist = "Άννα Βίσση", SongId = 15 });
            songs.Add(new Song { Title = "Με πονάει", Artist = "Μιχάλης Χαντζηγιάννης", SongId = 16 });

            return songs;
        }


    }
}
