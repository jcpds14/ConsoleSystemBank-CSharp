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
            Console.WriteLine("            2 - Entrar com CPF e Senha                 ");
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
            Console.WriteLine("            Digite seu CPF:                              ");
            string cpf = Console.ReadLine();
            Console.WriteLine("            ------------------------------               ");
            Console.WriteLine("            Digite sua Senha:                            ");
            string password = Console.ReadLine();
            Console.WriteLine("            ------------------------------               ");

            CheckingAccount checkingAccount = new CheckingAccount();
            Person person = new Person();

            person.SetName(name);
            person.SetCPF(cpf);
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
            Console.WriteLine("            Digite seu CPF:                            ");
            string cpf = Console.ReadLine();
            Console.WriteLine("            ------------------------------               ");
            Console.WriteLine("            Digite sua Senha:                            ");
            string password = Console.ReadLine();
            Console.WriteLine("            ------------------------------               ");
            //Vai buscar o primeiro ou o único registro dentro da lista selecionada
            Person person = persons.FirstOrDefault(x => x.CPF == cpf && x.Password == password);

            if (person != null)
            {
                WelcomeWindow(person);
                AccountLoggedInWindow(person);
            }
            else
            {
                Console.Clear();


                Console.WriteLine("                     CPF Inválido!                   ");
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
                    DepositWindow(person);
                    break;
                case "2":
                    WithDrawWindow(person);
                    break;
                case "3":
                    BalanceWindow(person);
                    break;
                case "4":
                    BankStatementWindow(person);
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

        private static void DepositWindow(Person person)
        {
            Console.Clear();

            WelcomeWindow(person);

            Console.WriteLine("              Digite o valor de Depósito:                 ");
            double value = double.Parse(Console.ReadLine());
            Console.WriteLine("          ==================================              ");

            person.Account.Deposit(value);

            Console.Clear();

            WelcomeWindow(person);
            Console.WriteLine("                                                          ");
            Console.WriteLine("                                                          ");
            Console.WriteLine("             Depósito realizado com Sucesso!              ");
            Console.WriteLine("           ===================================            ");
            Console.WriteLine("                                                          ");
            Console.WriteLine("                                                          ");

            OptionBackToLoggedIn(person);
        }

        private static void WithDrawWindow(Person person)
        {
            Console.Clear();

            WelcomeWindow(person);

            Console.WriteLine("           Digite o valor que deseja sacar:               ");
            double value = double.Parse(Console.ReadLine());
            Console.WriteLine("          ==================================              ");

            bool okWithDraw = person.Account.WithDraw(value);

            Console.Clear();

            WelcomeWindow(person);
            Console.WriteLine("                                                          ");
            Console.WriteLine("                                                          ");
            if (okWithDraw)
            {
                Console.WriteLine("             Saque realizado com Sucesso!                 ");
                Console.WriteLine("           ===================================            ");
            }
            else
            {
                Console.WriteLine("             Saldo Insuficiente!                          ");
                Console.WriteLine("           ===================================            ");
            }
            Console.WriteLine("                                                          ");
            Console.WriteLine("                                                          ");

            OptionBackToLoggedIn(person);
        }

        private static void BalanceWindow(Person person)
        {
            Console.Clear();

            WelcomeWindow(person);

            Console.WriteLine($"            Seu saldo é: {person.Account.BalanceInquiry()} ");
            Console.WriteLine("           ===================================              ");
            Console.WriteLine("                                                            ");

            OptionBackToLoggedIn(person);
        }

        private static void BankStatementWindow(Person person)
        {
            Console.Clear();

            WelcomeWindow(person);

            if (person.Account.BankStatement().Any())
            {
                double total = person.Account.BankStatement().Sum(x => x.Value);

                foreach (BankStatement bankStatement in person.Account.BankStatement())
                {
                    Console.WriteLine("                                                          ");
                    Console.WriteLine($"             Data da movimentação: {bankStatement.Date.ToString("dd/MM/yyyy HH:mm:ss")}  ");
                    Console.WriteLine($"             Tipo da movimentação: {bankStatement.Description}  ");
                    Console.WriteLine($"             Valor da movimentação: {bankStatement.Value}  ");
                    Console.WriteLine("           ===================================            ");
                }

                Console.WriteLine("                                                          ");
                Console.WriteLine("                                                          ");
                Console.WriteLine($"                   SUB TOTAL: {total}                    ");
                Console.WriteLine("           ===================================            ");
            }
            else
            {
                Console.WriteLine("               Não há extrato a ser exibido!              ");
                Console.WriteLine("           ===================================            ");
            }

            OptionBackToLoggedIn(person);
        }

        private static void OptionBackToLoggedIn(Person person)
        {
            Console.WriteLine("                Escolha uma opção abaixo                  ");
            Console.WriteLine("           ===================================            ");
            Console.WriteLine("             1 - Voltar para minha conta                  ");
            Console.WriteLine("           ===================================            ");
            Console.WriteLine("             2 - Sair                                     ");
            Console.WriteLine("           ===================================            ");

            string option = Console.ReadLine();

            if (option == "1")
                AccountLoggedInWindow(person);
            else
                MainWindow();
        }

        private static void OptionBackLoggedOff()
        {
            Console.WriteLine("                Escolha uma opção abaixo                  ");
            Console.WriteLine("           ===================================            ");
            Console.WriteLine("             1 - Voltar para o menu Principal             ");
            Console.WriteLine("           ===================================            ");
            Console.WriteLine("             2 - Sair                                     ");
            Console.WriteLine("           ===================================            ");

            string option = Console.ReadLine();

            if (option == "1")
                MainWindow();
            else
            {
                Console.WriteLine("                Opção inválida!                       ");
                Console.WriteLine("          ============================                ");
            }
        }
    }
}