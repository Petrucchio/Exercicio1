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
            string url = "";
            string clientId = "";
            string clientSecret = "";
            CrmServiceClient serviceClient = new CrmServiceClient($"AuthType=ClientSecret;Url={url};AppId={clientId};ClientSecret={clientSecret};");

            if (!serviceClient.CurrentAccessToken.Equals(null))
                Console.WriteLine("Conexão Realizada com Sucesso");
            else
                Console.WriteLine("Erro na conexão");
                return serviceClient;
            
        }
    }
}
