using Color = Xadrez_TIC.Enums.Color;
using Xadrez_TIC.Chess;

namespace Xadrez_TIC.Pieces {
    class Torre : Piece {

        public Torre(Board tab, Color color) : base(tab, color) {
        }

        public override string ToString() {
            return "torre";
        }

        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[tab.rows, tab.columns];

            Position pos = new Position(0, 0);

            // acima
            pos.DefineNewPositionValues(position.row - 1, position.column);
            while (pos.IsPositionValid() && IsFreeToMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) is not Free && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewPositionValues(pos.row - 1, pos.column);
            }

            // abaixo
            pos.DefineNewPositionValues(position.row + 1, position.column);
            while (pos.IsPositionValid() && IsFreeToMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) is not Free && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewPositionValues(pos.row + 1, pos.column);
            }

            // direita
            pos.DefineNewPositionValues(position.row, position.column + 1);
            while (pos.IsPositionValid() && IsFreeToMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) is not Free && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewPositionValues(pos.row, pos.column + 1);
            }

            // esquerda
            pos.DefineNewPositionValues(position.row, position.column - 1);
            while (pos.IsPositionValid() && IsFreeToMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) is not Free && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewPositionValues(pos.row, pos.column - 1);
            }

            return mat;
        }
    }
}
