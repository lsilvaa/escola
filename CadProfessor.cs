using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;

namespace Escola
{
    public partial class CadProfessor : Form
    {

        string query = "";
        string con;

        DataSet dados = new DataSet();
       // Conexao conec = new Conexao();

        NpgsqlConnection teste2 = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=P@ssw0rd;Database=escola;");

        public CadProfessor()
        {
            InitializeComponent();
        }

        private void CadProfessor_Load(object sender, EventArgs e)
        {
            teste2.Open();
            Int32 teste;
            //con = conec.connectionString;
            query = "SELECT MAX(CODIGO) FROM PROFESSOR;";
            NpgsqlCommand codigo = new NpgsqlCommand(query, teste2);
            Int64 count = (Int64)codigo.ExecuteScalar();
            label3.Text = Convert.ToString(count);
            //NpgsqlDataAdapter add = new NpgsqlDataAdapter(query, con);
            //teste = Convert.ToInt32(add.ExecuteScalar());
           // add.Fill(dados);
            //label3.Text = 
        }
    }
}
