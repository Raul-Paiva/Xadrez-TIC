using Xadrez_TIC.Enums;
using Color = Xadrez_TIC.Enums.Color;

namespace Xadrez_TIC.Chess
{

    class Board : ChessPage
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Piece[,] pecas;

        //Instanciacao de um tabuleiro (normalmente feito no inicio de cada jogo)
        public Board()
        {
            this.linhas = 8;
            this.colunas = 8;
            pecas = new Piece[linhas, colunas];
            Build();
        }

        //Funcao de construcao do tabuleiro
        private void Build()
        {
            //Pecas Brancas
            AddPiece(new Position.Chess(1, 'a'), PiecesList.Torre,Color.White);
            AddPiece(new Position.Chess(1, 'b'), PiecesList.Cavalo, Color.White);
            AddPiece(new Position.Chess(1, 'c'), PiecesList.Bispo, Color.White);
            AddPiece(new Position.Chess(1, 'd'), PiecesList.Dama, Color.White);
            AddPiece(new Position.Chess(1, 'e'), PiecesList.Rei, Color.White);
            AddPiece(new Position.Chess(1, 'f'), PiecesList.Bispo, Color.White);
            AddPiece(new Position.Chess(1, 'g'), PiecesList.Cavalo, Color.White);
            AddPiece(new Position.Chess(1, 'h'), PiecesList.Torre, Color.White);
            AddPiece(new Position.Chess(2, 'a'), PiecesList.Peao, Color.White);
            AddPiece(new Position.Chess(2, 'b'), PiecesList.Peao, Color.White);
            AddPiece(new Position.Chess(2, 'c'), PiecesList.Peao, Color.White);
            AddPiece(new Position.Chess(2, 'd'), PiecesList.Peao, Color.White);
            AddPiece(new Position.Chess(2, 'e'), PiecesList.Peao, Color.White);
            AddPiece(new Position.Chess(2, 'f'), PiecesList.Peao, Color.White);
            AddPiece(new Position.Chess(2, 'g'), PiecesList.Peao, Color.White);
            AddPiece(new Position.Chess(2, 'h'), PiecesList.Peao, Color.White);

            //Pecas Pretas
        }

        // função mover peças; função remover peças; criação do tabuleiro
    }

}