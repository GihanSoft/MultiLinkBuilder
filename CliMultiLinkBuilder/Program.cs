using System.Diagnostics;

namespace CliMultiLinkBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var links = MultiLinkBuilder.Builder.BuildMultiLink(args[0], int.Parse(args[1]), int.Parse(args[2]));
            foreach (var link in links)
            {
                Process.Start(link);
            }
        }
    }
}
