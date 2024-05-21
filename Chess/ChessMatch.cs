using System.Security.Cryptography.X509Certificates;
using Color = Xadrez_TIC.Enums.Color;

namespace Xadrez_TIC.Chess
{
    class ChessMatch
    {
        public Board tab { get; private set; }
        public Color Player { get; private set; }
        public bool finished { get; private set; }
        public bool xeque { get; private set; }
        public Piece? EnPassant { get; private set; }

        public ChessMatch()
        {
            tab = new Board();
            Player = Color.White;
            finished = false;
            xeque = false;
            EnPassant = null;
        }

        public Piece MovePiece(Position origin, Position destination)
        {
            Piece p = tab.RemovePiece(origin,p,Player);

            //En Passant
            if (propa is )
            {

            }

            
        }

        public void CheckPositionOrigin(Position pos)
        {

        }
        //jogadas especiais e movimento/remoção real da peça
    }
}
