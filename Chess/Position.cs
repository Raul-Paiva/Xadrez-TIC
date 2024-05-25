using Color = Xadrez_TIC.Enums.Color;
using Xadrez_TIC.Exceptions;

namespace Xadrez_TIC.Chess
{
    public class Position
    {
        public int row { get; set; }
        public int column { get; set; }


        //Regista as informacoes da coluna e linha da peca
        public Position(int row, int column)
        {
            this.row = row;
            this.column = column;
        }
        private Position() { }

        //Construtor para ser usado na subclasse Chess
        private Position(int row, char column) { }

        //Cor da posicao no tabuleiro, ou seja, dos quadrados
        public Enums.Color PositionColor()
        {
            string position = ToString();

            // Convertendo a posição para minúsculas para evitar problemas de comparação
            position = position.ToLower();

            // Verificando se a soma dos índices é par
            int collumIndex = position[0] - 'a' + 1;
            int rowIndex = int.Parse(position[1].ToString());
            // False - White; True - Black \\
            if ((collumIndex + rowIndex) % 2 == 0) { return Enums.Color.Black; }
            else { return Enums.Color.White; }
        }

        //Define novos valores para a posicao
        public void DefineNewValues(int row, int column)
        {
            this.row = row;
            this.column = column;

        }

        public virtual Chess ToChessPosition()
        {
            char c;
            if (column == 0) { c = 'a'; }//--------------------------------------------------------Possivel erro(nao sei se comeca no 0 ou no 1)-------------------------------------
            else if (column == 1) { c = 'b'; }
            else if (column == 2) { c = 'c'; }
            else if (column == 3) { c = 'd'; }
            else if (column == 4) { c = 'e'; }
            else if (column == 5) { c = 'f'; }
            else if (column == 6) { c = 'g'; }
            else if (column == 7) { c = 'h'; }
            else { throw new FatalException("Erro na conversão de integers para caracteres."); }

            return new Chess(9 - row, c);
        }

        //Retorna a coluna e a linha da peca ou a posicao do tipo "a2"
        public override string ToString()
        {
            return row
            + ","
            + column;
        }

        public virtual bool IsPositionValid()
        {
            //Position
            if (row < 0 || row >= 8 || column < 0 || column >= 8) { return false; }
            else { return true; }
        }


        public class Chess : Position
        {
            public int chessRow { get; set; }
            public char chessColumn { get; set; }


            //Regista as informacoes da coluna e linha da peca
            public Chess(int row, char column) : base(row, column)
            {
                chessRow = row;
                chessColumn = column;
            }
            public Chess(string fullPosition)
            {                
                int number;
                fullPosition = fullPosition.Trim().ToLower();                
                char character = fullPosition[0];
                try { number = int.Parse(fullPosition[1].ToString()); } catch (Exception e) { throw new Exception("A posição é inválida!"); }
                chessColumn = character;
                chessRow = number;
            }


            //Entra com a posicao do tipo "a2" e sai com uma posicao do tipo posicao
            public Position ToPosition()
            {
                return new Position(9 - chessRow, chessColumn - 'a');
            }

            public override sealed bool IsPositionValid()
            {
                //Position.Chess
                Position pos = this.ToPosition();
                if (pos.row < 0 || pos.row >= 8 || pos.column < 0 || pos.column >= 8) { return false; }
                else { return true; }
            }

            /// <summary>
            /// Vai dar erro, não use a conversão ToChessPosition na SubClasse Chess 
            /// </summary>
            /// <returns></returns>
            /// <exception cref="FatalException"></exception>
            public override sealed Chess ToChessPosition()
            {
                throw new FatalException("Não use a conversão ToChessPosition na SubClasse Chess");
            }


            //Retorna a posicao do tipo "a2"
            public override string ToString()
            {
                return chessColumn.ToString()
                + chessRow.ToString();
            }
        }
    }
}
