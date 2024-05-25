using Xadrez_TIC.Chess;
using Color = Xadrez_TIC.Enums.Color;

namespace Xadrez_TIC.Pieces {

    class Peao : Piece {

        private ChessMatch partida;

        public Peao(Board tab, Color color, ChessMatch partida) : base(tab, color) {
            this.partida = partida;
        }

        public override string ToString() {
            return "peao";
        }

        private bool existeInimigo(Position pos) {
            Piece p = tab.PiecePosition(pos);
            return p != null && p.color != color;
        }

        private bool free(Position pos) {
            return tab.PiecePosition(pos) == null;
        }

        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[tab.rows, tab.columns];

            Position pos = new Position(0, 0);

            if (color == Color.White) {
                pos.DefineNewValues(position.row - 1, position.column);
                if (pos.IsPositionValid() && free(pos)) {
                    mat[pos.row, pos.column] = true;
                }
                pos.DefineNewValues(position.row - 2, position.column);
                Position p2 = new Position(position.row - 1, position.column);
                if (p2.IsPositionValid() && free(p2) && pos.IsPositionValid() && free(pos) && nMoves == 0) {
                    mat[pos.row, pos.column] = true;
                }
                pos.DefineNewValues(position.row - 1, position.column - 1);
                if (pos.IsPositionValid() && existeInimigo(pos)) {
                    mat[pos.row, pos.column] = true;
                }
                pos.DefineNewValues(position.row - 1, position.column + 1);
                if (pos.IsPositionValid() && existeInimigo(pos)) {
                    mat[pos.row, pos.column] = true;
                }

                // #jogadaespecial en passant
                if (position.row == 3) {
                    Position esquerda = new Position(position.row, position.column - 1);
                    if (esquerda.IsPositionValid() && existeInimigo(esquerda) && tab.PiecePosition(esquerda) == partida.EnPassant) {
                        mat[esquerda.row - 1, esquerda.column] = true;
                    }
                    Position direita = new Position(position.row, position.column + 1);
                    if (direita.IsPositionValid() && existeInimigo(direita) && tab.PiecePosition(direita) == partida.EnPassant) {
                        mat[direita.row - 1, direita.column] = true;
                    }
                }
            }
            else {
                pos.DefineNewValues(position.row + 1, position.column);
                if (pos.IsPositionValid() && free(pos)) {
                    mat[pos.row, pos.column] = true;
                }
                pos.DefineNewValues(position.row + 2, position.column);
                Position p2 = new Position(position.row + 1, position.column);
                if (p2.IsPositionValid() && free(p2) && pos.IsPositionValid() && free(pos) && nMoves == 0) {
                    mat[pos.row, pos.column] = true;
                }
                pos.DefineNewValues(position.row + 1, position.column - 1);
                if (pos.IsPositionValid() && existeInimigo(pos)) {
                    mat[pos.row, pos.column] = true;
                }
                pos.DefineNewValues(position.row + 1, position.column + 1);
                if (pos.IsPositionValid() && existeInimigo(pos)) {
                    mat[pos.row, pos.column] = true;
                }

                // #jogadaespecial en passant
                if (position.row == 4) {
                    Position esquerda = new Position(position.row, position.column - 1);
                    if (esquerda.IsPositionValid() && existeInimigo(esquerda) && tab.PiecePosition(esquerda) == partida.EnPassant) {
                        mat[esquerda.row + 1, esquerda.column] = true;
                    }
                    Position direita = new Position(position.row, position.column + 1);
                    if (direita.IsPositionValid() && existeInimigo(direita) && tab.PiecePosition(direita) == partida.EnPassant) {
                        mat[direita.row + 1, direita.column] = true;
                    }
                }
            }

            return mat;
        }
    }
}
