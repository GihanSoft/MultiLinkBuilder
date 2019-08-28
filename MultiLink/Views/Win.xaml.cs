using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MultiLink.Views
{
    /// <summary>
    /// Interaction logic for Win.xaml
    /// </summary>
    public partial class Win
    {
        public Win()
        {
            InitializeComponent();
        }

        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {
            SpLinks.Children.Clear();
            foreach (var link in MultiLinkBuilder.Builder.BuildMultiLink(TxtBaseUrl.Text, int.Parse(TxtStartNum.Text), int.Parse(TxtEndNum.Text)))
            {
                SpLinks.Children.Add(new TextBox { Text = link });
            }
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            foreach (TextBox item in SpLinks.Children)
            {
                Process.Start(item.Text);
            }
        }

        private async void BtnDl_Click(object sender, RoutedEventArgs e)
        {
            MpbDl.Visibility = Visibility.Visible;
            MpbDl.Maximum = 1;
            var l = SpLinks.Children.Count;
            var i = 1;
            foreach (TextBox item in SpLinks.Children)
            {
                MpbDl.Value = i * 1.0 / l;
                var path = Path.Combine(TxtDlPath.Text, item.Text.Substring(item.Text.LastIndexOf("/") + 1));
                var link = item.Text;
                await Task.Run(() =>
                {
                    try
                    {
                        Download(link, path);
                    }
                    catch
                    {
                        Dispatcher.Invoke(() =>
                        {
                            item.Background = new SolidColorBrush(Colors.DarkRed);
                            item.Foreground = new SolidColorBrush(Colors.White);
                        });
                    }
                });
                i++;
            }
            MpbDl.Visibility = Visibility.Collapsed;
        }
        private int dlStack = 0;
        private void Download(string link, string path)
        {
            dlStack++;
            var client = new System.Net.WebClient();
            try
            {
                client.DownloadFile(link, path);
            }
            catch
            {
                if (dlStack < 4)
                    Download(link, path);
                else
                    throw;
            }
            dlStack--;
        }
    }
}
