using System;
using System.IO;
using System.Net;
namespace updater
{
    class Program
    {
        static void Main()
        {
            // download link
            string dl = "https://github.com/megabyte112/megabyte112-mc-resourcepack/releases/latest/download/megabyte112RP.zip";

            // find the current directory, check if it's the resourcepacks folder
            string dir = Directory.GetCurrentDirectory().ToString();
            if (dir.Length <= 13)   // this saves the code from crashing at the next IF statement
            {
                Console.WriteLine("Failed: Wrong folder");
                Console.WriteLine("Close the program, move to Minecraft's resourcepacks folder, and try again.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else if (dir.Substring(dir.Length-13, 13) != "resourcepacks")
            {
                Console.WriteLine("Failed: Wrong folder");
                Console.WriteLine("Close the program, move to Minecraft's resourcepacks folder, and try again.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            // Remove older version
            try 
            {
                if (File.Exists("megabyte112RP.zip"))
                {
                    Console.WriteLine("Removing older version...");
                    File.Delete("megabyte112RP.zip");
                }
            }
            catch
            {
                Console.WriteLine("\nFailed: Resource pack is likely in use");
                Console.WriteLine("Go to Minecraft, deselect the resource pack, click Done, and try again.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            // if all is well, begin the download and save to this folder
            Console.WriteLine("Downloading latest release...");
            try
            {
                WebClient client = new WebClient();
                client.DownloadFile(dl, dir + "\\megabyte112RP.zip");
            }
            catch
            {
                Console.WriteLine("Failed: Download error");
                Console.WriteLine("Check your internet and try again");
                Console.ReadLine();
                Environment.Exit(0);
            }
            Console.WriteLine("\nSuccess!\nYou can now close the updater.");
            Console.ReadLine();
        }
    }
}
