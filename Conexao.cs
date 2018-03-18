using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace Escola
{
     public class Conexao
    {
        static string server = "localhost";
        static string database = "escola";
        static string usuario = "postgres";
        static string senha = "P@ssw0rd";

        public string connectionString = "Server=" + server + ";Port=5432;UserID=" + usuario + ";password=" + senha + ";Database=" + database + ";";

        public Conexao()
        {
            try
            {
                NpgsqlConnection con = new NpgsqlConnection(connectionString);
                con.Open();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message);
            }
            
        }

    }
}
