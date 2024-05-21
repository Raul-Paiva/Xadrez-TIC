using Xadrez_TIC.Enums;
using Xadrez_TIC.ViewModels;
using Xadrez_TIC.Exceptions;
using Color = Xadrez_TIC.Enums.Color;
using Xadrez_TIC.Pieces;
using Xadrez_TIC.Chess;
using System.Security.Cryptography;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace Xadrez_TIC;

public partial class ChessPage : ContentPage
{
    //public static Dictionary<string, ImageButton>? ChessPositions { get; private set; }
    //public bool[,] PositionInfo { get; private set; }
    public object[,] PiecesInfo { get; set; } = new object[32, 3];

    public ChessPage(ChessViewModel vm)
    {
        //ChessPositions = new Dictionary<string, ImageButton>
        //{
        //   { "a1",a1 },{ "b1",b1 },{ "c1",c1 },{ "d1",d1 },{ "e1",e1 },{ "f1",f1 },{ "g1",g1 },{ "h1",h1 },
        //    { "a2",a2 },{ "b2",b2 },{ "c2",c2 },{ "d2",d2 },{ "e2",e2 },{ "f2",f2 },{ "g2",g2 },{ "h2",h2 },
        //    { "a3",a3 },{ "b3",b3 },{ "c3",c3 },{ "d3",d3 },{ "e3",e3 },{ "f3",f3 },{ "g3",g3 },{ "h3",h3 },
        //    { "a4",a4 },{ "b4",b4 },{ "c4",c4 },{ "d4",d4 },{ "e4",e4 },{ "f4",f4 },{ "g4",g4 },{ "h4",h4 },
        //    { "a5",a5 },{ "b5",b5 },{ "c5",c5 },{ "d5",d5 },{ "e5",e5 },{ "f5",f5 },{ "g5",g5 },{ "h5",h5 },
        //    { "a6",a6 },{ "b6",b6 },{ "c6",c6 },{ "d6",d6 },{ "e6",e6 },{ "f6",f6 },{ "g6",g6 },{ "h6",h6 },
        //    { "a7",a7 },{ "b7",b7 },{ "c7",c7 },{ "d7",d7 },{ "e7",e7 },{ "f7",f7 },{ "g7",g7 },{ "h7",h7 },
        //    { "a8",a8 },{ "b8",b8 },{ "c8",c8 },{ "d8",d8 },{ "e8",e8 },{ "f8",f8 },{ "g8",g8 },{ "h8",h8 },
        //};

        //funcao para  fazer o mesmo com o dicionário
        InitializeComponent();
        BindingContext = vm;
        Board tab = new Board();
    }

    public ChessPage(ChessViewModel vm, List<object[]> list)
    {
        InitializeComponent();
        BindingContext = vm;

        a1.Source = "livre.png";
        a2.Source = "livre.png";
        a3.Source = "livre.png";
        a4.Source = "livre.png";
        a5.Source = "livre.png";
        a6.Source = "livre.png";
        a7.Source = "livre.png";
        a8.Source = "livre.png";
        b1.Source = "livre.png";
        b2.Source = "livre.png";
        b3.Source = "livre.png";
        b4.Source = "livre.png";
        b5.Source = "livre.png";
        b6.Source = "livre.png";
        b7.Source = "livre.png";
        b8.Source = "livre.png";
        c1.Source = "livre.png";
        c2.Source = "livre.png";
        c3.Source = "livre.png";
        c4.Source = "livre.png";
        c5.Source = "livre.png";
        c6.Source = "livre.png";
        c7.Source = "livre.png";
        c8.Source = "livre.png";
        d1.Source = "livre.png";
        d2.Source = "livre.png";
        d3.Source = "livre.png";
        d4.Source = "livre.png";
        d5.Source = "livre.png";
        d6.Source = "livre.png";
        d7.Source = "livre.png";
        d8.Source = "livre.png";
        e1.Source = "livre.png";
        e2.Source = "livre.png";
        e3.Source = "livre.png";
        e4.Source = "livre.png";
        e5.Source = "livre.png";
        e6.Source = "livre.png";
        e7.Source = "livre.png";
        e8.Source = "livre.png";
        f1.Source = "livre.png";
        f2.Source = "livre.png";
        f3.Source = "livre.png";
        f4.Source = "livre.png";
        f5.Source = "livre.png";
        f6.Source = "livre.png";
        f7.Source = "livre.png";
        f8.Source = "livre.png";
        g1.Source = "livre.png";
        g2.Source = "livre.png";
        g3.Source = "livre.png";
        g4.Source = "livre.png";
        g5.Source = "livre.png";
        g6.Source = "livre.png";
        g7.Source = "livre.png";
        g8.Source = "livre.png";
        h1.Source = "livre.png";
        h2.Source = "livre.png";
        h3.Source = "livre.png";
        h4.Source = "livre.png";
        h5.Source = "livre.png";
        h6.Source = "livre.png";
        h7.Source = "livre.png";
        h8.Source = "livre.png";

        foreach (object[] vet in list)
        {
            PiecesNames p = (PiecesNames)vet[1];
            Color c = (Color)vet[2];           

            switch (vet[0].ToString())
            {
                case "a1":
                    a1.Source = Source.PiecesSource(p, c);
                    break;
                case "a2":
                    a2.Source = Source.PiecesSource(p, c);
                    break;
                case "a3":
                    a3.Source = Source.PiecesSource(p, c);
                    break;
                case "a4":
                    a4.Source = Source.PiecesSource(p, c);
                    break;
                case "a5":
                    a5.Source = Source.PiecesSource(p, c);
                    break;
                case "a6":
                    a6.Source = Source.PiecesSource(p, c);
                    break;
                case "a7":
                    a7.Source = Source.PiecesSource(p, c);
                    break;
                case "a8":
                    a8.Source = Source.PiecesSource(p, c);
                    break;
                case "b1":
                    b1.Source = Source.PiecesSource(p, c);
                    break;
                case "b2":
                    b2.Source = Source.PiecesSource(p, c);
                    break;
                case "b3":
                    b3.Source = Source.PiecesSource(p, c);
                    break;
                case "b4":
                    b4.Source = Source.PiecesSource(p, c);
                    break;
                case "b5":
                    b5.Source = Source.PiecesSource(p, c);
                    break;
                case "b6":
                    b6.Source = Source.PiecesSource(p, c);
                    break;
                case "b7":
                    b7.Source = Source.PiecesSource(p, c);
                    break;
                case "b8":
                    b8.Source = Source.PiecesSource(p, c);
                    break;
                case "c1":
                    c1.Source = Source.PiecesSource(p, c);
                    break;
                case "c2":
                    c2.Source = Source.PiecesSource(p, c);
                    break;
                case "c3":
                    c3.Source = Source.PiecesSource(p, c);
                    break;
                case "c4":
                    c4.Source = Source.PiecesSource(p, c);
                    break;
                case "c5":
                    c5.Source = Source.PiecesSource(p, c);
                    break;
                case "c6":
                    c6.Source = Source.PiecesSource(p, c);
                    break;
                case "c7":
                    c7.Source = Source.PiecesSource(p, c);
                    break;
                case "c8":
                    c8.Source = Source.PiecesSource(p, c);
                    break;
                case "d1":
                    d1.Source = Source.PiecesSource(p, c);
                    break;
                case "d2":
                    d2.Source = Source.PiecesSource(p, c);
                    break;
                case "d3":
                    d3.Source = Source.PiecesSource(p, c);
                    break;
                case "d4":
                    d4.Source = Source.PiecesSource(p, c);
                    break;
                case "d5":
                    d5.Source = Source.PiecesSource(p, c);
                    break;
                case "d6":
                    d6.Source = Source.PiecesSource(p, c);
                    break;
                case "d7":
                    d7.Source = Source.PiecesSource(p, c);
                    break;
                case "d8":
                    d8.Source = Source.PiecesSource(p, c);
                    break;
                case "e1":
                    e1.Source = Source.PiecesSource(p, c);
                    break;
                case "e2":
                    e2.Source = Source.PiecesSource(p, c);
                    break;
                case "e3":
                    e3.Source = Source.PiecesSource(p, c);
                    break;
                case "e4":
                    e4.Source = Source.PiecesSource(p, c);
                    break;
                case "e5":
                    e5.Source = Source.PiecesSource(p, c);
                    break;
                case "e6":
                    e6.Source = Source.PiecesSource(p, c);
                    break;
                case "e7":
                    e7.Source = Source.PiecesSource(p, c);
                    break;
                case "e8":
                    e8.Source = Source.PiecesSource(p, c);
                    break;
                case "f1":
                    f1.Source = Source.PiecesSource(p, c);
                    break;
                case "f2":
                    f2.Source = Source.PiecesSource(p, c);
                    break;
                case "f3":
                    f3.Source = Source.PiecesSource(p, c);
                    break;
                case "f4":
                    f4.Source = Source.PiecesSource(p, c);
                    break;
                case "f5":
                    f5.Source = Source.PiecesSource(p, c);
                    break;
                case "f6":
                    f6.Source = Source.PiecesSource(p, c);
                    break;
                case "f7":
                    f7.Source = Source.PiecesSource(p, c);
                    break;
                case "f8":
                    f8.Source = Source.PiecesSource(p, c);
                    break;
                case "g1":
                    g1.Source = Source.PiecesSource(p, c);
                    break;
                case "g2":
                    g2.Source = Source.PiecesSource(p, c);
                    break;
                case "g3":
                    g3.Source = Source.PiecesSource(p, c);
                    break;
                case "g4":
                    g4.Source = Source.PiecesSource(p, c);
                    break;
                case "g5":
                    g5.Source = Source.PiecesSource(p, c);
                    break;
                case "g6":
                    g6.Source = Source.PiecesSource(p, c);
                    break;
                case "g7":
                    g7.Source = Source.PiecesSource(p, c);
                    break;
                case "g8":
                    g8.Source = Source.PiecesSource(p, c);
                    break;
                case "h1":
                    h1.Source = Source.PiecesSource(p, c);
                    break;
                case "h2":
                    h2.Source = Source.PiecesSource(p, c);
                    break;
                case "h3":
                    h3.Source = Source.PiecesSource(p, c);
                    break;
                case "h4":
                    h4.Source = Source.PiecesSource(p, c);
                    break;
                case "h5":
                    h5.Source = Source.PiecesSource(p, c);
                    break;
                case "h6":
                    h6.Source = Source.PiecesSource(p, c);
                    break;
                case "h7":
                    h7.Source = Source.PiecesSource(p, c);
                    break;
                case "h8":
                    h8.Source = Source.PiecesSource(p, c);
                    break;
            }

        }
    }

    public ChessPage() { }
    /*
    public ChessPage(byte MethodAddPiece, Position.Chess pos, PiecesList p, Color c)
    {
        //ImageButton positon = ChessPositions.GetValueOrDefault(pos.ToString());
        //if (position == null)
        //{
        //    throw new FatalException("A posição não é válida.");
        //}
        //else
        //{
        //    position.Source = Source.PiecesSource(p, c);
        //}        

        switch (pos.ToString())
        {
            case "a1":
                a1.Source = Source.PiecesSource(p, c);
                break;
            case "a2":
                a2.Source = Source.PiecesSource(p, c);
                break;
            case "a3":
                a3.Source = Source.PiecesSource(p, c);
                break;
            case "a4":
                a4.Source = Source.PiecesSource(p, c);
                break;
            case "a5":
                a5.Source = Source.PiecesSource(p, c);
                break;
            case "a6":
                a6.Source = Source.PiecesSource(p, c);
                break;
            case "a7":
                a7.Source = Source.PiecesSource(p, c);
                break;
            case "a8":
                a8.Source = Source.PiecesSource(p, c);
                break;
            case "b1":
                b1.Source = Source.PiecesSource(p, c);
                break;
            case "b2":
                b2.Source = Source.PiecesSource(p, c);
                break;
            case "b3":
                b3.Source = Source.PiecesSource(p, c);
                break;
            case "b4":
                b4.Source = Source.PiecesSource(p, c);
                break;
            case "b5":
                b5.Source = Source.PiecesSource(p, c);
                break;
            case "b6":
                b6.Source = Source.PiecesSource(p, c);
                break;
            case "b7":
                b7.Source = Source.PiecesSource(p, c);
                break;
            case "b8":
                b8.Source = Source.PiecesSource(p, c);
                break;
            case "c1":
                c1.Source = Source.PiecesSource(p, c);
                break;
            case "c2":
                c2.Source = Source.PiecesSource(p, c);
                break;
            case "c3":
                c3.Source = Source.PiecesSource(p, c);
                break;
            case "c4":
                c4.Source = Source.PiecesSource(p, c);
                break;
            case "c5":
                c5.Source = Source.PiecesSource(p, c);
                break;
            case "c6":
                c6.Source = Source.PiecesSource(p, c);
                break;
            case "c7":
                c7.Source = Source.PiecesSource(p, c);
                break;
            case "c8":
                c8.Source = Source.PiecesSource(p, c);
                break;
            case "d1":
                d1.Source = Source.PiecesSource(p, c);
                break;
            case "d2":
                d2.Source = Source.PiecesSource(p, c);
                break;
            case "d3":
                d3.Source = Source.PiecesSource(p, c);
                break;
            case "d4":
                d4.Source = Source.PiecesSource(p, c);
                break;
            case "d5":
                d5.Source = Source.PiecesSource(p, c);
                break;
            case "d6":
                d6.Source = Source.PiecesSource(p, c);
                break;
            case "d7":
                d7.Source = Source.PiecesSource(p, c);
                break;
            case "d8":
                d8.Source = Source.PiecesSource(p, c);
                break;
            case "e1":
                e1.Source = Source.PiecesSource(p, c);
                break;
            case "e2":
                e2.Source = Source.PiecesSource(p, c);
                break;
            case "e3":
                e3.Source = Source.PiecesSource(p, c);
                break;
            case "e4":
                e4.Source = Source.PiecesSource(p, c);
                break;
            case "e5":
                e5.Source = Source.PiecesSource(p, c);
                break;
            case "e6":
                e6.Source = Source.PiecesSource(p, c);
                break;
            case "e7":
                e7.Source = Source.PiecesSource(p, c);
                break;
            case "e8":
                e8.Source = Source.PiecesSource(p, c);
                break;
            case "f1":
                f1.Source = Source.PiecesSource(p, c);
                break;
            case "f2":
                f2.Source = Source.PiecesSource(p, c);
                break;
            case "f3":
                f3.Source = Source.PiecesSource(p, c);
                break;
            case "f4":
                f4.Source = Source.PiecesSource(p, c);
                break;
            case "f5":
                f5.Source = Source.PiecesSource(p, c);
                break;
            case "f6":
                f6.Source = Source.PiecesSource(p, c);
                break;
            case "f7":
                f7.Source = Source.PiecesSource(p, c);
                break;
            case "f8":
                f8.Source = Source.PiecesSource(p, c);
                break;
            case "g1":
                g1.Source = Source.PiecesSource(p, c);
                break;
            case "g2":
                g2.Source = Source.PiecesSource(p, c);
                break;
            case "g3":
                g3.Source = Source.PiecesSource(p, c);
                break;
            case "g4":
                g4.Source = Source.PiecesSource(p, c);
                break;
            case "g5":
                g5.Source = Source.PiecesSource(p, c);
                break;
            case "g6":
                g6.Source = Source.PiecesSource(p, c);
                break;
            case "g7":
                g7.Source = Source.PiecesSource(p, c);
                break;
            case "g8":
                g8.Source = Source.PiecesSource(p, c);
                break;
            case "h1":
                h1.Source = Source.PiecesSource(p, c);
                break;
            case "h2":
                h2.Source = Source.PiecesSource(p, c);
                break;
            case "h3":
                h3.Source = Source.PiecesSource(p, c);
                break;
            case "h4":
                h4.Source = Source.PiecesSource(p, c);
                break;
            case "h5":
                h5.Source = Source.PiecesSource(p, c);
                break;
            case "h6":
                h6.Source = Source.PiecesSource(p, c);
                break;
            case "h7":
                h7.Source = Source.PiecesSource(p, c);
                break;
            case "h8":
                h8.Source = Source.PiecesSource(p, c);
                break;
        }

    }

    private protected void AddPiece(Position.Chess pos, PiecesList p, Color c)
    {

    }

    private protected void RemovePiece(Position.Chess pos)
    {
        //ImageButton position = ChessPositions.GetValueOrDefault(pos.ToString());
        //if (position == null)
        //{
        //    throw new FatalException("A posição não é válida.");
        //}
        //else
        //{
        //    position.Source = "livre.png";
        //}

        switch (pos.ToString())
        {
            case "a1":
                a1.Source = "livre.png";
                break;
            case "a2":
                a2.Source = "livre.png";
                break;
            case "a3":
                a3.Source = "livre.png";
                break;
            case "a4":
                a4.Source = "livre.png";
                break;
            case "a5":
                a5.Source = "livre.png";
                break;
            case "a6":
                a6.Source = "livre.png";
                break;
            case "a7":
                a7.Source = "livre.png";
                break;
            case "a8":
                a8.Source = "livre.png";
                break;
            case "b1":
                b1.Source = "livre.png";
                break;
            case "b2":
                b2.Source = "livre.png";
                break;
            case "b3":
                b3.Source = "livre.png";
                break;
            case "b4":
                b4.Source = "livre.png";
                break;
            case "b5":
                b5.Source = "livre.png";
                break;
            case "b6":
                b6.Source = "livre.png";
                break;
            case "b7":
                b7.Source = "livre.png";
                break;
            case "b8":
                b8.Source = "livre.png";
                break;
            case "c1":
                c1.Source = "livre.png";
                break;
            case "c2":
                c2.Source = "livre.png";
                break;
            case "c3":
                c3.Source = "livre.png";
                break;
            case "c4":
                c4.Source = "livre.png";
                break;
            case "c5":
                c5.Source = "livre.png";
                break;
            case "c6":
                c6.Source = "livre.png";
                break;
            case "c7":
                c7.Source = "livre.png";
                break;
            case "c8":
                c8.Source = "livre.png";
                break;
            case "d1":
                d1.Source = "livre.png";
                break;
            case "d2":
                d2.Source = "livre.png";
                break;
            case "d3":
                d3.Source = "livre.png";
                break;
            case "d4":
                d4.Source = "livre.png";
                break;
            case "d5":
                d5.Source = "livre.png";
                break;
            case "d6":
                d6.Source = "livre.png";
                break;
            case "d7":
                d7.Source = "livre.png";
                break;
            case "d8":
                d8.Source = "livre.png";
                break;
            case "e1":
                e1.Source = "livre.png";
                break;
            case "e2":
                e2.Source = "livre.png";
                break;
            case "e3":
                e3.Source = "livre.png";
                break;
            case "e4":
                e4.Source = "livre.png";
                break;
            case "e5":
                e5.Source = "livre.png";
                break;
            case "e6":
                e6.Source = "livre.png";
                break;
            case "e7":
                e7.Source = "livre.png";
                break;
            case "e8":
                e8.Source = "livre.png";
                break;
            case "f1":
                f1.Source = "livre.png";
                break;
            case "f2":
                f2.Source = "livre.png";
                break;
            case "f3":
                f3.Source = "livre.png";
                break;
            case "f4":
                f4.Source = "livre.png";
                break;
            case "f5":
                f5.Source = "livre.png";
                break;
            case "f6":
                f6.Source = "livre.png";
                break;
            case "f7":
                f7.Source = "livre.png";
                break;
            case "f8":
                f8.Source = "livre.png";
                break;
            case "g1":
                g1.Source = "livre.png";
                break;
            case "g2":
                g2.Source = "livre.png";
                break;
            case "g3":
                g3.Source = "livre.png";
                break;
            case "g4":
                g4.Source = "livre.png";
                break;
            case "g5":
                g5.Source = "livre.png";
                break;
            case "g6":
                g6.Source = "livre.png";
                break;
            case "g7":
                g7.Source = "livre.png";
                break;
            case "g8":
                g8.Source = "livre.png";
                break;
            case "h1":
                h1.Source = "livre.png";
                break;
            case "h2":
                h2.Source = "livre.png";
                break;
            case "h3":
                h3.Source = "livre.png";
                break;
            case "h4":
                h4.Source = "livre.png";
                break;
            case "h5":
                h5.Source = "livre.png";
                break;
            case "h6":
                h6.Source = "livre.png";
                break;
            case "h7":
                h7.Source = "livre.png";
                break;
            case "h8":
                h8.Source = "livre.png";
                break;
        }
    }

    private protected static void Options()
    {// Opcoes de possiveis movimentos ponto.png
    }
    */
}