using Xadrez_TIC.Chess;
using Color = Xadrez_TIC.Enums.Color;

namespace Xadrez_TIC.Pieces {

    class Bispo : Piece {

        public Bispo(Board tab, Color color) : base(tab, color) {
        }

        public override string ToString() {
            return "bispo";
        }

        private bool CanMove(Position pos) {
            Piece p = tab.PiecePosition(pos);
            return p == null || p.color != color;
        }
        
        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[tab.rows, tab.columns];

            Position pos = new Position(0, 0);

            // NO
            pos.DefineNewValues(position.row - 1, position.column - 1);
            while (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) != null && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewValues(pos.row - 1, pos.column - 1);
            }

            // NE
            pos.DefineNewValues(position.row - 1, position.column + 1);
            while (pos.IsPositionValid()  && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) != null && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewValues(pos.row - 1, pos.column + 1);
            }

            // SE
            pos.DefineNewValues(position.row + 1, position.column + 1);
            while (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) != null && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewValues(pos.row + 1, pos.column + 1);
            }

            // SO
            pos.DefineNewValues(position.row + 1, position.column - 1);
            while (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) != null && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewValues(pos.row + 1, pos.column - 1);
            }

            return mat;
        }
    }
}
