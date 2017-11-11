using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizFilosofando
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {


        }

        protected void btnFacil_Click(object sender, EventArgs e)

        {

            //Busca os parametros de conexao da config
            string conexao = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

            //Abre conexão com o banco de dados
            SqlServerConnector banco = new SqlServerConnector(conexao);

            //Verifica se esta conectado com o banco de dados
            if (banco.Conectado())
            {
                banco.ClearParameters();
                banco.Query = "SELECT descricao FROM Perguntas WHERE Nivel = @Nivel order by id_perguntas";
                banco.AddParameters("@Nivel", DbType.String, "1");

                DataTable data = banco.ExecuteReader();

                foreach (DataRow item in data.Rows)
                {
                    //Busca os valores da seleção

                    lblRandom.Text = item["descricao"].ToString();

                }
                banco.Dispose();
            }
            Response.Redirect("Perguntas");
        }

        protected void btnMedio_Click(object sender, EventArgs e)
        {
            //Busca os parametros de conexao da config
            string conexao = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

            //Abre conexão com o banco de dados
            SqlServerConnector banco = new SqlServerConnector(conexao);

            //Verifica se esta conectado com o banco de dados
            if (banco.Conectado())
            {
                banco.ClearParameters();
                banco.Query = "SELECT descricao FROM Perguntas WHERE Nivel = @Nivel order by id_perguntas";
                banco.AddParameters("@Nivel", DbType.String, "2");

                DataTable data = banco.ExecuteReader();

                foreach (DataRow item in data.Rows)
                {
                    //Busca os valores da seleção

                    lblRandom.Text = item["descricao"].ToString();

                }
                banco.Dispose();
            }
            Response.Redirect("Perguntas");
        }


    }
}