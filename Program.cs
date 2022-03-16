using System;
using System.Windows.Forms;

namespace updater
{
    public class Program
    {
        public static Form1 form = new Form1();
        [STAThread]
        static void Main(string[] args)
        {
            form.FormLayout();;
            Application.Run(form);
        }
    }
}