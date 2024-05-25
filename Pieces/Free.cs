using Xadrez_TIC.Chess;
using Color = Xadrez_TIC.Enums.Color;

namespace Xadrez_TIC.Pieces
{

    class Free : Piece
    {

        public Free(Board tab, Position pos) : base(tab)
        {
            this.tab = tab;
            position = pos;
        }
        public Free(Board tab) : base(tab)
        {
            this.tab = tab;
        }

        public override bool[,]? PossibleMoves()
        {
            return null;
        }

        public override string? ToString()
        {
            return null;
        }
    }
}
