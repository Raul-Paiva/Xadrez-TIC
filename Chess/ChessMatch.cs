using Xadrez_TIC.Exceptions;
using Xadrez_TIC.Pieces;
using Color = Xadrez_TIC.Enums.Color;

namespace Xadrez_TIC.Chess
{
    class ChessMatch
    {
        public Board tab { get; private set; }
        public int round { get; private set; }
        public Color PlayerColor { get; private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> pieces;//List of all the Pieces(including captured Pieces) 
        private HashSet<Piece> captured;
        public bool xeque { get; private set; }
        public Piece? EnPassant { get; private set; }

        public ChessMatch(Board b)
        {
            tab = b;
            round = 1;
            PlayerColor = Color.White;
            finished = false;
            xeque = false;
            EnPassant = null;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            foreach (Piece x in tab.PiecesPos) { if (x != null) { pieces.Add(x); } }
        }

        public void CheckPositionOrigin(Position pos)
        {

        }

        public void CheckPositionDestination(Position origin, Position destination)
        {

        }

        public void PlayPieces(Position origin, Position destination)
        {
            Piece capturedPiece = MovePiece(origin, destination);

            if (IsXeque(PlayerColor))
            {
                UnmovePiece(origin, destination, capturedPiece);
                throw new ChessException("Não te podes colocar em xeque!");
            }

            Piece p = tab.PiecePosition(destination);
            /*
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
            }*/

            if (IsXeque(oppositeColor(PlayerColor)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            if (TestXequemate(oppositeColor(PlayerColor)))
            {
                finished = true;
            }
            else
            {
                round++;
                if (PlayerColor == Color.White)
                {
                    PlayerColor = Color.Black;
                }
                else
                {
                    PlayerColor = Color.White;
                }
            }
            /*
            // #jogadaespecial en passant
            if (p is Peao && (destination.row == origin.row - 2 || destination.row == origin.row + 2))
            {
                EnPassant = p;
            }
            else
            {
                EnPassant = null;
            }*/

        }

        private Piece MovePiece(Position origin, Position destination)
        {
            Piece p = tab.RemovePiece(origin);
            p.AddNMoves();
            Piece capturedPiece = tab.RemovePiece(destination);
            tab.AddPiece(destination, p);
            if (capturedPiece is not Free)
            {
                captured.Add(capturedPiece);
                capturedPiece.Captured();
            }


            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            /*

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
            //----------\\*/
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            return capturedPiece;
        }

        //Undo the move of a piece
        private void UnmovePiece(Position originalposorigin, Position originalposdestination, Piece capturedPiece)//tenho de fazer uns ajustes para desfazer os movimentos apenas em pecas recentes
        {
            Piece p = tab.RemovePiece(originalposdestination);//Remove the piece moved from it original destination position
            p.RemoveNMoves();//Remove the move from the nMoves list
            if (capturedPiece is not Free && capturedPiece != null)//Tests if was captured any piece
            {
                tab.AddPiece(originalposdestination, capturedPiece);//Add the piece captured to it original position
                captured.Remove(capturedPiece);//Remove the caputred piece from the captured list
                capturedPiece.UndoCapture();
            }
            tab.AddPiece(originalposorigin, p);//Add the moved piece to it original origin position



            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            /*
            //Roque Pequeno\\
            if (p is Rei && originalposdestination.column == originalposorigin.column + 2)
            {
                Position origemT = new Position(originalposorigin.row, originalposorigin.column + 3);
                Position destinoT = new Position(originalposorigin.row, originalposorigin.column + 1);
                Piece T = tab.RemovePiece(destinoT);
                T.RemoveNMoves();
                tab.AddPiece(origemT, T);
            }
            //----------\\

            //Roque Grande\\
            if (p is Rei && originalposdestination.column == originalposorigin.column - 2)
            {
                Position origemT = new Position(originalposorigin.row, originalposorigin.column - 4);
                Position destinoT = new Position(originalposorigin.row, originalposorigin.column - 1);
                Piece T = tab.RemovePiece(destinoT);
                T.RemoveNMoves();
                tab.AddPiece(origemT, T);
            }
            //----------\\

            // #jogadaespecial en passant
            if (p is Peao)
            {
                if (originalposorigin.column != originalposdestination.column && capturedPiece == EnPassant)
                {
                    Piece peao = tab.RemovePiece(originalposdestination);
                    Position posP;
                    if (p.color == Color.White)
                    {
                        posP = new Position(3, originalposdestination.column);
                    }
                    else
                    {
                        posP = new Position(4, originalposdestination.column);
                    }
                    tab.AddPiece(posP, peao);
                }
            }*/
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        }

        /// <summary>
        /// Returns every piece in captured list and with the provided color.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public HashSet<Piece> CapturedPieces(Color color)
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

        //---------- Returns a list of the Pieces in the game ----------\\
        public HashSet<Piece> PiecesInGame(Color color)
        {
            //---------- Add every piece with the provided color to inGamePieces ----------\\
            HashSet<Piece> inGamePieces = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.color == color)
                {
                    inGamePieces.Add(x);
                }
            }
            //-------------------------------------------------------------------------------\\

            inGamePieces.ExceptWith(CapturedPieces(color));//Removes the captured pieces from the inGamePieces list

            return inGamePieces;
        }

        //---------- Checks if the Rei is Xeque ----------\\
        public bool IsXeque(Color color)
        {
            Piece R = rei(color);//--------------Tenho de lidar com a excecao

            foreach (Piece x in PiecesInGame(oppositeColor(color)))
            {//If the Rei position in the mat is true, it means it is possible to capture the Rei
                bool[,] mat = x.PossibleMoves();
                if (mat[R.position.row, R.position.column])
                {
                    return true;
                }
            }
            return false;

            //---------- Returns the Rei's info ----------\\
            Piece rei(Color color)
            {
                foreach (Piece x in PiecesInGame(color))
                {
                    if (x is Rei)
                    {
                        return x;
                    }
                }
                throw new FatalException("Não existe um rei da cor " + color + " no tabuleiro!");
            }
            //---------------------------------------------\\
        }

        public bool TestXequemate(Color color)
        {
            if (!IsXeque(color))
            {
                return false;
            }
            foreach (Piece x in PiecesInGame(color))
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

        public void PutNewPiece(char column, int row, Piece piece)
        {
            tab.AddPiece(new Position(row, column), piece);
            pieces.Add(piece);
        }

        private Color oppositeColor(Color color)
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
    }
}
