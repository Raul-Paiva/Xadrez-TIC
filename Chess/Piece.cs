using Color = Xadrez_TIC.Enums.Color;

namespace Xadrez_TIC.Chess
{
    abstract class Piece
    {
        public Position? posicao { get; set; }
        public Enums.Color color { get; protected set; }
        public int nMoves { get; protected set; }
        public Board tab { get; protected set; }


        public Piece(Board tab, Color color)
        {
            posicao = null;
            this.tab = tab;
            this.color = color;
            nMoves = 0;
        }

        public void AddNMoves()
        {
            nMoves++;
        }

        public void RemoveNMoves()
        {
            nMoves--;
        }

        public bool ExistPossibleMoves()
        {
            bool[,] mat = PossibleMoves();
            for (int i = 0; i < tab.linhas; i++)
            {
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //public bool possibleMove(Position pos) ---- porque bool?
        //{
        //    return possibleMoves()[int.Parse(pos.row), int.Parse(pos.column)];
        //}

        public abstract bool[,] PossibleMoves();
    }
}
