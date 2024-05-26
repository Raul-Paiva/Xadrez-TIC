using Xadrez_TIC.Enums;
using Xadrez_TIC.Pieces;
using Color = Xadrez_TIC.Enums.Color;
using Xadrez_TIC.Exceptions;
using Microsoft.Maui.Controls;

namespace Xadrez_TIC.Chess
{

    public class Board
    {
        //---------- Main Board Properties ----------\\
        public readonly int rows = 8;
        public readonly int columns = 8;
        public Piece[,] PiecesPos;//Pieces Positions on the Board
        private ChessPage chessPage;//Page where the Board is
        //---------------------------------------------\\

        /// <summary>
        /// Creating a new Board (usually done at the beginning of each game)
        /// </summary>
        public Board(ChessPage chess)
        {
            //---------- Main Board Properties ----------\\
            chessPage = chess;
            PiecesPos = new Piece[rows, columns];
            //---------------------------------------------\\

            Build();//Build the Board with the initial Pieces
        }


        //---------- Build the Board with the initial Pieces ----------\\
        private void Build()
        {
            //White Pieces
            AddPiece(new Position(1, 'a'), PiecesNames.Torre, Color.White, 1);
            AddPiece(new Position(1, 'b'), PiecesNames.Cavalo, Color.White, 1);
            AddPiece(new Position(1, 'c'), PiecesNames.Bispo, Color.White, 1);
            AddPiece(new Position(1, 'd'), PiecesNames.Dama, Color.White, 1);
            AddPiece(new Position(1, 'e'), PiecesNames.Rei, Color.White, 1);
            AddPiece(new Position(1, 'f'), PiecesNames.Bispo, Color.White, 1);
            AddPiece(new Position(1, 'g'), PiecesNames.Cavalo, Color.White, 1);
            AddPiece(new Position(1, 'h'), PiecesNames.Torre, Color.White, 1);
            AddPiece(new Position(2, 'a'), PiecesNames.Peao, Color.White, 1);
            AddPiece(new Position(2, 'b'), PiecesNames.Peao, Color.White, 1);
            AddPiece(new Position(2, 'c'), PiecesNames.Peao, Color.White, 1);
            AddPiece(new Position(2, 'd'), PiecesNames.Peao, Color.White, 1);
            AddPiece(new Position(2, 'e'), PiecesNames.Peao, Color.White, 1);
            AddPiece(new Position(2, 'f'), PiecesNames.Peao, Color.White, 1);
            AddPiece(new Position(2, 'g'), PiecesNames.Peao, Color.White, 1);
            AddPiece(new Position(2, 'h'), PiecesNames.Peao, Color.White, 1);

            //Black Pieces
            AddPiece(new Position(8, 'a'), PiecesNames.Torre, Color.Black, 1);
            AddPiece(new Position(8, 'b'), PiecesNames.Cavalo, Color.Black, 1);
            AddPiece(new Position(8, 'c'), PiecesNames.Bispo, Color.Black, 1);
            AddPiece(new Position(8, 'd'), PiecesNames.Dama, Color.Black, 1);
            AddPiece(new Position(8, 'e'), PiecesNames.Rei, Color.Black, 1);
            AddPiece(new Position(8, 'f'), PiecesNames.Bispo, Color.Black, 1);
            AddPiece(new Position(8, 'g'), PiecesNames.Cavalo, Color.Black, 1);
            AddPiece(new Position(8, 'h'), PiecesNames.Torre, Color.Black, 1);
            AddPiece(new Position(7, 'a'), PiecesNames.Peao, Color.Black, 1);
            AddPiece(new Position(7, 'b'), PiecesNames.Peao, Color.Black, 1);
            AddPiece(new Position(7, 'c'), PiecesNames.Peao, Color.Black, 1);
            AddPiece(new Position(7, 'd'), PiecesNames.Peao, Color.Black, 1);
            AddPiece(new Position(7, 'e'), PiecesNames.Peao, Color.Black, 1);
            AddPiece(new Position(7, 'f'), PiecesNames.Peao, Color.Black, 1);
            AddPiece(new Position(7, 'g'), PiecesNames.Peao, Color.Black, 1);
            AddPiece(new Position(7, 'h'), PiecesNames.Peao, Color.Black, 1);
        }

        private void SetPiecesPos(Piece piece)
        {
            if (piece.position == null) { throw new FatalException("Não podes definir uma peça em PiecesPos sem Posição!"); }
            Position pos = piece.position;
            PiecesPos[pos.row, pos.column] = piece;
        }
        private void SetPiecesPos(Position pos, PiecesNames p, Color c)
        {
            Piece piece = chessPage.CreatePiece(pos, p, c);
            if (piece.position == null) { throw new FatalException("Não podes definir uma peça em PiecesPos sem Posição!"); }
            PiecesPos[pos.row, pos.column] = piece;
        }
        private void RemovePiecesPos(Position pos)
        {
            PiecesPos[pos.row, pos.column] = null;//????????????Erro?????????
        }



        private void AddPiece(Position pos, PiecesNames p, Color c, int i)//-----------------------------------------------------------------------------------------------------------\\
        {
            i = 1;//e so para diferenciar a construcao dos movimentos de pecas
            string color;
            if (c == Color.White) { color = "b"; }
            else if (c == Color.Black) { color = "p"; }
            else { throw new FatalException("Erro nas Cores."); }
            chessPage.Add(pos, p.ToString().ToLower() + "_" + color + ".png");
            SetPiecesPos(pos, p, c);
        }
        public void AddPiece(Position pos, PiecesNames p, Color c)//-----------------------------------------------------------------------------------------------------------\\
        {
            string color;
            if (c == Color.White) { color = "b"; }
            else if (c == Color.Black) { color = "p"; }
            else { throw new FatalException("Erro nas Cores."); }
            chessPage.Add(pos, p.ToString().ToLower() + "_" + color + ".png");
            SetPiecesPos(pos, p, c);
        }
        public void AddPiece(Position pos, Piece p)//-----------------------------------------------------------------------------------------------------------\\
        {
            string color;
            if (p.color == Color.White) { color = "b"; }
            else if (p.color == Color.Black) { color = "p"; }
            else { throw new FatalException("Erro nas Cores."); }
            chessPage.Add(pos, p.ToString().ToLower() + "_" + color + ".png");
            p.position = pos;
            SetPiecesPos(p);
        }







        public Piece RemovePiece(Position pos)//retorna peça retirada
        {
            Piece removed;
            try { removed = chessPage.Remove(pos); } catch (Exception) { throw new FatalException("Erro ao Remover Peca."); }
            RemovePiecesPos(pos);
            return removed;            
        }




        public Piece PiecePosition(Position pos)
        {
            if (chessPage.PiecePos(pos) is Free)//não tem peca(e um ponto ou livre) --- não vai ser resgistrada em PiecesPos
            {
                return chessPage.PiecePos(pos);
            }
            else
            {
                if (PiecesPos[pos.row, pos.column] == chessPage.PiecePos(pos))
                {
                    return chessPage.PiecePos(pos);
                }
                else { throw new FatalException("Erro a descobrir a posição da peca."); }
            }


        }




        public bool PieceExistence(Position pos)
        {
            CheckPosition(pos);
            Piece piece = PiecePosition(pos);
            return true;// testar se a peça existe (se é diferente de livre.png) ------------------------------------------------------------------------------------------\\
        }

        public void CheckPosition(Position pos)
        {
            if (!pos.IsPositionValid())
            {
                throw new ChessException();//------------------------------------------------------------------------------------------------------------------------------\\
            }
        }
    }

}