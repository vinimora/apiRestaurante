using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;
using ApiRestaurante.DAO;
using System.Globalization;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace RestauranteApi.Models
{

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
            mesa = new Mesa() { id = 1 };


            data = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss", new CultureInfo("en-US"));
        }
        public void Incluir()
        {


            // OracleConnection c = new OracleConnection();

                ClasseConexao c = new ClasseConexao();


                SQL = " INSERT INTO sys.pedido(NUMERO_PEDIDO, numero_mesa, HORA_DATA_PEDIDO, STATUS_PEDIDO)" +
                "VALUES(sequencePedidos.NEXTVAL,'" + mesa.id + "','" + data + "'," + status +")";
                c.ExecutarComando(SQL);
                
           
        }
        public List<Pedido> listar()
        {
            ClasseConexao c = new ClasseConexao();
            SQL = " SELECT NUMERO_PEDIDO, HORA_DATA_PEDIDO from PEDIDO WHERE NUMERO_MESA = '1'";

            OracleDataReader dr = c.ExecutarComandoRetorno(SQL);

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

