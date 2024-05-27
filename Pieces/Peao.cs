using Xadrez_TIC.Chess;
using Color = Xadrez_TIC.Enums.Color;

namespace Xadrez_TIC.Pieces
{

    class Peao : Piece
    {

        private ChessMatch match;

        public Peao(Board tab, Color color, ChessMatch match) : base(tab, color)
        {
            this.match = match;
        }

        public override string ToString()
        {
            return "peao";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[tab.rows, tab.columns];

            Position pos = new Position(0, 0);

            if (color == Color.Black)
            {
                pos.DefineNewPositionValues(position.row - 1, position.column);
                if (pos.IsPositionValid() && IsFree(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.DefineNewPositionValues(position.row - 2, position.column);
                Position p2 = new Position(position.row - 1, position.column);
                if (p2.IsPositionValid() && IsFree(p2) && pos.IsPositionValid() && IsFree(pos) && nMoves == 0)
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.DefineNewPositionValues(position.row - 1, position.column - 1);
                if (pos.IsPositionValid() && IsFreeToMove(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.DefineNewPositionValues(position.row - 1, position.column + 1);
                if (pos.IsPositionValid() && IsFreeToMove(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                //----------------------------------------------\\
                //---------- Special Move - EnPassant ----------\\
                //----------------------------------------------\\
                if (position.row == 3)
                {
                    Position left = new Position(position.row - 1, position.column - 1);
                    if (left.IsPositionValid() && IsFreeToMove(new Position(left.row + 1, left.column)) && IsFree(left) && match.IsCaptingWithEnPassant(position, left, color))
                    {  //Não funcionou match.IsCaptingWithEnPassant(position, left, color) <- Preferia assim
                        mat[left.row, left.column] = true;
                    }

                    Position right = new Position(position.row - 1, position.column + 1);
                    if (right.IsPositionValid() && IsFreeToMove(new Position(right.row + 1, right.column)) && IsFree(right) && match.IsCaptingWithEnPassant(position, right, color))
                    {
                        mat[right.row, right.column] = true;
                    }
                }
                //----------------------------------------------\\
            }
            else
            {
                pos.DefineNewPositionValues(position.row + 1, position.column);
                if (pos.IsPositionValid() && IsFree(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.DefineNewPositionValues(position.row + 2, position.column);
                Position p2 = new Position(position.row + 1, position.column);
                if (p2.IsPositionValid() && IsFree(p2) && pos.IsPositionValid() && IsFree(pos) && nMoves == 0)
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.DefineNewPositionValues(position.row + 1, position.column - 1);
                if (pos.IsPositionValid() && IsFreeToMove(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.DefineNewPositionValues(position.row + 1, position.column + 1);
                if (pos.IsPositionValid() && IsFreeToMove(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                //----------------------------------------------\\
                //---------- Special Move - EnPassant ----------\\
                //----------------------------------------------\\
                if (position.row == 4)
                {
                    Position left = new Position(position.row + 1, position.column - 1);
                    if (left.IsPositionValid() && IsFreeToMove(new Position(left.row - 1, left.column)) && IsFree(left) && match.IsCaptingWithEnPassant(position, left, color))
                    {
                        mat[left.row, left.column] = true;
                    }

                    Position right = new Position(position.row + 1, position.column + 1);
                    if (right.IsPositionValid() && IsFreeToMove(new Position(right.row - 1, right.column)) && IsFree(right) && match.IsCaptingWithEnPassant(position, right, color))
                    {
                        mat[right.row, right.column] = true;
                    }
                }
                //----------------------------------------------\\
            }

            return mat;
        }

        private protected sealed override bool IsFreeToMove(Position pos)
        {
            Piece p = tab.PiecePosition(pos);
            return p is not Free && p.color != color;
        }
    }
}
