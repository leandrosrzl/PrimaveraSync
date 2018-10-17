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

namespace PrimaveraSync.Controller
{
    public class SyncCliente
    {
        Clientes cliente;
        HttpWebService httpWebService;
        string acao;
        string json = "";
        FbCommand comandoFirebird;
        FbConnection conexaoFirebird;
        StringBuilder comandoSql;
        SyncPedido syncPedido = new SyncPedido();
        WriteLog writeLog;

        public Clientes prvGetClientesEcommerce()
        {
            httpWebService = new HttpWebService();
            acao = "clientes";
            json = httpWebService.prvHttpWebService(acao, "GET", "", "");
            var jsonClientes = JsonConvert.DeserializeObject<Clientes>(json);
            cliente = new Clientes();
            cliente = jsonClientes;

            return cliente;
        }

        public void puvInsertCliente(DadosCliente cliente)
        {
            try
            {
                using (conexaoFirebird = new FbConnection(Utils.Conexoes.conexaoSjobs))
                {
                    conexaoFirebird.Open();

                    comandoFirebird = new FbCommand();
                    comandoSql = new StringBuilder();

                    comandoSql.Append("INSERT INTO SJCLI(IDCLI, IDREP, IDTRA, IDBAN, CLIENTE, FANTASIA, ENDERECO, BAIRRO, ");
                    comandoSql.Append("UF, CEP, FONE1, EMAIL1, DESDE, TIPO_DOC, CREDITO, INATIVO, CAD_SITE, WEB_IDUSU) ");
                    comandoSql.Append("VALUES (@IDCLI, @IDREP, @IDTRA, @IDBAN, @CLIENTE, @FANTASIA, @ENDERECO, @BAIRRO, ");
                    comandoSql.Append("@UF, @CEP, @FONE1, @EMAIL1, 'NOW', @TIPO_DOC, @CREDITO, @INATIVO, @CAD_SITE, @WEB_IDUSU)");

                    comandoFirebird.Parameters.Add(new FbParameter("@IDCLI", (syncPedido.prvLerGenerator("GEN_SJCLI_IDCLI", 1))));
                    comandoFirebird.Parameters.Add(new FbParameter("@IDREP", PrimaveraSync.Properties.Settings.Default.idRepDefault));
                    comandoFirebird.Parameters.Add(new FbParameter("@IDTRA", PrimaveraSync.Properties.Settings.Default.idTraDefault));
                    comandoFirebird.Parameters.Add(new FbParameter("@IDBAN", PrimaveraSync.Properties.Settings.Default.idBanDefault));
                    comandoFirebird.Parameters.Add(new FbParameter("@CLIENTE", cliente.nomeContato));
                    comandoFirebird.Parameters.Add(new FbParameter("@FANTASIA", cliente.nomeContato));
                    comandoFirebird.Parameters.Add(new FbParameter("@ENDERECO", (cliente.logradouro + "," + cliente.numeroLogradouro)));
                    comandoFirebird.Parameters.Add(new FbParameter("@BAIRRO", cliente.bairro));
                    comandoFirebird.Parameters.Add(new FbParameter("@UF", cliente.siglaEstado));
                    comandoFirebird.Parameters.Add(new FbParameter("@CEP", cliente.cep));
                    comandoFirebird.Parameters.Add(new FbParameter("@FONE1", (cliente.dddTelefonePrincipal + cliente.telefonePrincipal)));
                    comandoFirebird.Parameters.Add(new FbParameter("@EMAIL1", cliente.emailContato));
                    //comandoFirebird.Parameters.Add(new FbParameter("@DESDE", "NOW"));
                    if(cliente.tipoPessoa == "1")
                    {
                        comandoFirebird.Parameters.Add(new FbParameter("@TIPO_DOC", "CPF"));
                    }
                    else
                    {
                        comandoFirebird.Parameters.Add(new FbParameter("@TIPO_DOC", "CNPJ"));
                    }
                    comandoFirebird.Parameters.Add(new FbParameter("@CREDITO", "l"));
                    comandoFirebird.Parameters.Add(new FbParameter("@INATIVO", "N"));
                    comandoFirebird.Parameters.Add(new FbParameter("@CAD_SITE", "S"));
                    comandoFirebird.Parameters.Add(new FbParameter("@WEB_IDUSU", cliente.codigoClienteWeb));
                    

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
