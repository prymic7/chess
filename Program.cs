using ConsoleApp7;
using Raylib_cs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Runtime.CompilerServices;



public class Piece
{

    private Vector2 position = new Vector2();
    private Vector2 flyingPosition = new Vector2();
    private bool active = false;
    private bool alive = true;
    private bool moved = false;
    private string pieceName;
    private string color;
    private Vector2 startingPos = new Vector2();
    private List<Vector2> movesPossible = new List<Vector2>();
    private List<Vector2> opponentPiecesInReach = new List<Vector2>();
    private List<Vector2> ourPiecesInReach = new List<Vector2>();
    private List<Vector2> castleSquares = new List<Vector2>();
    private Image pieceImg = new Image();
    private Texture2D pieceTxt = new Texture2D();
    private bool isPieceFlying = false;
    private bool underAttack = false;
    private bool justMoved = false;
    public static int idAdder = 0;
    public int id = 0;
    

    public Piece(Vector2 position, string color, string imgPath, string pieceName)
    {
        this.position = position;
        this.color = color;
        this.pieceName = pieceName;
        pieceImg = Raylib.LoadImage(imgPath);
        pieceTxt = Raylib.LoadTextureFromImage(pieceImg);
        idAdder++;
        id = idAdder;
        startingPos = position;
    }

    public List<Vector2> OurPiecesInReach
    {
        get { return ourPiecesInReach; }
        set { ourPiecesInReach = value; }
    }

    public List<Vector2> CastleSquares
    {
        get { return castleSquares; }
        set { castleSquares = value; }
    }

    public string PieceName
    {
        get { return pieceName; }
        set { pieceName = value; }
    }

    public Vector2 StartingPos
    {
        get { return startingPos; }
        set { startingPos = value; }
    }

    public bool JustMoved
    {
        get { return justMoved; }
        set { justMoved = value; }
    }

    public List<Vector2> MovesPossible
    {
        get { return movesPossible; }
        set { movesPossible = value; }
    }

    public bool UnderAttack
    {
        get { return underAttack; }
        set { underAttack = value; }
    }
    public List<Vector2> OpponentsPiecesInReach
    {
        get { return opponentPiecesInReach; }
        set { opponentPiecesInReach = value; }
    }

    public Texture2D Texture
    {
        get { return pieceTxt; }
        set { pieceTxt = value; }
    }

    public Vector2 FlyingPosition
    {
        get { return flyingPosition; }
        set { flyingPosition = value; }
    }

    public bool PieceFlying
    {
        get { return isPieceFlying; }
        set { isPieceFlying = value; }
    }

    public bool Moved
    {
        get { return moved; }
        set { moved = value; }
    }
    public bool Active
    {
        get { return active; }
        set { active = value; }
    }

    public string ColorPiece
    {
        get { return color; }
        set { color = value; }
    }
    public bool Alive
    {
        get { return alive; }
        set { alive = value; }
    }
    public Vector2 Position
    {
        get { return position; }
        set { position = value; }
    }

    public virtual void BringMoves(List<Piece> Pieces, List<Vector2> checkSquares, Vector2 attackerPos, bool isCheck)
    {
        //
    }

    public virtual void BringDefendingPieces(List<Piece> Pieces, List<Vector2> checkSquares)
    {
        //
    }

    public virtual void BringCastle(List<Piece> Pieces, List<Vector2> checkSquares)
    {
        //
    }

    public void Update()
    {
        //
    }

    public void Draw()
    {
        /*DrawPieceOnBoard();*/
    }
}
public class Board
{
    public int squareSize = 120;
    public int squaresCountToSide = 8;
    public Pawn pawn1B = new Pawn(new Vector2(0, 6), "black", "../../../img/bpawn.png");
    public Pawn pawn2B = new Pawn(new Vector2(1, 6), "black", "../../../img/bpawn.png");
    public Pawn pawn3B = new Pawn(new Vector2(2, 6), "black", "../../../img/bpawn.png");
    public Pawn pawn4B = new Pawn(new Vector2(3, 6), "black", "../../../img/bpawn.png");
    public Pawn pawn5B = new Pawn(new Vector2(4, 6), "black", "../../../img/bpawn.png");
    public Pawn pawn6B = new Pawn(new Vector2(5, 6), "black", "../../../img/bpawn.png");
    public Pawn pawn7B = new Pawn(new Vector2(6, 6), "black", "../../../img/bpawn.png");
    public Pawn pawn8B = new Pawn(new Vector2(7, 6), "black", "../../../img/bpawn.png");

    public Pawn pawn1W = new Pawn(new Vector2(0, 1), "white", "../../../img/wpawn.png");
    public Pawn pawn2W = new Pawn(new Vector2(1, 1), "white", "../../../img/wpawn.png");
    public Pawn pawn3W = new Pawn(new Vector2(2, 1), "white", "../../../img/wpawn.png");
    public Pawn pawn4W = new Pawn(new Vector2(3, 1), "white", "../../../img/wpawn.png");
    public Pawn pawn5W = new Pawn(new Vector2(4, 1), "white", "../../../img/wpawn.png");
    public Pawn pawn6W = new Pawn(new Vector2(5, 1), "white", "../../../img/wpawn.png");
    public Pawn pawn7W = new Pawn(new Vector2(6, 1), "white", "../../../img/wpawn.png");
    public Pawn pawn8W = new Pawn(new Vector2(7, 1), "white", "../../../img/wpawn.png");

    public Bishop bishop1B = new Bishop(new Vector2(2, 7), "black", "../../../img/bbishop.png");
    public Bishop bishop2B = new Bishop(new Vector2(5, 7), "black", "../../../img/bbishop.png");

    public Bishop bishop1W = new Bishop(new Vector2(2, 0), "white", "../../../img/wbishop.png");
    public Bishop bishop2W = new Bishop(new Vector2(5, 0), "white", "../../../img/wbishop.png");

    public Rook rook1B = new Rook(new Vector2(0, 7), "black", "../../../img/brook.png");
    public Rook rook2B = new Rook(new Vector2(7, 7), "black", "../../../img/brook.png");

    public Rook rook1W = new Rook(new Vector2(0, 0), "white", "../../../img/wrook.png");
    public Rook rook2W = new Rook(new Vector2(7, 0), "white", "../../../img/wrook.png");

    public Knight knight1B = new Knight(new Vector2(1, 7), "black", "../../../img/bknight.png");
    public Knight knight2B = new Knight(new Vector2(6, 7), "black", "../../../img/bknight.png");

    public Knight knight1W = new Knight(new Vector2(1, 0), "white", "../../../img/wknight.png");
    public Knight knight2W = new Knight(new Vector2(6, 0), "white", "../../../img/wknight.png");

    public Queen queen1B = new Queen(new Vector2(4, 7), "black", "../../../img/bqueen.png");

    public Queen queen1W = new Queen(new Vector2(4, 0), "white", "../../../img/wqueen.png");

    public King king1B = new King(new Vector2(3, 7), "black", "../../../img/bking.png");

    public King king1W = new King(new Vector2(3, 0), "white", "../../../img/wking.png");


    public List<Raylib_cs.Rectangle> boardRectangles = new List<Raylib_cs.Rectangle>();
    public List<Piece> pieces = new List<Piece>();
    public List<Vector2> checkSquares = new List<Vector2>();
    public List<Vector2> checkSquaresToBlock = new List<Vector2>();

    public Vector2 activeSquareCoord;
    public Vector2[][] boardSquares = new Vector2[8][];
    public Raylib_cs.Color firstSquareColor = new Raylib_cs.Color(250, 214, 165, 255);
    public Raylib_cs.Color secondSquareColor = new Raylib_cs.Color(138, 51, 36, 255);
    public List<Vector2> possibleMoves;
    public Vector2 startPiecePosition;
    public string pieceColorPlaying = "white";
    public Stopwatch stopwatch = new Stopwatch();
    bool kingChecked = false;
    Vector2 attackerPiecePosition = new Vector2();
    string whoWon;
    bool displayBillboard = false;
    string checkDirection;
    bool moveFinished = false;
    bool restartGameBool = false;
    bool restartFinished = false;
    bool mat = false;
    bool draw = true;
    public Board()
    {
        pieces.Add(pawn1B);
        pieces.Add(pawn2B);
        pieces.Add(pawn3B);
        pieces.Add(pawn4B);
        pieces.Add(pawn5B);
        pieces.Add(pawn6B);
        pieces.Add(pawn7B);
        pieces.Add(pawn8B);

        pieces.Add(pawn1W);
        pieces.Add(pawn2W);
        pieces.Add(pawn3W);
        pieces.Add(pawn4W);
        pieces.Add(pawn5W);
        pieces.Add(pawn6W);
        pieces.Add(pawn7W);
        pieces.Add(pawn8W);

        pieces.Add(bishop1B);
        pieces.Add(bishop2B);

        pieces.Add(bishop1W);
        pieces.Add(bishop2W);

        pieces.Add(rook1B);
        pieces.Add(rook2B);

        pieces.Add(rook1W);
        pieces.Add(rook2W);

        pieces.Add(knight1B);
        pieces.Add(knight2B);

        pieces.Add(knight1W);
        pieces.Add(knight2W);

        pieces.Add(queen1B);

        pieces.Add(queen1W);

        pieces.Add(king1B);

        pieces.Add(king1W);
        CreateBoardVisual();
        for (int i = 0; i < 8; i++)
        {
            boardSquares[i] = new Vector2[8];
            for (int j = 0; j < 8; j++)
            {
                boardSquares[i][j] = new Vector2(i, j);
            }
        }
    }

    public List<Piece> Pieces
    {
        get { return pieces; }
    }



    public int SquareSize
    {
        get { return squareSize; }
    }

    public void CreateBoardVisual()
    {
        for (int i = 0; i <= squaresCountToSide * squareSize; i += squareSize)
        {
            for (int j = 0; j <= squaresCountToSide * squareSize; j += squareSize)
            {
                Raylib_cs.Rectangle rectangle = new Raylib_cs.Rectangle(i, j, squareSize, squareSize);
                boardRectangles.Add(rectangle);
            }
        }
    }

    public void DrawPieces()
    {
        foreach (Piece piece in pieces)
        {
            if (!piece.PieceFlying)
            {
                Raylib.DrawTexture(piece.Texture, (int)piece.Position.X * 120, (int)piece.Position.Y * 120, Raylib_cs.Color.WHITE);
            }
        }
        foreach (Piece piece in pieces)
        {

            if (piece.PieceFlying)
            {
                Raylib.DrawTexture(piece.Texture, (int)piece.FlyingPosition.X, (int)piece.FlyingPosition.Y, Raylib_cs.Color.WHITE);
            }
        }
    }

    public void DrawBoard()
    {
        int ColorNow = 1;
        foreach (Raylib_cs.Rectangle rect in boardRectangles)
        {
            if (ColorNow == 1)
            {
                Raylib.DrawRectangle((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height, firstSquareColor);
                ColorNow = 2;
            } else if (ColorNow == 2)
            {
                ColorNow = 1;
                Raylib.DrawRectangle((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height, secondSquareColor);
            }
        }
    }

    public void CheckMovePossible(Piece piece)
    {
        bool jeCheck = isCheck("after");
        Vector2 jebak = new Vector2();
        foreach(Piece pic in pieces)
        {
            if (pic.Active)
            {
                foreach (Piece kurwa in pieces)
                {
                    if(kurwa.PieceName != "king" && kurwa.ColorPiece == pieceColorPlaying)
                    {
                        List<Vector2> list = new List<Vector2>(kurwa.OpponentsPiecesInReach);

                        foreach (Vector2 vec in list)
                        {
                            

                            if (vec == pic.Position)
                            {
                                jebak = kurwa.Position;
                                Console.WriteLine(kurwa.Position);
                                kurwa.BringMoves(pieces, checkSquares, jebak, jeCheck);

                            }
                        }
                    }
                    
                }
            }
        }
    }

    public void DrawMovesPossible()
    {
        List<Vector2> movesPossible = new List<Vector2>();
        List<Vector2> opponentPiecesInReach = new List<Vector2>();
        List<Vector2> ourPiecesInReach = new List<Vector2>();
        List<Vector2> castleSquares = new List<Vector2>();
        Vector2 piecePos = new Vector2();
        bool isPieceActive = false;

        foreach (Piece piece in pieces)
        {

            if (piece.Active)
            {
                piecePos = piece.Position;
                isPieceActive = true;
            }
            if (!piece.PieceFlying && piece.Active)
            {
                activeSquareCoord = piece.Position;
            }
        }
        if (isPieceActive)
        {
            int num = 0;

            foreach (Piece piece in pieces)
            {
                if (piece.Active)
                {
                    CheckMovePossible(piece);
                    movesPossible = piece.MovesPossible;

                    Raylib_cs.Rectangle rectangle = new Raylib_cs.Rectangle();
                    foreach (Vector2 vec in movesPossible)
                    {
                        rectangle.x = vec.X * squareSize;
                        rectangle.y = vec.Y * squareSize;
                        rectangle.width = squareSize;
                        rectangle.height = squareSize;
                        Raylib.DrawRectangleLinesEx(rectangle, 5.0f, Raylib_cs.Color.BLUE);
                    }
                }
            }

            foreach (Piece piece in pieces)
            {
                if (piece.Active)
                {
                    CheckMovePossible(piece);
                    piece.BringDefendingPieces(pieces, checkSquares);
                    piece.BringCastle(pieces, checkSquares);
                    opponentPiecesInReach = piece.OpponentsPiecesInReach;
                    ourPiecesInReach = piece.OurPiecesInReach;
                    castleSquares = piece.CastleSquares;
                    Raylib_cs.Rectangle rectangle = new Raylib_cs.Rectangle();
                    foreach (Vector2 vec in opponentPiecesInReach)
                    {
                        rectangle.x = vec.X * 120;
                        rectangle.y = vec.Y * 120;
                        rectangle.width = squareSize;
                        rectangle.height = squareSize;
                        Raylib.DrawRectangleLinesEx(rectangle, 5.0f, Raylib_cs.Color.YELLOW);
                    }
                    foreach (Vector2 vec in ourPiecesInReach)
                    {
                        rectangle.x = vec.X * 120;
                        rectangle.y = vec.Y * 120;
                        rectangle.width = squareSize;
                        rectangle.height = squareSize;
                        Raylib.DrawRectangleLinesEx(rectangle, 5.0f, Raylib_cs.Color.PURPLE);
                    }
                    foreach (Vector2 vec in castleSquares)
                    {
                        rectangle.x = vec.X * 120;
                        rectangle.y = vec.Y * 120;
                        rectangle.width = squareSize;
                        rectangle.height = squareSize;
                        Raylib.DrawRectangleLinesEx(rectangle, 5.0f, Raylib_cs.Color.PINK);
                    }
                }
                num++;
            }
            Raylib_cs.Rectangle rectangle1 = new Raylib_cs.Rectangle();
            rectangle1.x = activeSquareCoord.X * 120;
            rectangle1.y = activeSquareCoord.Y * 120;
            rectangle1.width = 120;
            rectangle1.height = 120;
            Raylib.DrawRectangleLinesEx(rectangle1, 5.0f, Raylib_cs.Color.GREEN);
        }
    }
    public void gameOver()
    {
        int num;
        List<Vector2> kingMovesPossible = new List<Vector2>();
        List<Vector2> attackingPieceMoves = new List<Vector2>();
        List<Vector2> defendingPieceMovesPossible = new List<Vector2>();
        bool kingCantMove = false;

        checkSquares.Clear();

        foreach (Piece jmPiece in pieces)
        {
            if (jmPiece.ColorPiece != pieceColorPlaying && jmPiece.PieceName != "pawn")
            {
                jmPiece.BringMoves(pieces, checkSquares, attackerPiecePosition, isCheck("after"));
                List<Vector2> list = new List<Vector2>(jmPiece.MovesPossible);
                foreach (Vector2 vec in list)
                {
                    checkSquares.Add(vec);
                }
            }

            if (jmPiece.ColorPiece != pieceColorPlaying && jmPiece.PieceName == "pawn")
            {
                if (pieceColorPlaying == "black")
                {
                    num = 1;
                }
                else
                {
                    num = -1;
                }
                jmPiece.BringMoves(pieces, checkSquares, attackerPiecePosition, isCheck("after"));



                checkSquares.Add(new Vector2(jmPiece.Position.X - 1, jmPiece.Position.Y + num));
                checkSquares.Add(new Vector2(jmPiece.Position.X + 1, jmPiece.Position.Y + num));

            }
        }

        foreach (Piece kingPiece in pieces)
        {
            if (kingPiece.ColorPiece == pieceColorPlaying && kingPiece.PieceName == "king")
            {
                kingPiece.BringMoves(pieces, checkSquares, attackerPiecePosition, isCheck("after"));
                kingMovesPossible = kingPiece.MovesPossible;
                if (kingMovesPossible.Count < 0)
                {
                    kingCantMove = true;
                    Console.WriteLine("king cant move");
                    break;
                }
            }
        }
    }

    public bool willBeCheck()
    {
        List<Vector2> checkSquares = new List<Vector2>();
        foreach(Piece piece in pieces)
        {
            piece.BringMoves(pieces, checkSquares, attackerPiecePosition, isCheck("after"));
        }
        List<Vector2> movesPossible = new List<Vector2>();
        List<Vector2> kingMovesPossible = new List<Vector2>();
        List<Vector2> kingKicksPossible = new List<Vector2>();
        List<Vector2> opponentPiecesInReach = new List<Vector2>();
        List<Vector2> pieceMovedAttackedPieces = new List<Vector2>();
        Vector2 attackedKingVec = new Vector2();


        foreach (Piece kingPiece in pieces)
        {
            if (kingPiece.PieceName == "king" && kingPiece.ColorPiece == pieceColorPlaying)
            {
                attackedKingVec.X = kingPiece.Position.X;
                attackedKingVec.Y = kingPiece.Position.Y;

                break;
            }
        }

        foreach (Piece piece in pieces)
        {
            if(piece.ColorPiece != pieceColorPlaying)
            {
                opponentPiecesInReach = piece.OpponentsPiecesInReach;
                foreach(Vector2 vec in opponentPiecesInReach)
                {

                    if (vec == attackedKingVec)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public bool isCheck(string when)
    {
        List<Vector2> movesPossible = new List<Vector2>();
        List<Vector2> kingMovesPossible = new List<Vector2>();
        List<Vector2> kingKicksPossible = new List<Vector2>();
        List<Vector2> opponentPiecesInReach = new List<Vector2>();
        List<Vector2> pieceMovedAttackedPieces = new List<Vector2>();
        Vector2 attackedKingVec = new Vector2();


        kingChecked = false;

        foreach (Piece kingPiece in pieces)
        {
            if (kingPiece.PieceName == "king" && kingPiece.ColorPiece == pieceColorPlaying)
            {
                attackedKingVec.X = kingPiece.Position.X;
                attackedKingVec.Y = kingPiece.Position.Y;
                break;
            }
        }

        foreach (Piece piece in pieces)
        {

            if (when == "after")
            {

                if (piece.ColorPiece != pieceColorPlaying && piece.JustMoved)
                {
                    piece.BringMoves(pieces, checkSquares, attackerPiecePosition, false);
                    checkSquaresToBlock = piece.MovesPossible;
                    attackerPiecePosition = piece.Position;

                    pieceMovedAttackedPieces = piece.OpponentsPiecesInReach;

                    foreach (Vector2 vec in pieceMovedAttackedPieces)
                    {
                        if (vec.X == attackedKingVec.X && vec.Y == attackedKingVec.Y)
                        {

                            kingChecked = true;
                            break;
                        }
                    }
                }
            }
            else if (when == "before")
            {
                if (piece.ColorPiece != pieceColorPlaying)
                {
                    piece.BringMoves(pieces, checkSquares, attackerPiecePosition, isCheck("after"));
                    checkSquaresToBlock = piece.MovesPossible;
                    attackerPiecePosition = piece.Position;
                    pieceMovedAttackedPieces = piece.OpponentsPiecesInReach;

                    foreach (Vector2 vec in pieceMovedAttackedPieces)
                    {
                        if (vec.X == attackedKingVec.X && vec.Y == attackedKingVec.Y)
                        {
                            
                            kingChecked = true;
                            break;
                        }
                    }
                }
            }
        }

        if (kingChecked)
        {
            return true;
        } else
        {
            return false;
        }
    }
    //Kdyz je kral schovany za svym piecem, aby piece nemohl zmenit pozici
    public void CheckForUserInput()
    {
        List<Vector2> movesPossible = new List<Vector2>();
        List<Vector2> kingMovesPossible = new List<Vector2>();
        List<Vector2> kingKicksPossible = new List<Vector2>();
        List<Vector2> opponentPiecesInReach = new List<Vector2>();
        List<Vector2> castleSquares = new List<Vector2>();
        Vector2 mousePosition = Raylib.GetMousePosition();
        float mousePosX = mousePosition.X;
        float mousePosY = mousePosition.Y;
        bool wouldBeCheck = false;
        int isFlyingNum = 0;
        bool canCastle = true;

        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {
            int num;
            checkSquares.Clear();
            foreach (Piece jmPiece in pieces)
            {
                if (jmPiece.ColorPiece != pieceColorPlaying && jmPiece.PieceName != "pawn")
                {
                    jmPiece.BringMoves(pieces, checkSquares, attackerPiecePosition, isCheck("after"));
                    List<Vector2> list = new List<Vector2>(jmPiece.MovesPossible);
                    foreach (Vector2 vec in list)
                    {
                        checkSquares.Add(vec);
                    }
                }
                if (jmPiece.ColorPiece != pieceColorPlaying && jmPiece.PieceName == "pawn")
                {
                    if (pieceColorPlaying == "black")
                    {
                        num = 1;
                    }
                    else
                    {
                        num = -1;
                    }
                    jmPiece.BringMoves(pieces, checkSquares, attackerPiecePosition, isCheck("after"));


                    checkSquares.Add(new Vector2(jmPiece.Position.X - 1, jmPiece.Position.Y + num));
                    checkSquares.Add(new Vector2(jmPiece.Position.X + 1, jmPiece.Position.Y + num));

                }

            }
            foreach (Piece piece in pieces)
            {
                if (!piece.Active)
                {
                    Vector2 piecePos = piece.Position;
                    if (mousePosition.X > piecePos.X * 120 && 120 * piecePos.X + 120 > mousePosition.X && mousePosition.Y > piecePos.Y * 120 && 120 * piecePos.Y + 120 > mousePosition.Y && piece.ColorPiece == pieceColorPlaying)
                    {
                        startPiecePosition = piecePos;
                        activeSquareCoord = piecePos;
                        piece.Active = true;
                        piece.BringMoves(pieces, checkSquares, attackerPiecePosition, isCheck("after"));

                    }
                }
                else if (piece.Active)
                {
                    Vector2 piecePos = piece.Position;
                    if (mousePosition.X > piecePos.X * 120 && 120 * piecePos.X + 120 > mousePosition.X && mousePosition.Y > piecePos.Y * 120 && 120 * piecePos.Y + 120 > mousePosition.Y && piece.ColorPiece == pieceColorPlaying)
                    {

                        piece.Active = false;
                        break;
                    }
                }
            }
        }
        if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
        {
            int activenum = 0;
            foreach (Piece piece in pieces)
            {
                if (piece.Active && piece.ColorPiece == pieceColorPlaying)
                {
                    activenum++;
                    piece.PieceFlying = true;
                    Vector2 provisionalPosPiece;
                    provisionalPosPiece.X = (mousePosition.X - 60);
                    provisionalPosPiece.Y = (mousePosition.Y - 60);
                    Texture2D pieceTexture = piece.Texture;
                    piece.FlyingPosition = provisionalPosPiece;


                }
                CheckMovePossible(piece);
            }
            



        }
        if (Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON))
        {
            bool castled = false;
            foreach (Piece pc in pieces)
            {
                if (pc is Pawn)
                {
                    Pawn pawn = (Pawn)pc;

                    if (pawn.Active)
                    {
                        foreach (Piece piece in pieces)
                        {
                            if (piece is Pawn)
                            {
                                Pawn paw = (Pawn)piece;
                                if (paw.PawnJumped)
                                {
                                    if (pawn.ColorPiece == "black")
                                    {
                                        List<Vector2> list1 = new List<Vector2>();
                                        list1 = pawn.OpponentsPiecesInReach;
                                        foreach (Vector2 vec in list1)
                                        {
                                            if (mousePosition.X > vec.X * 120 && mousePosition.X < 120 + vec.X * 120 && mousePosition.Y > vec.Y * 120 && mousePosition.Y < 120 + vec.Y * 120)
                                            {
                                                if (vec.Y < paw.Position.Y && Math.Abs(vec.X - paw.Position.X) == 0)
                                                {
                                                    pawn.JustMoved = true;
                                                    paw.Position = new Vector2(2000, 2000);
                                                    pawn.Position = vec;
                                                    pawn.Active = false;
                                                    pawn.Moved = true;
                                                    paw.PawnJumped = false;
                                                    if (pieceColorPlaying == "black")
                                                    {
                                                        pieceColorPlaying = "white";
                                                    }
                                                    else
                                                    {
                                                        pieceColorPlaying = "black";
                                                    }
                                                    break;

                                                }
                                            }
                                        }
                                    }
                                    else if (pawn.ColorPiece == "white")
                                    {
                                        List<Vector2> list1 = new List<Vector2>();
                                        list1 = pawn.OpponentsPiecesInReach;
                                        foreach (Vector2 vec in list1)
                                        {
                                            if (mousePosition.X > vec.X * 120 && mousePosition.X < 120 + vec.X * 120 && mousePosition.Y > vec.Y * 120 && mousePosition.Y < 120 + vec.Y * 120)
                                            {
                                                if (vec.Y > paw.Position.Y && Math.Abs(vec.X - paw.Position.X) == 0)
                                                {
                                                    pawn.JustMoved = true;
                                                    paw.Position = new Vector2(2000, 2000);
                                                    pawn.Position = vec;
                                                    pawn.Active = false;
                                                    pawn.Moved = true;
                                                    paw.PawnJumped = false;
                                                    if (pieceColorPlaying == "black")
                                                    {
                                                        pieceColorPlaying = "white";
                                                    }
                                                    else
                                                    {
                                                        pieceColorPlaying = "black";
                                                    }
                                                    break;

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }

            List<Vector2> pieceMovedAttackedPieces = new List<Vector2>();
            Vector2 attackedKingVec = new Vector2();
            bool opponentPieceOut = false;
            
            foreach (Piece kingPiece in pieces)
            {
                if (kingPiece.PieceName == "king" && kingPiece.ColorPiece == pieceColorPlaying && kingPiece.PieceFlying)
                {
                    attackedKingVec = new Vector2(kingPiece.Position.X, kingPiece.Position.Y);
                    castleSquares = kingPiece.CastleSquares;
                    foreach (Vector2 square in castleSquares)
                    {
                        if (mousePosition.X > square.X * 120 && mousePosition.Y > square.Y * 120 && mousePosition.X < 120 + square.X * 120 && mousePosition.Y < 120 + square.Y * 120)
                        {
                            if (square.X < 3)
                            {
                                foreach (Piece rook in pieces)
                                {
                                    if (rook.PieceName == "rook" && rook.Position.X == 0 && rook.ColorPiece == pieceColorPlaying)
                                    {
                                        rook.Position = new Vector2(square.X + 1, square.Y);
                                        rook.JustMoved = true;
                                        rook.Moved = true;
                                        if (pieceColorPlaying == "black")
                                        {
                                            pieceColorPlaying = "white";
                                        }
                                        else
                                        {
                                            pieceColorPlaying = "black";
                                        }

                                        kingPiece.Position = square;
                                        kingPiece.JustMoved = true;
                                        kingPiece.Moved = true;
                                        kingPiece.Active = false;

                                        castled = true;

                                        break;
                                    }
                                }
                            }
                            if (square.X > 3)
                            {
                                foreach (Piece rook in pieces)
                                {
                                    if (rook.PieceName == "rook" && rook.Position.X == 7 && rook.ColorPiece == pieceColorPlaying)
                                    {
                                        castled = true;
                                        rook.Position = new Vector2(square.X - 1, square.Y);
                                        rook.JustMoved = true;
                                        rook.Moved = true;
                                        if (pieceColorPlaying == "black")
                                        {
                                            pieceColorPlaying = "white";
                                        }
                                        else
                                        {
                                            pieceColorPlaying = "black";
                                        }

                                        kingPiece.Position = square;
                                        kingPiece.JustMoved = true;
                                        kingPiece.Moved = true;
                                        kingPiece.Active = false;
                                        castled = true;
                                        break;
                                    }
                                }
                            }

                        }
                    }
                }
            }

            foreach (Piece piece in pieces)
            {
                if (piece.Position.X == attackerPiecePosition.X && piece.Position.Y == attackerPiecePosition.Y)
                {
                    foreach (Piece pic in pieces)
                    {
                        List<Vector2> list = new List<Vector2>(pic.OpponentsPiecesInReach);
                        foreach (Vector2 l in list)
                        {
                            if (l.X == attackerPiecePosition.X && l.Y == attackerPiecePosition.Y)
                            {
                                piece.UnderAttack = true;
                            }
                        }
                    }
                }
            }

            foreach (Piece piece in pieces)
            {
                if (piece.PieceFlying && piece.Active)
                {
                    List<Vector2> list = new List<Vector2>(piece.OpponentsPiecesInReach);
                    
                       
                    foreach(Vector2 l in list)
                    {
                       
                        if (mousePosX > l.X * 120 && 120 * l.X + 120 > mousePosX && mousePosY > 120 * l.Y && 120 + l.Y * 120 > mousePosY)
                        {
                            foreach (Piece deza in pieces)
                            {
                                if (deza.Position == l)
                                {
                                    Vector2 oldPos1 = new Vector2(piece.Position.X, piece.Position.Y);
                                    Vector2 oldPos2 = new Vector2(deza.Position.X, deza.Position.Y);
                                    deza.UnderAttack = false;
                                    deza.Alive = false;
                                    piece.Position = new Vector2(deza.Position.X, deza.Position.Y);
                                    deza.Position = new Vector2(2000, 2000);
                                    opponentPieceOut = true;
                                    piece.PieceFlying = false;
                                    piece.Moved = true;
                                    piece.Active = false;
                                    piece.JustMoved = true;

                                    if (willBeCheck())
                                    {
                                        piece.Position = oldPos1;
                                        deza.Position = oldPos2;
                                        break;
                                    }
                                    if (pieceColorPlaying == "black")
                                    {
                                        pieceColorPlaying = "white";
                                    }
                                    else
                                    {
                                        pieceColorPlaying = "black";
                                    }
                                    break;
                                    

                                }
                            }
                        }
                        
                        if (opponentPieceOut)
                        {
                            break;
                        }
                    }
                    
                    movesPossible = piece.MovesPossible;
                    opponentPiecesInReach = piece.OpponentsPiecesInReach;
                    if (!isCheck("after"))
                    {
                        attackerPiecePosition = piece.Position;
                    }

                    isFlyingNum++;
                    //Normalni vyhozeni
                    foreach (Piece piece2 in pieces)
                    {
                        if (piece2.UnderAttack)
                        {

                            if (mousePosX > piece2.Position.X * 120 && 120 * piece2.Position.X + 120 > mousePosX && mousePosY > 120 * piece2.Position.Y && 120 + piece2.Position.Y * 120 > mousePosY)
                            {


                                if (piece.ColorPiece != piece2.ColorPiece && piece.Position.X == attackerPiecePosition.X && piece.Position.Y == attackerPiecePosition.Y)
                                {
                                    foreach (Piece piecak in pieces)
                                    {
                                        if (piecak.JustMoved)
                                        {
                                            piecak.JustMoved = false;

                                        }
                                    }
                                    piece2.UnderAttack = false;
                                    piece2.Alive = false;
                                    piece.Position = new Vector2(piece2.Position.X, piece2.Position.Y);
                                    piece2.Position = new Vector2(2000, 2000);
                                    opponentPieceOut = true;
                                    piece.PieceFlying = false;
                                    piece.Moved = true;
                                    piece.Active = false;
                                    piece.JustMoved = true;

                                    if (pieceColorPlaying == "black")
                                    {
                                        pieceColorPlaying = "white";
                                    }
                                    else
                                    {
                                        pieceColorPlaying = "black";
                                    }
                                    break;


                                }

                            }
                        }
                    }

                    //}
                    if (opponentPieceOut)
                    {
                        break;
                    }
                    if (movesPossible.Count() == 0)
                    {
                        piece.Active = false;
                    }
                    foreach (Vector2 vec in movesPossible)
                    {
                        bool finish = false;
                        bool backed = false;
                        bool blockMoveCorrect = false;
                        // El passant
                        if (!kingChecked)
                        {

                            Vector2 oldPos;
                            if (mousePosX > vec.X * 120 && 120 * vec.X + 120 > mousePosX && mousePosY > 120 * vec.Y && 120 + vec.Y * 120 > mousePosY)
                            {
                                foreach (Piece pic in pieces)
                                {
                                    if (pic.JustMoved)
                                    {
                                        pic.JustMoved = false;
                                    }
                                }
                                foreach (Piece pc in pieces)
                                {
                                    if (pc is Pawn)
                                    {
                                        Pawn pawn = (Pawn)pc;
                                        pawn.PawnJumped = false;
                                    }
                                }
                                if (piece is Pawn && piece.Moved == false)
                                {
                                    if (piece.ColorPiece == "white")
                                    {
                                        if (Math.Abs(mousePosition.Y - piece.Position.Y * 120) > 240 && Math.Abs(mousePosition.X - piece.Position.X * 120) < 120)
                                        {

                                            Pawn pawn = (Pawn)piece;
                                            pawn.PawnJumped = true;
                                        }
                                    }
                                    else if (piece.ColorPiece == "black")
                                    {
                                        if (Math.Abs(mousePosition.Y - piece.Position.Y * 120) > 120 && Math.Abs(mousePosition.X - piece.Position.X * 120) < 120)
                                        {

                                            Pawn pawn = (Pawn)piece;
                                            pawn.PawnJumped = true;
                                        }
                                    }
                                }

                                moveFinished = true;
                                oldPos = new Vector2(piece.Position.X, piece.Position.Y);
                                piece.Position = vec;
                                piece.PieceFlying = false;
                                piece.Active = false;


                                piece.JustMoved = true;

                                piece.Moved = true;


                                if (isCheck("before"))
                                {
                                    piece.Position = oldPos;
                                    piece.PieceFlying = true;
                                    piece.Moved = false;
                                    piece.JustMoved = false;
                                    backed = true;
                                    break;
                                }
                                if (!backed)
                                {
                                    if (pieceColorPlaying == "black")
                                    {
                                        pieceColorPlaying = "white";
                                    }
                                    else
                                    {
                                        pieceColorPlaying = "black";
                                    }

                                    break;
                                }

                            }
                            else
                            {
                                if (!castled)
                                {
                                    piece.Position = startPiecePosition;
                                    piece.PieceFlying = false;
                                    piece.Active = false;
                                }

                            }
                        }

                        //Zablokovani utocnika
                        else if (kingChecked && piece.PieceName != "king")
                        /*else if (isCheck("after") && piece.PieceName != "king")*/
                        {
                            foreach (Piece pie in pieces)
                            {
                                

                                if(pie.PieceName == "king" && pieceColorPlaying == pie.ColorPiece)
                                {
                                    attackedKingVec = pie.Position;
                                }
                                if (pie.JustMoved)
                                {
                                    attackerPiecePosition = pie.Position;
                                }
                            }
                            

                            if (mousePosX > vec.X * 120 && 120 * vec.X + 120 > mousePosX && mousePosY > 120 * vec.Y && 120 + vec.Y * 120 > mousePosY)
                            {

                                if (attackerPiecePosition.X > attackedKingVec.X && attackerPiecePosition.Y > attackedKingVec.Y)
                                {
                                    checkDirection = "LeftUp";
                                    
                                }
                                else if (attackerPiecePosition.X > attackedKingVec.X && attackerPiecePosition.Y < attackedKingVec.Y)

                                {
                                    checkDirection = "LeftDown";

                                }
                                else if (attackerPiecePosition.X < attackedKingVec.X && attackerPiecePosition.Y > attackedKingVec.Y)
                                {
                                    checkDirection = "RightUp";

                                }
                                else if (attackerPiecePosition.X < attackedKingVec.X && attackerPiecePosition.Y < attackedKingVec.Y)
                                {
                                    checkDirection = "RightDown";


                                }
                                else if (attackerPiecePosition.X > attackedKingVec.X && attackerPiecePosition.Y == attackedKingVec.Y)
                                {
                                    checkDirection = "Left";
                                }
                                else if (attackerPiecePosition.X < attackedKingVec.X && attackerPiecePosition.Y == attackedKingVec.Y)
                                {
                                    checkDirection = "Right";
                                }
                                else if (attackerPiecePosition.X == attackedKingVec.X && attackerPiecePosition.Y > attackedKingVec.Y)
                                {
                                    checkDirection = "Up";
                                }
                                else if (attackerPiecePosition.X == attackedKingVec.X && attackerPiecePosition.Y < attackedKingVec.Y)
                                {
                                    checkDirection = "Down";
                                }


                                foreach (Vector2 vec2 in checkSquaresToBlock)
                                {
                                    bool pieceMoved = false;
                                    if (vec.X == vec2.X && vec.Y == vec2.Y)
                                    {
                                        if (checkDirection == "LeftUp")
                                        {

                                            if (attackerPiecePosition.X > vec2.X && attackerPiecePosition.Y > vec2.Y)
                                            {
                                                piece.Position = vec2;
                                                pieceMoved = true;
                                            }
                                        }
                                        else if (checkDirection == "LeftDown")
                                        {

                                            if (attackerPiecePosition.X > vec2.X && attackerPiecePosition.Y < vec2.Y)
                                            {
                                                piece.Position = vec2;
                                                pieceMoved = true;
                                            }
                                        }
                                        else if (checkDirection == "RightUp")
                                        {

                                            if (attackerPiecePosition.X < vec2.X && attackerPiecePosition.Y > vec2.Y)
                                            {
                                                piece.Position = vec2;
                                                pieceMoved = true;
                                            }
                                        }
                                        else if (checkDirection == "RightDown")
                                        {

                                            if (attackerPiecePosition.X < vec2.X && attackerPiecePosition.Y < vec2.Y)
                                            {
                                                piece.Position = vec2;
                                                pieceMoved = true;
                                            }
                                        }
                                        else if (checkDirection == "Left")
                                        {

                                            if (attackerPiecePosition.X > vec2.X && attackerPiecePosition.Y == vec2.Y)
                                            {
                                                piece.Position = vec2;
                                                pieceMoved = true;
                                            }
                                        }
                                        else if (checkDirection == "Right")
                                        {

                                            if (attackerPiecePosition.X < vec2.X && attackerPiecePosition.Y == vec2.Y)
                                            {
                                                piece.Position = vec2;
                                                pieceMoved = true;
                                            }
                                        }
                                        else if (checkDirection == "Up")
                                        {

                                            if (attackerPiecePosition.X == vec2.X && attackerPiecePosition.Y > vec2.Y)
                                            {
                                                piece.Position = vec2;
                                                pieceMoved = true;
                                            }
                                        }
                                        else if (checkDirection == "Down")
                                        {

                                            if (attackerPiecePosition.X == vec2.X && attackerPiecePosition.Y < vec2.Y)
                                            {
                                                piece.Position = vec2;
                                                pieceMoved = true;

                                            }
                                        }


                                        if (pieceMoved)
                                        {
                                            if (pieceColorPlaying == "black")
                                            {
                                                pieceColorPlaying = "white";
                                            }
                                            else
                                            {
                                                pieceColorPlaying = "black";
                                            }
                                            moveFinished = true;

                                            piece.PieceFlying = false;
                                            piece.Active = false;
                                            piece.Moved = true;
                                            piece.JustMoved = true;
                                            blockMoveCorrect = true;
                                            break;
                                        }
                                    }

                                    else
                                    {

                                        piece.Position = startPiecePosition;
                                        piece.PieceFlying = false;
                                        piece.Active = false;
                                    }
                                }
                            }
                            if (blockMoveCorrect)
                            {
                                break;
                            }
                            
                        }
                        if (finish)
                        {
                            break;
                        }
                    }
                }
            }
            //Pohyb krale na volne policka pri checku
            if (kingChecked)
            {
                foreach (Piece piece in pieces)
                {
                    if (piece.PieceFlying)
                    {
                        if (piece.PieceName == "king" && piece.ColorPiece == pieceColorPlaying)
                        {



                            kingMovesPossible = piece.MovesPossible;
                            kingKicksPossible = piece.OpponentsPiecesInReach;

                            foreach (Vector2 vec1 in kingMovesPossible)
                            {
                                
                               
                                
                                if (mousePosX > vec1.X * 120 && 120 * vec1.X + 120 > mousePosX && mousePosY > 120 * vec1.Y && 120 + vec1.Y * 120 > mousePosY)
                                {
                                    foreach (Piece pic in pieces)
                                    {
                                        if (pic.JustMoved)
                                        {
                                            pic.JustMoved = false;
                                        }
                                    }
                                    piece.Position = vec1;
                                    piece.PieceFlying = false;
                                    piece.Active = false;
                                    piece.Moved = true;
                                    piece.JustMoved = true;
                                    moveFinished = true;


                                    if (pieceColorPlaying == "black")
                                    {
                                        pieceColorPlaying = "white";
                                    }
                                    else
                                    {
                                        pieceColorPlaying = "black";
                                    }
                                    break;
                                }
                                



                            }
                            if (!moveFinished)
                            {
                                piece.Position = startPiecePosition;
                                piece.PieceFlying = false;
                                piece.Active = false;
                            }
                        }
                    }
                }
            }
            bool promoting = false;
            Vector2 position = new Vector2();
            string color = new string("");

            foreach (Piece piece in pieces)
            {
                if(piece is Pawn)
                {
                    Pawn pawn = (Pawn)piece;
                    if (pawn.CheckPromote())
                    {
                        promoting = true;
                        position = new Vector2(pawn.Position.X, pawn.Position.Y);
                        color = new string(pawn.ColorPiece);
                        
                        pieces.Remove(pawn);
                        break;
                    }
                }
            }

            if (promoting)
            {
                Queen queen = new Queen(position, color, "C:\\csharpProjects\\ConsoleApp7\\ConsoleApp7\\img\\bqueen.png");

                if (color == "black")
                {
                    queen = new Queen(position, color, "C:\\csharpProjects\\ConsoleApp7\\ConsoleApp7\\img\\bqueen.png");

                }
                else if (color == "white")
                {
                    queen = new Queen(position, color, "C:\\csharpProjects\\ConsoleApp7\\ConsoleApp7\\img\\wqueen.png");

                }
                queen.PieceFlying = false;
                queen.Active = false;
                queen.Moved = true;
                queen.JustMoved = true;
                pieces.Add(queen);
            }
            if (isCheck("after"))
            {
                
                kingChecked = true;
                gameOver();
                List<Vector2> canKingMove = new List<Vector2>();

                foreach (Piece king in pieces)
                {
                    if (king.PieceName == "king" && king.ColorPiece == pieceColorPlaying)
                    {
                        attackedKingVec = king.Position;
                        canKingMove = king.MovesPossible;

                    }
                }
                //Sledovani, jestli je mozne zablokovat utocici figurku
                if (attackerPiecePosition.X > attackedKingVec.X && attackerPiecePosition.Y > attackedKingVec.Y)
                {
                    checkDirection = "LeftUp";

                }
                else if (attackerPiecePosition.X > attackedKingVec.X && attackerPiecePosition.Y < attackedKingVec.Y)

                {
                    checkDirection = "LeftDown";

                }
                else if (attackerPiecePosition.X < attackedKingVec.X && attackerPiecePosition.Y > attackedKingVec.Y)
                {
                    checkDirection = "RightUp";
                    

                }
                else if (attackerPiecePosition.X < attackedKingVec.X && attackerPiecePosition.Y < attackedKingVec.Y)
                {
                    checkDirection = "RightDown";


                }
                else if (attackerPiecePosition.X > attackedKingVec.X && attackerPiecePosition.Y == attackedKingVec.Y)
                {
                    checkDirection = "Left";
                }
                else if (attackerPiecePosition.X < attackedKingVec.X && attackerPiecePosition.Y == attackedKingVec.Y)
                {
                    checkDirection = "Right";
                }
                else if (attackerPiecePosition.X == attackedKingVec.X && attackerPiecePosition.Y > attackedKingVec.Y)
                {
                    checkDirection = "Up";
                }
                else if (attackerPiecePosition.X == attackedKingVec.X && attackerPiecePosition.Y < attackedKingVec.Y)
                {
                    checkDirection = "Down";
                }

                bool blockingPossible = false;
                if (canKingMove.Count() > 0)
                {

                    blockingPossible = false;
                }
                if (checkDirection == "LeftUp")
                {
                    if (attackerPiecePosition.X > attackedKingVec.X && attackerPiecePosition.Y > attackedKingVec.Y)
                    {
                        bool changeColors = false;
                        foreach (Vector2 check in checkSquaresToBlock)
                        {
                            foreach (Piece blockingPiece in pieces)
                            {
                                if (blockingPiece.PieceName != "king" && blockingPiece.ColorPiece == pieceColorPlaying)
                                {
                                    List<Vector2> list1 = new List<Vector2>();
                                    List<Vector2> list2 = new List<Vector2>();
                                    blockingPiece.BringMoves(pieces, checkSquares, attackerPiecePosition, false);
                                    list1 = blockingPiece.MovesPossible;
                                    list2 = blockingPiece.OpponentsPiecesInReach;

                                    foreach (Vector2 vec in list1)
                                    {
                                        if (check.X < attackerPiecePosition.X && check.Y < attackerPiecePosition.Y)
                                        {
                                            if (vec.X == check.X && vec.Y == check.Y)
                                            {


                                                blockingPossible = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (checkDirection == "LeftDown")
                {

                    if (attackerPiecePosition.X > attackedKingVec.X && attackerPiecePosition.Y < attackedKingVec.Y)
                    {
                        foreach (Vector2 check in checkSquaresToBlock)
                        {
                            foreach (Piece blockingPiece in pieces)
                            {
                                if (blockingPiece.PieceName != "king" && blockingPiece.ColorPiece == pieceColorPlaying)
                                {

                                    List<Vector2> list1 = new List<Vector2>();
                                    List<Vector2> list2 = new List<Vector2>();

                                    blockingPiece.BringMoves(pieces, checkSquares, attackerPiecePosition, false);
                                    list1 = blockingPiece.MovesPossible;
                                    list2 = blockingPiece.OpponentsPiecesInReach;


                                    foreach (Vector2 vec in list1)
                                    {
                                        if (check.X < attackerPiecePosition.X && check.Y > attackerPiecePosition.Y)

                                        {
                                            if (vec.X == check.X && vec.Y == check.Y)
                                            {
                                                blockingPossible = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (checkDirection == "RightUp")
                {
                    if (attackerPiecePosition.X < attackedKingVec.X && attackerPiecePosition.Y > attackedKingVec.Y)
                    {

                        foreach (Vector2 check in checkSquaresToBlock)
                        {
                            foreach (Piece blockingPiece in pieces)
                            {
                                if (blockingPiece.PieceName != "king" && blockingPiece.ColorPiece == pieceColorPlaying)
                                {
                                    List<Vector2> list1 = new List<Vector2>();
                                    List<Vector2> list2 = new List<Vector2>();
                                    blockingPiece.BringMoves(pieces, checkSquares, attackerPiecePosition, false);
                                    list1 = blockingPiece.MovesPossible;
                                    list2 = blockingPiece.OpponentsPiecesInReach;
                                    foreach (Vector2 vec in list1)
                                    {
                                        if (check.X > attackerPiecePosition.X && check.Y < attackerPiecePosition.Y)
                                        {

                                            if (vec.X == check.X && vec.Y == check.Y)
                                            {
                                                blockingPossible = true;
                                                
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (checkDirection == "RightDown")
                {

                    if (attackerPiecePosition.X < attackedKingVec.X && attackerPiecePosition.Y < attackedKingVec.Y)
                    {
                        foreach (Vector2 check in checkSquaresToBlock)
                        {
                            foreach (Piece blockingPiece in pieces)
                            {
                                if (blockingPiece.PieceName != "king" && blockingPiece.ColorPiece == pieceColorPlaying)
                                {
                                    List<Vector2> list1 = new List<Vector2>();
                                    List<Vector2> list2 = new List<Vector2>();
                                    blockingPiece.BringMoves(pieces, checkSquares, attackerPiecePosition, false);
                                    list1 = blockingPiece.MovesPossible;
                                    list2 = blockingPiece.OpponentsPiecesInReach;
                                    foreach (Vector2 vec in list1)
                                    {
                                        if (check.X > attackerPiecePosition.X && check.Y > attackerPiecePosition.Y)

                                        {
                                            if (vec.X == check.X && vec.Y == check.Y)
                                            {
                                                blockingPossible = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (checkDirection == "Left")
                {

                    if (attackerPiecePosition.X > attackedKingVec.X && attackerPiecePosition.Y == attackedKingVec.Y)
                    {
                        foreach (Vector2 check in checkSquaresToBlock)
                        {
                            foreach (Piece blockingPiece in pieces)
                            {
                                if (blockingPiece.PieceName != "king" && blockingPiece.ColorPiece == pieceColorPlaying)
                                {
                                    List<Vector2> list1 = new List<Vector2>();
                                    List<Vector2> list2 = new List<Vector2>();
                                    blockingPiece.BringMoves(pieces, checkSquares, attackerPiecePosition, false);
                                    list1 = blockingPiece.MovesPossible;
                                    list2 = blockingPiece.OpponentsPiecesInReach;
                                    foreach (Vector2 vec in list1)
                                    {
                                        if (check.X < attackerPiecePosition.X && check.Y == attackerPiecePosition.Y)

                                        {
                                            if (vec.X == check.X && vec.Y == check.Y)
                                            {
                                                blockingPossible = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (checkDirection == "Right")
                {

                    if (attackerPiecePosition.X < attackedKingVec.X && attackerPiecePosition.Y == attackedKingVec.Y)
                    {
                        foreach (Vector2 check in checkSquaresToBlock)
                        {
                            foreach (Piece blockingPiece in pieces)
                            {
                                if (blockingPiece.PieceName != "king" && blockingPiece.ColorPiece == pieceColorPlaying)
                                {
                                    List<Vector2> list1 = new List<Vector2>();
                                    List<Vector2> list2 = new List<Vector2>();
                                    blockingPiece.BringMoves(pieces, checkSquares, attackerPiecePosition, false);
                                    list1 = blockingPiece.MovesPossible;
                                    list2 = blockingPiece.OpponentsPiecesInReach;
                                    foreach (Vector2 vec in list1)
                                    {
                                        if (check.X > attackerPiecePosition.X && check.Y == attackerPiecePosition.Y)

                                        {
                                            if (vec.X == check.X && vec.Y == check.Y)
                                            {
                                                blockingPossible = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (checkDirection == "Up")
                {

                    if (attackerPiecePosition.X == attackedKingVec.X && attackerPiecePosition.Y > attackedKingVec.Y)
                    {
                        foreach (Vector2 check in checkSquaresToBlock)
                        {
                            foreach (Piece blockingPiece in pieces)
                            {
                                if (blockingPiece.PieceName != "king" && blockingPiece.ColorPiece == pieceColorPlaying)
                                {
                                    List<Vector2> list1 = new List<Vector2>();
                                    List<Vector2> list2 = new List<Vector2>();
                                    blockingPiece.BringMoves(pieces, checkSquares, attackerPiecePosition, false);
                                    list1 = blockingPiece.MovesPossible;
                                    list2 = blockingPiece.OpponentsPiecesInReach;
                                    foreach (Vector2 vec in list1)
                                    {
                                        if (check.X == attackerPiecePosition.X && check.Y < attackerPiecePosition.Y)
                                        {
                                            if (vec.X == check.X && vec.Y == check.Y)
                                            {
                                                blockingPossible = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (checkDirection == "Down")
                {

                    if (attackerPiecePosition.X == attackedKingVec.X && attackerPiecePosition.Y < attackedKingVec.Y)
                    {
                        foreach (Vector2 check in checkSquaresToBlock)
                        {
                            foreach (Piece blockingPiece in pieces)
                            {
                                if (blockingPiece.PieceName != "king" && blockingPiece.ColorPiece == pieceColorPlaying)
                                {
                                    List<Vector2> list1 = new List<Vector2>();
                                    List<Vector2> list2 = new List<Vector2>();
                                    blockingPiece.BringMoves(pieces, checkSquares, attackerPiecePosition, false);
                                    list1 = blockingPiece.MovesPossible;
                                    list2 = blockingPiece.OpponentsPiecesInReach;
                                    foreach (Vector2 vec in list1)
                                    {
                                        if (check.X == attackerPiecePosition.X && check.Y > attackerPiecePosition.Y)
                                        {
                                            if (vec.X == check.X && vec.Y == check.Y)
                                            {
                                                blockingPossible = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
                List<Vector2> list3 = new List<Vector2>();
                List<Vector2> list4 = new List<Vector2>();
                bool kingCanMove = false;

                bool canKickAttacker = false;
                foreach (Piece defendingBlockingPiece in pieces)
                {
                    if(defendingBlockingPiece.Position == attackedKingVec)
                    {
                        list4 = defendingBlockingPiece.MovesPossible;
                        if(list4.Count() > 0)
                        {
                            kingCanMove = true;
                        }
                    }
                    if (defendingBlockingPiece.ColorPiece == pieceColorPlaying)
                    {

                        

                        list3 = defendingBlockingPiece.OpponentsPiecesInReach;
                        foreach (Vector2 vec1 in list3)
                        {

                            if (vec1.X == attackerPiecePosition.X && vec1.Y == attackerPiecePosition.Y)
                            {
                                canKickAttacker = true; break;
                            }
                        }
                    }
                }
                //Check if gameover
                if(!canKickAttacker && !blockingPossible && !kingCanMove)
                {
                    Console.WriteLine("GG");
                    restartGameBool = true;
                    restartFinished = false;
                    mat = true;
                    displayBillboard = true;
                }
                Console.WriteLine($"Mmuzes vyhodit: {canKickAttacker}");
                Console.WriteLine($"Muzes blokovat: {blockingPossible}");
                Console.WriteLine($"King se muze hnout: {kingCanMove}");
            }
            
            
            foreach (Piece piece in pieces)
            {
                if (piece.PieceFlying)
                {
                    piece.Active = false;
                    piece.PieceFlying = false;
                }

            }

            
            CheckDraw();

            


        }
    }

    public void CheckDraw()
    {
        int num;
        draw = true;
        while (checkSquares.Count() > 0)
        {
            checkSquares.RemoveAt(0);
        }
        foreach (Piece jmPiece in pieces)
        {
            if (jmPiece.ColorPiece != pieceColorPlaying && jmPiece.PieceName != "pawn")
            {
                jmPiece.BringMoves(pieces, checkSquares, attackerPiecePosition, isCheck("after"));
                List<Vector2> list = new List<Vector2>(jmPiece.MovesPossible);
                foreach (Vector2 vec in list)
                {
                    checkSquares.Add(vec);
                }
            }
            if(jmPiece.ColorPiece != pieceColorPlaying && jmPiece.PieceName == "pawn")
            {
                if(pieceColorPlaying == "black")
                {
                    num = -1;
                } else
                {
                    num = 1;
                }
                jmPiece.BringMoves(pieces, checkSquares, attackerPiecePosition, isCheck("after"));
                
                
                
                checkSquares.Add(new Vector2(jmPiece.Position.X - 1, jmPiece.Position.Y + num));
                checkSquares.Add(new Vector2(jmPiece.Position.X + 1, jmPiece.Position.Y + num));
                
            }
        }
        foreach (Piece piece in pieces)
        {
            
            if (piece.ColorPiece == pieceColorPlaying && piece.Position.X < 100)
            {
                piece.BringMoves(pieces, checkSquares, attackerPiecePosition, isCheck("after"));

                List<Vector2> movesPossible = new List<Vector2>(piece.MovesPossible);
                List<Vector2> kicksPossible = new List<Vector2>(piece.OpponentsPiecesInReach);
                if (movesPossible.Count() > 0 || kicksPossible.Count() > 0)
                {

                   


                    draw = false;
                    break;
                }
            }
           
            
        }
        if (draw && !mat)
        {
            Console.WriteLine("DRAW");

            displayBillboard = true;
            restartGameBool = true;
            restartFinished = false;
        }
    }

    public void DrawAfterGameText()
    {
        /*displayBillboard = true;*/
        int tableW = 300;
        int tableH = 50;
        int tableW2 = 200;
        int tableH2 = 50;
        Raylib_cs.Rectangle rect = new Raylib_cs.Rectangle((960 / 2) - tableW / 2, (960 / 2) - tableH / 2, tableW, tableH);
        Raylib_cs.Rectangle rect2 = new Raylib_cs.Rectangle((960 / 2) - tableW2 / 2, (960 / 2) - tableH2 / 2, tableW2, tableH2);
        if (displayBillboard && mat)
        {
            
            
            
            Raylib.DrawRectangle((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height, Raylib_cs.Color.BLACK);
            if (pieceColorPlaying == "white")
            {
                Raylib.DrawText("BLACK WON!", (int)rect.x + 30, (int)rect.y + 7, 40, Raylib_cs.Color.WHITE);
            }
            if(pieceColorPlaying == "black")
            {
                Raylib.DrawText("WHITE WON!", (int)rect.x + 30, (int)rect.y + 7, 40, Raylib_cs.Color.WHITE);
            }
        }
        if(displayBillboard && draw && !mat)
        {
            
            

            Raylib.DrawRectangle((int)rect2.x, (int)rect2.y, (int)rect2.width, (int)rect2.height, Raylib_cs.Color.BLACK);
            Raylib.DrawText("DRAW", (int)rect2.x + 40, (int)rect2.y + 7, 40, Raylib_cs.Color.WHITE);
        }
    }
    public void Draw()
    {
        DrawBoard();
        DrawMovesPossible();
        foreach (Piece piece in pieces)
        {
            piece.Draw();
        }
        DrawPieces();
        DrawAfterGameText();


    }

    public void RestartGame()
    {
        pawn1B = new Pawn(new Vector2(0, 6), "black", "../../../img/bpawn.png");
        pawn2B = new Pawn(new Vector2(1, 6), "black", "../../../img/bpawn.png");
        pawn3B = new Pawn(new Vector2(2, 6), "black", "../../../img/bpawn.png");
        pawn4B = new Pawn(new Vector2(3, 6), "black", "../../../img/bpawn.png");
        pawn5B = new Pawn(new Vector2(4, 6), "black", "../../../img/bpawn.png");
        pawn6B = new Pawn(new Vector2(5, 6), "black", "../../../img/bpawn.png");
        pawn7B = new Pawn(new Vector2(6, 6), "black", "../../../img/bpawn.png");
        pawn8B = new Pawn(new Vector2(7, 6), "black", "../../../img/bpawn.png");

        pawn1W = new Pawn(new Vector2(0, 1), "white", "../../../img/wpawn.png");
        pawn2W = new Pawn(new Vector2(1, 1), "white", "../../../img/wpawn.png");
        pawn3W = new Pawn(new Vector2(2, 1), "white", "../../../img/wpawn.png");
        pawn4W = new Pawn(new Vector2(3, 1), "white", "../../../img/wpawn.png");
        pawn5W = new Pawn(new Vector2(4, 1), "white", "../../../img/wpawn.png");
        pawn6W = new Pawn(new Vector2(5, 1), "white", "../../../img/wpawn.png");
        pawn7W = new Pawn(new Vector2(6, 1), "white", "../../../img/wpawn.png");
        pawn8W = new Pawn(new Vector2(7, 1), "white", "../../../img/wpawn.png");

        bishop1B = new Bishop(new Vector2(2, 7), "black", "../../../img/bbishop.png");
        bishop2B = new Bishop(new Vector2(5, 7), "black", "../../../img/bbishop.png");

        bishop1W = new Bishop(new Vector2(2, 0), "white", "../../../img/wbishop.png");
        bishop2W = new Bishop(new Vector2(5, 0), "white", "../../../img/wbishop.png");

        rook1B = new Rook(new Vector2(0, 7), "black", "../../../img/brook.png");
        rook2B = new Rook(new Vector2(7, 7), "black", "../../../img/brook.png");

        rook1W = new Rook(new Vector2(0, 0), "white", "../../../img/wrook.png");
        rook2W = new Rook(new Vector2(7, 0), "white", "../../../img/wrook.png");

        knight1B = new Knight(new Vector2(1, 7), "black", "../../../img/bknight.png");
        knight2B = new Knight(new Vector2(6, 7), "black", "../../../img/bknight.png");

        knight1W = new Knight(new Vector2(1, 0), "white", "../../../img/wknight.png");
        knight2W = new Knight(new Vector2(6, 0), "white", "../../../img/wknight.png");

        queen1B = new Queen(new Vector2(4, 7), "black", "../../../img/bqueen.png");

        queen1W = new Queen(new Vector2(4, 0), "white", "../../../img/wqueen.png");

        king1B = new King(new Vector2(3, 7), "black", "../../../img/bking.png");

        king1W = new King(new Vector2(3, 0), "white", "../../../img/wking.png");


        List<Piece> copyPieces = new List<Piece>();

        copyPieces = pieces;

        pieceColorPlaying = "white";

        while (pieces.Count > 0)
        {
            pieces.RemoveAt(0);
        }

        pieces.Add(pawn1B);
        pieces.Add(pawn2B);
        pieces.Add(pawn3B);
        pieces.Add(pawn4B);
        pieces.Add(pawn5B);
        pieces.Add(pawn6B);
        pieces.Add(pawn7B);
        pieces.Add(pawn8B);

        pieces.Add(pawn1W);
        pieces.Add(pawn2W);
        pieces.Add(pawn3W);
        pieces.Add(pawn4W);
        pieces.Add(pawn5W);
        pieces.Add(pawn6W);
        pieces.Add(pawn7W);
        pieces.Add(pawn8W);

        pieces.Add(bishop1B);
        pieces.Add(bishop2B);

        pieces.Add(bishop1W);
        pieces.Add(bishop2W);

        pieces.Add(rook1B);
        pieces.Add(rook2B);

        pieces.Add(rook1W);
        pieces.Add(rook2W);

        pieces.Add(knight1B);
        pieces.Add(knight2B);

        pieces.Add(knight1W);
        pieces.Add(knight2W);

        pieces.Add(queen1B);

        pieces.Add(queen1W);

        pieces.Add(king1B);

        pieces.Add(king1W);
        
        

       
    }

    public void Update()
    {
        string currentDirectory = System.IO.Directory.GetCurrentDirectory();
        Console.WriteLine("\n" + "\n" + currentDirectory + "\n" + "\n");
        CheckForUserInput();
        if (restartGameBool)
        {
            stopwatch.Restart();
            stopwatch.Start();
            restartGameBool = false;
        }

        if(stopwatch.ElapsedMilliseconds > 20000 && !restartFinished)
        {
            RestartGame();
            restartFinished = true;
            displayBillboard = false;
            draw = false;
            mat = false;
        }
        
    }
}
public class Game
{
    public Board board = new Board();
    public List<Piece> pieces = new List<Piece>();
    public bool mouseButtonDown = false;
    public Vector2 startPiecePosition;
    public bool pieceClickedFound = false;

    public void Update()
    {
        board.Update();
    }
    public void Draw()
    {
        board.Draw();
    }
}

static class Program
{
    public static int ScreenWidth = 960;
    public static int ScreenHeight = 960;

    public static void Main()
    {

        Raylib.InitWindow(ScreenWidth, ScreenHeight, "Hello World");
        Game game = new Game();
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.WHITE);

            game.Update();
            game.Draw();

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
