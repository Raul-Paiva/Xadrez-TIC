﻿using Xadrez_TIC.Exceptions;
using Xadrez_TIC.Enums;
using Color = Xadrez_TIC.Enums.Color;

namespace Xadrez_TIC.Pieces
{
    //Local onde estao as pecas
    public static class Source
    {
        public static string PiecesSource(PiecesNames p, Color c)
        {
            switch (p)
            {
                case PiecesNames.Bispo:
                    if (Color.White == c) return "bispo_b.png";
                    else return "bispo_p.png";
                case PiecesNames.Rei:
                    if (Color.White == c) return "rei_b.png";
                    else return "rei_p.png";
                case PiecesNames.Dama:
                    if (Color.White == c) return "rainha_b.png";
                    else return "rainha_p.png";
                case PiecesNames.Cavalo:
                    if (Color.White == c) return "cavalo_b.png";
                    else return "cavalo_p.png";
                case PiecesNames.Peao:
                    if (Color.White == c) return "peao_b.png";
                    else return "peao_p.png";
                case PiecesNames.Torre:
                    if (Color.White == c) return "torre_b.png";
                    else return "torre_p.png";
                default:
                    throw new FatalException("Erro na Enum PiecesList ou no Source.");
            }
        }
        public static string PiecesSource(string piecesNames, Color c)
        {
            if (Color.White == c) return piecesNames + "_b.png";
            else return piecesNames + "_p.png";
        }
    }
}
