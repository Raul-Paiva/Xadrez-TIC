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

        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[tab.rows, tab.columns];

            Position pos = new Position(0, 0);

            if (color == Color.Black) {
                pos.DefineNewPositionValues(position.row - 1, position.column);
                if (pos.IsPositionValid() && IsFree(pos)) {
                    mat[pos.row, pos.column] = true;
                }
                pos.DefineNewPositionValues(position.row - 2, position.column);
                Position p2 = new Position(position.row - 1, position.column);
                if (p2.IsPositionValid() && IsFree(p2) && pos.IsPositionValid() && IsFree(pos) && nMoves == 0) {
                    mat[pos.row, pos.column] = true;
                }
                pos.DefineNewPositionValues(position.row - 1, position.column - 1);
                if (pos.IsPositionValid() && IsFreeToMove(pos)) {
                    mat[pos.row, pos.column] = true;
                }
                pos.DefineNewPositionValues(position.row - 1, position.column + 1);
                if (pos.IsPositionValid() && IsFreeToMove(pos)) {
                    mat[pos.row, pos.column] = true;
                }
                /*
                // #jogadaespecial en passant
                if (position.row == 3) {
                    Position esquerda = new Position(position.row, position.column - 1);
                    if (esquerda.IsPositionValid() && IsFreeToMove(esquerda) && tab.PiecePosition(esquerda) == partida.EnPassant) {
                        mat[esquerda.row - 1, esquerda.column] = true;
                    }
                    Position direita = new Position(position.row, position.column + 1);
                    if (direita.IsPositionValid() && IsFreeToMove(direita) && tab.PiecePosition(direita) == partida.EnPassant) {
                        mat[direita.row - 1, direita.column] = true;
                    }
                }*/
            }
            else {
                pos.DefineNewPositionValues(position.row + 1, position.column);
                if (pos.IsPositionValid() && IsFree(pos)) {
                    mat[pos.row, pos.column] = true;
                }
                pos.DefineNewPositionValues(position.row + 2, position.column);//Erro
                Position p2 = new Position(position.row + 1, position.column);
                if (p2.IsPositionValid() && IsFree(p2) && pos.IsPositionValid() && IsFree(pos) && nMoves == 0) {
                    mat[pos.row, pos.column] = true;
                }
                pos.DefineNewPositionValues(position.row + 1, position.column - 1);
                if (pos.IsPositionValid() && IsFreeToMove(pos)) {
                    mat[pos.row, pos.column] = true;
                }
                pos.DefineNewPositionValues(position.row + 1, position.column + 1);
                if (pos.IsPositionValid() && IsFreeToMove(pos)) {
                    mat[pos.row, pos.column] = true;
                }
                /*
                // #jogadaespecial en passant
                if (position.row == 4) {
                    Position esquerda = new Position(position.row, position.column - 1);
                    if (esquerda.IsPositionValid() && IsFreeToMove(esquerda) && tab.PiecePosition(esquerda) == partida.EnPassant) {
                        mat[esquerda.row + 1, esquerda.column] = true;
                    }
                    Position direita = new Position(position.row, position.column + 1);
                    if (direita.IsPositionValid() && IsFreeToMove(direita) && tab.PiecePosition(direita) == partida.EnPassant) {
                        mat[direita.row + 1, direita.column] = true;
                    }
                }*/
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
