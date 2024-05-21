using Xadrez_TIC.Chess;
using Color = Xadrez_TIC.Enums.Color;

namespace xadrez {

    class Bispo : Piece {

        public Bispo(Board tab, Color color) : base(tab, color) {
        }

        public override string ToString() {
            return "B";
        }

        private bool CanMove(Position pos) {
            Piece p = tab.PiecePosition(pos);
            return p == null || p.color != color;
        }
        
        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Position pos = new Position(0, 0);

            // NO
            pos.DefineNewValues(posicao.row - 1, posicao.column - 1);
            while (tab.IsPositionValid(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) != null && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewValues(pos.row - 1, pos.column - 1);
            }

            // NE
            pos.DefineNewValues(posicao.row - 1, posicao.column + 1);
            while (tab.IsPositionValid(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) != null && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewValues(pos.row - 1, pos.column + 1);
            }

            // SE
            pos.DefineNewValues(posicao.row + 1, posicao.column + 1);
            while (tab.IsPositionValid(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) != null && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewValues(pos.row + 1, pos.column + 1);
            }

            // SO
            pos.DefineNewValues(posicao.row + 1, posicao.column - 1);
            while (tab.IsPositionValid(pos) && CanMove(pos)) {
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
