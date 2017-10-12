using System;
using System.Windows.Forms;

namespace MSMQDemo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            main form = new main();

            form.SetBounds((Screen.GetBounds(form).Width / 2) - (form.Width / 2), (Screen.GetBounds(form).Height / 2) - (form.Height / 2),
               form.Width,
               form.Height,
               BoundsSpecified.Location);

            Application.Run(form);

        }
    }
}
