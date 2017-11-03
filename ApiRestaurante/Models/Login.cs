using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;
using ApiRestaurante.DAO1;
using System.Globalization;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using Newtonsoft.Json;

namespace ApiRestaurante.Models
{
    public static class Login
    {
        private static OracleConnection cn;
        private static OracleDataReader dr;
        public static string ID_FUNC { get; set; }
        public static string USUARIO { get; set; }
        public static string SENHA { get; set; }
        public static string NIVEL_ACESSO { get; set; }
        public static string STATUS_LOGIN { get; set; }
        private static string SQL;


        public static bool Logar()
        {
            ClasseConexao objConexao = new ClasseConexao();
            SQL = "SELECT ID_FUNC, SENHA, USUARIO, NIVEL_ACESSO,STATUS_LOGIN FROM LOGIN_FUNC WHERE STATUS_LOGIN=1 AND USUARIO='" + USUARIO + "' AND SENHA='" + SENHA + "' and NIVEL_ACESSO = '3'";

            OracleDataReader dr =  objConexao.RetornarDataReader(SQL);
            dr = objConexao.RetornarDataReader(SQL);
            dr.Read();
            if (dr.HasRows) //dr.Read()
            {

                SENHA = dr["SENHA"].ToString();
                NIVEL_ACESSO = dr["NIVEL_ACESSO"].ToString();
                USUARIO = dr["USUARIO"].ToString();
                ID_FUNC = dr["ID_FUNC"].ToString();
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
   
       
   
