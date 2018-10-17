using FirebirdSql.Data.FirebirdClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimaveraSync.Utils;
using PrimaveraSync.Model;

namespace PrimaveraSync.Controller
{
    class SyncProduto : Form1
    {
        HttpWebService httpWebService;
        string json = "";
        FbCommand comandoFirebird;
        FbConnection conexaoFirebird;
        StringBuilder comandoSql;
        DataTable dados;
        SyncPedido syncPedido = new SyncPedido();
        WriteLog writeLog;
        string divisao = PrimaveraSync.Properties.Settings.Default.divisao;

        public void conectaWebService(int codigoProduto, double num, string acao)
        {
            httpWebService = new HttpWebService();
            string parametros = "&codigo=" + codigoProduto;
            if (acao == "estoque")
            {
                parametros += "&estoque=";
            }
            else
            {
                parametros += "&preco";
            }
            parametros += num;

            json = httpWebService.prvHttpWebService(acao, "GET", parametros, "");
        }

        public string sincronizarProduto(Produto produto, string escreveString)
        {
            httpWebService = new HttpWebService();
            string acao = "produto";
            string parametros =
                "&codigo=" + produto.idpro +
                "&barra=" + produto.codbarra +
                "&nomeProduto=" + produto.produto +
                "&grupo=" + produto.idgrp4 +
                "&grupoNome=" + produto.grupo +
                "&grupoSub=" + produto.idsgr4 +
                "&grupoSubNome=" + produto.subgrupo +
                "&marcaNome=" + produto.marca +
                "&resumoProduto=" + produto.detalhes +
                "&peso=" + produto.peso +
                "&estoque=" + produto.stok_off +
                "&precoaVista=" + produto.spotTabPrice +        //preco a vista  TAB13 - a vista
                "&precoPrazo=" + produto.retailTabPrice +        //preco a prazo  TAB11 - varejo
                "&precoRevenda=" + produto.wholesaleTabPrice +   //preco revenda  TAB12 - atacado
                "&precoPromocao=" + produto.promoTabPrice +      //preco promocao TAB14 - promocao
                "&imagem=" + produto.imagem
            ;
            
            json = httpWebService.prvHttpWebService(acao, "GET", parametros, escreveString);

            return json;
        }

        public List<Produto> puvAtualizarProduto(string cpro)
        {
            int i = 0;
            try
            {
                using (conexaoFirebird = new FbConnection(Conexoes.conexaoSjobs))
                {
                    conexaoFirebird.Open();
                    dados = new DataTable();
                    comandoFirebird = new FbCommand();
                    comandoSql = new StringBuilder();
                    Produto produto = new Produto();
                    List<Produto> listaProdutos = new List<Produto>();
                    string prefixo = "";

                    comandoSql.Append(" SELECT P.IDPRO, P.IDEXT_PRO, P.CODBARRA, P.PRODUTO, P.IDGRP4, G.GRUPO, P.IDSGR4, S.SUBGRUPO, P.MARCA, ");
                    comandoSql.Append(" P.DETALHES, P.PESO * 1000 AS \"PESO\", P.STOK_OFF, ");
                    if(PrimaveraSync.Properties.Settings.Default.imagemSite == "REFERENCIA")
                    {
                        prefixo = "IMG";
                    }
                    else if(PrimaveraSync.Properties.Settings.Default.imagemSite == "REFERENCIA2")
                    {
                        prefixo = "HIMG";
                    }
                    else
                    {
                        prefixo = "OIMG";
                    }
                    comandoSql.Append(" '" + prefixo + "' ||");
                    comandoSql.Append(" I.IDIMG AS \"IMAGEM\" ");
                    comandoSql.Append(" FROM SJ4PRO P ");
                    comandoSql.Append(" LEFT JOIN SJ1GRP G ");
                    comandoSql.Append(" ON P.IDGRP4 = G.IDGRP ");
                    comandoSql.Append(" LEFT JOIN SJ2SGR S ");
                    comandoSql.Append(" ON P.IDSGR4 = S.IDSGR");
                    comandoSql.Append(" LEFT JOIN SJ7IMG I ");
                    comandoSql.Append(" ON P.IDIMG4 = I.IDIMG ");
                    comandoSql.Append(" WHERE P.DIVISAO IN (" + divisao + ")");
                    if(cpro.Length > 0)
                    {
                        comandoSql.Append(" AND CPRO = @CPRO ");

                        comandoFirebird.Parameters.Add(new FbParameter("@CPRO", cpro));
                    }

                    comandoFirebird.CommandText = comandoSql.ToString();
                    comandoFirebird.Connection = conexaoFirebird;
                    dados.Load(comandoFirebird.ExecuteReader());
                    
                    for(i = 0; i < dados.Rows.Count; i++)
                    {
                        produto = new Produto();
                        produto.idpro    = Convert.ToInt32(dados.Rows[i]["IDPRO"]);
                        produto.idext_pro = Convert.ToInt32(dados.Rows[i]["IDEXT_PRO"]);
                        if (dados.Rows[i]["CODBARRA"].ToString() == "" || dados.Rows[i]["CODBARRA"] == null)
                        {
                            produto.codbarra = "0";
                        }
                        else
                        {
                            produto.codbarra = dados.Rows[i]["CODBARRA"].ToString();
                        }
                        produto.produto  =                 dados.Rows[i]["PRODUTO"].ToString();
                        produto.idgrp4   = Convert.ToInt32(dados.Rows[i]["IDGRP4"]);
                        produto.grupo    =                 dados.Rows[i]["GRUPO"].ToString();
                        produto.idsgr4   = Convert.ToInt32(dados.Rows[i]["IDSGR4"]);
                        produto.subgrupo =                 dados.Rows[i]["SUBGRUPO"].ToString();
                        produto.marca    =                 dados.Rows[i]["MARCA"].ToString();
                        produto.detalhes =                 dados.Rows[i]["DETALHES"].ToString();
                        if (dados.Rows[i]["PESO"].ToString() == "" || dados.Rows[i]["PESO"] == null)
                        {
                            produto.peso = 0;
                        }
                        else
                        {
                            produto.peso = Convert.ToDouble(dados.Rows[i]["PESO"]);
                        }

                        if (dados.Rows[i]["STOK_OFF"].ToString() == "" || dados.Rows[i]["STOK_OFF"] == null)
                        {
                            produto.stok_off = 0;
                        }
                        else
                        {
                            produto.stok_off = Convert.ToInt32(dados.Rows[i]["STOK_OFF"]);
                        }
                        produto.imagem   = dados.Rows[i]["IMAGEM"].ToString();

                        listaProdutos.Add(produto);
                    }

                    return listaProdutos;
                }
            }
            catch (Exception ex)
            {
                writeLog = new WriteLog();
                writeLog.WriteErrorMessage(i.ToString() + ex.Message);
                throw;
            }
        }

        public DataTable puvAtualizarEstoque()
        {
            try
            {
                using (conexaoFirebird = new FbConnection(Conexoes.conexaoSjobs))
                {
                    conexaoFirebird.Open();
                    dados = new DataTable();
                    comandoFirebird = new FbCommand();
                    comandoSql = new StringBuilder();

                    comandoSql.Append(" SELECT IDPRO, ");
                    comandoSql.Append(" P.STOK_OFF, P." + PrimaveraSync.Properties.Settings.Default.spotTabPrice);
                    comandoSql.Append(" FROM SJ4PRO WHERE P.DIVISAO IN (" + divisao + ")");
                    

                    comandoFirebird.CommandText = comandoSql.ToString();
                    comandoFirebird.Connection = conexaoFirebird;
                    dados.Load(comandoFirebird.ExecuteReader());

                    //conectaWebService(12345, 15);

                    return dados;
                }
            }
            catch (Exception ex)
            {
                writeLog = new WriteLog();
                writeLog.WriteErrorMessage(ex.Message);
                throw;
            }
        }

        public DataTable pdtSincronizaTabelas(int idpat)
        {
            try
            {
                using (conexaoFirebird = new FbConnection(Conexoes.conexaoBDG))
                {
                    conexaoFirebird.Open();
                    dados = new DataTable();
                    comandoFirebird = new FbCommand();
                    comandoSql = new StringBuilder();

                    string atacado, avista, promocao, varejo, syncAtacado, syncAvista, syncPromocao;

                    syncAtacado = Properties.Settings.Default.syncTabWholesale;
                    syncAvista = Properties.Settings.Default.syncTabSpot;
                    syncPromocao = Properties.Settings.Default.syncTabPromo;

                    atacado  = Properties.Settings.Default.wholesaleTabPrice;
                    avista   = Properties.Settings.Default.spotTabPrice;
                    promocao = Properties.Settings.Default.promoTabPrice;
                    varejo   = Properties.Settings.Default.retailTabPrice;

                    //comandoSql.Append(" SELECT " + atacado + "," + avista + ", " + promocao + "," + varejo + " ");
                    comandoSql.Append(" SELECT ");
                    
                    comandoSql.Append(varejo);
                    
                    if (syncAtacado == "S")
                    {
                        comandoSql.Append("," + atacado);
                    }
                    if (syncAvista == "S")
                    {
                        comandoSql.Append("," + avista);
                    }
                    if (syncPromocao == "S")
                    {
                        comandoSql.Append("," + promocao);
                    }
                    comandoSql.Append(" ");
                    comandoSql.Append(" FROM P2PAT WHERE IDPAT = @IDPAT AND TAB11 > 0 ");
                    if (syncAtacado == "S")
                    {
                        comandoSql.Append(" AND TAB12 > 0");
                    }
                    if (syncAvista == "S")
                    {
                        comandoSql.Append(" AND TAB13 > 0");
                    }
                    if (syncPromocao == "S")
                    {
                        comandoSql.Append(" AND TAB14 > 0");
                    }

                    comandoFirebird.Parameters.Add(new FbParameter("@IDPAT", idpat));

                    comandoFirebird.CommandText = comandoSql.ToString();
                    comandoFirebird.Connection  = conexaoFirebird;
                    dados.Load(comandoFirebird.ExecuteReader());

                    return dados;
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
