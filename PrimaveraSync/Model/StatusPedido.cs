using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaveraSync.Model
{
    class StatusPedido //Classe responsável para receber o status do pedido.
    {
        public string numeroOriginal { get; set; }
        public string situacaoPagamento { get; set; }
        public string situacaoPagamentoNome { get; set; }
        public string situacaoPagamentoData { get; set; }
    }
}
