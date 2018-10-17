using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrimaveraSync.Controller;
using PrimaveraSync.Model;

namespace PrimaveraSync
{
    public partial class Form1 : Form
    {
        SyncPedido syncPedido;
        SyncCliente syncCliente;
        SyncProduto syncProduto;
        Pedido pedidos;
        Pedidos pedidosEcommerce;
        Clientes clientes;
        DataTable dados;
        DataTable dadosTab;
        bool syncPedidos = true;
        bool syncProdutos = true;
        WriteLog writeLog;

        public Form1()
        {
            InitializeComponent();
        }

        private void prvInsertPedidos(PedidoEcommerce pedidoEcommerce, ItemPedidoComp itemPedidoComp, List<ItemPedidoComp> itensPedidoComp, int qtd)
        {
            int idped = 0;
            syncPedido = new SyncPedido();
            idped = syncPedido.puvInsertPedido(pedidoEcommerce);
            if(qtd == 1)
            {
                syncPedido.puvInsertItens(itemPedidoComp, idped);
            }
            else
            {
                for (int i = 0; i < qtd; i++)
                {
                    syncPedido.puvInsertItens(itensPedidoComp[i], idped);
                }
            }
        }

        private void prvInsertClientes(DadosCliente cliente)
        {
            syncCliente = new SyncCliente();
            syncCliente.puvInsertCliente(cliente);
        }

        private void prvGetProdutos()
        {
            string syncAtacado, syncAvista, syncPromocao;

            syncAtacado = Properties.Settings.Default.syncTabWholesale;
            syncAvista = Properties.Settings.Default.syncTabSpot;
            syncPromocao = Properties.Settings.Default.syncTabPromo;

            dados = new DataTable();
            syncProduto = new SyncProduto();
            List<Produto> listaProdutos = new List<Produto>();
            if (txtCpro.TextLength > 0)
            {
                listaProdutos = syncProduto.puvAtualizarProduto(txtCpro.Text);
            }
            else
            {
                listaProdutos = syncProduto.puvAtualizarProduto("");
            }
            for(int i = 0; i < listaProdutos.Count; i++)
            {
                dadosTab = new DataTable();
                dadosTab = syncProduto.pdtSincronizaTabelas(listaProdutos[i].idext_pro);
                if (dadosTab.Rows.Count > 0)
                {
                    //retorno vem varejo atacado avista promocao
                    if (dadosTab.Rows[0][0].ToString().Length > 0)
                    {
                        listaProdutos[i].retailTabPrice = Convert.ToDouble(dadosTab.Rows[0][0]); //varejo;
                    }
                    else
                    {
                        listaProdutos[i].retailTabPrice = 0;
                    }

                    if (syncAtacado == "S")
                    {
                        if (dadosTab.Rows[0][1].ToString().Length > 0)
                        {
                            listaProdutos[i].wholesaleTabPrice = Convert.ToDouble(dadosTab.Rows[0][1]); //atacado
                        }
                        else
                        {
                            listaProdutos[i].wholesaleTabPrice = 0;
                        }
                    }
                    else
                    {
                        listaProdutos[i].wholesaleTabPrice = 0;
                    }

                    if (syncAvista == "S")
                    {
                        if (dadosTab.Rows[0][2].ToString().Length > 0)
                        {
                            listaProdutos[i].spotTabPrice = Convert.ToDouble(dadosTab.Rows[0][2]); //avista
                        }
                        else
                        {
                            listaProdutos[i].spotTabPrice = 0;
                        }
                    }
                    else
                    {
                        listaProdutos[i].spotTabPrice = 0;
                    }

                    if (syncPromocao == "S")
                    {
                        if (dadosTab.Rows[0][3].ToString().Length > 0)
                        {
                            listaProdutos[i].promoTabPrice = Convert.ToDouble(dadosTab.Rows[0][3]); //promocao;
                        }
                        else
                        {
                            listaProdutos[i].promoTabPrice = 0;
                        }
                    }
                    else
                    {
                        listaProdutos[i].promoTabPrice = 0;
                    }
                }
            }
            dtgResultado.DataSource = listaProdutos;
            lblTtlRegs.Text = "Total de registros: " + listaProdutos.Count;
            pgbProgresso.Visible = true;
            lblProduto.Visible = true;
            pgbProgresso.Maximum = dtgResultado.Rows.Count;
            for (int i = 1; i <= dtgResultado.Rows.Count; i++)
            {
                lblProduto.Text = "IDPRO: " + Convert.ToInt32(listaProdutos[i - 1].idpro) +
                                  ", PRODUTO: " + (listaProdutos[i - 1].produto) +
                                  ", "+ PrimaveraSync.Properties.Settings.Default.spotTabPrice + ": " + Convert.ToDouble(listaProdutos[i - 1].spotTabPrice) +
                                  ", STOK_OFF: " + Convert.ToInt32(listaProdutos[i - 1].stok_off);
                string escreveString = "";
                if(cbxEscreveString.Checked == true)
                {
                    escreveString = "true";
                }
                else
                {
                    escreveString = "false";
                }

                txtResult.Text += syncProduto.sincronizarProduto(listaProdutos[i - 1], escreveString);
                txtResult.Text += "\r\n\r\n\r\n";
                pgbProgresso.Value = i;
                lblTtlRegs.Text = i.ToString();
                Thread.Sleep(10);
            }
        }

        private void prvGetEstoqueProdutos()
        {
            dados = new DataTable();
            syncProduto = new SyncProduto();
            dados = syncProduto.puvAtualizarEstoque();
            dtgResultado.DataSource = dados;
            lblTtlRegs.Text = "Total de registros: " + dados.Rows.Count;
            pgbProgresso.Visible = true;
            lblProduto.Visible = true;
            pgbProgresso.Maximum = dtgResultado.Rows.Count;
            for (int i = 1; i <= dtgResultado.Rows.Count; i++)
            {
                lblProduto.Text = "IDPRO: "     + Convert.ToInt32 (dtgResultado.Rows[i - 1].Cells["IDPRO"]  .Value)   + 
                                  ", PRODUTO: "  +                 (dtgResultado.Rows[i - 1].Cells["PRODUTO"].Value)     + 
                                  ", " + PrimaveraSync.Properties.Settings.Default.spotTabPrice + ": " + Convert.ToDouble(dtgResultado.Rows[i - 1].Cells[PrimaveraSync.Properties.Settings.Default.spotTabPrice]   .Value)    +
                                  ", STOK_OFF: " + Convert.ToInt32 (dtgResultado.Rows[i - 1].Cells["STOK_OFF"]   .Value)    ;
                syncProduto.conectaWebService(Convert.ToInt32(dtgResultado.Rows[i-1].Cells["IDPRO"].Value), Convert.ToInt32(dtgResultado.Rows[i-1].Cells["STOK_OFF"].Value), "estoque");
                syncProduto.conectaWebService(Convert.ToInt32(dtgResultado.Rows[i-1].Cells["IDPRO"].Value), Convert.ToDouble(dtgResultado.Rows[i-1].Cells[PrimaveraSync.Properties.Settings.Default.spotTabPrice].Value), "preco");
                pgbProgresso.Value = i;
                lblTtlRegs.Text = i.ToString();
            }
        }

        private void btnReceberClientes_Click(object sender, EventArgs e)
        {
            syncCliente = new SyncCliente();
            clientes = new Clientes();
            clientes = syncCliente.prvGetClientesEcommerce();

            txtResult.Clear();

            for(int i = 0; i < clientes.cliente.Count; i++)
            {
                txtResult.Text += "Cliente: " + i;
                txtResult.Text += "\r\nindicadorOrigem  : ";
                txtResult.Text += clientes.cliente[i].indicadorOrigem;
                txtResult.Text += "\r\ncodigoClienteWeb  : ";
                txtResult.Text += clientes.cliente[i].codigoClienteWeb;
                txtResult.Text += "\r\ncodigoIBGECidade  : ";
                txtResult.Text += clientes.cliente[i].codigoIBGECidade;
                txtResult.Text += "\r\nnome  : ";
                txtResult.Text += clientes.cliente[i].nome;
                txtResult.Text += "\r\nnomeContato  : ";
                txtResult.Text += clientes.cliente[i].nomeContato;
                txtResult.Text += "\r\ntipoPessoa  : ";
                txtResult.Text += clientes.cliente[i].tipoPessoa;
                txtResult.Text += "\r\ncpfCNPJ  : ";
                txtResult.Text += clientes.cliente[i].cpfCNPJ;
                txtResult.Text += "\r\ndataCadastro  : ";
                txtResult.Text += clientes.cliente[i].dataCadastro;
                txtResult.Text += "\r\ntipoLogradouro  : ";
                txtResult.Text += clientes.cliente[i].tipoLogradouro;
                txtResult.Text += "\r\nlogradouro  : ";
                txtResult.Text += clientes.cliente[i].logradouro;
                txtResult.Text += "\r\nnumeroLogradouro  : ";
                txtResult.Text += clientes.cliente[i].numeroLogradouro;
                txtResult.Text += "\r\ncomplemento  : ";
                txtResult.Text += clientes.cliente[i].complemento;
                txtResult.Text += "\r\nbairro  : ";
                txtResult.Text += clientes.cliente[i].bairro;
                txtResult.Text += "\r\ncep  : ";
                txtResult.Text += clientes.cliente[i].cep;
                txtResult.Text += "\r\nsiglaEstado  : ";
                txtResult.Text += clientes.cliente[i].siglaEstado;
                txtResult.Text += "\r\nemailContato  : ";
                txtResult.Text += clientes.cliente[i].emailContato;
                txtResult.Text += "\r\ntelefonePrincipal  : ";
                txtResult.Text += clientes.cliente[i].telefonePrincipal;
                txtResult.Text += "\r\ndddTelefonePrincipal  : ";
                txtResult.Text += clientes.cliente[i].dddTelefonePrincipal;
                txtResult.Text += "\r\n\r\n";

                prvInsertClientes(clientes.cliente[i]);
            }
        }

        private void btnStatusPedido_Click(object sender, EventArgs e)
        {
            syncPedido = new SyncPedido();
            pedidos = new Pedido();
            pedidos = syncPedido.prvGetStatusPedido();

            txtResult.Clear();

            for (int i = 0; i < pedidos.pedido.Count; i++)
            {
                txtResult.Text += "Status Pedido: " + i;
                txtResult.Text += "\r\nNumero Original: ";
                txtResult.Text += pedidos.pedido[i].numeroOriginal;
                txtResult.Text += "\r\nSituacao Pagamento: ";
                txtResult.Text += pedidos.pedido[i].situacaoPagamento;
                txtResult.Text += "\r\nSituacao Pagamento Data: ";
                txtResult.Text += pedidos.pedido[i].situacaoPagamentoData;
                txtResult.Text += "\r\nSituacao Pagamento Nome: ";
                txtResult.Text += pedidos.pedido[i].situacaoPagamentoNome;
                txtResult.Text += "\r\n\r\n";
            }
        }

        private void btnReceberPedidos_Click(object sender, EventArgs e)
        {
            ItemPedidoComp itemPedidoExt;
            List<ItemPedidoComp> itensPedidoExt;
            int qtdItem;

            if (syncPedidos == true)
            {
                syncPedido = new SyncPedido();
                pedidosEcommerce = new Pedidos();
                string escreveString = "false";
                if(getCbxEscreveString() == true)
                {
                    escreveString = "true";
                }
                else
                {
                    escreveString = "false";
                }
                pedidosEcommerce = syncPedido.prvGetPedidosEcommerce(escreveString);

                dtgResultado.DataSource = pedidosEcommerce.pedido;

                txtResult.Clear();
                lblProduto.Visible = false;
                pgbProgresso.Visible = true;
                if (pedidosEcommerce.pedido == null)
                {
                    pgbProgresso.Maximum = 0;
                }
                else
                {
                    pgbProgresso.Maximum = pedidosEcommerce.pedido.Count;
                    itensPedidoExt = new List<ItemPedidoComp>();
                    itemPedidoExt = new ItemPedidoComp();

                    for (int i = 0; i < pedidosEcommerce.pedido.Count; i++)
                    {
                        {
                            txtResult.Text += "Pedido: " + i;
                            txtResult.Text += "\r\nbairroEntrega: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].bairroEntrega;
                            txtResult.Text += "\r\ncepEntrega: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].cepEntrega;
                            txtResult.Text += "\r\ncodigoCliente: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].codigoCliente;
                            txtResult.Text += "\r\ncodigoIBGECidadeEntrega: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].codigoIBGECidadeEntrega;
                            txtResult.Text += "\r\ncomplementoEntrega: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].complementoEntrega;
                            txtResult.Text += "\r\ncpfCnpj: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].cpfCnpj;
                            txtResult.Text += "\r\ndataHoraDigitacao: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].dataHoraDigitacao;
                            txtResult.Text += "\r\nemail: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].email;
                            txtResult.Text += "\r\nidCondicaoPagamento: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].idCondicaoPagamento;
                            txtResult.Text += "\r\nidentificadorOrigem: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].identificadorOrigem;
                            txtResult.Text += "\r\nidFormaCobranca: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].idFormaCobranca;
                            txtResult.Text += "\r\nitens: ";
                            string tipoItem = pedidosEcommerce.pedido[i].itens.item.ToString();
                            try //Se for array, entra no try
                            {
                                var tipo = JsonConvert.DeserializeObject<List<ItemPedidoComp>>(tipoItem);
                                List<ItemPedidoComp> itensPedido = new List<ItemPedidoComp>();
                                itensPedido = tipo;
                                itensPedidoExt = itensPedido;
                                qtdItem = itensPedido.Count;
                                for (int j = 0; j < qtdItem; j++)
                                {
                                    txtResult.Text += "\r\n\titem[" + j + "].idProduto: ";
                                    txtResult.Text += itensPedido[j].idProduto;
                                    txtResult.Text += "\r\n\titem[" + j + "].numeroItem: ";
                                    txtResult.Text += itensPedido[j].numeroItem;
                                    txtResult.Text += "\r\n\titem[" + j + "].numeroPedido: ";
                                    txtResult.Text += itensPedido[j].numeroPedido;
                                    txtResult.Text += "\r\n\titem[" + j + "].quantidade: ";
                                    txtResult.Text += itensPedido[j].quantidade;
                                    txtResult.Text += "\r\n\titem[" + j + "].unidade: ";
                                    txtResult.Text += itensPedido[j].unidade;
                                    txtResult.Text += "\r\n\titem[" + j + "].valorUnitario: ";
                                    txtResult.Text += itensPedido[j].valorUnitario;
                                    //pedidosEcommerce.pedido[i].itens.item = itensPedido;
                                }
                            }
                            catch (Exception) //Se for objeto, entra no catch
                            {
                                try //Se der para converter o Json em objeto, entra no try
                                {
                                    var tipo = JsonConvert.DeserializeObject<ItemPedidoComp>(tipoItem);
                                    ItemPedidoComp itemPedido = new ItemPedidoComp();
                                    itemPedido = tipo;
                                    itemPedidoExt = itemPedido;
                                    qtdItem = 1;

                                    txtResult.Text += "\r\n\titem.idProduto: ";
                                    txtResult.Text += itemPedido.idProduto;
                                    txtResult.Text += "\r\n\titem.numeroItem: ";
                                    txtResult.Text += itemPedido.numeroItem;
                                    txtResult.Text += "\r\n\titem.numeroPedido: ";
                                    txtResult.Text += itemPedido.numeroPedido;
                                    txtResult.Text += "\r\n\titem.quantidade: ";
                                    txtResult.Text += itemPedido.quantidade;
                                    txtResult.Text += "\r\n\titem.unidade: ";
                                    txtResult.Text += itemPedido.unidade;
                                    txtResult.Text += "\r\n\titem.valorUnitario: ";
                                    txtResult.Text += itemPedido.valorUnitario;
                                    //pedidosEcommerce.pedido[i].itens.item = itemPedido;
                                }
                                catch (Exception ex) //Caso de algum erro, o catch retorna
                                {
                                    writeLog = new WriteLog();
                                    writeLog.WriteErrorMessage(ex.Message);
                                    throw;
                                }
                            }
                            txtResult.Text += "\r\nlogradouroEntrega: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].logradouroEntrega;
                            txtResult.Text += "\r\nnomeContato: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].nomeContato;
                            txtResult.Text += "\r\nnumeroLogradouroEntrega: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].numeroLogradouroEntrega;
                            txtResult.Text += "\r\nnumeroOriginal: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].numeroOriginal;
                            txtResult.Text += "\r\nobservacao: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].observacao;
                            txtResult.Text += "\r\nsiglaEstadoEntrega: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].siglaEstadoEntrega;
                            txtResult.Text += "\r\nsituacaoPagamento: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].situacaoPagamento;
                            txtResult.Text += "\r\ntipoFreteWeb: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].tipoFreteWeb;
                            txtResult.Text += "\r\ntipoLogradouroEntrega: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].tipoLogradouroEntrega;
                            txtResult.Text += "\r\nvalorDesconto: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].valorDesconto;
                            txtResult.Text += "\r\nvalorFrete: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].valorFrete;
                            txtResult.Text += "\r\nvalorTotal: ";
                            txtResult.Text += pedidosEcommerce.pedido[i].valorTotal;
                            txtResult.Text += "\r\n\r\n";
                        }
                        pgbProgresso.Value = (i + 1);
                        prvInsertPedidos(pedidosEcommerce.pedido[i], itemPedidoExt, itensPedidoExt, qtdItem);
                    }
                }
            }
        }

        private void btnEscreverPedidos_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSetEstoque_Click(object sender, EventArgs e)
        {
            tbcResultados.SelectedIndex = 1;
            prvGetEstoqueProdutos();
        }

        private void btnSetProdutos_Click(object sender, EventArgs e)
        {
            if (syncProdutos == true)
            {
                prvGetProdutos();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(PrimaveraSync.Properties.Settings.Default.imageLogo.Length > 0)
            pbxLogo.Load(PrimaveraSync.Properties.Settings.Default.imageLogo);
            pbxLogo.Visible = true;

            if (Properties.Settings.Default.debugMode == "N")
            {
                this.Text = "PrimaveraSync - Sincronismo automatico";

                btnReceberPedidos_Click(sender, e);
                btnSetProdutos_Click(sender, e);
                //btnSetEstoque_Click(sender, e);

                this.Text = "PrimaveraSync";
            }
        }

        private void tempoSync_Tick(object sender, EventArgs e)
        {
            this.Text = "PrimaveraSync - Sincronismo automatico";

            btnReceberPedidos_Click(sender, e);
            btnSetProdutos_Click(sender, e);
            //btnSetEstoque_Click(sender, e);

            this.Text = "PrimaveraSync";
        }

        private void tempoStart_Tick(object sender, EventArgs e)
        {
            tempoSync.Enabled = true;
            tempoSync_Tick(sender, e);
            tempoStart.Enabled = false;
            tempoStart.Stop();
        }

        private void cbxExibeGrid_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxExibeGrid.Checked == true)
            {
                tbcResultados.Visible = true;
            }
            else
            {
                tbcResultados.Visible = false;
            }
        }

        public void setTxtResult(string valor)
        {
            txtResult.Text += valor;
        }

        public bool getCbxEscreveString()
        {
            if (cbxEscreveString.Checked == true)
                return true;
            else
                return false;
        }

        private void cbxSyncPedido_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxSyncPedido.Checked == true)
            {
                syncPedidos = true;
            }
            else
            {
                syncPedidos = false;
            }
        }

        private void cbxSyncProduto_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxSyncProduto.Checked == true)
            {
                syncProdutos = true;
            }
            else
            {
                syncProdutos = false;
            }
        }

        private void cbxSyncPedido_CheckStateChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Mudou");
        }
    }
}
