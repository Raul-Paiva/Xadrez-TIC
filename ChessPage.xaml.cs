using Xadrez_TIC.Enums;
using Xadrez_TIC.ViewModels;
using Xadrez_TIC.Exceptions;
using Color = Xadrez_TIC.Enums.Color;
using Xadrez_TIC.Pieces;
using Xadrez_TIC.Chess;

namespace Xadrez_TIC;

public partial class ChessPage : ContentPage
{
    //---------- Deal with received data ----------\\
    private bool isItTheFirstClick = true;
    private Piece firstPieceClicked;
    //----------------------------------------------\\

    //---------- Main Game Properties ----------\\
    private Board tab;
    private ChessMatch play;
    public readonly ChessViewModel viewModel;
    //-------------------------------------------\\

    //---------- Chess Positions Listed ----------\\
    public static Dictionary<string, ImageButton>? ChessPositions { get; private set; }
    //---------------------------------------------\\


    public ChessPage(ChessViewModel vm)
    {
        //---------- Initializing and Binding Components ----------\\
        InitializeComponent();        
        BindingContext = vm;
        //----------------------------------------------------------\\

        //---------- Chess Positions Listed ----------\\
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
        //---------------------------------------------\\

        //---------- Main Game Properties ----------\\
        viewModel = vm;
        tab = new Board(this);
        play = new ChessMatch(tab);
        //-------------------------------------------\\
    }

    //---------- Prepares the Source provided by xaml to be accepted by the code ----------\\
    private string SourceFileName(ImageButton piece)
    {
        string[] p = piece.Source.ToString().Split(' ');

        return p[1];
    }

    //---------- Reacts when a ImageButton is clicked and initializes game logic ----------\\
    void PressedOn(object sender, EventArgs e)
    {
        ImageButton positionPiece = (ImageButton)sender;
        string positionPieceConverted = ConvertPosition(positionPiece);

        if (ChessPositions.ContainsKey(positionPieceConverted))
        {
            if (isItTheFirstClick)
            {
                isItTheFirstClick = false;
                Piece pieceClicked = PiecePos(new Position(positionPieceConverted));

                if (pieceClicked is Free) { isItTheFirstClick = true; }
                else if (pieceClicked.color == play.PlayerColor) { firstPieceClicked = pieceClicked; }//vou ter de alterar para captar pecas apenas em lugares marcados(ponto.png) ou na class MovePiece
                else if (pieceClicked.color != play.PlayerColor) { throw new ChessException("Não podes mover a peça do teu adversário!"); }
                else { throw new FatalException("Não sei o que aconteceu! (linha 59 -- ChessPAge.xaml.cs)"); }
            }
            else
            {
                isItTheFirstClick = true;//prepares for the next round
                Piece pieceClicked = PiecePos(new Position(positionPieceConverted));

                if (pieceClicked is Free || pieceClicked.color != play.PlayerColor) { play.PlayPieces(firstPieceClicked.position, pieceClicked.position); }
                else if (pieceClicked.color == play.PlayerColor) { throw new ChessException("Não podes captar a tua prórpia peça!"); }
                else { throw new FatalException("Não sei o que aconteceu! (linha 74 -- ChessPAge.xaml.cs)"); }

                //tenho de mudar cor do jogador(já muda no metodo PlayPieces mas tenho de ver melhor)
            }
        }
        else { throw new FatalException("A posição clicada não existe!"); }

        //---------- Converts from a general Position to a well-defined one ----------\\
        string ConvertPosition(ImageButton position)
        {
            foreach (KeyValuePair<string, ImageButton> ib in ChessPositions)
            {
                if (position == ib.Value) { return ib.Key; }
            }
            throw new FatalException("Posição não existe? Erro desconhecido...");
        }
    }

    //---------- Adds the Position to the Board ----------\\
    public void Add(Position p, string source)
    {
        //InitializeComponent();
        ChessPositions[p.Chess()].Source = source;
    }

    //---------- Removes the Position from the Board ----------\\
    public Piece Remove(Position p)
    {
        Piece piece;

        try { piece = PiecePos(p); }
        catch (ChessException ce) { throw new ChessException(ce.Message); }
        catch (FatalException fe) { throw new FatalException("Erro em PiecePos:" + fe); }

        ChessPositions[p.Chess()].Source = "livre.png";
        piece.Captured();//pode ter um error porque cria uma replica da peca no tabuleiro
        return piece;
    }

    //---------- Displays the possible moves on the Board ----------\\
    public void MoveOptions(params Position[] positions)
    {
        foreach (Position p in positions) { ChessPositions[p.Chess()].Source = "ponto.png"; }//"File: ponto.png" é o que retorna da source -- se der erro é por isso
    }
    public void MoveOptions(Position p)
    {
        ChessPositions[p.Chess()].Source = "ponto.png";
    }

    //---------- Returns the Piece to a given Position on the Board ----------\\
    public Piece PiecePos(Position p)
    {
        Color color;

        string source = SourceFileName(ChessPositions[p.Chess()]);
        if (source == null) { throw new FatalException("A identificação posição deu nulo!"); }
        string nc = source.Split('.')[0];

        if (nc == "ponto") { return new Free(tab, p, "ponto"); }
        if (nc == "livre") { return new Free(tab, p, "livre"); }

        string[] info = nc.Split('_');
        if (info[1] == "p") { color = Color.Black; }
        else if (info[1] == "b") { color = Color.White; }
        else { throw new FatalException("Erro nas Cores."); }
        return CreatePiece(p, info[0], color);//pode ter um error porque cria uma replica da peca no tabuleiro
    }

    //---------- Creates a Piece with the provided characteristics ----------\\
    /// <summary>
    /// CreatePiece() returns a Piece with the given characteristics. Doesn't work when Piece is Free. 
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="piecesNames"></param>
    /// <param name="color"></param>
    /// <returns></returns>
    public Piece CreatePiece(Position pos, PiecesNames pieceName, Color color)//pode ter um error porque cria uma replica da peca no tabuleiro
    {
        Dictionary<string, Piece>? pieces = new Dictionary<string, Piece> {
            { "bispo", new Bispo(tab,color) }, { "cavalo", new Cavalo(tab, color) },
            { "torre", new Torre(tab, color) }, { "peao", new Peao(tab, color, play) },
            { "rei", new Rei(tab, color, play) }, { "dama", new Dama(tab, color) },
        };
        Piece newPiece = pieces[pieceName.ToString().ToLower().Trim()];
        newPiece.position = pos;
        return newPiece;
    }
    /// <summary>
    /// CreatePiece() returns a Piece with the given characteristics. Doesn't work when Piece is Free. 
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="piecesNames"></param>
    /// <param name="color"></param>
    /// <returns></returns>
    public Piece CreatePiece(Position pos, string pieceName, Color color)//pode ter um error porque cria uma replica da peca no tabuleiro
    {
        Dictionary<string, Piece>? pieces = new Dictionary<string, Piece> {
            { "bispo", new Bispo(tab,color) }, { "cavalo", new Cavalo(tab, color) },
            { "torre", new Torre(tab, color) }, { "peao", new Peao(tab, color, play) },
            { "rei", new Rei(tab, color, play) }, { "dama", new Dama(tab, color) },
        };
        if (pieceName == "livre" || pieceName == "ponto") { throw new FatalException("CreatePiece() returns a Piece with the given characteristics. Doesn't work when Piece is Free."); }
        else if (!pieces.ContainsKey(pieceName)) { throw new FatalException("Unknow error!"); }

        Piece newPiece = pieces[pieceName.ToLower().Trim()];
        newPiece.position = pos;
        return newPiece;
    }
}


