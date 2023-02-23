using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_alfa_people.Services
{
    internal class ConexaoService
    {
        public static CrmServiceClient GetService()
        {
            string url = "https://orgbf9820cf.crm2.dynamics.com/";
            string clientId = "f8d1b742-37df-4cd1-9deb-2efd717664ba";
            string clientSecret = "flf8Q~RAbjrc3U3oCf4EyUxeAulB5.bfEyAavcrL";
            CrmServiceClient serviceClient = new CrmServiceClient($"AuthType=ClientSecret;Url={url};AppId={clientId};ClientSecret={clientSecret};");
            if (!serviceClient.CurrentAccessToken.Equals(null))
                Console.WriteLine("Conexão Realizada com Sucesso");
            else
                Console.WriteLine("Erro na conexão");
            return serviceClient;

        }
    }
}
