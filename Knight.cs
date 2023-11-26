using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class Knight : Piece
    {

        Image pieceImg = new Image();
        Texture2D pieceTxt = new Texture2D();
        private List<Vector2> movesPossible = new List<Vector2>();
        private List<Vector2> opponentPiecesInReach = new List<Vector2>();
        private List<Vector2> ourPiecesInReach = new List<Vector2>();
        private bool canCastleRight = true;
        private bool canCastleLeft = true;



        public Knight(Vector2 pos, string col, string imgp) : base(pos, col, imgp, "knight")
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
            bool moveRightUp = true;
            bool moveRightDown = true;
            bool moveDownRight = true;
            bool moveDownLeft = true;
            bool moveLeftDown = true;
            bool moveLeftUp = true;
            bool moveUpLeft = true;
            bool moveUpRight = true;

           

            foreach (Piece piece in Pieces)
            {
                if (position.X + 2 > 8 || position.Y - 1 < 0)
                {
                    moveRightUp = false;

                    break;
                }
                if (piece.Position.X == position.X + 2 && piece.Position.Y == position.Y - 1 && piece.ColorPiece == ColorPiece)
                {
                    moveRightUp = false;

                    break;
                }

                if (piece.Position.X == position.X + 2 && piece.Position.Y == position.Y - 1 && piece.ColorPiece != ColorPiece)
                {
                    opponentPiecesInReach.Add(new Vector2(piece.Position.X, piece.Position.Y));
                    piece.UnderAttack = true;
                    moveRightUp = false;
                }
            }
            foreach (Piece piece in Pieces)
            {
                if (position.X + 2 > 8 || position.Y + 1 > 8)
                {
                    moveRightDown = false;

                    break;
                }
                if (piece.Position.X == position.X + 2 && piece.Position.Y == position.Y + 1 && piece.ColorPiece == ColorPiece)
                {
                    moveRightDown = false;
                    break;
                }
                if (piece.Position.X == position.X + 2 && piece.Position.Y == position.Y + 1 && piece.ColorPiece != ColorPiece)
                {
                    opponentPiecesInReach.Add(new Vector2(piece.Position.X, piece.Position.Y));
                    moveRightDown = false;
                    piece.UnderAttack = true;

                }
            }

            foreach (Piece piece in Pieces)
            {
                if (position.X + 1 > 8 || position.Y + 2 > 8)
                {
                    moveDownRight = false;
                    break;

                }
                if (piece.Position.X == position.X + 1 && piece.Position.Y == position.Y + 2 && piece.ColorPiece == ColorPiece)
                {
                    moveDownRight = false;
                    break;
                }
                if (piece.Position.X == position.X + 1 && piece.Position.Y == position.Y + 2 && piece.ColorPiece != ColorPiece)
                {
                    opponentPiecesInReach.Add(new Vector2(piece.Position.X, piece.Position.Y));
                    moveDownRight = false;
                    piece.UnderAttack = true;

                }
            }

            foreach (Piece piece in Pieces)
            {
                if (position.X - 1 < 0 || position.Y + 2 > 8)
                {
                    moveDownLeft = false;

                    break;
                }
                if (piece.Position.X == position.X - 1 && piece.Position.Y == position.Y + 2 && piece.ColorPiece == ColorPiece)
                {
                    moveDownLeft = false;
                    break;
                }
                if (piece.Position.X == position.X - 1 && piece.Position.Y == position.Y + 2 && piece.ColorPiece != ColorPiece)
                {
                    opponentPiecesInReach.Add(new Vector2(piece.Position.X, piece.Position.Y));
                    moveDownLeft = false;
                    piece.UnderAttack = true;

                }
            }

            foreach (Piece piece in Pieces)
            {
                if (position.X - 2 < 0 || position.Y + 1 > 8)
                {
                    moveLeftDown = false;
                    break;
                }
                if (piece.Position.X == position.X - 2 && piece.Position.Y == position.Y + 1 && piece.ColorPiece == ColorPiece)
                {
                    moveLeftDown = false;
                    break;
                }
                if (piece.Position.X == position.X - 2 && piece.Position.Y == position.Y + 1 && piece.ColorPiece != ColorPiece)
                {
                    opponentPiecesInReach.Add(new Vector2(piece.Position.X, piece.Position.Y));
                    moveLeftDown = false;
                    piece.UnderAttack = true;

                }
            }

            foreach (Piece piece in Pieces)
            {
                if (position.X - 2 < 0 || position.Y - 1 < 0)
                {
                    moveLeftUp = false;
                    break;

                }
                if (piece.Position.X == position.X - 2 && piece.Position.Y == position.Y - 1 && piece.ColorPiece == ColorPiece)
                {
                    moveLeftUp = false;
                    break;
                }
                if (piece.Position.X == position.X - 2 && piece.Position.Y == position.Y - 1 && piece.ColorPiece != ColorPiece)
                {
                    opponentPiecesInReach.Add(new Vector2(piece.Position.X, piece.Position.Y));
                    moveLeftUp = false;
                    piece.UnderAttack = true;

                }
            }

            foreach (Piece piece in Pieces)
            {
                if (position.X - 1 < 0 || position.Y - 2 < 0)
                {
                    moveUpLeft = false;
                    break;

                }
                if (piece.Position.X == position.X - 1 && piece.Position.Y == position.Y - 2 && piece.ColorPiece == ColorPiece)
                {
                    moveUpLeft = false;
                    break;
                }
                if (piece.Position.X == position.X - 1 && piece.Position.Y == position.Y - 2 && piece.ColorPiece != ColorPiece)
                {
                    opponentPiecesInReach.Add(new Vector2(piece.Position.X, piece.Position.Y));
                    moveUpLeft = false;
                    piece.UnderAttack = true;

                }
            }

            foreach (Piece piece in Pieces)
            {
                if (position.X + 1 > 8 || position.Y - 2 < 0)
                {
                    moveUpRight = false;
                    break;

                }
                if (piece.Position.X == position.X + 1 && piece.Position.Y == position.Y - 2 && piece.ColorPiece == ColorPiece)
                {
                    moveUpRight = false;
                    break;
                }
                if (piece.Position.X == position.X + 1 && piece.Position.Y == position.Y - 2 && piece.ColorPiece != ColorPiece)
                {
                    opponentPiecesInReach.Add(new Vector2(piece.Position.X, piece.Position.Y));
                    moveUpRight = false;
                    piece.UnderAttack = true;

                }
            }

            if (moveRightUp)
            {
                movesPossible.Add(new Vector2(position.X + 2, position.Y - 1));

            }

            if (moveRightDown)
            {
                movesPossible.Add(new Vector2(position.X + 2, position.Y + 1));

            }

            if (moveDownRight)
            {
                movesPossible.Add(new Vector2(position.X + 1, position.Y + 2));

            }

            if (moveDownLeft)
            {
                movesPossible.Add(new Vector2(position.X - 1, position.Y + 2));

            }

            if (moveLeftDown)
            {
                movesPossible.Add(new Vector2(position.X - 2, position.Y + 1));

            }

            if (moveLeftUp)
            {
                movesPossible.Add(new Vector2(position.X - 2, position.Y - 1));

            }

            if (moveUpLeft)
            {
                movesPossible.Add(new Vector2(position.X - 1, position.Y - 2));

            }

            if (moveUpRight)
            {
                movesPossible.Add(new Vector2(position.X + 1, position.Y - 2));

            }
        }

        public override void BringDefendingPieces(List<Piece> Pieces, List<Vector2> checkSquares)
        {
            Vector2 position = Position;
            ourPiecesInReach.Clear();
            foreach(Piece piece in Pieces)
            {
                if (piece.Position.X == position.X + 2 && piece.Position.Y == position.Y - 1 && piece.ColorPiece == ColorPiece)
                {
                    ourPiecesInReach.Add(new Vector2(position.X + 2, position.Y - 1));
                    break;
                }

                
            }
            foreach(Piece piece in Pieces)
            {
                if (piece.Position.X == position.X + 2 && piece.Position.Y == position.Y + 1 && piece.ColorPiece == ColorPiece)
                {
                    ourPiecesInReach.Add(new Vector2(position.X + 2, position.Y + 1));
                    break;
                }
            }
            foreach (Piece piece in Pieces)
            {
                if (piece.Position.X == position.X + 1 && piece.Position.Y == position.Y + 2 && piece.ColorPiece == ColorPiece)
                {
                    ourPiecesInReach.Add(new Vector2(position.X + 1, position.Y + 2));
                    break;
                }
            }

            foreach (Piece piece in Pieces)
            {
                if (piece.Position.X == position.X - 1 && piece.Position.Y == position.Y + 2 && piece.ColorPiece == ColorPiece)
                {
                    ourPiecesInReach.Add(new Vector2(position.X - 1, position.Y + 2));
                    break;
                }
            }

            foreach (Piece piece in Pieces)
            {
                if (piece.Position.X == position.X - 2 && piece.Position.Y == position.Y + 1 && piece.ColorPiece == ColorPiece)
                {
                    ourPiecesInReach.Add(new Vector2(position.X - 2, position.Y + 1));
                    break;
                }
            }

            foreach (Piece piece in Pieces)
            {
                if (piece.Position.X == position.X - 2 && piece.Position.Y == position.Y - 1 && piece.ColorPiece == ColorPiece)
                {
                    ourPiecesInReach.Add(new Vector2(position.X - 2, position.Y - 1));
                    break;
                }
            }

            foreach (Piece piece in Pieces)
            {
                if (piece.Position.X == position.X - 1 && piece.Position.Y == position.Y - 2 && piece.ColorPiece == ColorPiece)
                {
                    ourPiecesInReach.Add(new Vector2(position.X - 1, position.Y - 2));
                    break;
                }
            }

            foreach (Piece piece in Pieces)
            {
                if (piece.Position.X == position.X + 1 && piece.Position.Y == position.Y - 2 && piece.ColorPiece == ColorPiece)
                {
                    ourPiecesInReach.Add(new Vector2(position.X + 1, position.Y - 2));
                    break;
                }
            }



            OurPiecesInReach = ourPiecesInReach;
        }
    }
}
