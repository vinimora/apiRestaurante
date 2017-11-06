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
    public class Contato
    {
        private string SQL { get; set; }
        public string NOME { get; set; }
        public string EMAIL { get; set; }
        public string TELEFONE { get; set; }
        public string MENSAGEM { get; set; }
        public string DATA { get; set; }
        private void setData()
        {
            //inicia mesa teste
            //mesa = new Mesa() { id = 1 };
            System.Web.HttpContext.Current.Session["sessionString"] = "string";

            DATA = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss", new CultureInfo("en-US"));
        }
        public void Incluir()
        {
            // OracleConnection c = new OracleConnection();
            ClasseConexao c = new ClasseConexao();
            //seta a data
            setData();

            SQL = " INSERT INTO sys.pedido(NOME, EMAIL, TELEFONE, MENSAGEM, DATA)" +
            "VALUES('" + NOME + "','" + EMAIL + "','" + TELEFONE + "','" + MENSAGEM + "','" + DATA + "')";
            c.ExecutarComando(SQL);
        }
    }
}
   
       
   
