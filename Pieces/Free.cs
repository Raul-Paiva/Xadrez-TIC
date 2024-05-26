using Xadrez_TIC.Chess;
using Xadrez_TIC.Exceptions;
using Color = Xadrez_TIC.Enums.Color;

namespace Xadrez_TIC.Pieces
{    
    class Free : Piece
    {
        public string pieceType { get; set; }

        public Free(Board tab, Position pos, string pType) : base(tab)
        {
            this.tab = tab;
            position = pos;
            if (pType == "livre" || pType == "ponto") { pieceType = pType; }
            else { throw new FatalException("Erro no tipo da peça aplicada ao tipo Free"); }
            
        }
        public Free(Board tab, string pType) : base(tab)
        {
            this.tab = tab;
            if (pType == "livre" || pType == "ponto") { pieceType = pType; }
            else { throw new FatalException("Erro no tipo da peça aplicada ao tipo Free"); }
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
