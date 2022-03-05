namespace desafio_intermediário
{
    public class Serie : Geral
    {
        public Serie(int id, Genero genero, string titulo, string descricao, int ano, bool excluido)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = excluido;

        }
        public string Descricao { get; set; }

        public int Ano { get; set; }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }
        
    }

    
}