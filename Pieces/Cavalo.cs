using Xadrez_TIC.Chess;
using Color = Xadrez_TIC.Enums.Color;

namespace Xadrez_TIC.Pieces
{

    class Cavalo : Piece {

        public Cavalo(Board tab, Color color) : base(tab, color) {
        }

        public override string ToString() {
            return "cavalo";
        }

        private bool CanMove(Position pos) {
            Piece p = tab.PiecePosition(pos);
            return p == null || p.color != color;
        }

        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[tab.rows, tab.columns];

            Position pos = new Position(0, 0);

            pos.DefineNewPositionValues(position.row - 1, position.column - 2);
            if (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            pos.DefineNewPositionValues(position.row - 2, position.column - 1);
            if (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            pos.DefineNewPositionValues(position.row - 2, position.column + 1);
            if (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            pos.DefineNewPositionValues(position.row - 1, position.column + 2);
            if (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            pos.DefineNewPositionValues(position.row + 1, position.column + 2);
            if (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            pos.DefineNewPositionValues(position.row + 2, position.column + 1);
            if (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            pos.DefineNewPositionValues(position.row + 2, position.column - 1);
            if (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            pos.DefineNewPositionValues(position.row + 1, position.column - 2);
            if (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }

            return mat;
        }
    }
}
