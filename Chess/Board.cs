using System.Diagnostics;
using Xadrez_TIC.Enums;
using Xadrez_TIC.ViewModels;
using Color = Xadrez_TIC.Enums.Color;
using Xadrez_TIC.Exceptions;

namespace Xadrez_TIC.Chess
{

    public class Board : ChessPage
    {
        public int linhas { get; private set; }
        public int colunas { get; private set; }
        private Piece[,] PiecesPos;

        //Instanciacao de um tabuleiro (normalmente feito no inicio de cada jogo)
        /// <summary>
        /// Creating a new Board (usually done at the beginning of the game)
        /// </summary>
        public Board()
        {
            linhas = 8;
            colunas = 8;
            PiecesPos = new Piece[linhas, colunas];
            Build();
        }

        //Funcao de construcao do tabuleiro
        private async void Build()
        {
            //Pecas Brancas
            AddPiece(new Position.Chess(1, 'a'), PiecesNames.Torre, Color.White);
            AddPiece(new Position.Chess(1, 'b'), PiecesNames.Cavalo, Color.White);
            AddPiece(new Position.Chess(1, 'c'), PiecesNames.Bispo, Color.White);
            AddPiece(new Position.Chess(1, 'd'), PiecesNames.Dama, Color.White);
            AddPiece(new Position.Chess(1, 'e'), PiecesNames.Rei, Color.White);
            AddPiece(new Position.Chess(1, 'f'), PiecesNames.Bispo, Color.White);
            AddPiece(new Position.Chess(1, 'g'), PiecesNames.Cavalo, Color.White);
            AddPiece(new Position.Chess(1, 'h'), PiecesNames.Torre, Color.White);
            AddPiece(new Position.Chess(2, 'a'), PiecesNames.Peao, Color.White);
            AddPiece(new Position.Chess(2, 'b'), PiecesNames.Peao, Color.White);
            AddPiece(new Position.Chess(2, 'c'), PiecesNames.Peao, Color.White);
            AddPiece(new Position.Chess(2, 'd'), PiecesNames.Peao, Color.White);
            AddPiece(new Position.Chess(2, 'e'), PiecesNames.Peao, Color.White);
            AddPiece(new Position.Chess(2, 'f'), PiecesNames.Peao, Color.White);
            AddPiece(new Position.Chess(2, 'g'), PiecesNames.Peao, Color.White);
            AddPiece(new Position.Chess(2, 'h'), PiecesNames.Peao, Color.White);

            //Pecas Pretas


            await UpdateBoardUI();
        }

        public void AddPiece(Position.Chess pos, PiecesNames p, Color c)//-----------------------------------------------------------------------------------------------------------\\
        {
            object[] vet = { pos, p, c };//vet[0] = pos; vet[1] = p; vet[2] = c
            PiecesPos[pos.row, pos.column] = new Piece(new Board(), c, p);
        }

        public Piece/*retorna peça retirada*/ RemovePiece(Position.Chess pos, PiecesNames p, Color c)//------------------------------------------------------------------------------------------------------------\\
        {
            object[] vet = { pos, p, c };//vet[0] = pos; vet[1] = p; vet[2] = c
            PiecesList.Remove(vet);
        }
        public Piece PiecePosition(Position pos)
        {
            return piece[pos.column, pos.row];
        }


        /// <summary>
        /// Only use this Method when you have already added all the pieces! 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FatalException"></exception>
        public async Task UpdateBoardUI()//-------------------------------------------------------------------------------------------------------------------------------------------------\\
        {
            //await Navigation.PushAsync(new ChessPage());

            // Get current page
            var page = Navigation.NavigationStack.Last();
            if (page is not ChessPage) { throw new FatalException("Erro updating uma página que não é ChessPage"); }

            //Create new page
            ChessPage newPage = new ChessPage(new ChessViewModel(), PiecesList);

            // Load new page
            await Navigation.PushAsync(newPage);

            // Remove old page
            Navigation.RemovePage(page);

        }

        public bool PieceExistence(Position pos)
        {
            CheckPosition(pos);
            return true;// testar se a peça existe (se é diferente de livre.png) ------------------------------------------------------------------------------------------\\
        }

        public bool IsPositionValid(Position pos)
        {
            if (pos.row<0 || pos.row>=linhas || pos.column<0 || pos.column>=colunas) { return false; }
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