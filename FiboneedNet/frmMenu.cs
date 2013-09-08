using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace FiboneedNet
{
    public partial class frmMenu : Form
    {
        private int highestPercentageReached = 0;

        public frmMenu()
        {
            InitializeComponent();
        }

        private void bntCalcular_Click(object sender, EventArgs e)
        {
            int number = 0;
            if (int.TryParse(this.tbNumber.Text, out number))
            {
                tbNumber.Enabled = false;
                lblResultado.Text = string.Empty;
                highestPercentageReached = 0;
                progressBar.Value = 0;
                bw.RunWorkerAsync(number);
                tbNumber.Enabled = true;
            }
            else
            {
                MessageBox.Show("No ha sido introducido un número válido.");
            }
        }

        public long Fibonacci(long n)
        {
            //a representa el valor n-1
            //b representa el valor n
            long a = 1, b = 1;
            for (long i = 2; i <= n; i++)
            {
                long c = a + b;
                a = b;
                b = c;
            }
            return a;
        }

        public long FiboRecur(long n, BackgroundWorker worker, DoWorkEventArgs e)
        {
            long result = 0;
            if (n < 2)
            {
                result = 1;
            }
            else
            {
                result = FiboRecur(n - 1, worker, e) +
                         FiboRecur(n - 2, worker, e);
            }

            //Tuve que adaptar el cálculo recursivo inicial al 
            //ejemplo http://msdn.microsoft.com/es-es/library/system.componentmodel.backgroundworker.aspx 
            //porque lo tenía implementado en un formato parecido a:
            /*
             if (n < 2)
            {
                result = 1;
            }
            else
            {
             * int percentComplete =
                (int)((float)n / (float)long.Parse(e.Argument.ToString()) * 100);
                if (percentComplete > highestPercentageReached)
                {
                    highestPercentageReached = percentComplete;
                    worker.ReportProgress(percentComplete);
                }
                result = FiboRecur(n - 1, worker, e) +
                         FiboRecur(n - 2, worker, e);
            }
             */
            //y esto provocaba errores en la progressbar mostrando datos incorrectos (actualizaba antes de ningún cálculo)
            //entonces finalizaba la progressbar mucho antes de los return. 
            int percentComplete =
                (int)((float)n / (float)long.Parse(e.Argument.ToString()) * 100);
            if (percentComplete > highestPercentageReached)
            {
                highestPercentageReached = percentComplete;
                worker.ReportProgress(percentComplete);
            }

            return result;
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //Recuperamos el worker que lanza el evento:
            BackgroundWorker worker = sender as BackgroundWorker;
            long numberArgument = long.Parse(e.Argument.ToString());
            StringBuilder sresultado = new StringBuilder();
            //Nota: Para calcular un espacio de tiempo, mejor que TimeSpan es Stopwatch
            Stopwatch timer = new Stopwatch();
            //Nota: Las cadenas de texto se inician con string.empty y no con comillas. 
            DateTime tiempo1 = DateTime.Now;//Inicio medida tiempo
            //Nota: Los string en Net son inmutables, por lo que cada vez que se usa uno métodos de System.String
            //se genera un nuevo objeto en memoria -> para generar cadenas usar StringBuilder. 
            timer.Start();
            sresultado.AppendFormat("Fibonacci Iterativo para n = {0}: {1}", numberArgument, Fibonacci(numberArgument));
            timer.Stop();
            //Nota: Para los saltos de línea usar Environment.NewLine porque sirve para todos los sistemas
            sresultado.AppendFormat("{0}Tiempo del Fibonacci iterativo: {1}", Environment.NewLine, timer.Elapsed.ToString());

            timer.Start();
            sresultado.AppendFormat("{0}Fibonacci Recursivo para n = {1}: {2}", Environment.NewLine, numberArgument, FiboRecur(numberArgument, worker, e));
            timer.Stop();
            sresultado.AppendFormat("{0}Tiempo del Fibonacci recursivo: {1}", Environment.NewLine, timer.Elapsed.ToString());

            e.Result = sresultado.ToString();
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.lblResultado.Text = e.Result.ToString();
            lblResultado.Refresh();
        }
    }
}
