using Color = Xadrez_TIC.Enums.Color;
using Xadrez_TIC.Chess;

namespace xadrez {
    class Torre : Piece {

        public Torre(Board tab, Color color) : base(tab, color) {
        }

        public override string ToString() {
            return "T";
        }

        private bool podeMover(Position pos) {
            Piece p = tab.PiecePosition(pos);
            return p == null || p.color != color;
        }

        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Position pos = new Position(0, 0);

            // acima
            pos.DefineNewValues(posicao.row - 1, posicao.column);
            while (tab.IsPositionValid(pos) && podeMover(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) != null && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.row = pos.row - 1;
            }

            // abaixo
            pos.DefineNewValues(posicao.row + 1, posicao.column);
            while (tab.IsPositionValid(pos) && podeMover(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) != null && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.row  = pos.row + 1;
            }

            // direita
            pos.DefineNewValues(posicao.row, posicao.column + 1);
            while (tab.IsPositionValid(pos) && podeMover(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) != null && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.column = pos.column + 1;
            }

            // esquerda
            pos.DefineNewValues(posicao.row, posicao.column - 1);
            while (tab.IsPositionValid(pos) && podeMover(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) != null && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.column = pos.column - 1;
            }

            return mat;
        }
    }
}
