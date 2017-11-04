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

namespace RestauranteApi.Models
{
    [Serializable]
    [JsonObject(Title = "pedido")]
    public class Pedido
    {

        private static OracleConnection cn;
        public int id { get; set; }
        public List<ItemPedido> itens { get; set; }
        public Mesa mesa { get; set; }
        public Funcionario funcionario { get; set; }
        public string data { get; set; }
        public EStatus status { get; set; }
        private string SQL;

        public Pedido()
        {
            //inicia mesa teste
            //mesa = new Mesa() { id = 1 };
            System.Web.HttpContext.Current.Session["sessionString"] = "string";

            setData();
        }

        private void setData()
        {
            //inicia mesa teste
            //mesa = new Mesa() { id = 1 };
            System.Web.HttpContext.Current.Session["sessionString"] = "string";

            data = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss", new CultureInfo("en-US"));
        }
        public void Incluir(int idmesa)
        {
            mesa = new Mesa() { id = idmesa };

            // OracleConnection c = new OracleConnection();
            ClasseConexao c = new ClasseConexao();
            //seta a data
            setData();

            SQL = " INSERT INTO sys.pedido(NUMERO_PEDIDO, numero_mesa, HORA_DATA_PEDIDO, STATUS_PEDIDO)" +
            "VALUES(sequencePedidos.NEXTVAL,'" + mesa.id + "','" + data + "'," + (int)status +")";
            c.ExecutarComando(SQL);

            int lastId = getSequence("sequencePedidos");

            if(lastId > 0)
            {
                foreach (ItemPedido it in itens)
                {
                    SQL = "insert into itens_pedidos (id_prod_item, id_prod, numero_pedido, quantidade, ativo) values(secItensPedidos.nextval," + it.id + "," + lastId + "," + it.quantidade + ",1)";
                    c.ExecutarComando(SQL);
                }
            }
            
        }
        public void Incluir()
        {
            if(mesa != null && mesa.id > 0)
            {
                Incluir(mesa.id);
            }
        }
        public List<Pedido> listar()
        {
            ClasseConexao c = new ClasseConexao();
            SQL = " SELECT NUMERO_PEDIDO, HORA_DATA_PEDIDO from PEDIDO";

            OracleDataReader dr = c.RetornarDataReader(SQL);

            List<Pedido> retorno = new List<Pedido>();
            if (dr.HasRows)
            {
                //dr.GetName(1);
                while (dr.Read())
                {
                    Pedido p = new Pedido();
                    p.id = (int)dr["NUMERO_PEDIDO"];
                    p.data = (string)dr["HORA_DATA_PEDIDO"].ToString();
                    retorno.Add(p);
                    //dr.NextResult();
                }
            }

            return retorno;

        }
        //select sequencePedidos.CURRVAL from pedido
        public int getSequence(string sequencia)
        {
            ClasseConexao c = new ClasseConexao();
            SQL = "SELECT TO_CHAR(sys." + sequencia + ".nextval, 'TM9') as s FROM DUAL";

            OracleDataReader dr = c.RetornarDataReader(SQL);

            while (dr.Read())
            {
                int retorno = 0;
                if (dr["s"] != null)
                {
                    retorno = int.Parse(dr["s"].ToString());
                    retorno = retorno - 1;
                }
                return  retorno;
            }

            return 0;

        }
        public List<Pedido> getByMesa(int idmesa)
        {
            mesa = new Models.Mesa()
            {
                id = idmesa
            };
            ClasseConexao c = new ClasseConexao();
            SQL = " SELECT NUMERO_PEDIDO, HORA_DATA_PEDIDO from PEDIDO WHERE NUMERO_MESA = '" + mesa.id + "'";

            OracleDataReader dr = c.RetornarDataReader(SQL);

            List<Pedido> retorno = new List<Pedido>();
            if (dr.HasRows)
            {
                //dr.GetName(1);
                while (dr.Read())
                {
                    Pedido p = new Pedido();
                    p.id = (int)dr["NUMERO_PEDIDO"];
                    p.data = (string)dr["HORA_DATA_PEDIDO"].ToString();
                    retorno.Add(p);
                    //dr.NextResult();
                }
            }

            return retorno;

        }
    }
}

