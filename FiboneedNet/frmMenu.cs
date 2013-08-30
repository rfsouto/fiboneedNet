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

            //Vaciamos la etiqueta de resultado.
            lblResultado.Text = "";
            DateTime tiempo1 = DateTime.Now;//Inicio medida tiempo
            string txtres = "Fibonacci Iterativo para n = " + n + ": " + Fibonacci(n);
            DateTime tiempo2 = DateTime.Now;//Fin medida tiempo
            txtres += "\nTiempo del Fibonacci recursivo: " + new TimeSpan(tiempo2.Ticks - tiempo1.Ticks).ToString() + "\n";
            tiempo1 = DateTime.Now;//Inicio medida tiempo
            txtres += "\nFibonacci Recursivo para n = " + n + ": " + FiboRecur(n);
            tiempo2 = DateTime.Now;//Fin medida tiempo
            txtres += "\nTiempo del Fibonacci recursivo: " + new TimeSpan(tiempo2.Ticks - tiempo1.Ticks).ToString() + "\n";
            lblResultado.Text = txtres;
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
