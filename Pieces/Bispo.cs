using Xadrez_TIC.Chess;
using Color = Xadrez_TIC.Enums.Color;

namespace Xadrez_TIC.Pieces {

    class Bispo : Piece {

        public Bispo(Board tab, Color color) : base(tab, color) {
        }

        public override string ToString() {
            return "bispo";
        }
        
        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[tab.rows, tab.columns];

            Position pos = new Position(0, 0);

            // NO
            pos.DefineNewPositionValues(position.row - 1, position.column - 1);
            while (pos.IsPositionValid() && IsFreeToMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) is not Free && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewPositionValues(pos.row - 1, pos.column - 1);
            }

            // NE
            pos.DefineNewPositionValues(position.row - 1, position.column + 1);
            while (pos.IsPositionValid()  && IsFreeToMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) is not Free && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewPositionValues(pos.row - 1, pos.column + 1);
            }

            // SE
            pos.DefineNewPositionValues(position.row + 1, position.column + 1);
            while (pos.IsPositionValid() && IsFreeToMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) is not Free && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewPositionValues(pos.row + 1, pos.column + 1);
            }

            // SO
            pos.DefineNewPositionValues(position.row + 1, position.column - 1);
            while (pos.IsPositionValid() && IsFreeToMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) is not Free && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewPositionValues(pos.row + 1, pos.column - 1);
            }

            return mat;
        }
    }
}
