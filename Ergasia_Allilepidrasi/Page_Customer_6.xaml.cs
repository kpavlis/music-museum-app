using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections;
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
    public sealed partial class Page_Customer_6 : Page
    {
        ObservableCollection<Songs> _songs;
        public int count = 0;
        int Song_Played = 0;
        RoutedEventArgs ee = new RoutedEventArgs();

        public Page_Customer_6()
        {
            this.InitializeComponent();

            count = 0;
            this._songs = new ObservableCollection<Songs>();


            _songs.Add(new Songs("Χέρια Ψηλά", "Μιχάλης Χαντζηγιάννης"));
            _songs.Add(new Songs("Η αγάπη δυναμώνει", "Μιχάλης Χαντζηγιάννης"));

            BaseExample.ItemsSource = _songs;

            values.Add(0);

            Run run1 = new Run();
            WinMessage.Blocks.Clear();
            WinMessageText.Inlines.Clear();

            values.Sort();
            values.Reverse();
            foreach (int x in values)
            {
                maxvalue = x;
                break;
            }

            run1.Text = maxvalue.ToString() + "(Μηδέν) : Καμία βαθμολόγηση !";
            WinMessageText.Inlines.Add(run1);
            WinMessage.Blocks.Add(WinMessageText);

            values.Clear();


            RatingBar.IsReadOnly = true;
            SubmitButton.IsEnabled = false;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {


            if (Song_Played == 1)
            {
                ButtonPlayer_Click(ButtonPlayer, ee);
            }

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {

            if (_mediaPlayerElement.MediaPlayer.CurrentState == MediaPlayerState.Playing)
            {

                ButtonPlayer_Click(ButtonPlayer, ee);
                Song_Played = 1;
            }
            else
            {
                Song_Played = 0;
            }
        }




        DispatcherTimer dt = new DispatcherTimer();
        Songs selectedSong = new Songs("", "");

        ArrayList values = new ArrayList();
        int maxvalue;

        List<String> lines = new List<String>()
        {
            "Δεν ξέρω μάτια μου τι θα πει αγάπη,",
            "όλοι μια λέξη λένε κι είν αρκετή.",
            "Μαζί σου έμαθα να ψάχνω αυτό το κάτι",
            "που κάνει δυο κορμιά να αντέχουνε μαζί.",

            "Χέρια ψηλά κι όλα τα φτάνω,",
            "έλα να πάμε απ' την αγάπη πιο πάνω.",
            "Χέρια ψηλά δώσ' μου να ανέβω.",
            "Σ' ένα θεό, σε σένα τώρα πιστεύω.",
            "Χέρια ψηλά κι όλα τα φτάνω,",
            "έλα να πάμε απ' την αγάπη πιο πάνω.",
            "Χέρια ψηλά κι είμαι μαζί σου,",
            "έτσι κερδίζω στη ζωή τη ζωή σου.",

            "Όλος ο κόσμος γύρω λέει σ' αγαπάω",
            "όμως για μας δε φτάνει μόνο ένα φιλί.",
            "Μαζί σου έμαθα τα ρήματα να σπάω,",
            "δες πόσα σ' αγαπώ φωνάζει η σιωπή.",

            "Χέρια ψηλά κι όλα τα φτάνω,",
            "έλα να πάμε απ' την αγάπη πιο πάνω.",
            "Χέρια ψηλά δώσ' μου να ανέβω.",
            "Σ' ένα θεό, σε σένα τώρα πιστεύω.",
            "Χέρια ψηλά κι όλα τα φτάνω,",
            "έλα να πάμε απ' την αγάπη πιο πάνω.",
            "Χέρια ψηλά κι είμαι μαζί σου,",
            "έτσι κερδίζω στη ζωή τη ζωή σου.",
        };




        private void ButtonPlayer_Click(object sender, RoutedEventArgs e)
        {



            if (PlayerButtonIcon.Glyph.Equals("\uE768") && selectedSong.Title.Equals("Χέρια Ψηλά"))
            {
                _mediaPlayerElement.MediaPlayer.Play();


                PlayerButtonIcon.Glyph = "\uE769";

                Lyrics.Blocks.Clear();
                LyricsText.Inlines.Clear();

                dt.Tick += Dt_Tick;
                dt.Interval = TimeSpan.FromSeconds(3);

                dt.Start();

                RatingBar.IsReadOnly = false;
                SubmitButton.IsEnabled = true;



            }
            else if (PlayerButtonIcon.Glyph.Equals("\uE769") && selectedSong.Title.Equals("Χέρια Ψηλά"))
            {
                _mediaPlayerElement.MediaPlayer.Pause();
                Lyrics.Blocks.Clear();
                LyricsText.Inlines.Clear();
                dt.Tick -= Dt_Tick;
                dt.Stop();
                PlayerButtonIcon.Glyph = "\uE768";
            }






        }

        private void Dt_Tick(object sender, object e)
        {

            if (count < lines.Count)
            {
                Run run1 = new Run();
                Lyrics.Blocks.Clear();
                LyricsText.Inlines.Clear();
                run1.Text = lines[count];
                LyricsText.Inlines.Add(run1);
                Lyrics.Blocks.Add(LyricsText);
                count++;
            }
            else
            {
                Lyrics.Blocks.Clear();
                LyricsText.Inlines.Clear();
                dt.Tick -= Dt_Tick;
                dt.Stop();
                PlayerButtonIcon.Glyph = "\uE768";
                count = 0;
                RatingBar.IsReadOnly = true;
                SubmitButton.IsEnabled = false;
                RatingBar.Value = 0;

            }


        }



        private void BaseExample_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selectedSong.Title.Equals("Η αγάπη δυναμώνει"))
            {
                _mediaPlayerElement.MediaPlayer.Pause();
                Lyrics.Blocks.Clear();
                LyricsText.Inlines.Clear();
                dt.Tick -= Dt_Tick;
                dt.Stop();
                PlayerButtonIcon.Glyph = "\uE768";
            }

            SubmitRateText.Text = string.Empty;
            SubmitRateCheckIcon.Visibility = Visibility.Collapsed;
            Songs thisitem = (Songs)BaseExample.SelectedItem;

            selectedSong.Name = thisitem.Name;
            selectedSong.Title = thisitem.Title;

            Run run1 = new Run();
            Run run2 = new Run();

            SongTitle.Blocks.Clear();
            SongTitleText.Inlines.Clear();
            run1.Text = thisitem.Title;
            SongTitleText.Inlines.Add(run1);
            SongTitle.Blocks.Add(SongTitleText);

            ArtistName.Blocks.Clear();
            ArtistNameText.Inlines.Clear();
            run2.Text = thisitem.Name;
            ArtistNameText.Inlines.Add(run2);
            ArtistName.Blocks.Add(ArtistNameText);

            RatingBar.IsReadOnly = false;
            SubmitButton.IsEnabled = true;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            SubmitRateText.Text = "Η βαθμολόγηση έγινε με επιτυχία !";
            SubmitRateCheckIcon.Visibility = Visibility.Visible;
            values.Add(Convert.ToInt32(RatingBar.Value));
            values.Sort();
            values.Reverse();

            foreach (int x in values)
            {
                maxvalue = x;
                break;

            }


            Run run1 = new Run();
            values.Clear();
            values.Add(maxvalue);
            if (Convert.ToInt32(RatingBar.Value) == maxvalue)
            {

                WinMessage.Blocks.Clear();
                WinMessageText.Inlines.Clear();
                run1.Text = "Το τραγούδι που νικάει είναι:" + Environment.NewLine + selectedSong.Title + "," + selectedSong.Name + Environment.NewLine + " με " + maxvalue.ToString() + " πόντους !";
                WinMessageText.Inlines.Add(run1);
                WinMessage.Blocks.Add(WinMessageText);
            }

        }


    }

    public class Songs
    {
        public string Title { get; set; }
        public string Name { get; set; }

        public Songs(string title, string name)
        {
            Title = title;
            Name = name;
        }
    }
}
