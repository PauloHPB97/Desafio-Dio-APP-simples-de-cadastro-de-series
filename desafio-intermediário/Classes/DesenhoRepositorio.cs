namespace desafio_intermediário.Classes
{
    public class DesenhoRepositorio : IRepositorio<Desenho>
    {
        private List<Desenho> listaDesenho = new List<Desenho>();
        public void Atualizar(int id, Desenho objeto)
        {
            listaDesenho[id] = objeto;
        }

        public void Excluir(int id)
        {
            listaDesenho[id].Excluir();
        }

        public void Insere(Desenho objeto)
        {
            listaDesenho.Add(objeto);
        }

        public List<Desenho> Lista()
        {
            return listaDesenho;
        }

        public int ProximoId()
        {
            return listaDesenho.Count;
        }

        public Desenho RetornaPorId(int id)
        {
            return listaDesenho[id];
        }
    }
}