using System;
using System.IO;
using System.Threading;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Editor de texto. informe o que deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");
            Console.Write("opção: ");

            short option = short.Parse(Console.ReadLine());

            Console.Clear();

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: AbrirArquivo(); break;
                case 2: CriarNovoArquivo(); break;
                default: Menu(); break;
            }
        }



        private static void AbrirArquivo()
        {
            Console.Write("Informe o local + nome do arquivo: ");
            string path = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("(Para Sair, digite /esc em nova linha)");
            Console.WriteLine("-----------------------------------------");

            string text = String.Empty;
            using (var file = new StreamReader(path))
            {
                text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            text = ConstruirTexto(text);

            SalvarArquivo(text);
        }

        private static void CriarNovoArquivo()
        {
            Console.Clear();
            Console.WriteLine("Digite seu text abaixo da linha tracejada. (Para Sair, digite /esc em nova linha)");
            Console.WriteLine("-----------------------------------------");

            String text = "";

            // do
            // {
            //     string auxText = Console.ReadLine();
            //     text += auxText;
            //     text += Environment.NewLine;
            // } while (Console.ReadKey().Key != ConsoleKey.Escape);
            text = ConstruirTexto(text);

            SalvarArquivo(text);
        }

        private static string ConstruirTexto(string text)
        {
            string auxText = "";
            while (auxText != "\\esc")
            {
                auxText = Console.ReadLine();
                if (auxText != "\\esc")
                {
                    text += auxText;
                    text += Environment.NewLine;
                }
            }

            return text;
        }

        private static void SalvarArquivo(string text)
        {
            Console.Write("Caminho para salvar o arquivo: ");
            string path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo salvo com sucesso em {path}");
            Thread.Sleep(2000);

            Menu();
        }
    }
}
