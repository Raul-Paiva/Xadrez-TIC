namespace Xadrez_TIC.Chess
{
    internal class Position
    {
        public int row { get; set; }
        public int column { get; set; }


        //Regista as informacoes da coluna e linha da peca
        public Position(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        //Construtor para ser usado na subclasse Chess
        private Position(int row, char column) { }

        //Cor da posicao no tabuleiro, ou seja, dos quadrados
        public Enums.Color Color()
        {
            string position = ToString();

            // Convertendo a posição para minúsculas para evitar problemas de comparação
            position = position.ToLower();

            // Verificando se a soma dos índices é par
            int collumIndex = position[0] - 'a' + 1;
            int rowIndex = int.Parse(position[1].ToString());
            // False - White; True - Black \\
            if ((collumIndex + rowIndex) % 2 == 0){return Enums.Color.Black;}
            else{return Enums.Color.White;}
        }

        //Define novos valores para a posicao
        public void DefineNewValues(int row, int column)
        {
            this.row = row;
            this.column = column;

        }

        //Retorna a coluna e a linha da peca ou a posicao do tipo "a2"
        public override string ToString()
        {
            return row
            + ","
            + column;
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

            //Entra com a posicao do tipo "a2" e sai com uma posicao do tipo posicao
            public Position ToPosition()
            {
                return new Position(8 - chessRow, chessColumn - 'a');
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
