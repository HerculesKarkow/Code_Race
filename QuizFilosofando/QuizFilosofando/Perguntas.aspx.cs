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
    public partial class Perguntas : System.Web.UI.Page
    {
        public class Pergunta
        {
            public int id;
            public string descricao;
            public bool respondida;
        }
        public class Resposta
        {
            public int id_resposta;
            public string descricao;
            public bool correta;
        }



        public List<Pergunta> listaPerguntas;
        public List<Resposta> listaRespostas;
        public int acertos;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                acertos = 0;

                //passagem de valor por query string ou session
                CarregarPerguntas();

                //Selecionar proxima pergunta
                SelecionarProximaPergunta();
            }
        }
        private void SelecionarProximaPergunta()
        {
            for (int indice = 0; indice < listaPerguntas.Count; indice++)
            {
                if (listaPerguntas[indice].respondida == false)
                {
                    //Mostra a pergunta na tela
                    lblIdPergunta.Value = listaPerguntas[indice].id.ToString();
                    lblPergunta.Text = listaPerguntas[indice].descricao.ToString();

                    //Carrega as respostas
                    SelecionarResposta(listaPerguntas[indice].id);

                    //Exibe as respostas
                    CarregarRespostas();
                    break;
                }
            }

            Session["listaRespostas"] = listaRespostas;
            Session["listaPerguntas"] = listaPerguntas;
            Session["qtdAcertos"] = acertos;
        }
        private void CarregarRespostas()
        {
            for (int indice = 0; indice < listaRespostas.Count; indice++)
            {
                rbRespostas.Items[indice].Text = listaRespostas[indice].descricao.ToString();
                //rbRespostas.Items[indice].Value = listaRespostas[indice].id_resposta.ToString();
                rbRespostas.Items[indice].Value = listaRespostas[indice].correta.ToString();
                rbRespostas.Items[indice].Selected = false;
            }
        }

        private void SelecionarResposta(int id_pergunta)
        {
            listaRespostas = new List<Resposta>();

            //Busca os parametros de conexao da config
            string conexao = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

            //Abre conexão com o banco de dados
            SqlServerConnector banco = new SqlServerConnector(conexao);

            //Verifica se esta conectado com o banco de dados
            if (banco.Conectado())
            {
                banco.ClearParameters();
                banco.Query = "SELECT * FROM Respostas WHERE id_perguntas = @Id_pergunta";
                banco.AddParameters("@Id_pergunta", DbType.Int32, id_pergunta);

                DataTable data = banco.ExecuteReader();

                foreach (DataRow item in data.Rows)
                {
                    //Busca os valores da seleção
                    Resposta resposta = new Resposta();

                    //Popula variavel pergunta
                    resposta.id_resposta = (int)item["id_respostas"];
                    resposta.descricao = item["descricao"].ToString();
                    resposta.correta = (bool)item["correta"];

                    //Adiciona a pergunta na lista
                    listaRespostas.Add(resposta);
                }
                banco.Dispose();
            }

        }

        private void CarregarPerguntas()
        {
            listaPerguntas = new List<Pergunta>();

            //Busca os parametros de conexao da config
            string conexao = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

            //Abre conexão com o banco de dados
            SqlServerConnector banco = new SqlServerConnector(conexao);

            //Verifica se esta conectado com o banco de dados
            if (banco.Conectado())
            {
                banco.ClearParameters();
                banco.Query = "SELECT * FROM Perguntas WHERE Nivel = @Nivel order by id_perguntas";
                banco.AddParameters("@Nivel", DbType.String, "1");

                DataTable data = banco.ExecuteReader();

                foreach (DataRow item in data.Rows)
                {
                    //Busca os valores da seleção
                    Pergunta pergunta = new Pergunta();

                    //Popula variavel pergunta
                    pergunta.id = (int)item["id_perguntas"];
                    pergunta.descricao = item["descricao"].ToString();

                    //Adiciona a pergunta na lista
                    listaPerguntas.Add(pergunta);
                }
                banco.Dispose();
            }
        }

        protected void btnEnviarResposta_Click(object sender, EventArgs e)
        {
            listaRespostas = (List<Resposta>)Session["listaRespostas"];
            listaPerguntas = (List<Pergunta>)Session["listaPerguntas"];
            acertos = (int)Session["qtdAcertos"];

            int id_pergunta = 0;
            int.TryParse(lblIdPergunta.Value.ToString(), out id_pergunta);

            SetarPerguntaRespondida(id_pergunta);
            VerificarResposta();
            SelecionarProximaPergunta();

        }
        private void VerificarResposta()
        {
            bool correta;
            bool.TryParse(rbRespostas.SelectedValue, out correta);

            if (correta)
            {
                acertos = acertos + 1;
                //acertos++;
            }


        }


        private void SetarPerguntaRespondida(int id_pergunta)
        {
            for (int indice = 0; indice < listaPerguntas.Count; indice++)
            {
                if (listaPerguntas[indice].id == id_pergunta)
                {
                    listaPerguntas[indice].respondida = true;
                    break;
                }
            }
        }
    }
}