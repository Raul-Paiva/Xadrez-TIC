using Xadrez_TIC.Enums;
using Xadrez_TIC.Pieces;
using Color = Xadrez_TIC.Enums.Color;
using Xadrez_TIC.Exceptions;

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
            PiecesPos = new Piece[rows, columns];//pode estar mal, conta o 0 ou o 1?
            //---------------------------------------------\\
        }


        //---------- Build the Board with the initial Pieces ----------\\
        public void BuildNewBoard()
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
            Position? pos = piece.position;
            if (pos == null) { throw new FatalException("Não podes definir uma peça em PiecesPos sem Posição!"); }
            if (piece == null || piece is Free) { throw new FatalException("Não podes definir uma peça sem a peça!"); }
            PiecesPos[pos.row, pos.column] = piece;
        }
        private Piece RemovePiecesPos(Position pos)
        {
            try
            {
                Piece removed = PiecesPos[pos.row, pos.column];
                if (removed == null) { removed = chessPage.PiecePosOnBoard(pos); }
                PiecesPos[pos.row, pos.column] = null;
                return removed;
            }
            catch (Exception) { throw new FatalException("Erro ao Remover Peca da lista de pecas PiecesPos."); }
        }



        private void AddPiece(Position pos, PiecesNames p, Color c, int i)//-----------------------------------------------------------------------------------------------------------\\
        {
            i = 1;//e so para diferenciar a construcao dos movimentos de pecas

            string color;
            if (c == Color.White) { color = "b"; }
            else if (c == Color.Black) { color = "p"; }
            else { throw new FatalException("Erro nas Cores."); }

            chessPage.Add(pos, p.ToString().ToLower() + "_" + color + ".png");
            SetPiecesPos(chessPage.CreatePiece(pos, p, c));
        }
        public void AddPiece(Position pos, Piece p)//-----------------------------------------------------------------------------------------------------------\\
        {
            string color;
            if (p.color == Color.White) { color = "b"; }
            else if (p.color == Color.Black) { color = "p"; }
            else { throw new FatalException("Erro nas Cores."); }

            p.position = pos;
            chessPage.Add(pos, p.ToString().ToLower() + "_" + color + ".png");
            SetPiecesPos(p);
        }

        public Piece RemovePiece(Position pos)//retorna peça retirada
        {
            try
            {
                Piece removed = RemovePiecesPos(pos);
                chessPage.Remove(pos);
                return removed;
            }
            catch (FatalException fe) { throw new FatalException(fe.Message); }
            catch (Exception) { throw new FatalException("Erro ao Remover Peca."); }
        }



        /// <summary>
        /// Returns the Registered Piece in the provided position.
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public Piece PiecePosition(Position pos)
        {
            if (chessPage.PiecePosOnBoard(pos) is Free && PiecesPos[pos.row, pos.column] == null)//não tem peca(e um ponto ou livre)
            {
                return chessPage.PiecePosOnBoard(pos);// return Free();
            }


            Piece piece1 = chessPage.PiecePosOnBoard(pos);
            Piece piece2 = PiecesPos[pos.row, pos.column];
            if (piece1.GetType() == piece2.GetType() && piece1.color == piece2.color && piece1.position.Equals(piece2.position))
            {
                return piece2;
            }
            else { throw new FatalException("Erro a descobrir a posição da peca."); }
        }




        public bool PieceExistence(Position pos)
        {
            Piece piece = PiecePosition(pos);
            if(piece is not Free) { return true; }
            else { return false; }
        }
    }

}