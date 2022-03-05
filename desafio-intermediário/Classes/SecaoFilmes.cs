namespace desafio_intermediário
{
    public class SecaoFilmes
    {
        static FilmeRepositorio repositorio = new FilmeRepositorio();
        public void ObterSecaoFilmes()
        {

            string opcaoDoUsuario = ObterOpcaoUsuario();

            while (opcaoDoUsuario.ToUpper() != "X")
            {
                switch (opcaoDoUsuario)
                {
                    case "1":
                        ListaFilmes();
                        break;

                    case "2":
                        InserirFilme();
                        break;

                    case "3":
                        AtualizarFilme();
                        break;

                    case "4":
                        ExcluirFilme();
                        break;

                    case "5":
                        VizualizarFilme();
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
            Console.WriteLine("Seção de Filmes!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar filmes");
            Console.WriteLine("2- Inserir novo filme");
            Console.WriteLine("3- Atualizar filme");
            Console.WriteLine("4- Excluir filme");
            Console.WriteLine("5- Visualizar filme");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Voltar ao menu principal");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }

        private static void ListaFilmes()
        {
            Console.WriteLine();
            Console.WriteLine("Lista de filmes:");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Lista não existente");
                return;
            }

            foreach (var filme in lista)
            {
                Console.WriteLine("#ID: {0} - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (filme.retornaExcluido() ? "*Obs: O filme foi exluído*" : ""));
            }
        }

        private static void InserirFilme()
        {
            Console.WriteLine();
            Console.WriteLine("Inserir um novo filme");

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

            Console.WriteLine("Digite o título do filme:");
            string tituloNovo = Console.ReadLine();
            Console.WriteLine("Digite o nome do diretor:");
            string diretorNovo = Console.ReadLine();
            Console.WriteLine("Digite a data de lançamento:");
            DateTime dataNova = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Digite o orçamento do filme (em milhões):");
            int orcamentoNovo = int.Parse(Console.ReadLine());


            Filme filmeNovo = new Filme(
                id: repositorio.ProximoId(),
                genero: (Genero)generoNovo,
                titulo: tituloNovo,
                diretor: diretorNovo,
                dataLancamento: dataNova,
                orcamento: orcamentoNovo,
                excluido: false
            );
            repositorio.Insere(filmeNovo);
        }

        private static void AtualizarFilme()
        {
            Console.WriteLine();
            Console.WriteLine("Atualizar filme");
            Console.WriteLine("Digite a id do filme a ser atualizado: ");
            int idFilme = int.Parse(Console.ReadLine());

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

            Console.WriteLine("Digite o atual título do filme:");
            string tituloAtualizado = Console.ReadLine();
            Console.WriteLine("Digite o atual diretor do filme:");
            string diretorAtualizado = Console.ReadLine();
            Console.WriteLine("Digite a atual data de lançamento:");
            DateTime dataAtualizada = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Digite o atual orçamento do filme (em milhões):");
            int orcamentoAtualizado = int.Parse(Console.ReadLine());


            Filme filmeAtualizado = new Filme(
                id: idFilme,
                genero: (Genero)generoAtualizado,
                titulo: tituloAtualizado,
                diretor: diretorAtualizado,
                dataLancamento: dataAtualizada,
                orcamento: orcamentoAtualizado,
                excluido: false
            );
            repositorio.Atualizar(idFilme, filmeAtualizado);
        }

        private static void ExcluirFilme()
        {
            Console.WriteLine();
            Console.WriteLine("Excluir filme");
            Console.WriteLine("Digite a id do filme a ser excluído: ");
            int idFilmeExcluido = int.Parse(Console.ReadLine());

            repositorio.Excluir(idFilmeExcluido);
        }

        private static void VizualizarFilme()
        {
            Console.WriteLine();
            Console.WriteLine("Vizualizar filme");
            Console.WriteLine("Digite a id do filme a ser vizualizado: ");
            int idFilmeVizualizado = int.Parse(Console.ReadLine());

            var filmeVizualizado = repositorio.RetornaPorId(idFilmeVizualizado);
            Console.WriteLine(filmeVizualizado);
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
    }
}