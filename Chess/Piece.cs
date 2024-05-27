using Xadrez_TIC.Pieces;
using Color = Xadrez_TIC.Enums.Color;

namespace Xadrez_TIC.Chess
{
    public abstract class Piece
    {
        public Position? position { get; set; }
        public Enums.Color color { get; private set; }
        public int nMoves { get; set; }
        public Board tab { get; set; }
        public bool IsCaptured { get; private set; }


        public Piece(Board tab, Color color)
        {
            position = null;
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

        public bool IsPossibleMove(Position toThisPosition)
        {
            bool[,] mat = PossibleMoves();
            if (mat[toThisPosition.row, toThisPosition.column]) { return true; }
            return false;
        }

        //public bool possibleMove(Position pos) ---- porque bool?
        //{
        //    return possibleMoves()[int.Parse(pos.row), int.Parse(pos.column)];
        //}

        private protected bool IsFree(Position pos)
        {
            if (!pos.IsPositionValid()) { return false; }
            return tab.PiecePosition(pos) is Free;
        }
        private protected virtual bool IsFreeToMove(Position pos)//para o peao e diferente(nao sei se tambem e para o rei)
        {
            if (!pos.IsPositionValid()) { return false; }
            Piece p = tab.PiecePosition(pos);
            return p is Free || p.color != color;
        }

        public abstract bool[,] PossibleMoves();

        public void Captured()
        {
            IsCaptured = true;
        }
        public void UndoCapture()
        {
            IsCaptured = false;
        }
    }
}
