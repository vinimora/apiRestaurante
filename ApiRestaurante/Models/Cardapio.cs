using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;
using ApiRestaurante.DAO1;
using System.Globalization;
using Oracle.DataAccess.Types;
using Newtonsoft.Json;
using Oracle.DataAccess.Client;

namespace RestauranteApi.Models
{
    [Serializable]
    [JsonObject(Title = "cardapio")]
    public class Cardapio
    {

        private static OracleConnection cn;
        public int id { get; set; }
        public double preco { get; set; }
        public int ativo { get; set; }
        public int ordem { get; set; }
        public string ingredientes { get; set; }
        public string nome { get; set; }
        public TipoProdutos tipo { get; set; }
        
        private string SQL;

        public Cardapio()
        {
            //inicia mesa teste
            //mesa = new Mesa() { id = 1 };
            System.Web.HttpContext.Current.Session["sessionString"] = "string";

        }
        //public void Incluir(int idmesa)
        //{
        //    mesa = new Mesa() { id = idmesa };

        //    // OracleConnection c = new OracleConnection();
        //    ClasseConexao c = new ClasseConexao();

        //    SQL = " INSERT INTO sys.pedido(NUMERO_PEDIDO, numero_mesa, HORA_DATA_PEDIDO, STATUS_PEDIDO)" +
        //    "VALUES(sequencePedidos.NEXTVAL,'" + mesa.id + "','" + data + "'," + status +")";
        //    c.ExecutarComando(SQL);
                
           
        //}
        public List<Cardapio> listar()
        {
            ClasseConexao c = new ClasseConexao();
            SQL = " select * from cardapio c inner join tipo_produtos tp on c.tipo = tp.ID_TIPO where c.ativo = 1 ";

            OracleDataReader dr = c.RetornarDataReader(SQL);

            List<Cardapio> retorno = new List<Cardapio>();
            
                //dr.GetName(1);
                while (dr.Read())
                {
                    Cardapio ca = new Models.Cardapio();
                    ca.id = int.Parse((string)dr["ID_ITEM"].ToString()); ;
                    //p.data = (string)dr["HORA_DATA_PEDIDO"].ToString();

                    ca.preco = double.Parse((string)dr["PRECO"].ToString());
                    ca.ativo = int.Parse((string)dr["ATIVO"].ToString());
                    ca.ordem = int.Parse((string)dr["ORDEM"].ToString()); ;
                    ca.ingredientes = (string)dr["INGREDIENTES"].ToString();
                    ca.nome = (string)dr["NOME"].ToString();
                    ca.tipo = new Models.TipoProdutos()
                    {
                        id = int.Parse((string)dr["ID_TIPO"].ToString()),
                        nome = (string)dr["NOME_TIPO"].ToString(),
                        descricao = (string)dr["DESCRICAO_TIPO"].ToString()
                    };


                    retorno.Add(ca);
                    //dr.NextResult();
                }
            

            return retorno;

        }
        
    }
}

