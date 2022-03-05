namespace desafio_intermediário
{
    public abstract class Geral : EntidadeBase
    {
        public string Titulo { get; set; }

        public Genero Genero { get; set; }

        public bool Excluido { get; set; }
        public void Excluir()
        {
            this.Excluido = true;
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
    }
}