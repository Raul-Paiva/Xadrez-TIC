using Xadrez_TIC.Enums;
using Xadrez_TIC.ViewModels;
using Xadrez_TIC.Exceptions;
using Color = Xadrez_TIC.Enums.Color;
using Xadrez_TIC.Pieces;
using Xadrez_TIC.Chess;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Xadrez_TIC;

public partial class ChessPage : ContentPage
{
    public static Dictionary<string, ImageButton>? ChessPositions { get; private set; }
    private Board tab;
    private ChessMatch play;
    ChessViewModel viewModel;
    //public bool[,] PositionInfo { get; private set; }
    //public object[,] PiecesInfo { get; set; } = new object[32, 3]; // na classe Board -> PiecesPos

    public ChessPage(ChessViewModel vm)
    {
        InitializeComponent();
        viewModel = vm;
        BindingContext = vm;
        ChessPositions = new Dictionary<string, ImageButton>
        {
           { "a1",a1 },{ "b1",b1 },{ "c1",c1 },{ "d1",d1 },{ "e1",e1 },{ "f1",f1 },{ "g1",g1 },{ "h1",h1 },
            { "a2",a2 },{ "b2",b2 },{ "c2",c2 },{ "d2",d2 },{ "e2",e2 },{ "f2",f2 },{ "g2",g2 },{ "h2",h2 },
            { "a3",a3 },{ "b3",b3 },{ "c3",c3 },{ "d3",d3 },{ "e3",e3 },{ "f3",f3 },{ "g3",g3 },{ "h3",h3 },
            { "a4",a4 },{ "b4",b4 },{ "c4",c4 },{ "d4",d4 },{ "e4",e4 },{ "f4",f4 },{ "g4",g4 },{ "h4",h4 },
            { "a5",a5 },{ "b5",b5 },{ "c5",c5 },{ "d5",d5 },{ "e5",e5 },{ "f5",f5 },{ "g5",g5 },{ "h5",h5 },
            { "a6",a6 },{ "b6",b6 },{ "c6",c6 },{ "d6",d6 },{ "e6",e6 },{ "f6",f6 },{ "g6",g6 },{ "h6",h6 },
            { "a7",a7 },{ "b7",b7 },{ "c7",c7 },{ "d7",d7 },{ "e7",e7 },{ "f7",f7 },{ "g7",g7 },{ "h7",h7 },
            { "a8",a8 },{ "b8",b8 },{ "c8",c8 },{ "d8",d8 },{ "e8",e8 },{ "f8",f8 },{ "g8",g8 },{ "h8",h8 },
        };       
        tab = new Board(this);
        play = new ChessMatch(tab);
    }

    void PressedOn(object sender, EventArgs e)
    {
        ImageButton positionpiece = (ImageButton)sender;//------------------------------------Hello World saves world again!!!!---------------------
        if (positionpiece.IsPressed) { throw new ChessException("Hello World!"); }
    }

    /*private void Match(ChessViewModel vm)
    {
        //BindingContext = vm;
        while (!play.finished)
        {
        FirstChoiceLoop:
            Piece? clickedPiece1 = ClickedPiece(vm);
            if (clickedPiece1 is Free) { goto FirstChoiceLoop; }
            else if (clickedPiece1.color == play.Player)
            {
                    Piece? clickedPiece2 = ClickedPiece(vm);
                    if (clickedPiece2 is Free) { play.MovePiece(clickedPiece1.position,clickedPiece2.position); }//vou ter de alterar para captar pecas apenas em lugares marcados(ponto.png)
                    else if (clickedPiece2.color == play.Player)
                    {
                        throw new ChessException("Não podes captar a tua prórpia peça!");
                    }
                    else if (clickedPiece2.color != play.Player)
                    {
                    throw new FatalException("Não programei ainda.");
                    }
            }
            else if (clickedPiece1.color != play.Player)
            {
                throw new ChessException("Não podes mover a peça do teu adversário!");
            }
        }
    }*/

    /*private Piece ClickedPiece(ChessViewModel vm)
    {
        Position pos = new Position.Chess(vm.PressActions()).ToPosition();
        return tab.PiecePosition(pos);

    }*/

    public void Add(Position.Chess p, string source)
    {
        //InitializeComponent();
        ChessPositions[p.ToString()].Source = source;
    }

    public Piece Remove(Position.Chess p)
    {
        Piece piece;

        try { piece = PiecePos(p); }
        catch (ChessException ce) { throw new ChessException(ce.Message); }
        catch (FatalException fe) { throw new FatalException("Erro em PiecePos:" + fe); }

        ChessPositions[p.ToString()].Source = "livre.png";
        piece.Captured();//pode ter um error porque cria uma replica da peca no tabuleiro
        return piece;
    }

    public Piece PiecePos(Position.Chess p)
    {
        Color color;

        string source = ChessPositions[p.ToString()].Source.ToString();
        if (source == null) { throw new FatalException("A identificação posição deu nulo!"); }
        string nc = source.Split('.')[0];

        if (nc == "ponto") { throw new ChessException("ponto"); }
        if (nc == "livre") { throw new ChessException("livre"); }

        string[] info = nc.Split('_');
        if (info[1] == "p") { color = Color.Black; }
        else if (info[1] == "b") { color = Color.White; }
        else { throw new FatalException("Erro nas Cores."); }

        Dictionary<string, Piece>? pieces = new Dictionary<string, Piece> {//pode ter um error porque cria uma replica da peca no tabuleiro
            { "bispo", new Bispo(tab,color) }, { "cavalo", new Cavalo(tab, color) },
            { "torre", new Torre(tab, color) }, { "peao", new Peao(tab, color, play) },
            { "rei", new Rei(tab, color, play) }, { "dama", new Dama(tab, color) }, {"free",new Free(tab) },
        };

        pieces[info[0]].position = p.ToPosition();
        return pieces[info[0]];
    }


    public void MoveOptions(params Position.Chess[] positions)
    {
        foreach (Position.Chess p in positions) { ChessPositions[p.ToString()].Source = "ponto.png"; }
    }
    public void MoveOptions(Position.Chess p)
    {
        ChessPositions[p.ToString()].Source = "ponto.png";
    }
}

