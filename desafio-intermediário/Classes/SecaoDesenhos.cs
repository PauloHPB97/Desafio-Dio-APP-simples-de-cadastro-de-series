using desafio_intermediário.Classes;

namespace desafio_intermediário
{
    public class SecaoDesenhos
    {
        static DesenhoRepositorio repositorio = new DesenhoRepositorio();
        
        public void ObterSecaoDesenhos()
        {

            string opcaoDoUsuario = ObterOpcaoUsuario();

            while (opcaoDoUsuario.ToUpper() != "X")
            {
                switch (opcaoDoUsuario)
                {
                    case "1":
                        ListarDesenhos();
                        break;

                    case "2":
                        InserirDesenho();
                        break;

                    case "3":
                        AtualizarDesenho();
                        break;

                    case "4":
                        ExcluirDesenho();
                        break;

                    case "5":
                        VizualizarDesenho();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoDoUsuario = ObterOpcaoUsuario();
            }

        }

        public static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Seção de Desenhos!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar desenhos");
            Console.WriteLine("2- Inserir novo desenho");
            Console.WriteLine("3- Atualizar desenho");
            Console.WriteLine("4- Excluir desenho");
            Console.WriteLine("5- Visualizar desenho");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Voltar ao menu principal");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }



        private static void ListarDesenhos()
        {
            Console.WriteLine();
            Console.WriteLine("Lista de desenho:");

            var lista = repositorio.Lista();
            

            if (lista.Count == 0)
            {
                Console.WriteLine("Lista não existente");
                return;
            }

            foreach (var desenho in lista)
            {
                Console.WriteLine("#ID: {0} - {1} {2}", desenho.retornaId(), desenho.retornaTitulo(), (desenho.retornaExcluido() ? "*Obs: O desenho foi exluído*" : ""));
            }
        }

        private static void InserirDesenho()
        {
            Console.WriteLine();
            Console.WriteLine("Inserir um novo desenho");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima:");
            int generoNovo = int.Parse(Console.ReadLine());

            if (generoNovo > Enum.GetValues(typeof(Genero)).Length)
            {
                generoNovo = ValidarGenero(generoNovo);
            }

            Console.WriteLine("Digite o título do desenho:");
            string tituloNovo = Console.ReadLine();

            Console.WriteLine("Digite a quantidade de episódios:");
            int quantidadeEpisodiosNovo = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do criador:");
            string criadorNovo = Console.ReadLine();

            Console.WriteLine("Digite o nome da emissora de exibição do desenho:");
            string emissoraNova = Console.ReadLine();


            Desenho desenhoNovo = new Desenho(
                id: repositorio.ProximoId(),
                genero: (Genero)generoNovo,
                titulo: tituloNovo,
                quantidadeEpisodios: quantidadeEpisodiosNovo,
                criador: criadorNovo,
                emissora: emissoraNova,
                excluido: false
            );
            repositorio.Insere(desenhoNovo);
        }

        private static void AtualizarDesenho()
        {
            Console.WriteLine();
            Console.WriteLine("Atualizar Desenho");
            Console.WriteLine("Digite a id do desenho a ser atualizado: ");
            int idDesenho = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite qual o atual gênero entre as opções acima:");
            int generoAtualizado = int.Parse(Console.ReadLine());

            if (generoAtualizado > Enum.GetValues(typeof(Genero)).Length)
            {
                generoAtualizado = ValidarGenero(generoAtualizado);
            }

            Console.WriteLine("Digite o título do desenho:");
            string tituloAtualizado = Console.ReadLine();

            Console.WriteLine("Digite a quantidade de episódios:");
            int quantidadeEpisodiosAtualizado = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o atual nome do criador:");
            string criadorAtualizado = Console.ReadLine();

            Console.WriteLine("Digite o atual nome da emissora de exibição do desenho:");
            string emissoraAtualizado = Console.ReadLine();


            Desenho desenhoAtualizado = new Desenho(
                id: idDesenho,
                genero: (Genero)generoAtualizado,
                titulo: tituloAtualizado,
                quantidadeEpisodios: quantidadeEpisodiosAtualizado,
                criador: criadorAtualizado,
                emissora: emissoraAtualizado,
                excluido: false
            );
            repositorio.Atualizar(idDesenho, desenhoAtualizado);
        }

        private static void ExcluirDesenho()
        {
            Console.WriteLine();
            Console.WriteLine("Excluir Desenho");
            Console.WriteLine("Digite a id do desenho a ser excluído: ");
            int idDesenhoExcluido = int.Parse(Console.ReadLine());

            repositorio.Excluir(idDesenhoExcluido);
        }

        private static void VizualizarDesenho()
        {
            Console.WriteLine();
            Console.WriteLine("Vizualizar desenho");
            Console.WriteLine("Digite a id do desenho a ser vizualizado: ");
            int idDesenhoVizualizado = int.Parse(Console.ReadLine());

            var desenhoVizualizado = repositorio.RetornaPorId(idDesenhoVizualizado);
            Console.WriteLine(desenhoVizualizado);
        }

        private static int ValidarGenero(int genero)
        {
            while (genero > 13)
            {
                Console.WriteLine("Opção não encontrada. Digite um número das opções acima!");
                genero = int.Parse(Console.ReadLine());
            }
            int generoNovo = genero;
            return generoNovo;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}