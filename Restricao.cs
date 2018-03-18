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
    public partial class Restricao : Form
    {
        string query = "";
        string con;
        
        DataSet dados = new DataSet();
        Conexao conec = new Conexao();


        public Restricao()
        {
            InitializeComponent();
        }

        private static string Verificasemana(int coluna)
        {
            string semana = "";
            switch (coluna)
            {
                case 1:
                    semana = "segunda";
                    break;

                case 2:
                    semana = "terca";
                    break;

                case 3:
                    semana = "quarta";
                    break;

                case 4:
                    semana = "quinta";
                    break;

                case 5:
                    semana = "sexta";
                    break;
            }

            return semana;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Restricao_Load(object sender, EventArgs e)
        {
            con = conec.connectionString;
            query = "SELECT(H.HORAINICIO || ' - ' || H.HORAFIM) AS HORARIO, R.SEGUNDA, R.TERCA, R.QUARTA, R.QUINTA, R.SEXTA FROM RESTRICAO R LEFT JOIN HORARIO H ON R.CODHORARIO = H.CODHORARIO WHERE R.CODIGOPROF = 1;";
            NpgsqlDataAdapter add = new NpgsqlDataAdapter(query, con);
            add.Fill(dados);
            dataGridView1.DataSource = dados.Tables[0];

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            con = conec.connectionString;
            int linha = dataGridView1.CurrentRow.Index;
            int coluna = dataGridView1.CurrentCell.ColumnIndex;
            String semana;
            String hora = dataGridView1.Rows[linha].Cells[0].Value.ToString();
            String horaini = hora.Substring(0, 9);
            String horafim = hora.Substring(10, 9);
            String alteracao = dataGridView1.Rows[linha].Cells[coluna].Value.ToString();
            semana =  Verificasemana(coluna);
           
            query = "UPDATE RESTRICAO SET "+ semana +" = '"+ alteracao +"' WHERE codhorario =  (select CODHORARIO FROM HORARIO WHERE HORAINICIO = '" + horaini + "' and HORAFIM = '" + horafim + "')";
            //usar  NpgsqlCommand
            NpgsqlDataAdapter add = new NpgsqlDataAdapter(query, con);
            add.Fill(dados);
            dataGridView1.DataSource = dados.Tables[0];
        }
    }
}
