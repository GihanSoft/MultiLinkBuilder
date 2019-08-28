using System.Diagnostics;
using System.Windows;

namespace MultiLink
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var x = e.Args;
            if (x.Length > 0)
            {
                var links = MultiLinkBuilder.Builder.BuildMultiLink(e.Args[0], int.Parse(e.Args[1]), int.Parse(e.Args[2]));
                foreach (var link in links)
                {
                    Process.Start(link);
                }
            }
        }
    }
}
