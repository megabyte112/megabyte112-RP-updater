using System;
using System.IO;
using System.Diagnostics;
using Syroot.Windows.IO;
namespace updater
{
    class Program
    {
        static void Main()
        {
            string downloadsPath = new KnownFolder(KnownFolderType.Downloads).Path;
            if (File.Exists(downloadsPath+"\\megabyte112RP.zip"))
            {
                Console.WriteLine("There is already a resource pack file in your downloads folder.\nPress enter to remove it.");
                Console.ReadLine();
                File.Delete(downloadsPath+"\\megabyte112RP.zip");
            }
            Console.WriteLine("Installed at:\n" + Directory.GetCurrentDirectory());
            Console.WriteLine("\nPress enter to continue to GitHub. Save the resource pack to your downloads folder.\nThen come back here and press enter.");
            Console.ReadLine();
            var web = new ProcessStartInfo
            {
                FileName = "https://github.com/megabyte112/megabyte112-mc-resourcepack/releases",
                UseShellExecute = true
            };
            System.Diagnostics.Process.Start(web);
            Console.ReadLine();
            if (!File.Exists(downloadsPath+"\\megabyte112RP.zip"))
            {
                Console.WriteLine("The resource pack couldn't be found in your downloads folder.\nPress enter to close, and run the program again to try again.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Resource pack was found.\nPress enter to move to Minecraft");
                Console.ReadLine();
                File.Move(downloadsPath+"\\megabyte112RP.zip", "..\\megabyte112.zip");
            }
        }
    }
}