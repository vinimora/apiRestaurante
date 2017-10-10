using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;
using ApiRestaurante.DAO;
using System.Globalization;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using Newtonsoft.Json;

namespace RestauranteApi.Models
{
    [Serializable]
    [JsonObject(Title = "tipo-produto")]
    public class TipoProdutos
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        private string SQL;

        public List<TipoProdutos> listar()
        {
            ClasseConexao c = new ClasseConexao();
            SQL = " select * from tipo_produtos ";

            OracleDataReader dr = c.ExecutarComandoRetorno(SQL);

            List<TipoProdutos> retorno = new List<TipoProdutos>();
            if (dr.HasRows)
            {
                //dr.GetName(1);
                while (dr.Read())
                {
                    TipoProdutos tp = new Models.TipoProdutos();

                    tp.id = int.Parse((string)dr["ID_TIPO"].ToString());
                    tp.nome = (string)dr["NOME_TIPO"].ToString();
                    tp.descricao = (string)dr["DESCRICAO_TIPO"].ToString();


                    retorno.Add(tp);
                    //dr.NextResult();
                }
            }

            return retorno;

        }
    }
}