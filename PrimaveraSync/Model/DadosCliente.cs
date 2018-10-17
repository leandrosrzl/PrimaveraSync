using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaveraSync.Model
{
    public class DadosCliente
    {
        public string indicadorOrigem { get; set; }
        public string codigoClienteWeb { get; set; }
        public string codigoIBGECidade { get; set; }
        public string nome { get; set; }
        public string nomeContato { get; set; }
        public string tipoPessoa { get; set; }
        public string cpfCNPJ { get; set; }
        public DateTime dataCadastro { get; set; }
        public string tipoLogradouro { get; set; }
        public string logradouro { get; set; }
        public string numeroLogradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string siglaEstado { get; set; }
        public string emailContato { get; set; }
        public string telefonePrincipal { get; set; }
        public string dddTelefonePrincipal { get; set; }
    }
}
