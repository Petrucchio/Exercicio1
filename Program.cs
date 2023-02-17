using Exercicio_alfa_people.Controller;
using Exercicio_alfa_people.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_alfa_people
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CrmServiceClient serviceClient = ConexaoService.GetService();

            AccountController contaController = new AccountController(serviceClient);

            EntityCollection accountsToExecute = new EntityCollection();

            Entity account1 = new Entity("account");
            account1["name"] = "Conta 1";
            accountsToExecute.Entities.Add(account1);

            Entity account2 = new Entity("account", new Guid("81883308-7ad5-ea11-a813-000d3a33f3b4"));
            account2["name"] = "Conta 2";
            accountsToExecute.Entities.Add(account2);

            contaController.UpsertMultipleRequest(accountsToExecute);

            Console.WriteLine("Contas Criadas e Atualizadas com Sucesso");

            Console.ReadKey();
        }

    }
}
