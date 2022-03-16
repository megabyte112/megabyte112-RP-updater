using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace updater
{
    public class Form1 : Form
    {
        static string dl = "https://github.com/megabyte112/megabyte112-mc-resourcepack/releases/latest/download/megabyte112RP.zip";
        static string dir = Directory.GetCurrentDirectory().ToString();
        static bool isupdate = false;
        public void FormLayout()
        {
            this.Name = "Form1";
            this.Text = "Updater";
            this.Size = new Size(300, 120);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowIcon = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
        static private Button button1;
        public Form1()
        {
            button1 = new Button();
            button1.Size = new Size(242,40);
            button1.Location = new Point(20,20);
            Application.EnableVisualStyles();
            if (dir.Substring(dir.Length-13, 13) != "resourcepacks")
            {
                MessageBox.Show("This doesn't look like the resourcepacks folder...\nMove to Minecraft's resourcepacks folder and try again.",
                "Wrong Folder!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
            else if (File.Exists("megabyte112RP.zip"))
            {
                isupdate = true;
                button1.Text = "Update";
            }
            else button1.Text = "Install";
            Controls.Add(button1);
            button1.Click += new EventHandler(button1_click);
        }
        private void button1_click(object sender, EventArgs e)
        {
            button1.Enabled=false;
            DoUpdate();
        }
        private static async Task DoUpdate()
        {
            await Task.Run(() =>
            {
                if (isupdate)
                {
                    button1.Text = "Removing older version...";
                    try {File.Delete("megabyte112RP.zip");}
                    catch
                    {
                        button1.Text = "Try again";
                        MessageBox.Show("Error: Cannot remove older version.\nThis probably means the resource pack is in use.\nGo to Minecraft, deselect the resource pack, click Done, and try again.",
                        "Resource pack is in use!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        button1.Enabled = true;
                        return;
                    }
                }
                button1.Text = "Downloading...";
                try
                {
                    WebClient client = new WebClient();
                    client.DownloadFile(dl, dir + "\\megabyte112RP.zip");
                }
                catch
                {
                    button1.Text = "Try again";
                    MessageBox.Show("Error: Cannot download file.\nCheck your internet and try again.",
                    "Download Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    button1.Enabled = true;
                    return;
                }
                button1.Text = "Done!";
                MessageBox.Show("Thank you for downloading <3",
                "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            });
        }
    }
}