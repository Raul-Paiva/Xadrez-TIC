using Xadrez_TIC.Exceptions;
using Xadrez_TIC.Enums;
using Color = Xadrez_TIC.Enums.Color;

namespace Xadrez_TIC.Pieces
{
    //Local onde estao as pecas
    public static class Source
    {
        public static string PiecesSource(PiecesList p, Color c)
        {
            switch (p)
            {
                case PiecesList.Bispo:
                    if (Color.White == c) return "bispo_b.png";
                    else return "bispo_p.png";
                case PiecesList.Rei:
                    if (Color.White == c) return "rei_b.png";
                    else return "rei_p.png";
                case PiecesList.Dama:
                    if (Color.White == c) return "rainha_b.png";
                    else return "rainha_p.png";
                case PiecesList.Cavalo:
                    if (Color.White == c) return "cavalo_b.png";
                    else return "cavalo_p.png";
                case PiecesList.Peao:
                    if (Color.White == c) return "peao_b.png";
                    else return "peao_p.png";
                case PiecesList.Torre:
                    if (Color.White == c) return "torre_b.png";
                    else return "torre_p.png";
                default:
                    throw new FatalException("Erro na Enum PiecesList ou no Source.");
            }
        }
    }
}
