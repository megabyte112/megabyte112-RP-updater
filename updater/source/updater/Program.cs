using System;
using System.IO;
using System.Net;
namespace updater
{
    class Program
    {
        static void Main()
        {
            // Remove older version
            if (File.Exists("..\\megabyte112RP.zip")) {File.Delete("..\\megabyte112RP.zip");}

            // find the parent directory, check if it's the resourcepacks folder
            string dir = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            if (dir.ToString().Substring(dir.Length-13, 13) != "resourcepacks")
            {
                Console.WriteLine("The updater isn't in the right place.\nMake sure it is only one folder down from \\resourcepacks.\nPress enter to exit.");
                Console.ReadLine();
                Environment.Exit(0);
            }

            // if all is well, begin the download
            Console.WriteLine("Downloading...");
            try
            {
                WebClient client = new WebClient();
                client.DownloadFile("https://github.com/megabyte112/megabyte112-mc-resourcepack/releases/latest/download/megabyte112RP.zip", dir + "\\megabyte112RP.zip");
            }
            catch
            {
                Console.WriteLine("There was a problem somewhere.\nCheck that the resource pack is not in use in Minecraft.\nFailing that, come talk to me.");
                Console.WriteLine("\n\nFailed - Enter to exit");
                Console.ReadLine();
                Environment.Exit(0);
            }
            Console.WriteLine("Success!\nPress enter to close.");
            Console.ReadLine();
        }
    }
}
