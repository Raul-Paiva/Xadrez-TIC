using Xadrez_TIC.Exceptions;
using Xadrez_TIC.Pieces;
using Color = Xadrez_TIC.Enums.Color;

namespace Xadrez_TIC.Chess
{
    class ChessMatch
    {
        public Board tab { get; private set; }
        public int turno { get; private set; }//---??
        public Color Player { get; private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool xeque { get; private set; }
        public Piece? EnPassant { get; private set; }

        public ChessMatch(Board b)
        {
            tab = b;
            //turno = 1;
            Player = Color.White;
            finished = false;
            xeque = false;
            EnPassant = null;
        }

        public Piece? MovePiece(Position origin, Position destination)
        {
            Piece p = tab.RemovePiece(origin);
            p.AddNMoves();
            Piece capturedPiece = tab.RemovePiece(destination);
            tab.AddPiece(destination, p);
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }

            //Roque Pequeno\\
            if (p is Rei && destination.column == origin.column + 2)
            {
                Position origemT = new Position(origin.row, origin.column + 3);
                Position destinoT = new Position(origin.row, origin.column + 1);
                Piece T = tab.RemovePiece(origemT);
                T.AddNMoves();
                tab.AddPiece(destinoT, T);
            }
            //----------\\

            //Roque Grande\\
            if (p is Rei && destination.column == origin.column - 2)
            {
                Position origemT = new Position(origin.row, origin.column - 4);
                Position destinoT = new Position(origin.row, origin.column - 1);
                Piece T = tab.RemovePiece(origemT);
                T.AddNMoves();
                tab.AddPiece(destinoT, T);
            }
            //----------\\

            //En Passant\\
            if (p is Peao)
            {
                if (origin.column != destination.column && capturedPiece == null)
                {
                    Position posP;
                    if (p.color == Color.White)
                    {
                        posP = new Position(destination.row + 1, destination.column);
                    }
                    else
                    {
                        posP = new Position(destination.row - 1, destination.column);
                    }
                    capturedPiece = tab.RemovePiece(posP);
                    captured.Add(capturedPiece);
                }
            }
            //----------\\

            return capturedPiece;
        }

        public void UnmovePiece(Position origin, Position destination, Piece capturedPiece)
        {
            Piece p = tab.RemovePiece(destination);
            p.RemoveNMoves();
            if (capturedPiece != null)
            {
                tab.AddPiece(destination, capturedPiece);
                captured.Remove(capturedPiece);
            }
            tab.AddPiece(origin, p);

            //Roque Pequeno\\
            if (p is Rei && destination.column == origin.column + 2)
            {
                Position origemT = new Position(origin.row, origin.column + 3);
                Position destinoT = new Position(origin.row, origin.column + 1);
                Piece T = tab.RemovePiece(destinoT);
                T.RemoveNMoves();
                tab.AddPiece(origemT, T);
            }
            //----------\\

            //Roque Grande\\
            if (p is Rei && destination.column == origin.column - 2)
            {
                Position origemT = new Position(origin.row, origin.column - 4);
                Position destinoT = new Position(origin.row, origin.column - 1);
                Piece T = tab.RemovePiece(destinoT);
                T.RemoveNMoves();
                tab.AddPiece(origemT, T);
            }
            //----------\\

            // #jogadaespecial en passant
            if (p is Peao)
            {
                if (origin.column != destination.column && capturedPiece == EnPassant)
                {
                    Piece peao = tab.RemovePiece(destination);
                    Position posP;
                    if (p.color == Color.White)
                    {
                        posP = new Position(3, destination.column);
                    }
                    else
                    {
                        posP = new Position(4, destination.column);
                    }
                    tab.AddPiece(posP, peao);
                }
            }
        }

        public void PlayPieces(Position origin, Position destination)
        {
            Piece capturedPiece = MovePiece(origin, destination);

            if (IsXeque(Player))
            {
                UnmovePiece(origin, destination, capturedPiece);
                throw new ChessException("Você não pode se colocar em xeque!");
            }

            Piece p = tab.PiecePosition(destination);

            // #jogadaespecial promocao
            if (p is Peao)
            {
                if ((p.color == Color.White && destination.row == 0) || (p.color == Color.Black && destination.row == 7))
                {
                    p = tab.RemovePiece(destination);
                    pieces.Remove(p);
                    Piece dama = new Dama(tab, p.color);
                    tab.AddPiece(destination, dama);
                    pieces.Add(dama);
                }
            }

            if (IsXeque(adversaria(Player)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            if (testeXequemate(adversaria(Player)))
            {
                finished = true;
            }
            else
            {
                turno++;
                changePlayer();
            }

            // #jogadaespecial en passant
            if (p is Peao && (destination.row == origin.row - 2 || destination.row == origin.row + 2))
            {
                EnPassant = p;
            }
            else
            {
                EnPassant = null;
            }

        }

        public void CheckPositionOrigin(Position pos)
        {

        }

        public void CheckPositionDestination(Position origin, Position destination)
        {

        }

        private void changePlayer()
        {
            if (Player == Color.White)
            {
                Player = Color.Black;
            }
            else
            {
                Player = Color.White;
            }
        }

        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> piecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        private Color adversaria(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece rei(Color color)
        {
            foreach (Piece x in piecesInGame(color))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool IsXeque(Color color)
        {
            Piece R = rei(color);
            if (R == null)
            {
                throw new ChessException("Não tem rei da cor " + color + " no tabuleiro!");
            }
            foreach (Piece x in piecesInGame(adversaria(color)))
            {
                bool[,] mat = x.PossibleMoves();
                if (mat[R.position.row, R.position.column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testeXequemate(Color color)
        {
            if (!IsXeque(color))
            {
                return false;
            }
            foreach (Piece x in piecesInGame(color))
            {
                bool[,] mat = x.PossibleMoves();
                for (int i = 0; i < tab.rows; i++)
                {
                    for (int j = 0; j < tab.columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.position;
                            Position destination = new Position(i, j);
                            Piece capturedPiece = MovePiece(origin, destination);
                            bool verifyXeque = IsXeque(color);
                            UnmovePiece(origin, destination, capturedPiece);
                            if (!verifyXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void putNewPiece(char column, int row, Piece piece)
        {
            tab.AddPiece(new Position.Chess(row, column).ToPosition(), piece);
            pieces.Add(piece);
        }
    }
}
