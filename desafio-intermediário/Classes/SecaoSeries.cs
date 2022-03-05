namespace desafio_intermediário
{
    public class SecaoSeries
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        
        public void ObterSecaoSeries()
        {

            string opcaoDoUsuario = ObterOpcaoUsuario();

            while (opcaoDoUsuario.ToUpper() != "X")
            {
                switch (opcaoDoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;

                    case "2":
                        InserirSerie();
                        break;

                    case "3":
                        AtualizarSerie();
                        break;

                    case "4":
                        ExcluirSerie();
                        break;

                    case "5":
                        VizualizarSerie();
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
            Console.WriteLine("Seção de Séries!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Voltar ao menu principal");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }

        private static void ListarSeries()
        {
            Console.WriteLine();
            Console.WriteLine("Lista de séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Lista não existente");
                return;
            }

            foreach (var serie in lista)
            {
                Console.WriteLine("#ID: {0} - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (serie.retornaExcluido() ? "*Obs: A série foi exluída*" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine();
            Console.WriteLine("Inserir uma nova série");

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

            Console.WriteLine("Digite o título da série:");
            string tituloNovo = Console.ReadLine();
            Console.WriteLine("Digite a descrição da série:");
            string descricaoNova = Console.ReadLine();
            Console.WriteLine("Digite o ano da série:");
            int anoNovo = int.Parse(Console.ReadLine());


            Serie serieNova = new Serie(
                id: repositorio.ProximoId(),
                genero: (Genero)generoNovo,
                titulo: tituloNovo,
                descricao: descricaoNova,
                ano: anoNovo,
                excluido: false
            );
            repositorio.Insere(serieNova);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine();
            Console.WriteLine("Atualizar série");
            Console.WriteLine("Digite a id da série a ser atualizada: ");
            int idSerie = int.Parse(Console.ReadLine());

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

            Console.WriteLine("Digite o atual título da série:");
            string tituloAtualizado = Console.ReadLine();
            Console.WriteLine("Digite a atual descrição da série:");
            string descricaoAtualizada = Console.ReadLine();
            Console.WriteLine("Digite o atual ano da série:");
            int anoAtualizado = int.Parse(Console.ReadLine());


            Serie serieAtualizada = new Serie(
                id: idSerie,
                genero: (Genero)generoAtualizado,
                titulo: tituloAtualizado,
                descricao: descricaoAtualizada,
                ano: anoAtualizado,
                excluido: false
            );
            repositorio.Atualizar(idSerie, serieAtualizada);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine();
            Console.WriteLine("Excluir série");
            Console.WriteLine("Digite a id da série a ser excluída: ");
            int idSerieExcluida = int.Parse(Console.ReadLine());

            repositorio.Excluir(idSerieExcluida);
        }

        private static void VizualizarSerie()
        {
            Console.WriteLine();
            Console.WriteLine("Vizualizar série");
            Console.WriteLine("Digite a id da série a ser vizualizada: ");
            int idSerieVizualizada = int.Parse(Console.ReadLine());

            var serieVizualizada = repositorio.RetornaPorId(idSerieVizualizada);
            Console.WriteLine(serieVizualizada);
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