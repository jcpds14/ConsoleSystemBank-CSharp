using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet.Models
{
    public class Layout
    {
        /*
        !static porque não está atrelado ao banco de dados, daí vai armazenar
        !dados enquanto o sistema estiver em execução.
        *MISSÃO: ADICIONAR UM BANDO DE DADOS E UMA API*
        *MISSION: ADD DATABASE AND A API*
        */
        private static List<Person> persons = new List<Person>();
        private static string option;
        public static void MainWindow()
        {

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Clear();//Limpar tela para aplicar a cor de background

            Console.WriteLine("                                                         ");
            Console.WriteLine("            Digite a opção desejada:                     ");
            Console.WriteLine("            ------------------------------               ");
            Console.WriteLine("            1 - Criar Conta                              ");
            Console.WriteLine("            ------------------------------               ");
            Console.WriteLine("            2 - Entrar com Login e Senha                 ");
            Console.WriteLine("            ------------------------------               ");

            option = Console.ReadLine();

            if (option == "1")
            {
                SingUpWindow();
            }
            else if (option == "2")
            {
                SingInWindow();
            }
            // Adicionar verificação caso o usuário digite um valor diferente de um inteiro
            else
            {
                Console.WriteLine("Opção inválida!");
                //Espera 1 segundo para ir para voltar ao Main Menu
                Thread.Sleep(1000);
                MainWindow();
            }
        }
        private static void SingUpWindow()
        {
            Console.Clear();

            Console.WriteLine("                                                         ");
            Console.WriteLine("            Digite seu nome:                             ");
            string name = Console.ReadLine();
            Console.WriteLine("            ------------------------------               ");
            Console.WriteLine("            Digite seu Login:                            ");
            string login = Console.ReadLine();
            Console.WriteLine("            ------------------------------               ");
            Console.WriteLine("            Digite sua Senha:                            ");
            string password = Console.ReadLine();
            Console.WriteLine("            ------------------------------               ");

            CheckingAccount checkingAccount = new CheckingAccount();
            Person person = new Person();

            person.SetName(name);
            person.SetLogin(login);
            person.SetPassword(password);
            //isso foi possível porque chekingAccount está vinvulado a Account
            //que está vinculado a IAccount
            person.Account = checkingAccount;

            persons.Add(person);//!MUDAR PARA DB

            Console.Clear();

            Console.WriteLine("            Usuário cadastrado com sucesso!              ");
            Console.WriteLine("            ------------------------------               ");
            //Espera 1 segundo para ir para a tela logada
            Thread.Sleep(1000);

            AccountLoggedInWindow(person);
        }
        private static void SingInWindow()
        {
            Console.Clear();

            Console.WriteLine("                                                         ");
            Console.WriteLine("            Digite seu Login:                            ");
            string login = Console.ReadLine();
            Console.WriteLine("            ------------------------------               ");
            Console.WriteLine("            Digite sua Senha:                            ");
            string password = Console.ReadLine();
            Console.WriteLine("            ------------------------------               ");
            //Vai buscar o primeiro ou o único registro dentro da lista selecionada
            Person person = persons.FirstOrDefault(x => x.Login == login && x.Password == password);

            if (person != null)
            {
                WelcomeWindow(person);
                AccountLoggedInWindow(person);
            }
            else
            {
                Console.Clear();


                Console.WriteLine("                     Login Inválido!                   ");
                Console.WriteLine("            ----------------------------------         ");
                Thread.Sleep(1000);
                Console.WriteLine("                Deseja tentar novamente?               ");
                Console.WriteLine("            ----------------------------------         ");
                Console.WriteLine("                       1 - SIM                         ");
                Console.WriteLine("            ----------------------------------         ");
                Console.WriteLine("                       2 - NÃO                         ");

                string option = Console.ReadLine();

                if (option == "1")
                {
                    SingInWindow();
                }
                else
                {
                    MainWindow();
                }
            }

        }
        private static void WelcomeWindow(Person person)
        {

            string WelcomeWindowMsg = $"{person.Name} | " +
            $"Banco: {person.Account.GetBankCode()} | " +
            $"Agência: {person.Account.GetAgencyNumber()} | " +
            $"Conta: {person.Account.GetAccountNumber()}";

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Seja bem-vindo {WelcomeWindowMsg}");
            Console.WriteLine();
            Console.WriteLine();
        }
        private static void AccountLoggedInWindow(Person person)
        {
            Console.Clear();

            WelcomeWindow(person);

            Console.WriteLine("                                                         ");
            Console.WriteLine("            Digite a opção desejada:                     ");
            Console.WriteLine("            ------------------------------               ");
            Console.WriteLine("            1 - Realizar um Depósito                     ");
            Console.WriteLine("            ------------------------------               ");
            Console.WriteLine("            2 - Saque                                    ");
            Console.WriteLine("            ------------------------------               ");
            Console.WriteLine("            3 - Saldo                                    ");
            Console.WriteLine("            ------------------------------               ");
            Console.WriteLine("            4 - Extrato                                  ");
            Console.WriteLine("            ------------------------------               ");
            Console.WriteLine("            5 - Sair                                     ");
            Console.WriteLine("            ------------------------------               ");

            option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    MainWindow();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("                   Opção inválida!                       ");
                    Console.WriteLine("            ------------------------------               ");
                    //Espera 1 segundo para voltar ao menu
                    Thread.Sleep(1000);
                    AccountLoggedInWindow(person);
                    break;
            }

        }
    }
}