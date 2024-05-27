using Xadrez_TIC.Exceptions;
using Xadrez_TIC.Chess;
using Color = Xadrez_TIC.Enums.Color;

namespace Xadrez_TIC.Pieces
{
    class Promotion
    {
        public ChessMatch chessMatch { get; set; }
        public Piece PieceToPromote { get; private set; }
        

        public Promotion(ChessMatch chessmatch, Piece pieceToPromote)
        {
            if (pieceToPromote is not Peao) { throw new FatalException("Só os Peões podem ser promovidos!"); }
            chessMatch = chessmatch;
            PieceToPromote = pieceToPromote;
        }

        public void Promote()//falta criar para ter opcoes
        {
            Position destination = PieceToPromote.position;
            PieceToPromote = chessMatch.tab.RemovePiece(destination);
            Piece dama = new Dama(chessMatch.tab, PieceToPromote.color);
            chessMatch.tab.AddPiece(destination, dama);
        }
    }
}
