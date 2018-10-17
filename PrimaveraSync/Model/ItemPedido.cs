using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaveraSync.Model
{
    public class ItemPedidoComp
    {
        public string idProduto { get; set; }
        public string numeroItem { get; set; }
        public string numeroPedido { get; set; }
        public int quantidade { get; set; }
        public string unidade { get; set; }
        public float valorUnitario { get; set; }
    }

    public class cUnidade
    {
        public object un { get; set; }
    }

    public class ItemPedido
    {
        public object item { get; set; }
    }
}
