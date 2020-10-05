using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormularioKwikEMart
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormLogin login = new FormLogin();
            FormPrincipal formPrincipal = new FormPrincipal();

            do
            {
                formPrincipal.DialogResult = DialogResult.Retry;
                if (login.ShowDialog() == DialogResult.OK)
                {
                    formPrincipal.ShowDialog();
                }
                else if(login.DialogResult.Equals(DialogResult.Abort))
                {
                    formPrincipal.DialogResult = DialogResult.Abort;
                }
            } while (formPrincipal.DialogResult == DialogResult.Retry);
        }
    }
}
