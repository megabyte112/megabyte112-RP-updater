using System;
using System.IO;
using System.Net;
namespace updater
{
    class Program
    {
        static void Main()
        {
            // find the parent directory, check if it's the resourcepacks folder
            string dir = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            if (dir.ToString().Substring(dir.Length-13, 13) != "resourcepacks")
            {
                Console.WriteLine("The updater isn't in the right place.\nMake sure it is in \"\\resourcepacks\\updater\".");
                Console.ReadLine();
                Environment.Exit(0);
            }
            // Remove older version
            try 
            {
                if (File.Exists("..\\megabyte112RP.zip"))
                {
                    Console.WriteLine("Removing older version...");
                    File.Delete("..\\megabyte112RP.zip");
                }
            }
            catch
            {
                Console.WriteLine("\n\nThere was a problem - Check that the resource pack is NOT selected in Minecraft.\nFailing that, come talk to me.");
                Console.WriteLine("\nFailed - Close and try again");
                Console.ReadLine();
                Environment.Exit(0);
            }
            // if all is well, begin the download
            Console.WriteLine("Downloading lastest release...");
            WebClient client = new WebClient();
            client.DownloadFile("https://github.com/megabyte112/megabyte112-mc-resourcepack/releases/latest/download/megabyte112RP.zip", dir + "\\megabyte112RP.zip");
            Console.WriteLine("\n\nSuccess!\nYou can now close the updater.");
            Console.ReadLine();
        }
    }
}
