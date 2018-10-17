using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaveraSync.Model
{
    class Pedido //Classe responsável para receber o status do pedido. Tera como dependente, o StatusPedido
    {
        public List<StatusPedido> pedido { get; set; } 
    }
}
