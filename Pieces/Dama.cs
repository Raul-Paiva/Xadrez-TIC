﻿using Xadrez_TIC.Chess;
using Color = Xadrez_TIC.Enums.Color;

namespace Xadrez_TIC.Pieces {

    class Dama : Piece {

        public Dama(Board tab, Color color) : base(tab, color) {
        }

        public override string ToString() {
            return "dama";
        }

        private bool CanMove(Position pos) {
            Piece p = tab.PiecePosition(pos);
            return p == null || p.color != color;
        }

        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[tab.rows, tab.columns];

            Position pos = new Position(0, 0);

            // esquerda
            pos.DefineNewPositionValues(position.row, position.column - 1);
            while (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) != null && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewPositionValues(pos.row, pos.column - 1);
            }

            // direita
            pos.DefineNewPositionValues(position.row, position.column + 1);
            while (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) != null && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewPositionValues(pos.row, pos.column + 1);
            }

            // acima
            pos.DefineNewPositionValues(position.row - 1, position.column);
            while (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) != null && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewPositionValues(pos.row - 1, pos.column);
            }

            // abaixo
            pos.DefineNewPositionValues(position.row + 1, position.column);
            while (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) != null && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewPositionValues(pos.row + 1, pos.column);
            }

            // NO
            pos.DefineNewPositionValues(position.row - 1, position.column - 1);
            while (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) != null && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewPositionValues(pos.row - 1, pos.column - 1);
            }

            // NE
            pos.DefineNewPositionValues(position.row - 1, position.column + 1);
            while (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) != null && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewPositionValues(pos.row - 1, pos.column + 1);
            }

            // SE
            pos.DefineNewPositionValues(position.row + 1, position.column + 1);
            while (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) != null && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewPositionValues(pos.row + 1, pos.column + 1);
            }

            // SO
            pos.DefineNewPositionValues(position.row + 1, position.column - 1);
            while (pos.IsPositionValid() && CanMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (tab.PiecePosition(pos) != null && tab.PiecePosition(pos).color != color) {
                    break;
                }
                pos.DefineNewPositionValues(pos.row + 1, pos.column - 1);
            }

            return mat;
        }
    }
}
