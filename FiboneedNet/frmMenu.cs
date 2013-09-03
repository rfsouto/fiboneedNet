using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace FiboneedNet
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void bntCalcular_Click(object sender, EventArgs e)
        {
            long n = long.Parse(this.tbNumber.Text);//Se lee el numero a calcular 
            StringBuilder sresultado = new StringBuilder();
            //Nota: Para calcular un espacio de tiempo, mejor que TimeSpan es Stopwatch
            Stopwatch timer = new Stopwatch();
            //Nota: Las cadenas de texto se inician con string.empty y no con comillas. 
            lblResultado.Text = string.Empty;
            

            DateTime tiempo1 = DateTime.Now;//Inicio medida tiempo
            //Nota: Los string en Net son inmutables, por lo que cada vez que se usa uno métodos de System.String
            //se genera un nuevo objeto en memoria -> para generar cadenas usar StringBuilder. 
            timer.Start();
            sresultado.AppendFormat("Fibonacci Iterativo para n = {0}: {1}", n, Fibonacci(n));
            timer.Stop();
            //Nota: Para los saltos de línea usar Environment.NewLine porque sirve para todos los sistemas
            sresultado.AppendFormat("{0}Tiempo del Fibonacci iterativo: {1}", Environment.NewLine, timer.Elapsed.ToString());
            
            timer.Start();
            sresultado.AppendFormat("{0}Fibonacci Recursivo para n = {1}: {2}", Environment.NewLine, n, FiboRecur(n));
            timer.Stop();
            sresultado.AppendFormat("{0}Tiempo del Fibonacci recursivo: {1}", Environment.NewLine, timer.Elapsed.ToString());
            
            lblResultado.Text = sresultado.ToString();
            lblResultado.Refresh();
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

        public long FiboRecur(long n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                return FiboRecur(n - 1) + FiboRecur(n - 2);
            }
        }
    }
}
