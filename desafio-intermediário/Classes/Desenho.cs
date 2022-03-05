namespace desafio_intermediário
{
    public class Desenho : Geral
    {
        public Desenho(int id, Genero genero, string titulo, int quantidadeEpisodios, string criador, string emissora, bool excluido)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Criador = criador;
            this.Emissora = emissora;
            this.Excluido = excluido;
        }

        public int QuantidadeEpisodios { get; set; }

        public string Criador { get; set; }

        public string Emissora { get; set; }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Criador: " + this.Criador + Environment.NewLine;
            retorno += "Emissora: " + this.Emissora + Environment.NewLine;
            retorno += "Excluído: " + this.Excluido;
            return retorno;
        }
    }

}