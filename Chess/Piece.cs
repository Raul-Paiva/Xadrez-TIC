using Color = Xadrez_TIC.Enums.Color;

namespace Xadrez_TIC.Chess
{
    public abstract class Piece
    {
        public Position? position { get; set; }
        public Enums.Color color { get; protected set; }
        public int nMoves { get; protected set; }
        public Board tab { get; protected set; }


        public Piece(Board tab, Color color)
        {
            position = null;
            this.tab = tab;
            this.color = color;
            nMoves = 0;
        }
        public Piece(Board tab)
        {
            position = null;
            this.tab = tab;
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
            for (int i = 0; i < tab.rows; i++)
            {
                for (int j = 0; j < tab.columns; j++)
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

        public void Captured()
        {
            position = null;
        }
    }
}
