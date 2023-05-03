
namespace tabuleiro
{
     class Tabuleiro
    {

        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas; //matriz de pecas

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
            // vai me retornar a matriz peça, como é público eu posso acessar ele
        }

        public Peca peca(Posicao pos) { 
            return pecas[pos.linha, pos.coluna];
        }

        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
            // primeiro válido a posição, depois retorno que já existe peça nessa posição
        }
        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            //vou colocar pecas na matriz pecas
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        public Peca retirarPeca(Posicao pos)
        {
            if(peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null; // marco a peça e marco sua posição e digo que as duas são nulas
            return aux;
        }
        public bool posicaoValida(Posicao pos) {
            if(pos.linha<0 || pos.linha>=linhas || pos.coluna<0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
            // estou verificando se a posição dada é válida dentro da matriz
        }

        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição Inválida!");
            }
        }
    }

}
