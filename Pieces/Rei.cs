using Xadrez_TIC.Chess;
using Color = Xadrez_TIC.Enums.Color;

namespace Xadrez_TIC.Pieces
{
    class Rei : Piece {

        private ChessMatch partida;

        public Rei(Board tab, Color color, ChessMatch partida) : base(tab, color) {
            this.partida = partida;
        }

        public override string ToString() {
            return "rei";
        }

        private bool CanMove(Position pos) {
            Piece p = tab.PiecePosition(pos);
            return p == null || p.color != color;
        }

        private bool testeTorreParaRoque(Position pos) {
            Piece p = tab.PiecePosition(pos);
            return p != null && p is Torre && p.color == color && p.nMoves == 0;
        }

        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[tab.rows, tab.columns];

            Position pos = new Position(0, 0);

            // acima
            pos.DefineNewPositionValues(position.row - 1, position.column);
            if (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            // ne
            pos.DefineNewPositionValues(position.row - 1, position.column + 1);
            if (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            // direita
            pos.DefineNewPositionValues(position.row, position.column + 1);
            if (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            // se
            pos.DefineNewPositionValues(position.row + 1, position.column + 1);
            if (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            // abaixo
            pos.DefineNewPositionValues(position.row + 1, position.column);
            if (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            // so
            pos.DefineNewPositionValues(position.row + 1, position.column - 1);
            if (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            // esquerda
            pos.DefineNewPositionValues(position.row, position.column - 1);
            if (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            // no
            pos.DefineNewPositionValues(position.row - 1, position.column - 1);
            if (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
            }

            // #jogadaespecial roque
            if (nMoves==0 && !partida.xeque) {
                // #jogadaespecial roque pequeno
                Position posT1 = new Position(position.row, position.column + 3);
                if (testeTorreParaRoque(posT1)) {
                    Position p1 = new Position(position.row, position.column + 1);
                    Position p2 = new Position(position.row, position.column + 2);
                    if (tab.PiecePosition(p1)==null && tab.PiecePosition(p2)==null) {
                        mat[position.row, position.column + 2] = true;
                    }
                }
                // #jogadaespecial roque grande
                Position posT2 = new Position(position.row, position.column - 4);
                if (testeTorreParaRoque(posT2)) {
                    Position p1 = new Position(position.row, position.column - 1);
                    Position p2 = new Position(position.row, position.column - 2);
                    Position p3 = new Position(position.row, position.column - 3);
                    if (tab.PiecePosition(p1) == null && tab.PiecePosition(p2) == null && tab.PiecePosition(p3) == null) {
                        mat[position.row, position.column - 2] = true;
                    }
                }
            } 


            return mat;
        }
    }
}
