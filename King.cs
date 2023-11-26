using Raylib_cs;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class King : Piece
    {

        Image pieceImg = new Image();
        Texture2D pieceTxt = new Texture2D();
        bool knightAttacked = false;
        private List<Vector2> movesPossible = new List<Vector2>();
        private List<Vector2> opponentPiecesInReach = new List<Vector2>();
        private List<Vector2> ourPiecesInReach = new List<Vector2>();
        private List<Vector2> castleSquares = new List<Vector2>();



        public King(Vector2 pos, string col, string imgp) : base(pos, col, imgp, "king")
        {
            movesPossible = MovesPossible;
            opponentPiecesInReach = OpponentsPiecesInReach;

            pieceImg = Raylib.LoadImage(imgp);
            pieceTxt = Raylib.LoadTextureFromImage(pieceImg);

        }

        public bool KnightAttacked
        {
            get { return knightAttacked; }
            set { knightAttacked = value; }
        }


        public override void BringCastle(List<Piece> Pieces, List<Vector2> checkSquares)
        {

            castleSquares.Clear();

            Vector2 oneBlock = new Vector2();
            Vector2 twoBlock = new Vector2();
            Vector2 threeBlock = new Vector2();
            Vector2 fourBlock = new Vector2();
            Vector2 fiveBlock = new Vector2();
            Vector2 rookLeft = new Vector2();
            Vector2 rookRight = new Vector2();

            bool canCastleRight = true;
            bool canCastleLeft = true;


            if (!Moved)
            {
                if (ColorPiece == "black")
                {
                    oneBlock = new Vector2(1, 7); twoBlock = new Vector2(2, 7); threeBlock = new Vector2(4, 7); fourBlock = new Vector2(5, 7); fiveBlock = new Vector2(6, 7);
                    rookLeft = new Vector2(0, 7); rookRight = new Vector2(7, 7);

                    foreach (Piece piece in Pieces)
                    {
                        if (piece.Position == oneBlock || piece.Position == twoBlock)
                        {
                            canCastleLeft = false;

                        }
                        if (piece.ColorPiece == ColorPiece && piece.PieceName == "rook"
                            && piece.StartingPos == rookLeft && piece.Moved)
                        {
                            canCastleLeft = false;


                        }



                        if (piece.Position == threeBlock || piece.Position == fourBlock || piece.Position == fiveBlock)
                        {
                            canCastleRight = false;

                        }
                        if (piece.ColorPiece == ColorPiece && piece.PieceName == "rook"
                            && piece.StartingPos == rookRight && piece.Moved)
                        {
                            canCastleRight = false;


                        }
                    }
                }
                else if (ColorPiece == "white")
                {
                    oneBlock = new Vector2(1, 0); twoBlock = new Vector2(2, 0); threeBlock = new Vector2(4, 0); fourBlock = new Vector2(5, 0); fiveBlock = new Vector2(6, 0);
                    rookLeft = new Vector2(0, 0); rookRight = new Vector2(7, 0);

                    foreach (Piece piece in Pieces)
                    {
                        if (piece.Position == oneBlock || piece.Position == twoBlock)
                        {
                            canCastleLeft = false;

                        }
                        if (piece.ColorPiece == ColorPiece && piece.PieceName == "rook"
                            && piece.StartingPos == rookLeft && piece.Moved)
                        {
                            canCastleLeft = false;

                        }

                        if (piece.Position == threeBlock || piece.Position == fourBlock || piece.Position == fiveBlock)
                        {
                            canCastleRight = false;


                        }

                        if (piece.ColorPiece == ColorPiece && piece.PieceName == "rook"
                            && piece.StartingPos == rookRight && piece.Moved)
                        {
                            canCastleRight = false;

                        }
                    }
                }
            }

            if (ColorPiece == "black")
            {
                if (!Moved && canCastleLeft)
                {
                    castleSquares.Add(new Vector2(1, 7));
                }
                if (!Moved && canCastleRight)
                {
                    castleSquares.Add(new Vector2(5, 7));

                }

            }
            if (ColorPiece == "white")
            {
                if (!Moved && canCastleLeft)
                {
                    castleSquares.Add(new Vector2(1, 0));

                }
                if (!Moved && canCastleRight)
                {
                    castleSquares.Add(new Vector2(5, 0));

                }
            }
            CastleSquares = castleSquares;
        }

        public override void BringMoves(List<Piece> Pieces, List<Vector2> checkSquares, Vector2 attackerPos, bool check)
        {
            Vector2 position = Position;
            movesPossible.Clear();
            opponentPiecesInReach.Clear();
            //Jeden smer


            bool canMoveToSquareRight = true;
            bool canMoveToSquareLeft = true;
            bool canMoveToSquareUp = true;
            bool canMoveToSquareDown = true;

            bool canMoveToSquareDownRight = true;
            bool canMoveToSquareDownLeft = true;
            bool canMoveToSquareUpRight = true;
            bool canMoveToSquareUpLeft = true;






            foreach (Piece piece in Pieces)
            {

                //Doprava
                bool pieceCovered = false;

                if (piece.Position.X == position.X + 1 && piece.Position.Y == position.Y && ColorPiece != piece.ColorPiece)
                {

                    foreach (Piece coveringPiece in Pieces)
                    {
                        if (coveringPiece.ColorPiece == piece.ColorPiece)
                        {
                            List<Vector2> list = new List<Vector2>();
                            coveringPiece.BringDefendingPieces(Pieces, checkSquares);
                            list = coveringPiece.OurPiecesInReach;
                            foreach (Vector2 vec in list)
                            {
                                if (vec.X == piece.Position.X && vec.Y == piece.Position.Y)
                                {
                                    pieceCovered = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (!pieceCovered)
                    {
                        canMoveToSquareRight = false;
                        opponentPiecesInReach.Add(new Vector2(position.X + 1, position.Y));
                        piece.UnderAttack = true;
                        break;
                    }


                }

                if (position.X + 1 > 7)
                {
                    canMoveToSquareRight = false;
                    break;
                }

                if (piece.Position.X == position.X + 1 && piece.Position.Y == position.Y)
                {
                    canMoveToSquareRight = false;

                }
                foreach (Vector2 vec in checkSquares)
                {
                    if (vec.X == position.X + 1 && vec.Y == position.Y)
                    {
                        canMoveToSquareRight = false;
                        break;
                    }
                }


            }
            foreach (Piece piece2 in Pieces)
            {
                //Doleva
                bool pieceCovered = false;

                if (piece2.Position.X == position.X - 1 && piece2.Position.Y == position.Y && ColorPiece != piece2.ColorPiece)
                {

                    foreach (Piece coveringPiece in Pieces)
                    {
                        if (coveringPiece.ColorPiece == piece2.ColorPiece)
                        {
                            List<Vector2> list = new List<Vector2>();
                            coveringPiece.BringDefendingPieces(Pieces, checkSquares);
                            list = coveringPiece.OurPiecesInReach;
                            foreach (Vector2 vec in list)
                            {
                                if (vec.X == piece2.Position.X && vec.Y == piece2.Position.Y)
                                {
                                    pieceCovered = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (!pieceCovered)
                    {
                        canMoveToSquareLeft = false;
                        opponentPiecesInReach.Add(new Vector2(position.X - 1, position.Y));
                        piece2.UnderAttack = true;
                        break;
                    }

                }


                if (position.X - 1 < 0)
                {
                    canMoveToSquareLeft = false;
                    break;
                }

                if (piece2.Position.X == position.X - 1 && piece2.Position.Y == position.Y)
                {
                    canMoveToSquareLeft = false;
                    break;
                }
                foreach (Vector2 vec in checkSquares)
                {
                    if (vec.X == position.X - 1 && vec.Y == position.Y)
                    {
                        canMoveToSquareLeft = false;
                        break;
                    }
                }


            }
            foreach (Piece piece3 in Pieces)
            {
                //Nahoru
                bool pieceCovered = false;

                if (piece3.Position.X == position.X && piece3.Position.Y == position.Y - 1 && ColorPiece != piece3.ColorPiece)
                {
                    foreach (Piece coveringPiece in Pieces)
                    {
                        if (coveringPiece.ColorPiece == piece3.ColorPiece)
                        {
                            List<Vector2> list = new List<Vector2>();
                            coveringPiece.BringDefendingPieces(Pieces, checkSquares);
                            list = coveringPiece.OurPiecesInReach;
                            foreach (Vector2 vec in list)
                            {
                                if (vec.X == piece3.Position.X && vec.Y == piece3.Position.Y)
                                {
                                    pieceCovered = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (!pieceCovered)
                    {
                        canMoveToSquareUp = false;
                        opponentPiecesInReach.Add(new Vector2(position.X, position.Y - 1));
                        piece3.UnderAttack = true;
                        break;
                    }

                }

                if (position.Y - 1 < 0)
                {
                    canMoveToSquareUp = false;
                    break;
                }


                if (piece3.Position.X == position.X && piece3.Position.Y == position.Y - 1)
                {
                    canMoveToSquareUp = false;
                    break;
                }
                foreach (Vector2 vec in checkSquares)
                {
                    if (vec.X == position.X && vec.Y == position.Y - 1)
                    {
                        canMoveToSquareUp = false;
                        break;
                    }
                }


            }
            foreach (Piece piece4 in Pieces)
            {
                //Dolu
                bool pieceCovered = false;

                if (piece4.Position.X == position.X && piece4.Position.Y == position.Y + 1 && ColorPiece != piece4.ColorPiece)
                {
                    foreach (Piece coveringPiece in Pieces)
                    {
                        if (coveringPiece.ColorPiece == piece4.ColorPiece)
                        {
                            List<Vector2> list = new List<Vector2>();
                            coveringPiece.BringDefendingPieces(Pieces, checkSquares);
                            list = coveringPiece.OurPiecesInReach;
                            foreach (Vector2 vec in list)
                            {
                                if (vec.X == piece4.Position.X && vec.Y == piece4.Position.Y)
                                {
                                    pieceCovered = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (!pieceCovered)
                    {
                        canMoveToSquareDown = false;
                        opponentPiecesInReach.Add(new Vector2(position.X, position.Y + 1));
                        piece4.UnderAttack = true;
                        break;
                    }
                }

                if (position.Y + 1 > 7)
                {
                    canMoveToSquareDown = false;
                    break;
                }

                if (piece4.Position.X == position.X && piece4.Position.Y == position.Y + 1)
                {
                    canMoveToSquareDown = false;
                    break;
                }
                foreach (Vector2 vec in checkSquares)
                {
                    if (vec.X == position.X && vec.Y == position.Y + 1)
                    {
                        canMoveToSquareDown = false;
                        break;
                    }
                }


            }
            foreach (Piece piece5 in Pieces)
            {
                //Dolu napravo
                bool pieceCovered = false;
                if (piece5.Position.X == position.X + 1 && piece5.Position.Y == position.Y + 1 && ColorPiece != piece5.ColorPiece)
                {
                    foreach (Piece coveringPiece in Pieces)
                    {
                        if (coveringPiece.ColorPiece == piece5.ColorPiece)
                        {
                            List<Vector2> list = new List<Vector2>();
                            coveringPiece.BringDefendingPieces(Pieces, checkSquares);
                            list = coveringPiece.OurPiecesInReach;
                            foreach (Vector2 vec in list)
                            {
                                if (vec.X == piece5.Position.X && vec.Y == piece5.Position.Y)
                                {
                                    pieceCovered = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (!pieceCovered)
                    {
                        canMoveToSquareDownRight = false;
                        opponentPiecesInReach.Add(new Vector2(position.X + 1, position.Y + 1));
                        piece5.UnderAttack = true;
                        break;
                    }
                }

                if (position.X + 1 > 7 || position.Y + 1 > 7)
                {
                    canMoveToSquareDownRight = false;
                    break;
                }

                if (piece5.Position.X == position.X + 1 && piece5.Position.Y == position.Y + 1)
                {
                    canMoveToSquareDownRight = false;
                    break;
                }
                foreach (Vector2 vec in checkSquares)
                {
                    if (vec.X == position.X + 1 && vec.Y == position.Y + 1)
                    {
                        canMoveToSquareDownRight = false;
                        break;
                    }
                }
            }
            foreach (Piece piece6 in Pieces)
            {
                //Dolu nalevo
                bool pieceCovered = false;

                if (piece6.Position.X == position.X - 1 && piece6.Position.Y == position.Y + 1 && ColorPiece != piece6.ColorPiece)
                {
                    Console.WriteLine("FOUND");
                    foreach (Piece coveringPiece in Pieces)
                    {
                        if (coveringPiece.ColorPiece == piece6.ColorPiece)
                        {
                            List<Vector2> list = new List<Vector2>();
                            coveringPiece.BringDefendingPieces(Pieces, checkSquares);
                            list = coveringPiece.OurPiecesInReach;
                            foreach (Vector2 vec in list)
                            {
                                if (vec.X == piece6.Position.X && vec.Y == piece6.Position.Y)
                                {
                                    pieceCovered = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (!pieceCovered)
                    {
                        canMoveToSquareDownLeft = false;
                        opponentPiecesInReach.Add(new Vector2(position.X - 1, position.Y + 1));
                        piece6.UnderAttack = true;
                        break;
                    }
                }

                if (position.X - 1 < 0 || position.Y + 1 > 7)
                {
                    canMoveToSquareDownLeft = false;
                    break;
                }

                if (piece6.Position.X == position.X - 1 && piece6.Position.Y == position.Y + 1)
                {
                    canMoveToSquareDownLeft = false;
                    break;
                }
                foreach (Vector2 vec in checkSquares)
                {
                    if (vec.X == position.X - 1 && vec.Y == position.Y + 1)
                    {
                        canMoveToSquareDownLeft = false;
                        break;
                    }
                }
            }
            foreach (Piece piece7 in Pieces)
            {
                //Nahoru doprava
                bool pieceCovered = false;

                if (piece7.Position.X == position.X + 1 && piece7.Position.Y == position.Y - 1 && ColorPiece != piece7.ColorPiece)
                {
                    foreach (Piece coveringPiece in Pieces)
                    {
                        if (coveringPiece.ColorPiece == piece7.ColorPiece)
                        {
                            List<Vector2> list = new List<Vector2>();
                            coveringPiece.BringDefendingPieces(Pieces, checkSquares);
                            list = coveringPiece.OurPiecesInReach;
                            foreach (Vector2 vec in list)
                            {
                                if (vec.X == piece7.Position.X && vec.Y == piece7.Position.Y)
                                {
                                    pieceCovered = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (!pieceCovered)
                    {
                        canMoveToSquareUpRight = false;
                        opponentPiecesInReach.Add(new Vector2(position.X + 1, position.Y - 1));
                        piece7.UnderAttack = true;
                        break;
                    }
                }

                if (position.X + 1 > 7 || position.Y - 1 < 0)
                {
                    canMoveToSquareUpRight = false;
                    break;
                }

                if (piece7.Position.X == position.X + 1 && piece7.Position.Y == position.Y - 1)
                {
                    canMoveToSquareUpRight = false;
                    break;
                }
                foreach (Vector2 vec in checkSquares)
                {
                    if (vec.X == position.X + 1 && vec.Y == position.Y - 1)
                    {
                        canMoveToSquareUpRight = false;
                        break;
                    }
                }
            }
            foreach (Piece piece8 in Pieces)
            {
                //Nahoru doleva
                bool pieceCovered = false;

                if (piece8.Position.X == position.X - 1 && piece8.Position.Y == position.Y - 1 && ColorPiece != piece8.ColorPiece)
                {
                    foreach (Piece coveringPiece in Pieces)
                    {
                        if (coveringPiece.ColorPiece == piece8.ColorPiece)
                        {
                            List<Vector2> list = new List<Vector2>();
                            coveringPiece.BringDefendingPieces(Pieces, checkSquares);
                            list = coveringPiece.OurPiecesInReach;
                            foreach (Vector2 vec in list)
                            {
                                if (vec.X == piece8.Position.X && vec.Y == piece8.Position.Y)
                                {
                                    pieceCovered = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (!pieceCovered)
                    {
                        canMoveToSquareUpLeft = false;
                        opponentPiecesInReach.Add(new Vector2(position.X - 1, position.Y - 1));
                        piece8.UnderAttack = true;
                        break;
                    }
                }

                if (position.X - 1 < 0 || position.Y - 1 < 0)
                {
                    canMoveToSquareUpLeft = false;
                    break;
                }

                if (piece8.Position.X == position.X - 1 && piece8.Position.Y == position.Y - 1)
                {

                    canMoveToSquareUpLeft = false;
                    break;
                }

                foreach (Vector2 vec in checkSquares)
                {

                    if (vec.X == position.X - 1 && vec.Y == position.Y - 1)
                    {
                        canMoveToSquareUpLeft = false;
                        break;
                    }
                }
            }


            Vector2 attackedKingVec = Position;
            string checkDirection = new string("D");


            if (canMoveToSquareRight)
            {
                Vector2 freeSquareToMove = new Vector2(position.X + 1, position.Y);
                movesPossible.Add(freeSquareToMove);
            }
            if (canMoveToSquareLeft)
            {
                Vector2 freeSquareToMove = new Vector2(position.X - 1, position.Y);
                movesPossible.Add(freeSquareToMove);
            }
            if (canMoveToSquareUp)
            {
                Vector2 freeSquareToMove = new Vector2(position.X, position.Y - 1);
                movesPossible.Add(freeSquareToMove);
            }
            if (canMoveToSquareDown)
            {
                Vector2 freeSquareToMove = new Vector2(position.X, position.Y + 1);
                movesPossible.Add(freeSquareToMove);
            }
            if (canMoveToSquareDownRight)
            {
                Vector2 freeSquareToMove = new Vector2(position.X + 1, position.Y + 1);
                movesPossible.Add(freeSquareToMove);
            }
            if (canMoveToSquareDownLeft)
            {
                Vector2 freeSquareToMove = new Vector2(position.X - 1, position.Y + 1);
                movesPossible.Add(freeSquareToMove);
            }
            if (canMoveToSquareUpRight)
            {
                Vector2 freeSquareToMove = new Vector2(position.X + 1, position.Y - 1);
                movesPossible.Add(freeSquareToMove);
            }
            if (canMoveToSquareUpLeft)
            {
                Vector2 freeSquareToMove = new Vector2(position.X - 1, position.Y - 1);
                movesPossible.Add(freeSquareToMove);
            }
            OpponentsPiecesInReach = opponentPiecesInReach;


            foreach (Piece attacker in Pieces)
            {
                if(attacker.Position == attackerPos && attacker.PieceName != "pawn" && attacker.PieceName != "king")
                {
                    if (attackerPos.X > attackedKingVec.X && attackerPos.Y > attackedKingVec.Y)
                    {
                        checkDirection = "LeftUp";

                    }
                    else if (attackerPos.X > attackedKingVec.X && attackerPos.Y < attackedKingVec.Y)

                    {
                        checkDirection = "LeftDown";

                    }
                    else if (attackerPos.X < attackedKingVec.X && attackerPos.Y > attackedKingVec.Y)
                    {
                        checkDirection = "RightUp";


                    }
                    else if (attackerPos.X < attackedKingVec.X && attackerPos.Y < attackedKingVec.Y)
                    {
                        checkDirection = "RightDown";


                    }
                    else if (attackerPos.X > attackedKingVec.X && attackerPos.Y == attackedKingVec.Y)
                    {
                        checkDirection = "Left";
                    }
                    else if (attackerPos.X < attackedKingVec.X && attackerPos.Y == attackedKingVec.Y)
                    {
                        checkDirection = "Right";
                    }
                    else if (attackerPos.X == attackedKingVec.X && attackerPos.Y > attackedKingVec.Y)
                    {
                        checkDirection = "Up";
                    }
                    else if (attackerPos.X == attackedKingVec.X && attackerPos.Y < attackedKingVec.Y)
                    {
                        checkDirection = "Down";
                    }
                }
            }
            List<Vector2> newList = new List<Vector2>();
            bool vpici = false;
            foreach (Vector2 square in movesPossible)
            {
                vpici = false;
                if(checkDirection == "LeftUp")
                {
                    if(square.X < Position.X && square.Y < Position.Y && square.X + 1 == Position.X && square.Y + 1 == Position.Y)
                    {
                        vpici = true;
                        Console.WriteLine("LeftUp");
                    } 
                    
                }
                else if(checkDirection == "LeftDown")
                {
                    if (square.X < Position.X && square.Y > Position.Y && square.X + 1 == Position.X && square.Y - 1 == Position.Y)
                    {
                        Console.WriteLine("LeftDown");

                        vpici = true;
                    }
                }
                else if (checkDirection == "RightUp")
                {
                    if (square.X > Position.X && square.Y < Position.Y && square.X - 1 == Position.X && square.Y + 1 == Position.Y)
                    {
                        Console.WriteLine("RightUp");

                        vpici = true;
                    }
                }
                else if (checkDirection == "RightDown")
                {
                    if (square.X > Position.X && square.Y > Position.Y && square.X - 1 == Position.X && square.Y - 1 == Position.Y)
                    {
                        Console.WriteLine("RightDown");

                        vpici = true;
                    }
                }
                else if (checkDirection == "Left")
                {
                    if (square.X < Position.X && square.Y == Position.Y && square.X + 1 == Position.X)
                    {
                        Console.WriteLine("Left");

                        vpici = true;
                    }
                }
                else if (checkDirection == "Right")
                {
                    if (square.X > Position.X && square.Y == Position.Y && square.X - 1 == Position.X)
                    {
                        Console.WriteLine("Right");

                        vpici = true;
                    }
                }
                else if (checkDirection == "Up")
                {
                    if (square.X == Position.X && square.Y < Position.Y && square.Y + 1 == Position.Y)
                    {
                        Console.WriteLine("Up");

                        vpici = true;
                    }
                }
                else if (checkDirection == "Down")
                {
                    if (square.X == Position.X && square.Y > Position.Y && square.Y - 1 == Position.Y)
                    {
                        Console.WriteLine("Down");

                        vpici = true;
                    }
                }
                if (!vpici)
                {
                    /*Console.WriteLine(attackerPos);*/
                    newList.Add(square);
                }
            }

            if (check)
            {
                Console.WriteLine("JE CHECK");
                movesPossible = newList;
            }
            
            MovesPossible = movesPossible;


        }




        public override void BringDefendingPieces(List<Piece> Pieces, List<Vector2> checkSquares)
        {
            bool canMoveToSquareRight = true;
            bool canMoveToSquareLeft = true;
            bool canMoveToSquareUp = true;
            bool canMoveToSquareDown = true;

            bool canMoveToSquareDownRight = true;
            bool canMoveToSquareDownLeft = true;
            bool canMoveToSquareUpRight = true;
            bool canMoveToSquareUpLeft = true;
            ourPiecesInReach.Clear();
            Vector2 position = Position;
            foreach (Piece piece in Pieces)
            {
                if (piece.Position.X == position.X + 1 && piece.Position.Y == position.Y && ColorPiece == piece.ColorPiece)
                {
                    canMoveToSquareRight = false;
                }
            }
            foreach (Piece piece2 in Pieces)
            {
                if (piece2.Position.X == position.X - 1 && piece2.Position.Y == position.Y && ColorPiece == piece2.ColorPiece)
                {

                    canMoveToSquareLeft = false;
                }
            }
            foreach (Piece piece3 in Pieces)
            {
                if (piece3.Position.X == position.X && piece3.Position.Y == position.Y - 1 && ColorPiece == piece3.ColorPiece)
                {

                    canMoveToSquareUp = false;
                }
            }
            foreach (Piece piece4 in Pieces)
            {
                if (piece4.Position.X == position.X && piece4.Position.Y == position.Y + 1 && ColorPiece == piece4.ColorPiece)
                {

                    canMoveToSquareDown = false;
                }
            }
            foreach (Piece piece5 in Pieces)
            {
                if (piece5.Position.X == position.X + 1 && piece5.Position.Y == position.Y + 1 && ColorPiece == piece5.ColorPiece)
                {

                    canMoveToSquareDownRight = false;
                }
            }
            foreach (Piece piece6 in Pieces)
            {
                if (piece6.Position.X == position.X - 1 && piece6.Position.Y == position.Y + 1 && ColorPiece == piece6.ColorPiece)
                {

                    canMoveToSquareDownLeft = false;
                }
            }

            foreach (Piece piece7 in Pieces)
            {
                if (piece7.Position.X == position.X + 1 && piece7.Position.Y == position.Y - 1 && ColorPiece == piece7.ColorPiece)
                {

                    canMoveToSquareUpRight = false;
                }
            }
            foreach(Piece piece8 in Pieces)
            {
                if (piece8.Position.X == position.X - 1 && piece8.Position.Y == position.Y - 1 && ColorPiece == piece8.ColorPiece)
                {

                    canMoveToSquareUpLeft = false;
                }
            }



            if (!canMoveToSquareRight)
            {

                Vector2 freeSquareToMove = new Vector2(position.X + 1, position.Y);
                ourPiecesInReach.Add(freeSquareToMove);
            }
            if (!canMoveToSquareLeft)
            {
                Vector2 freeSquareToMove = new Vector2(position.X - 1, position.Y);
                ourPiecesInReach.Add(freeSquareToMove);
            }
            if (!canMoveToSquareUp)
            {
                Vector2 freeSquareToMove = new Vector2(position.X, position.Y - 1);
                ourPiecesInReach.Add(freeSquareToMove);
            }
            if (!canMoveToSquareDown)
            {
                Vector2 freeSquareToMove = new Vector2(position.X, position.Y + 1);
                ourPiecesInReach.Add(freeSquareToMove);
            }
            if (!canMoveToSquareDownRight)
            {
                Vector2 freeSquareToMove = new Vector2(position.X + 1, position.Y + 1);
                ourPiecesInReach.Add(freeSquareToMove);
            }
            if (!canMoveToSquareDownLeft)
            {
                Vector2 freeSquareToMove = new Vector2(position.X - 1, position.Y + 1);
                ourPiecesInReach.Add(freeSquareToMove);
            }
            if (!canMoveToSquareUpRight)
            {
                Vector2 freeSquareToMove = new Vector2(position.X + 1, position.Y - 1);
                ourPiecesInReach.Add(freeSquareToMove);
            }
            if (!canMoveToSquareUpLeft)
            {
                Vector2 freeSquareToMove = new Vector2(position.X - 1, position.Y - 1);
                ourPiecesInReach.Add(freeSquareToMove);
            }


            OurPiecesInReach = ourPiecesInReach;
        }

    }

}
