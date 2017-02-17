using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CGoogleDrive.SettingForms;

namespace CGoogleDrive
{
    class Program
    {
        //public static ApplicationSettings appSettings { get; set; }

        private static void HideConsoleWindow()
        {
            var handle = GetConsoleWindow();

            ShowWindow(handle, 0);
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static void Main(string[] args)
        {
            if (args.Any() && args[0] == "-setup")
            {
                HideConsoleWindow();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ApplicationSetup());
            }
            else
            {
                try
                {
                    Processor p = new Processor();
                    p.Start();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    return;
                }
                Console.ReadLine();
            }
        }
    }
}
