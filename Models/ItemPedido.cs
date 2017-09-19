namespace RestauranteApi.Models
{
    public class ItemPedido
    {
        public int id { get; set; }
        public Pedido pedido { get; set; }
        public string nome { get; set; }
        public float valor { get; set; }

        public ItemPedido(int id)
        {
            pedido = new Pedido()
            {
                id = id
            };
        }
        public ItemPedido(Pedido p)
        {
            pedido = p;
        }
    }
}