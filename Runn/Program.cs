using CRM_UI;
using System;
using System.Windows;

namespace Runn
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var app = new Application();
            
            var userControl = new UserControl();

            app.Run(userControl);

            //if (userControl.SetFlag())
            //{
            //    var mainWindow = new MainWindow();
                
            //    //app.Run(mainWindow);
            //}
        }
    }
}
