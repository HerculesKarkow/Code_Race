using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizFilosofando
{
    /// <summary>
    /// Classe responsável por conectar com o banco de dados
    /// </summary>
    public class SqlServerConnector : IDisposable
    {
        #region Atributos (privados)

        /// <summary>
        /// Conexão com o banco de dados
        /// </summary>
        private SqlConnection conexao;

        /// <summary>
        /// Parametros utilizados
        /// </summary>
        private List<SqlParameter> parametros;

        /// <summary>
        /// Codigo a ser executado no banco de dados
        /// </summary>
        private string query;

        /// <summary>
        /// Tipo da execução (query ou procedure)
        /// </summary>
        private CommandType commandType;

        #endregion Atributos (privados)

        #region Propriedades (publicos)

        public string Query { set { this.query = value; } }

        public CommandType CommandType { set { commandType = value; } }

        #endregion Propriedades (publicos)

        #region Métodos

        /// <summary>
        /// Método construtor da classe
        /// </summary>
        public SqlServerConnector(string conexao)
        {
            #region Implementação

            try
            {
                this.Inicializar();
                this.Conectar(conexao);
            }
            catch
            {

            }
            finally
            {

            }

            #endregion Implementação
        }

        /// <summary>
        /// Metodo responsavel por iniciar as variaveis
        /// </summary>
        public void Inicializar()
        {
            #region Implementação

            if (parametros == null)
            {
                //parametros = new MySqlParameterCollection();
                parametros = new List<SqlParameter>();
            }

            parametros.Clear();

            #endregion Implementação
        }

        /// <summary>
        /// Metodo responsavel por retornar se está conectado no banco
        /// </summary>
        /// <returns></returns>
        public bool Conectado()
        {
            #region Implementação

            try
            {
                return this.conexao.State == ConnectionState.Open ? true : false;
            }
            catch (Exception ex)
            {

                return false;
            }

            #endregion Implementação
        }

        /// <summary>
        /// Metodo responsavel por executar as query retornando um datatable
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable ExecuteReader(string query)
        {
            #region Declaração

            DataTable table = null;
            SqlCommand comando = null;
            SqlDataReader reader = null;

            #endregion Declaração

            #region Implementação

            try
            {
                //Instancia a classe
                comando = new SqlCommand(query, this.conexao);

                //Tipo da instrução que será executada
                if (commandType != System.Data.CommandType.StoredProcedure &&
                    commandType != System.Data.CommandType.Text &&
                    commandType != System.Data.CommandType.TableDirect)
                {
                    commandType = System.Data.CommandType.Text;
                }

                //Adiciona os parametros
                if (parametros != null && parametros.Count > 0)
                {
                    comando.Parameters.AddRange(parametros.ToArray());
                }

                //Execute a consulta no banco de dados e retorna os valores
                reader = comando.ExecuteReader();

                //Converte de DataReader para DataTable
                table = new DataTable();
                table.Load(reader);

                //Retorna o DataTable
                return table;
            }
            catch (Exception ex)
            {
                string sql = string.Empty;

                if (comando != null)
                {
                    sql = ConvertSqlCommanToSql.SqlCommandToSql(comando);
                }

                throw new Exception(string.Format("Erro: {1} \n Query: {0} ", sql, ex.Message), ex.InnerException);

                //throw ex;
            }
            finally
            {
                if (table != null)
                {
                    table.Dispose();
                    table = null;
                }

                if (reader != null)
                {
                    reader.Dispose();
                    reader = null;
                }

                if (comando != null)
                {
                    comando.Dispose();
                    comando = null;
                }
            }

            #endregion Implementação
        }

        /// <summary>
        /// Metodo responsavel por executar as query retornando um datatable
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable ExecuteReader()
        {
            #region Declaração

            DataTable table = null;
            SqlCommand comando = null;
            SqlDataReader reader = null;

            #endregion Declaração

            #region Implementação

            try
            {
                //Instancia a classe
                comando = new SqlCommand(query, this.conexao);

                //Tipo da instrução que será executada
                if (commandType != System.Data.CommandType.StoredProcedure &&
                    commandType != System.Data.CommandType.Text &&
                    commandType != System.Data.CommandType.TableDirect)
                {
                    commandType = System.Data.CommandType.Text;
                }

                comando.CommandType = commandType;

                //Adiciona os parametros
                if (parametros != null && parametros.Count > 0)
                {
                    comando.Parameters.AddRange(parametros.ToArray());
                }

                //Execute a consulta no banco de dados e retorna os valores
                reader = comando.ExecuteReader();

                //Converte de DataReader para DataTable
                table = new DataTable();
                table.Load(reader);

                //Retorna o DataTable
                return table;
            }
            catch (Exception ex)
            {
                string sql = string.Empty;

                if (comando != null)
                {
                    sql = ConvertSqlCommanToSql.SqlCommandToSql(comando);
                }

                throw new Exception(string.Format("Erro: {1} \n Query: {0} ", sql, ex.Message), ex.InnerException);

                //throw ex;
            }
            finally
            {
                if (table != null)
                {
                    table.Dispose();
                    table = null;
                }

                if (reader != null)
                {
                    reader.Dispose();
                    reader = null;
                }

                if (comando != null)
                {
                    comando.Dispose();
                    comando = null;
                }
            }

            #endregion Implementação
        }

        /// <summary>
        /// Metodo responsavel por executar as querys sem consulta
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public bool ExecuteNonQuery(string query)
        {
            #region Declaração

            SqlCommand comando = null;
            int retorno;

            #endregion Declaração

            #region Implementação

            try
            {
                //Instancia a classe
                comando = new SqlCommand(query, this.conexao);

                //Tipo da instrução que será executada
                if (commandType != System.Data.CommandType.StoredProcedure &&
                    commandType != System.Data.CommandType.Text &&
                    commandType != System.Data.CommandType.TableDirect)
                {
                    commandType = System.Data.CommandType.Text;
                }

                //Adiciona os parametros
                if (parametros != null && parametros.Count > 0)
                {
                    comando.Parameters.AddRange(parametros.ToArray());
                }

                //Executa o comando de delete no banco de dados
                retorno = comando.ExecuteNonQuery();

                //Retorna o valor
                return retorno == 0 ? false : true;
            }
            catch (Exception ex)
            {
                string sql = string.Empty;

                if (comando != null)
                {
                    sql = ConvertSqlCommanToSql.SqlCommandToSql(comando);
                }

                throw new Exception(string.Format("Erro: {1} \n Query: {0} ", sql, ex.Message), ex.InnerException);

                //throw ex;
            }
            finally
            {
                if (comando != null)
                {
                    comando.Dispose();
                    comando = null;
                }
            }

            #endregion Implementação
        }

        /// <summary>
        /// Metodo responsavel por executar as querys sem consulta
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public bool ExecuteNonQuery()
        {
            #region Declaração

            SqlCommand comando = null;
            int retorno;

            #endregion Declaração

            #region Implementação

            try
            {
                //Instancia a classe
                comando = new SqlCommand(query, this.conexao);

                //Tipo da instrução que será executada
                if (commandType != System.Data.CommandType.StoredProcedure &&
                    commandType != System.Data.CommandType.Text &&
                    commandType != System.Data.CommandType.TableDirect)
                {
                    commandType = System.Data.CommandType.Text;
                }

                //Adiciona os parametros
                if (parametros != null && parametros.Count > 0)
                {
                    comando.Parameters.AddRange(parametros.ToArray());
                }

                //Executa o comando de delete no banco de dados
                retorno = comando.ExecuteNonQuery();

                //Retorna o valor
                return retorno == 0 ? false : true;
            }
            catch (Exception ex)
            {
                string sql = string.Empty;

                if (comando != null)
                {
                    sql = ConvertSqlCommanToSql.SqlCommandToSql(comando);
                }

                throw new Exception(string.Format("Erro: {1} \n Query: {0} ", sql, ex.Message), ex.InnerException);

                //throw ex;
            }
            finally
            {
                if (comando != null)
                {
                    comando.Dispose();
                    comando = null;
                }
            }

            #endregion Implementação
        }
        /// <summary>
        /// Metodo responsavel por executar as querys retornando o id do objeto (utilizado nos comando de INSERT)
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Int32 ExecuteScalar()
        {
            #region Declaração

            SqlCommand comando = null;

            #endregion Declaração

            #region Implementação

            try
            {
                //Instancia a classe
                comando = new SqlCommand(query, this.conexao);

                //Tipo da instrução que será executada
                if (commandType != System.Data.CommandType.StoredProcedure &&
                    commandType != System.Data.CommandType.Text &&
                    commandType != System.Data.CommandType.TableDirect)
                {
                    commandType = System.Data.CommandType.Text;
                }

                //Adiciona os parametros
                if (parametros != null && parametros.Count > 0)
                {
                    comando.Parameters.AddRange(parametros.ToArray());
                }

                //Executa o comando no banco
                return (Int32)comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                string sql = string.Empty;

                if (comando != null)
                {
                    sql = ConvertSqlCommanToSql.SqlCommandToSql(comando);
                }

                throw new Exception(string.Format("Erro: {1} \n Query: {0} ", sql, ex.Message), ex.InnerException);

                //throw ex;
            }
            finally
            {
                if (comando != null)
                {
                    comando.Dispose();
                    comando = null;
                }
            }

            #endregion Implementação
        }

        /// <summary>
        /// Metodo responsavel por setar a query de execução
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public bool SetQuery(string query)
        {
            #region Implementação

            try
            {
                this.query = query;
                return true;
            }
            catch
            {
                return false;
            }

            #endregion Implementação
        }

        /// <summary>
        /// Metodo responsavel por adicionar os parametros
        /// </summary>
        /// <param name="nomeCampo"></param>
        /// <param name="tipoCampo"></param>
        /// <param name="valorCampo"></param>
        /// <returns></returns>
        public bool AddParameters(string nomeCampo, DbType tipoCampo, object valorCampo)
        {
            #region Implementação

            try
            {
                //Verifica se o objeto esta instanciado
                if (parametros == null)
                {
                    parametros = new List<SqlParameter>();
                }

                parametros.Add(new SqlParameter() { ParameterName = nomeCampo, DbType = tipoCampo, Value = valorCampo });

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {

            }

            #endregion Implementação
        }

        /// <summary>
        /// Metodo responsavel por limpar os parametros
        /// </summary>
        /// <returns></returns>
        public bool ClearParameters()
        {
            #region Implementação

            try
            {
                if (parametros != null)
                {
                    parametros.Clear();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }

            #endregion Implementação
        }

        /// <summary>
        /// Método responsavel por finalizar a classe
        /// </summary>
        public void Dispose()
        {
            #region Implementação

            FecharConexao();

            #endregion Implementação
        }

        /// <summary>
        /// Método responsável por abrir a conexao com o banco de dados
        /// </summary>
        /// <param name="conexaoNome"></param>
        /// <returns></returns>
        private bool Conectar(string stringConexao)
        {
            #region Implementação

            try
            {
                //Abre a conexão com o banco de dados
                this.conexao = new SqlConnection(stringConexao);
                this.conexao.Open();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            #endregion Implementação
        }

        /// <summary>
        /// Metodo responsavel por realizar o fechamento da conexao com o banco de dados
        /// </summary>
        /// <returns></returns>
        private bool FecharConexao()
        {
            #region Implementação

            try
            {
                this.conexao.Close();
                this.conexao.Dispose();
                this.conexao = null;
                return true;
            }
            catch
            {
                return false;
            }

            #endregion Implementação
        }

        #endregion Métodos
    }

    /// <summary>
    /// Classe responsável por traduzir os comando sql's executados
    /// </summary>
    public static class ConvertSqlCommanToSql
    {
        #region Métodos

        /// <summary>
        /// Método responsável por retornar os valores informados como parametro
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public static String ParameterValueForSQL(this SqlParameter sp)
        {
            #region Implementação

            String retval = "";

            switch (sp.DbType)
            {
                case DbType.String:
                case DbType.Time:
                case DbType.Xml:
                case DbType.Date:
                case DbType.DateTime:
                case DbType.DateTime2:
                case DbType.DateTimeOffset:
                    retval = "'" + sp.Value.ToString().Replace("'", "''") + "'";
                    break;

                case DbType.Boolean:
                    retval = sp.Value.GetHashCode().ToString();
                    break;

                default:
                    retval = sp.Value.ToString().Replace("'", "''");
                    break;
            }

            return retval;

            #endregion Implementação
        }

        /// <summary>
        /// Método responsável por converter o comando sql
        /// </summary>
        /// <param name="sc"></param>
        /// <returns></returns>
        public static String SqlCommandToSql(this SqlCommand sc)
        {
            #region Declaração

            StringBuilder sql = new StringBuilder();
            Boolean FirstParam = true;

            #endregion  Declaração

            #region Implementação

            sql.AppendLine("use " + sc.Connection.Database + ";");
            switch (sc.CommandType)
            {
                case System.Data.CommandType.StoredProcedure:
                    foreach (SqlParameter sp in sc.Parameters)
                    {
                        if ((sp.Direction == ParameterDirection.InputOutput) || (sp.Direction == ParameterDirection.Output))
                        {
                            sql.Append("declare " + sp.ParameterName + "\t" + sp.DbType.ToString() + "\t= ");

                            sql.AppendLine(((sp.Direction == ParameterDirection.Output) ? "null" : sp.ParameterValueForSQL()) + ";");

                        }
                    }

                    sql.AppendLine("CALL `" + sc.CommandText + "`");

                    FirstParam = true;

                    foreach (SqlParameter sp in sc.Parameters)
                    {
                        if (sp.Direction != ParameterDirection.ReturnValue)
                        {
                            sql.Append((FirstParam) ? "\t (" : "\t, ");

                            if (FirstParam) FirstParam = false;

                            if (sp.Direction == ParameterDirection.Input)
                            {
                                sql.AppendLine(sp.ParameterName + " = " + sp.ParameterValueForSQL());
                            }
                            else
                            {
                                sql.AppendLine(sp.ParameterName + " = " + sp.ParameterName + " output");
                            }
                        }
                    }
                    sql.Append((FirstParam) ? ";" : ");");
                    sql.AppendLine("");

                    break;
                case CommandType.Text:
                    sql.AppendLine(sc.CommandText);
                    foreach (SqlParameter sp in sc.Parameters)
                    {
                        if (sp.Direction != ParameterDirection.ReturnValue)
                        {
                            sql.Append((FirstParam) ? "\nParâmetros:\n\t" : "\t, ");

                            if (FirstParam) FirstParam = false;

                            if (sp.Direction == ParameterDirection.Input)
                            {
                                sql.AppendLine(sp.ParameterName + " = " + sp.ParameterValueForSQL());
                            }
                            else
                            {
                                sql.AppendLine(sp.ParameterName + " = " + sp.ParameterName + " output");
                            }
                        }
                    }
                    sql.AppendLine("");
                    break;
            }
            return sql.ToString();

            #endregion Implementação
        }

        #endregion Métodos
    }
}
