using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaveraSync.Model
{
    class PedidoEcommerce
    {
        public string bairroEntrega { get; set; }
        public string cepEntrega { get; set; }
        public string codigoCliente { get; set; }
        public string codigoIBGECidadeEntrega { get; set; }
        public string complementoEntrega { get; set; }
        public string cpfCnpj { get; set; }
        public DateTime dataHoraDigitacao { get; set; }
        public string email { get; set; }
        public string identificadorOrigem { get; set; }
        public ItemPedido itens { get; set; }
        public string logradouroEntrega { get; set; }
        public string nomeContato { get; set; }
        public string numeroLogradouroEntrega { get; set; }
        public string numeroOriginal { get; set; }
        public string observacao { get; set; }
        public string siglaEstadoEntrega { get; set; }
        public string situacaoPagamento { get; set; }
        public string tipoFreteWeb { get; set; }
        public string idFormaCobranca { get; set; }
        public string idCondicaoPagamento { get; set; }
        public string tipoLogradouroEntrega { get; set; }
        public string valorFrete { get; set; }
        public string valorDesconto { get; set; }
        public string valorTotal { get; set; }
    }
}
