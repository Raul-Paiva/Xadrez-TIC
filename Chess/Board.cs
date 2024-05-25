using System.Diagnostics;
using Xadrez_TIC.Enums;
using Xadrez_TIC.Pieces;
using Color = Xadrez_TIC.Enums.Color;
using Xadrez_TIC.Exceptions;

namespace Xadrez_TIC.Chess
{

    public class Board
    {
        public int rows { get; private set; }
        public int columns { get; private set; }
        private Piece[,] PiecesPos;
        private ChessPage chessPage;

        //Instanciacao de um tabuleiro (normalmente feito no inicio de cada jogo)
        /// <summary>
        /// Creating a new Board (usually done at the beginning of the game)
        /// </summary>
        public Board(ChessPage chess)
        {
            rows = 8;
            columns = 8;
            chessPage = chess;

            PiecesPos = new Piece[rows, columns];
            Build().Wait();
        }


        //Funcao de construcao do tabuleiro
        private async Task Build()
        {
            //White Pieces
            AddPiece(new Position.Chess(1, 'a').ToPosition(), PiecesNames.Torre, Color.White,1);
            AddPiece(new Position.Chess(1, 'b').ToPosition(), PiecesNames.Cavalo, Color.White, 1);
            AddPiece(new Position.Chess(1, 'c').ToPosition(), PiecesNames.Bispo, Color.White, 1);
            AddPiece(new Position.Chess(1, 'd').ToPosition(), PiecesNames.Dama, Color.White, 1);
            AddPiece(new Position.Chess(1, 'e').ToPosition(), PiecesNames.Rei, Color.White, 1);
            AddPiece(new Position.Chess(1, 'f').ToPosition(), PiecesNames.Bispo, Color.White, 1);
            AddPiece(new Position.Chess(1, 'g').ToPosition(), PiecesNames.Cavalo, Color.White, 1);
            AddPiece(new Position.Chess(1, 'h').ToPosition(), PiecesNames.Torre, Color.White, 1);
            AddPiece(new Position.Chess(2, 'a').ToPosition(), PiecesNames.Peao, Color.White, 1);
            AddPiece(new Position.Chess(2, 'b').ToPosition(), PiecesNames.Peao, Color.White, 1);
            AddPiece(new Position.Chess(2, 'c').ToPosition(), PiecesNames.Peao, Color.White, 1);
            AddPiece(new Position.Chess(2, 'd').ToPosition(), PiecesNames.Peao, Color.White, 1);
            AddPiece(new Position.Chess(2, 'e').ToPosition(), PiecesNames.Peao, Color.White, 1);
            AddPiece(new Position.Chess(2, 'f').ToPosition(), PiecesNames.Peao, Color.White, 1);
            AddPiece(new Position.Chess(2, 'g').ToPosition(), PiecesNames.Peao, Color.White, 1);
            AddPiece(new Position.Chess(2, 'h').ToPosition(), PiecesNames.Peao, Color.White, 1);

            //Black Pieces
            AddPiece(new Position.Chess(8, 'a').ToPosition(), PiecesNames.Torre, Color.Black, 1);
            AddPiece(new Position.Chess(8, 'b').ToPosition(), PiecesNames.Cavalo, Color.Black, 1);
            AddPiece(new Position.Chess(8, 'c').ToPosition(), PiecesNames.Bispo, Color.Black, 1);
            AddPiece(new Position.Chess(8, 'd').ToPosition(), PiecesNames.Dama, Color.Black, 1);
            AddPiece(new Position.Chess(8, 'e').ToPosition(), PiecesNames.Rei, Color.Black, 1);
            AddPiece(new Position.Chess(8, 'f').ToPosition(), PiecesNames.Bispo, Color.Black, 1);
            AddPiece(new Position.Chess(8, 'g').ToPosition(), PiecesNames.Cavalo, Color.Black, 1);
            AddPiece(new Position.Chess(8, 'h').ToPosition(), PiecesNames.Torre, Color.Black, 1);
            AddPiece(new Position.Chess(7, 'a').ToPosition(), PiecesNames.Peao, Color.Black, 1);
            AddPiece(new Position.Chess(7, 'b').ToPosition(), PiecesNames.Peao, Color.Black, 1);
            AddPiece(new Position.Chess(7, 'c').ToPosition(), PiecesNames.Peao, Color.Black, 1);
            AddPiece(new Position.Chess(7, 'd').ToPosition(), PiecesNames.Peao, Color.Black, 1);
            AddPiece(new Position.Chess(7, 'e').ToPosition(), PiecesNames.Peao, Color.Black, 1);
            AddPiece(new Position.Chess(7, 'f').ToPosition(), PiecesNames.Peao, Color.Black, 1);
            AddPiece(new Position.Chess(7, 'g').ToPosition(), PiecesNames.Peao, Color.Black, 1);
            AddPiece(new Position.Chess(7, 'h').ToPosition(), PiecesNames.Peao, Color.Black, 1);
        }





        private void AddPiece(Position pos, PiecesNames p, Color c, int i)//-----------------------------------------------------------------------------------------------------------\\
        {
            i = 1;//e so para diferenciar a construcao dos movimentos de pecas
            string color;
            if (c == Color.White) { color = "b"; }
            else if (c == Color.Black) { color = "p"; }
            else { throw new FatalException("Erro nas Cores."); }
            chessPage.Add(pos.ToChessPosition(), p.ToString().ToLower() + "_" + color + ".png");
        }
        public void AddPiece(Position pos, PiecesNames p, Color c)//-----------------------------------------------------------------------------------------------------------\\
        {
            string color;
            if (c == Color.White) { color = "b"; }
            else if (c == Color.Black) { color = "p"; }
            else { throw new FatalException("Erro nas Cores."); }
            chessPage.Add(pos.ToChessPosition(), p.ToString().ToLower() + "_" + color + ".png");
        }
        public void AddPiece(Position.Chess pos, PiecesNames p, Color c)//-----------------------------------------------------------------------------------------------------------\\
        {
            string color;
            if (c == Color.White) { color = "b"; }
            else if (c == Color.Black) { color = "p"; }
            else { throw new FatalException("Erro nas Cores."); }
            chessPage.Add(pos, p.ToString().ToLower() + "_" + color + ".png");
        }
        public void AddPiece(Position pos, Piece p)//-----------------------------------------------------------------------------------------------------------\\
        {
            string color;
            if (p.color == Color.White) { color = "b"; }
            else if (p.color == Color.Black) { color = "p"; }
            else { throw new FatalException("Erro nas Cores."); }
            chessPage.Add(pos.ToChessPosition(), p.ToString().ToLower() + "_" + color + ".png");
        }
        public void AddPiece(Position.Chess pos, Piece p)//-----------------------------------------------------------------------------------------------------------\\
        {
            string color;
            if (p.color == Color.White) { color = "b"; }
            else if (p.color == Color.Black) { color = "p"; }
            else { throw new FatalException("Erro nas Cores."); }
            chessPage.Add(pos, p.ToString().ToLower() + "_" + color + ".png");
        }







        public Piece RemovePiece(Position pos)//retorna peça retirada
        {
            Piece removed;
            try { removed = chessPage.Remove(pos.ToChessPosition()); } catch (Exception) { throw new FatalException("Erro ao Remover Peca."); }
            return removed;
            //object[] vet = { pos, p, c };//vet[0] = pos; vet[1] = p; vet[2] = c
            //PiecesList.Remove(vet);
        }
        public Piece RemovePiece(Position.Chess pos)//retorna peça retirada
        {
            Piece removed;
            try { removed = chessPage.Remove(pos.ToChessPosition()); } catch (Exception) { throw new FatalException("Erro ao Remover Peca."); }
            return removed;
        }






        public Piece PiecePosition(Position pos)
        {
            if (PiecesPos[pos.row, pos.column] == chessPage.PiecePos(pos.ToChessPosition()))
            {
                return chessPage.PiecePos(pos.ToChessPosition());
            }
            else { throw new FatalException("Erro a descobrir a posição da peca."); }

        }
        public Piece PiecePosition(Position.Chess pos)
        {
            if (PiecesPos[pos.ToPosition().row, pos.ToPosition().column] == chessPage.PiecePos(pos))
            {
                return chessPage.PiecePos(pos.ToChessPosition());
            }
            else { throw new FatalException("Erro a descobrir a posição da peca."); }
        }






        public bool PieceExistence(Position pos)
        {
            CheckPosition(pos);
            return true;// testar se a peça existe (se é diferente de livre.png) ------------------------------------------------------------------------------------------\\
        }

        public bool IsPositionValid(Position pos)
        {
            if (pos.row < 0 || pos.row >= rows || pos.column < 0 || pos.column >= columns) { return false; }
            else { return true; }
        }

        public void CheckPosition(Position pos)
        {
            if (!IsPositionValid(pos))
            {
                throw new ChessException();//------------------------------------------------------------------------------------------------------------------------------\\
            }
        }
    }

}