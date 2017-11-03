using System;
using System.Collections.Generic;
using System.Linq;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
namespace ApiRestaurante.DAO1
{
    public class ClasseConexao
    {
        private static OracleConnection cn;
        private static OracleCommand cmd;
        private static OracleDataAdapter da;
        private static OracleDataReader dr;
        private static OracleParameter p;
        private static OracleParameter q;
        private static DataSet ds;
        private static string SQL;
        private static string dado;
        private static DataTable dt;

        private static string strConexaoOra = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LOCALHOST)(PORT=1521)))(CONNECT_DATA=(SID=xe)));User ID=SYS ;Password=123456 ;DBA Privilege=SYSDBA;";

        public static string Conexao()
        {
            string oradb = strConexaoOra;
            cn = new OracleConnection(oradb);
            string info = "";

            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                    info = "Conectado com a Versão Oracle." + cn.ServerVersion + " Utilizando a fonte " + cn.DataSource;
                }
            }
            catch (OracleException ex)
            {
                return ex.Message;
            }
            return info + "Estado da Conexão: " + cn.State.ToString() + " Ok.";
        }

        public static OracleConnection ConexaoBanco()
        {
            try
            {
                cn = new OracleConnection(strConexaoOra);
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                return cn;
            }
            catch (OracleException exOra)
            {
                throw exOra;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FecharBanco(OracleConnection cn)
        {
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
            catch (OracleException exOra)
            {
                throw exOra;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OracleDataReader RetornarDataReader(string sqlComando)
        {
            try
            {
                OracleDataReader dr;
                //OracleCommand cmd = new OracleCommand(sqlComando, abrirBanco());
                cmd = new OracleCommand(sqlComando, ConexaoBanco());
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable RetornarDataTable(string sqlComando)
        {
            try
            {
                DataTable dt = new DataTable();
                cmd = new OracleCommand(sqlComando, cn);
                da = new OracleDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet RetornarDataSet(string sqlComando)
        {
            try
            {
                ds = new DataSet();
                cmd = new OracleCommand(sqlComando, cn);
                da = new OracleDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecutarComando(string sqlComando)
        {
            try
            {
                OracleCommand cmd = new OracleCommand(sqlComando, cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void FinalizarConexao()
        {
            cn.Close();
            cn.Dispose();
        }

        public OracleParameter CriarParametro(string nomeParametro, OracleDbType tipoParametro, object valorParametro)
        {
            OracleParameter p = new OracleParameter();
            p.ParameterName = nomeParametro;
            p.OracleDbType = tipoParametro;
            if (valorParametro == null)
            {
                p.Value = DBNull.Value;
            }
            else
            {
                if (tipoParametro == OracleDbType.Varchar2 &&
                    valorParametro.ToString().Length == 0)
                {
                    p.Value = DBNull.Value;
                }
                else
                {
                    p.Value = valorParametro;
                }
            }
            return p;
        }

        public void ExecutarComandoParametro(string sqlComando, OracleParameter[] listaParametros)
        {
            try
            {
                cmd = new OracleCommand();
                cmd.CommandText = sqlComando;
                cmd.CommandType = CommandType.Text;
                if (listaParametros != null)
                {
                    foreach (OracleParameter p in listaParametros)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
            }
            catch (OracleException exOra)
            {
                throw exOra;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecutarStoredProcedureParametro(string nomeProcedure, OracleParameter[] listaParametros)
        {
            try
            {
                cmd = new OracleCommand();
                cmd.CommandText = nomeProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                if (listaParametros != null)
                {
                    foreach (OracleParameter p in listaParametros)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
            }
            catch (OracleException exOra)
            {
                throw exOra;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ExecutarComandoRetorno(string sqlComando)
        {
            try
            {
                cmd = new OracleCommand();
                cmd.CommandText = sqlComando;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                cmd.CommandText = "Select @@Identity";
                dr = cmd.ExecuteReader();
                dr.Read();
                return Convert.ToInt32(dr[0]);
            }
            catch (OracleException exOra)
            {
                throw exOra;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet RetornarDatasetParametro(string nomeProcedure, OracleParameter[] listaParametros)
        {
            try
            {
                cmd = new OracleCommand();
                cmd.CommandText = nomeProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                if (listaParametros != null)
                {
                    foreach (OracleParameter p in listaParametros)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                cmd.Connection = cn;
                da = new OracleDataAdapter();
                ds = new DataSet();
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (OracleException exOra)
            {
                throw exOra;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                FecharBanco(cn);
            }
        }

        public OracleDataReader RetornarDataReaderParametro(string nomeProcedure, OracleParameter[] listaParametros)
        {
            try
            {
                cmd = new OracleCommand();
                cmd.CommandText = nomeProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                if (listaParametros != null)
                {
                    foreach (OracleParameter p in listaParametros)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                cmd.Connection = cn;
                return cmd.ExecuteReader();
            }
            catch (OracleException exOra)
            {
                throw exOra;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string RetornarNomeBancoDados()
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                return cmd.Connection.DatabaseName;
            }
            catch (OracleException exOra)
            {
                throw exOra;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                FecharBanco(cn);
            }
        }

        public string RetornarStatusBancoDados()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    return "Fechado";
                }
                else
                {
                    return "Aberto";
                }
            }
            catch (OracleException exOra)
            {
                throw exOra;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string RetornarNomeServidor()
        {
            try
            {
                return cn.DataSource;
            }
            catch (OracleException exOra)
            {
                throw exOra;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}