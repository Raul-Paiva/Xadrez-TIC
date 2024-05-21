using Xadrez_TIC.Chess;
using Color = Xadrez_TIC.Enums.Color;

namespace xadrez {

    class Cavalo : Piece {

        public Cavalo(Board tab, Color color) : base(tab, color) {
        }

        public override string ToString() {
            return "C";
        }

        private bool CanMove(Position pos) {
            Piece p = tab.PiecePosition(pos);
            return p == null || p.color != color;
        }

        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Position pos = new Position(0, 0);

            pos.DefineNewValues(posicao.row - 1, posicao.column - 2);
            if (tab.IsPositionValid(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            pos.DefineNewValues(posicao.row - 2, posicao.column - 1);
            if (tab.IsPositionValid(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            pos.DefineNewValues(posicao.row - 2, posicao.column + 1);
            if (tab.IsPositionValid(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            pos.DefineNewValues(posicao.row - 1, posicao.column + 2);
            if (tab.IsPositionValid(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            pos.DefineNewValues(posicao.row + 1, posicao.column + 2);
            if (tab.IsPositionValid(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            pos.DefineNewValues(posicao.row + 2, posicao.column + 1);
            if (tab.IsPositionValid(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            pos.DefineNewValues(posicao.row + 2, posicao.column - 1);
            if (tab.IsPositionValid(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            pos.DefineNewValues(posicao.row + 1, posicao.column - 2);
            if (tab.IsPositionValid(pos) && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }

            return mat;
        }
    }
}
