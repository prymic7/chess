using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class Rook : Piece
    {
        
        Image pieceImg = new Image();
        Texture2D pieceTxt = new Texture2D();
        private List<Vector2> movesPossible = new List<Vector2>();
        private List<Vector2> opponentPiecesInReach = new List<Vector2>();
        private List<Vector2> ourPiecesInReach = new List<Vector2>();



        public Rook(Vector2 pos, string col, string imgp) : base(pos, col, imgp, "rook")
        {
            movesPossible = MovesPossible;
            opponentPiecesInReach = OpponentsPiecesInReach;
            pieceImg = Raylib.LoadImage(imgp);
            pieceTxt = Raylib.LoadTextureFromImage(pieceImg);

        }


        

        public override void BringMoves(List<Piece> Pieces, List<Vector2> checkSquares, Vector2 attackerPos, bool check)
        {
            Vector2 position = Position;
            movesPossible.Clear();
            opponentPiecesInReach.Clear();
            
            //Jeden smer
            for (int i = 1; i < 8; i++)
            {
                if (position.X + i > 8)
                {
                    break;
                }
                bool canMoveToSquare = true;
                foreach (Piece piece in Pieces)
                {
                    if (piece.Position.X == position.X + i && piece.Position.Y == position.Y && ColorPiece != piece.ColorPiece)
                    {
                        canMoveToSquare = false;
                        opponentPiecesInReach.Add(new Vector2(position.X + i, position.Y));
                        piece.UnderAttack = true;

                        break;
                    }
                    

                    if (piece.Position.X == position.X + i && piece.Position.Y == position.Y)
                    {
                        canMoveToSquare = false;
                        break;
                    }

                }
                if (canMoveToSquare)
                {
                    Vector2 freeSquareToMove = new Vector2(position.X + i, position.Y);
                    movesPossible.Add(freeSquareToMove);
                }
                if (!canMoveToSquare)
                {
                    break;
                }
            }

            for (int i = 1; i < 8; i++)
            {
                if (position.Y + i > 8)
                {
                    break;
                }
                bool canMoveToSquare = true;
                foreach (Piece piece in Pieces)
                {
                    if (piece.Position.X == position.X && piece.Position.Y == position.Y + i && ColorPiece != piece.ColorPiece)
                    {
                        canMoveToSquare = false;
                        opponentPiecesInReach.Add(new Vector2(position.X, position.Y + i));
                        piece.UnderAttack = true;

                        break;
                    }
                  
                    if (piece.Position.X == position.X && piece.Position.Y == position.Y + i)
                    {
                        canMoveToSquare = false;
                        break;
                    }

                }
                if (canMoveToSquare)
                {
                    Vector2 freeSquareToMove = new Vector2(position.X, position.Y + i);
                    movesPossible.Add(freeSquareToMove);
                }
                if (!canMoveToSquare)
                {
                    break;
                }
            }

            for (int i = 1; i < 8; i++)
            {
                if (position.Y - i < 0)
                {
                    break;
                }
                bool canMoveToSquare = true;
                foreach (Piece piece in Pieces)
                {
                    if (piece.Position.X == position.X && piece.Position.Y == position.Y - i && ColorPiece != piece.ColorPiece)
                    {
                        canMoveToSquare = false;
                        opponentPiecesInReach.Add(new Vector2(position.X, position.Y - i));
                        piece.UnderAttack = true;

                        break;
                    }
                 

                    if (piece.Position.X == position.X && piece.Position.Y == position.Y - i)
                    {
                        canMoveToSquare = false;
                        break;
                    }

                }
                if (canMoveToSquare)
                {
                    Vector2 freeSquareToMove = new Vector2(position.X, position.Y - i);
                    movesPossible.Add(freeSquareToMove);
                }
                if (!canMoveToSquare)
                {
                    break;
                }
            }

            for (int i = 1; i < 8; i++)
            {
                if (position.X - i < 0)
                {
                    break;
                }
                bool canMoveToSquare = true;
                foreach (Piece piece in Pieces)
                {
                    if (piece.Position.X == position.X - i && piece.Position.Y == position.Y && ColorPiece != piece.ColorPiece)
                    {
                        canMoveToSquare = false;
                        opponentPiecesInReach.Add(new Vector2(position.X - i, position.Y));
                        piece.UnderAttack = true;

                        break;
                    }
                
                    if (piece.Position.X == position.X - i && piece.Position.Y == position.Y)
                    {
                        canMoveToSquare = false;
                        break;
                    }

                }
                if (canMoveToSquare)
                {
                    Vector2 freeSquareToMove = new Vector2(position.X - i, position.Y);
                    movesPossible.Add(freeSquareToMove);
                }
                if (!canMoveToSquare)
                {
                    break;
                }
            }
            MovesPossible = movesPossible;
            OpponentsPiecesInReach = opponentPiecesInReach;
            
        }
        public override void BringDefendingPieces(List<Piece> Pieces, List<Vector2> checkSquares)
        {
            Vector2 position = Position;
            ourPiecesInReach.Clear();
            for (int i = 1; i < 8; i++)
            {
                bool goNext = false;
                if (position.X + i > 8)
                {
                    break;
                }
                foreach (Piece piece in Pieces)
                {
                    
                    if (piece.Position.X == position.X + i && piece.Position.Y == position.Y && ColorPiece == piece.ColorPiece)
                    {
                        ourPiecesInReach.Add(new Vector2(position.X + i, position.Y));
                        goNext = true;
                        break;
                    }

                    

                }
                if (goNext)
                {
                    break;
                }
                
            }

            for (int i = 1; i < 8; i++)
            {
                bool goNext = false;
                if (position.Y + i > 8)
                {
                    break;
                }
                foreach (Piece piece in Pieces)
                {

                    if (piece.Position.X == position.X && piece.Position.Y == position.Y + i && ColorPiece == piece.ColorPiece)
                    {
                        ourPiecesInReach.Add(new Vector2(position.X, position.Y + i));
                        goNext = true;
                        break;
                    }
                }
                if (goNext)
                {
                    break;
                }

            }

            for (int i = 1; i < 8; i++)
            {
                bool goNext = false;
                if (position.Y - i < 0)
                {

                    break;
                }
                foreach (Piece piece in Pieces)
                {

                    if (piece.Position.X == position.X && piece.Position.Y == position.Y - i && ColorPiece == piece.ColorPiece)
                    {
                        ourPiecesInReach.Add(new Vector2(position.X, position.Y - i));
                        goNext = true;
                        break;
                    }
                }
                if (goNext)
                {
                    break;
                }

            }

            for (int i = 1; i < 8; i++)
            {
                bool goNext = false;
                if (position.X - i < 0)
                {
                    break;
                }
                foreach (Piece piece in Pieces)
                {
                    
                    if (piece.Position.X == position.X - i && piece.Position.Y == position.Y && ColorPiece == piece.ColorPiece)
                    {
                        ourPiecesInReach.Add(new Vector2(position.X - i, position.Y));
                        goNext = true;
                        break;
                    }

                    

                }
                if (goNext)
                {
                    break;
                }

            }

            OurPiecesInReach = ourPiecesInReach;
        }

        

    }
}
