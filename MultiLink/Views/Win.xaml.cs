using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
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
    }
}
