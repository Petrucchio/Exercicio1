using Exercicio_alfa_people.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_alfa_people.Controller
{
    internal class AccountController
    {
        public CrmServiceClient ServiceClient { get; set; }
        public Account Conta { get; set; }

        public AccountController(CrmServiceClient crmServiceCliente)
        {
            ServiceClient = crmServiceCliente;
            this.Conta = new Account(ServiceClient);
        }

        public Guid Create()
        {
            return Conta.Create();
        }

        public bool Update(Guid accountId, string telephone1)
        {
            return Conta.Update(accountId, telephone1);
        }

        public bool Delete(Guid accountId)
        {
            return Conta.Delete(accountId);
        }

        public Entity GetAccountById(Guid id)
        {
            return Conta.GetAccountById(id);
        }

        public Entity GetAccountByName(string name)
        {
            return Conta.GetAccountByName(name);
        }

        public Entity GetAccountByContactName(string name, string[] columns)
        {
            return Conta.GetAccountByContactName(name, columns);
        }

        public Entity GetAccountByTelephone(string telephone)
        {
            return Conta.GetAccountByTelephone(telephone);
        }

        public EntityCollection GetAccountByLike(string like)
        {
            return Conta.GetAccountByLike(like);
        }

        public void UpsertMultipleRequest(EntityCollection entityCollection)
        {
            Conta.UpsertMultipleRequest(entityCollection);
        }
        private static void RetrieveMethods(AccountController contaController)
        {
            Console.WriteLine("1 - Pesquisar uma conta por id");
            Console.WriteLine("2 - Pesquisar uma conta por nome");
            Console.WriteLine("3 - Pesquisar uma conta por nome do contato");
            Console.WriteLine("4 - Pesquisar uma conta por telefone");
            Console.WriteLine("5 - Pesquisar várias contas");

            var answer = Console.ReadLine();

            switch (answer)
            {
                case "1":
                    Console.WriteLine("Qual o id da conta que você deseja pesquisar");
                    var accountId = Console.ReadLine();
                    Entity accountById = contaController.GetAccountById(new Guid(accountId));
                    ShowAccountName(accountById);
                    break;
                case "2":
                    Console.WriteLine("Qual o nome da conta que você deseja pesquisar");
                    var name = Console.ReadLine();
                    Entity accountByName = contaController.GetAccountByName(name);
                    Console.WriteLine($"O telefone da conta recuperada é {accountByName["telephone1"].ToString()}");
                    break;
                case "3":
                    Console.WriteLine("Qual o nome do contato relacionado a conta que você deseja pesquisar");
                    var nameContact = Console.ReadLine();
                    Entity accountByContact = contaController.GetAccountByContactName(nameContact, new string[] { "name" });
                    ShowAccountName(accountByContact);
                    break;
                case "4":
                    Console.WriteLine("Qual o telefone da conta que você deseja pesquisar");
                    var telephone = Console.ReadLine();
                    Entity accountByTelephone = contaController.GetAccountByTelephone(telephone);
                    ShowAccountName(accountByTelephone);
                    break;
                case "5":
                    Console.WriteLine("A conta que você pesquisa, começa com?");
                    var like = Console.ReadLine();
                    EntityCollection accounts = contaController.GetAccountByLike(like);

                    foreach (Entity account in accounts.Entities)
                    {
                        Console.WriteLine(account["name"].ToString());
                    }
                    break;
                default:
                    Console.WriteLine("Opção inválida, reinicie o aplicativo");
                    break;
            }
        }

        private static void ShowAccountName(Entity account)
        {
            Console.WriteLine($"A conta recuperada se chama {account["name"].ToString()}");
        }

        private static void CreateUpdateDelete(AccountController contaController)
        {
            Console.WriteLine("Digite 1 para Create/Update");
            Console.WriteLine("Digite 2 para Delete");

            var answerWhatToDo = Console.ReadLine();

            if (answerWhatToDo.ToString() == "1")
            {
                MakeCreateAndUpdate(contaController);
            }
            else
            {
                if (answerWhatToDo.ToString() == "2")
                {
                    MakeDelete(contaController);
                }
                else
                {
                    Console.WriteLine("Opção inválida, reinicie o aplicativo");
                }
            }
        }

        private static void MakeDelete(AccountController contaController)
        {
            Console.WriteLine("Digite o id da conta que você quer deletar");
            var accountId = Console.ReadLine();
            contaController.Delete(new Guid(accountId));
            Console.WriteLine("Deletado com sucesso!");
        }

        private static void MakeCreateAndUpdate(AccountController contaController)
        {
            Console.WriteLine("Aguarde enquanto a nova Conta é criada");
            Guid accountId = contaController.Create();
            Console.WriteLine("Conta criada com sucesso");

            Console.WriteLine($"https://dynacoop2023.crm2.dynamics.com/main.aspx?appid=4d306bb3-f4a9-ed11-9885-000d3a888f48&pagetype=entityrecord&etn=account&id={accountId}");

            Console.WriteLine("Deseja fazer a atualização da conta recém criada? (S/N)");
            var answerToUpdate = Console.ReadLine();

            if (answerToUpdate.ToString().ToUpper() == "S")
            {
                Console.WriteLine("Por favor informe o novo telefone");
                var newTelephone = Console.ReadLine();
                bool contaAtualizada = contaController.Update(accountId, newTelephone);

                if (contaAtualizada)
                    Console.WriteLine("Conta atualizada com sucesso");
                else
                    Console.WriteLine("Erro na atualização da conta");
            }
        }
    }
}
