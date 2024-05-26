using Color = Xadrez_TIC.Enums.Color;
using Xadrez_TIC.Exceptions;

namespace Xadrez_TIC.Chess
{
    public class Position
    {
        public int row { get; set; }
        public int column { get; set; }

        public int chessRow { get; set; }
        public char chessColumn { get; set; }

        public bool PositionValidity { get; set; }

        //Regista as informacoes da coluna e linha da peca
        public Position(int row, int column)
        {
            if (row >= 0 && row <= 7) { this.row = row; }
            else throw new FatalException("As posiçãos não foram bem definidas!");
            if (column >= 0 && column <= 7) { this.column = column; }
            else throw new FatalException("As posiçãos não foram bem definidas!");
            if (IsPositionValid()) { ToChessPosition(); }
        }

        //Construtor para ser usado na subclasse Chess
        public Position(int chessRow, char chessColumn)
        {
            if (chessRow >= 1 && chessRow <= 8) { this.chessRow = chessRow; }
            else throw new FatalException("As posiçãos não foram bem definidas!");
            if (chessColumn >= 'a' && chessColumn <= 'h') { this.chessColumn = chessColumn; }
            else throw new FatalException("As posiçãos não foram bem definidas!");
            if (IsChessPositionValid()) { ToPosition(); }
        }

        public Position(string fullChessPosition)
        {
            int number;
            fullChessPosition = fullChessPosition.Trim().ToLower();
            char character = fullChessPosition[0];
            try { number = int.Parse(fullChessPosition[1].ToString()); } catch (Exception e) { throw new FatalException("A posição é inválida!"); }
            chessColumn = character;
            chessRow = number;
            if (IsChessPositionValid()) { ToPosition(); }
        }

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
        public void DefineNewPositionValues(int row, int column)
        {
            this.row = row;
            this.column = column;

            if (IsPositionValid()) { ToChessPosition(); }
        }
        public void DefineNewChessValues(int chessRow, char chessColumn)
        {
            this.chessRow = chessRow;
            this.chessColumn = chessColumn;
            if (IsChessPositionValid()) { ToPosition(); }
        }

        private void ToPosition()
        {
            int i;
            if (chessColumn == 'a') { i = 0; }
            else if (chessColumn == 'b') { i = 1; }
            else if (chessColumn == 'c') { i = 2; }
            else if (chessColumn == 'd') { i = 3; }
            else if (chessColumn == 'e') { i = 4; }
            else if (chessColumn == 'f') { i = 5; }
            else if (chessColumn == 'g') { i = 6; }
            else if (chessColumn == 'h') { i = 7; }
            else { throw new FatalException("Erro na conversão de integers para caracteres."); }
            row = chessRow - 1;
            column = i;
        }

        private void ToChessPosition()
        {
            char c;
            if (column == 0) { c = 'a'; }
            else if (column == 1) { c = 'b'; }
            else if (column == 2) { c = 'c'; }
            else if (column == 3) { c = 'd'; }
            else if (column == 4) { c = 'e'; }
            else if (column == 5) { c = 'f'; }
            else if (column == 6) { c = 'g'; }
            else if (column == 7) { c = 'h'; }
            else { throw new FatalException("Erro na conversão de integers para caracteres."); }

            chessRow = row + 1;
            chessColumn = c;
        }

        public bool IsPositionValid()
        {
            //Position Type
            if (row <= 7 && row >= 0 && column <= 7 && column >= 0) { PositionValidity = true; return true; }
            else { PositionValidity = false; return false; }
        }
        private bool IsChessPositionValid()
        {
            if (chessRow <= 8 && chessRow >= 1 && chessColumn <= 'h' && chessColumn >= 'a') { PositionValidity = true; return true; }
            else { PositionValidity = false; return false; }
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) { return false; }
            if (obj is Position)
            {
                Position pos = (Position)obj;
                if (pos.column == column && pos.row == row) { return true; }
                else { return false; }
            }
            else { return false; }
        }

        //Retorna a coluna e a linha da peca ou a posicao do tipo "a2"
        public override string ToString()
        {
            return row
            + ","
            + column;
        }

        public string Chess()
        {
            return chessColumn.ToString()
                + chessRow.ToString();
        }

        /*
        public class Chess : Position
        {

            public int chessRow { get; set; }
            public char chessColumn { get; set; }


            //Regista as informacoes da coluna e linha da peca
            public Chess(int row, char column) : base(row, column)
            {
                if (chessRow >= 1 && chessRow <= 8) { chessRow = row; }
                else throw new FatalException("As posiçãos não foram bem definidas!");
                if (chessColumn >= 'a' && chessColumn <= 'h') { chessColumn = column; }
                else throw new FatalException("As posiçãos não foram bem definidas!");
            }
            public Chess(string fullPosition)
            {
                int number;
                fullPosition = fullPosition.Trim().ToLower();
                char character = fullPosition[0];
                try { number = int.Parse(fullPosition[1].ToString()); } catch (Exception e) { throw new FatalException("A posição é inválida!"); }
                chessColumn = character;
                chessRow = number;
            }


            //Entra com a posicao do tipo "a2" e sai com uma posicao do tipo posicao
            public Position ToPosition()
            {
                int i;
                if (chessColumn == 'a') { i = 0; }
                else if (chessColumn == 'b') { i = 1; }
                else if (chessColumn == 'c') { i = 2; }
                else if (chessColumn == 'd') { i = 3; }
                else if (chessColumn == 'e') { i = 4; }
                else if (chessColumn == 'f') { i = 5; }
                else if (chessColumn == 'g') { i = 6; }
                else if (chessColumn == 'h') { i = 7; }
                else { throw new FatalException("Erro na conversão de integers para caracteres."); }
                return new Position(chessRow + 1, i);
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
        }*/
    }
}
