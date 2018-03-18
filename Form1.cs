using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escola
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Restricao restricao = new Restricao();
            restricao.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CadProfessor cadprofessor = new Escola.CadProfessor();
            cadprofessor.Show();
        }
    }
}
