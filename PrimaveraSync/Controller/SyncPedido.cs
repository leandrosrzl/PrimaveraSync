using FirebirdSql.Data.FirebirdClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PrimaveraSync.Model;
using PrimaveraSync.Utils;
using PrimaveraSync.Properties;

namespace PrimaveraSync.Controller
{
    class SyncPedido
    {
        Pedido pedido;
        HttpWebService httpWebService;
        Pedidos pedidos;
        string acao;
        string json = "";
        FbCommand comandoFirebird, comandoFirebird2;
        FbConnection conexaoFirebird, conexaoFirebird2;
        StringBuilder comandoSql, comandoSql2;
        DataTable dados;
        WriteLog writeLog;

        public Pedido prvGetStatusPedido()
        {
            httpWebService = new HttpWebService();
            acao = "pedido-status";
            json = httpWebService.prvHttpWebService(acao, "GET", "", "");
            var statusPedido = JsonConvert.DeserializeObject<Pedido>(json);
            pedido = new Pedido();
            pedido = statusPedido;
            //listaStatusPedidos.Add(pedido);

            return pedido;
        }

        public Pedidos prvGetPedidosEcommerce(string escreveString)
        {
            httpWebService = new HttpWebService();
            acao = "pedidos";
            json = httpWebService.prvHttpWebService(acao, "GET", "", escreveString);
            if(escreveString == "false")
            {
                var jsonPedidos = JsonConvert.DeserializeObject<Pedidos>(json);
                pedidos = new Pedidos();
                pedidos = jsonPedidos;
            }
            else
            {
                pedidos = new Pedidos();
            }
            
            //listaPedidos.Add(jsonPedidos);

            return pedidos;
        }

        public int puvInsertPedido(PedidoEcommerce pedidoDoEcommerce)
        {
            try
            {
                int idped = 0;
                using (conexaoFirebird = new FbConnection(Utils.Conexoes.conexaoSjobs))
                {
                    conexaoFirebird.Open();

                    comandoFirebird = new FbCommand();
                    comandoSql = new StringBuilder();

                    comandoSql.Append("INSERT INTO SJPED(IDPED, IDCLI, IDREP, IDTRA, IDBAN, SNET_INICIO, SNET_ENVIO, JOBS_ENTRADA, TPRODUTO, ");
                    comandoSql.Append("OBSINTERNA, TABN, CANAL, TCUSTO, PDESCONTO, PRAZO, PRAZOMEDIO, COMREP, TPESO, MARKUP ) ");
                    comandoSql.Append("VALUES (@IDPED, @IDCLI, @IDREP, @IDTRA, @IDBAN, @SNET_INICIO, ");
                    comandoSql.Append("@SNET_ENVIO, @JOBS_ENTRADA, @TPRODUTO, @OBSINTERNA, @TABN, @CANAL, 0, 0, 0,0,@COMREP,@TPESO,0)");

                    pedidoDoEcommerce.observacao +=
                    "\n" +
                    "CPF/CNPJ: " + pedidoDoEcommerce.cpfCnpj + 
                    "\n" +
                    "Nome: " + pedidoDoEcommerce.nomeContato +
                    "\n" +
                    "e-mail: " + pedidoDoEcommerce.email +
                    "\n" +
                    /*"Telefone: " + pedidoDoEcommerce. +
                    "\n" +*/
                    "Rua: " + pedidoDoEcommerce.logradouroEntrega + ", " + pedidoDoEcommerce.numeroLogradouroEntrega + " - COMP: " + pedidoDoEcommerce.complementoEntrega +
                    "\n" +
                    "Bairro: " + pedidoDoEcommerce.bairroEntrega +
                    "\n" +
                    "UF: " + pedidoDoEcommerce.siglaEstadoEntrega + "\t" + "CEP: " + pedidoDoEcommerce.cepEntrega +
                    "\n" +
                    "IBGE: " + pedidoDoEcommerce.codigoIBGECidadeEntrega;

                    comandoFirebird.Parameters.Add(new FbParameter("@IDPED",(idped = prvLerGenerator("GEN_SJPED_IDPED",1))));
                    comandoFirebird.Parameters.Add(new FbParameter("@IDCLI", Properties.Settings.Default.idCliWeb));
                    comandoFirebird.Parameters.Add(new FbParameter("@IDREP", Properties.Settings.Default.idRepDefault));
                    comandoFirebird.Parameters.Add(new FbParameter("@IDTRA", Properties.Settings.Default.idTraDefault));
                    comandoFirebird.Parameters.Add(new FbParameter("@IDBAN", pedidoDoEcommerce.idFormaCobranca));
                    comandoFirebird.Parameters.Add(new FbParameter("@SNET_INICIO",pedidoDoEcommerce.dataHoraDigitacao));
                    comandoFirebird.Parameters.Add(new FbParameter("@SNET_ENVIO", DateTime.Now));
                    comandoFirebird.Parameters.Add(new FbParameter("@JOBS_ENTRADA", DateTime.Now));
                    comandoFirebird.Parameters.Add(new FbParameter("@TPRODUTO", pedidoDoEcommerce.valorTotal));
                    comandoFirebird.Parameters.Add(new FbParameter("@OBSINTERNA", pedidoDoEcommerce.observacao));
                    comandoFirebird.Parameters.Add(new FbParameter("@TABN", PrimaveraSync.Properties.Settings.Default.spotTabPrice));
                    comandoFirebird.Parameters.Add(new FbParameter("@CANAL", 5));
                    comandoFirebird.Parameters.Add(new FbParameter("@COMREP", PrimaveraSync.Properties.Settings.Default.comrep));
                    comandoFirebird.Parameters.Add(new FbParameter("@TPESO", 0));

                    comandoFirebird.CommandText = comandoSql.ToString();
                    comandoFirebird.Connection = conexaoFirebird;
                    comandoFirebird.ExecuteNonQuery();

                    return idped;
                }
            }
            catch (Exception ex)
            {
                writeLog = new WriteLog();
                writeLog.WriteErrorMessage(ex.Message);
                throw;
            }
        }

        public int prvLerGenerator(string generator, int interval)
        {
            int gen = 0;
            try
            {
                using (conexaoFirebird2 = new FbConnection(Utils.Conexoes.conexaoSjobs))
                {
                    conexaoFirebird2.Open();

                    comandoFirebird2 = new FbCommand();
                    comandoSql2 = new StringBuilder();
                    dados = new DataTable();

                    comandoSql2.Append("SELECT GEN_ID("+ generator + "," + interval +") FROM RDB$DATABASE");

                    comandoFirebird2.CommandText = comandoSql2.ToString();
                    comandoFirebird2.Connection = conexaoFirebird2;
                    dados.Load(comandoFirebird2.ExecuteReader());

                    gen = Convert.ToInt32(dados.Rows[0]["GEN_ID"]);

                    return gen;
                }
            }
            catch (Exception ex)
            {
                writeLog = new WriteLog();
                writeLog.WriteErrorMessage(ex.Message);
                throw;
            }
        }

        public void puvInsertItens(ItemPedidoComp itemPedido, int idped)
        {
            try
            {
                using (conexaoFirebird = new FbConnection(Utils.Conexoes.conexaoSjobs))
                {
                    conexaoFirebird.Open();

                    comandoFirebird = new FbCommand();
                    comandoSql = new StringBuilder();

                    comandoSql.Append("INSERT INTO SJMIP (IDMIP, IDPED, IDPRO, ITEM, QTE, VUNIT, VTOTAL, TABX) ");
                    comandoSql.Append("VALUES (@IDMIP, @IDPED, @IDPRO, @ITEM, @QTE, @VUNIT, @VTOTAL, @TABX)");

                    comandoFirebird.Parameters.Add(new FbParameter("@IDMIP", prvLerGenerator("GEN_SJMIP_ID", 1)));
                    comandoFirebird.Parameters.Add(new FbParameter("@IDPED", idped));
                    comandoFirebird.Parameters.Add(new FbParameter("@IDPRO", itemPedido.idProduto));
                    comandoFirebird.Parameters.Add(new FbParameter("@ITEM", itemPedido.numeroItem));
                    comandoFirebird.Parameters.Add(new FbParameter("@QTE", itemPedido.quantidade));
                    comandoFirebird.Parameters.Add(new FbParameter("@VUNIT", itemPedido.valorUnitario));
                    comandoFirebird.Parameters.Add(new FbParameter("@VTOTAL", (itemPedido.quantidade * itemPedido.valorUnitario)));
                    comandoFirebird.Parameters.Add(new FbParameter("@TABX", PrimaveraSync.Properties.Settings.Default.spotTabPrice));


                    comandoFirebird.CommandText = comandoSql.ToString();
                    comandoFirebird.Connection = conexaoFirebird;
                    comandoFirebird.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                writeLog = new WriteLog();
                writeLog.WriteErrorMessage(ex.Message);
                throw;
            }
        }
    }
}
