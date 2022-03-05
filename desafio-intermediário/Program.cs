namespace desafio_intermediário
{
    class Program
    {
        static void Main(string[] args)
        {
            string primeirOpcaoDoUsuario = PrimeiraObterOpcaoUsuario();

            while (primeirOpcaoDoUsuario.ToUpper() != "X")
            {
                switch (primeirOpcaoDoUsuario)
                {
                    case "1":
                        var escolha1 = new SecaoSeries();
                        escolha1.ObterSecaoSeries();
                        break;

                    case "2":
                        var escolha2 = new SecaoFilmes();
                        escolha2.ObterSecaoFilmes();
                        break;

                    case "3":
                        var escolha3 = new SecaoDesenhos();
                        escolha3.ObterSecaoDesenhos();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                primeirOpcaoDoUsuario = PrimeiraObterOpcaoUsuario();
            }

            Console.WriteLine("Sogra desce!!!!!!!!!");
            Console.ReadLine();
        }
        public static string PrimeiraObterOpcaoUsuario()
            {
                Console.WriteLine();
                Console.WriteLine("Séries a seu dispor!!!");
                Console.WriteLine("Informe a opção desejada:");
                Console.WriteLine("1- Seção Séries");
                Console.WriteLine("2- Seção Filmes");
                Console.WriteLine("3- Seção Desenhos");
                Console.WriteLine("C- Limpar Tela");
                Console.WriteLine("X- Sair");
                Console.WriteLine();

                

                string opcaoUsuario = Console.ReadLine().ToUpper();
                return opcaoUsuario;
            }
    }
}


