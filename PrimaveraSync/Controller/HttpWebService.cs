using System;
using System.IO;
using System.Net;
using PrimaveraSync.Utils;
using PrimaveraSync.Model;

namespace PrimaveraSync.Controller
{
    class HttpWebService
    {
        
        public string prvHttpWebService(string acao, string metodo, string parametros, string escreveString)
        {
            WriteLog writeLog;
            string resposta = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Conexoes.conexaoEcommerce() + acao + parametros);
            //request.Method = "GET";
            request.Method = metodo;
            if(escreveString == "false")
            {
                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            throw new ApplicationException("Error code: " + response.StatusCode.ToString());
                        }
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            if (responseStream != null)
                            {
                                using (StreamReader reader = new StreamReader(responseStream))
                                {
                                    resposta = reader.ReadToEnd();
                                }
                            }
                        }
                    }
                    return resposta;
                }
                catch (Exception ex)
                {
                    writeLog = new WriteLog();
                    writeLog.WriteErrorMessage(ex.Message);
                    throw;
                }
            }
            else
            {
                return request.Address.AbsoluteUri.ToString();
            }
        }
    }
}
