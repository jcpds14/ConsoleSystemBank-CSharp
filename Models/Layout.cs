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
        private static int option = 0;
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

            option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                SingUpWindow();
            }
            else if (option == 2)
            {
                SingInWindow();
            }
            // Adicionar verificação caso o usuário digite um valor diferente de um inteiro
            else
            {
                Console.WriteLine("Opção inválida!");
                return;
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
        }
    }
}