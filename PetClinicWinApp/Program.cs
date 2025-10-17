using PetClinicWinApp.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetClinicWinApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //LoginForm login = new LoginForm();
            //if (login.ShowDialog() == DialogResult.OK)
            //{
            //    Application.Run(new MainForm(login.AuthenticatedUser));
            //}
            //else
            //{
            //    Application.Exit();
            //}
            while (true)
            {
                LoginForm login = new LoginForm();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    // Run main application
                    Application.Run(new MainForm(login.AuthenticatedUser));
                }
                else
                {
                    // User cancelled login → exit app
                    break;
                }
            }

        }
    }
}
