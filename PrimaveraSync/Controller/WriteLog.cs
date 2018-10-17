using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaveraSync.Controller
{
    public class WriteLog
    {
        public void WriteErrorMessage(String mensagem)
        {
            try
            {
                string local = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "log.txt";
                using (StreamWriter arquivo = new StreamWriter(local, true))
                {
                    string novaMensagem = "";
                    novaMensagem += "Data/Hora: " + DateTime.Now.ToLocalTime() + "\r\n";
                    novaMensagem += "Mensagem: " + mensagem;
                    novaMensagem += "\r\n\r\n--------------------------------------------------------\r\n";
                    arquivo.WriteLine(novaMensagem);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao gravar o log na pasta de logs, mensagem de erro: \n" + ex.Message);
            }
        }
    }
}
