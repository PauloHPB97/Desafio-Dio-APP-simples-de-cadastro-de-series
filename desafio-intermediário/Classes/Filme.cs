namespace desafio_intermediário
{
    public class Filme : EntidadeBase
    {
        public Filme(int id, Genero genero, string titulo, string diretor, DateTime dataLancamento, decimal orcamento, bool excluido)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Diretor = diretor;
            this.DataLancamento = dataLancamento;
            this.Orcamento = orcamento;
            this.Excluido = excluido;
        }
        public string Titulo { get; set; }

        public DateTime DataLancamento { get; set; }

        public string Diretor { get; set; }

        public Genero Genero { get; set; }

        public decimal Orcamento { get; set; }

        public bool Excluido { get; set; }

        public override string ToString()
        {
            var retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Diretor: " + this.Diretor + Environment.NewLine;
            retorno += "Data de Lançamento: " + this.DataLancamento + Environment.NewLine;
            retorno += "Orçamento: " + this.Orcamento + " Milhões de dólares" + Environment.NewLine;
            retorno += "Excluído: " + this.Excluido;
            return retorno;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }


}