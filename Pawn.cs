using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class Pawn : Piece
    {
        
        Image pieceImg = new Image();
        Texture2D pieceTxt = new Texture2D();
        private List<Vector2> movesPossible = new List<Vector2>();
        private List<Vector2> opponentPiecesInReach = new List<Vector2>();
        private List<Vector2> ourPiecesInReach = new List<Vector2>();
        private bool pawnJumped = false;




        public Pawn(Vector2 pos, string col, string imgp) : base(pos, col, imgp, "pawn") 
        {
            movesPossible = MovesPossible;
            opponentPiecesInReach = OpponentsPiecesInReach;
            pieceImg = Raylib.LoadImage(imgp);
            pieceTxt = Raylib.LoadTextureFromImage(pieceImg);
         
            
        }

        public bool PawnJumped
        {
            get { return pawnJumped; }
            set { pawnJumped = value;}
        }

        public override void BringMoves(List<Piece> Pieces, List<Vector2> checkSquares, Vector2 attackerPos, bool check)
        {
            

                opponentPiecesInReach.Clear();
            movesPossible.Clear();
            Vector2 position = Position;

            bool goAhead1bool = true;
            bool goAhead2bool = true;
            int num;
            string color = ColorPiece;
            //Nastaveni jak se bude pohybovat po Y ose, podle barvy figurky
            if(color == "black")
            {
                num = -1;
            } 
            else
            {
                num = 1;
            }
            Vector2 move;
            Vector2 goAhead1 = new Vector2(position.X, position.Y + num);
            Vector2 goAhead2 = new Vector2(position.X, position.Y + num * 2);
            //Kontrola jestli muze pincl vyhodit soupere, pokud ano, pridame to do movesPossible
            foreach (Piece piece in Pieces)
            {
                Vector2 kickVector = new Vector2(position.X + num, position.Y + num);
                if(piece.Position.X == kickVector.X && piece.Position.Y == kickVector.Y && color != piece.ColorPiece) 
                { 
                    move = new Vector2(kickVector.X, kickVector.Y);
                    opponentPiecesInReach.Add(move);
                    piece.UnderAttack = true;
                }
                kickVector = new Vector2(position.X - num, position.Y + num);
                if (piece.Position.X == kickVector.X && piece.Position.Y == kickVector.Y && color != piece.ColorPiece)
                {
                    move = new Vector2(kickVector.X, kickVector.Y);
                    opponentPiecesInReach.Add(move);
                    piece.UnderAttack = true;
                }

                //Kontrola normalniho pohybu dopredu (o jeden nebo o dva)
                if(piece.Position.X == goAhead1.X && piece.Position.Y == goAhead1.Y)
                {
                    goAhead1bool = false;
                    goAhead2bool = false;
                }

                if (piece.Position.X == goAhead2.X && piece.Position.Y == goAhead2.Y)
                {
                    goAhead2bool = false;
                }

                

            }
            //Klasicky pohyb o jeden
            if (goAhead1bool)
            {
                move = new Vector2(position.X, position.Y + num);
                movesPossible.Add(move);
                
            }

            //Klasicky pohyb o dva
            if (!Moved && goAhead2bool &&goAhead1bool)
            {
                
                move = new Vector2(position.X, position.Y + num * 2);
                movesPossible.Add(move);
            }

            int numik = 0;
            foreach(Piece piece in Pieces)
            {
                
                if(piece is Pawn && piece.ColorPiece != ColorPiece)
                {
                    Pawn pawn = (Pawn)piece;
                    if (pawn.PawnJumped && pawn.Position.Y == position.Y && Math.Abs(pawn.Position.X - position.X) == 1)
                    {
                        if (pawn.ColorPiece == "black")
                        {
                            opponentPiecesInReach.Add(new Vector2(pawn.Position.X, pawn.Position.Y + 1));
                            pawn.UnderAttack = true;
                            Console.WriteLine(pawn.Position.X);

                            Console.WriteLine(pawn.Position.Y + 1);


                        }
                        if (pawn.ColorPiece == "white")
                        {

                            opponentPiecesInReach.Add(new Vector2(pawn.Position.X, pawn.Position.Y - 1));
                            pawn.UnderAttack = true;

                            Console.WriteLine(pawn.Position.X);

                            Console.WriteLine(pawn.Position.Y - 1);
                        }
                    }
                }
                
                    
               



                
            }
            

            MovesPossible = movesPossible;
            OpponentsPiecesInReach = opponentPiecesInReach;
            


        }

        public override void BringDefendingPieces(List<Piece> Pieces, List<Vector2> checkSquares)
        {
            
            int num;
            string color = ColorPiece;
            //Nastaveni jak se bude pohybovat po Y ose, podle barvy figurky
            if (color == "black")
            {
                num = -1;
            }
            else
            {
                num = 1;
            }
            Vector2 position = Position;
            ourPiecesInReach.Clear();

            foreach(Piece pic1 in Pieces)
            {   
                if(pic1.ColorPiece == ColorPiece)
                {
                    if (pic1.Position.X == position.X + 1 && pic1.Position.Y == position.Y + num)
                    {
                        ourPiecesInReach.Add(new Vector2(position.X + 1, position.Y + num));
                        break;
                    }
                }
                
            }

            foreach (Piece pic1 in Pieces)
            {   
                if(pic1.ColorPiece == ColorPiece)
                {
                    if (pic1.Position.X == position.X - 1 && pic1.Position.Y == position.Y + num)
                    {
                        ourPiecesInReach.Add(new Vector2(position.X - 1, position.Y + num));
                        break;
                    }
                }
                
            }



            OurPiecesInReach = ourPiecesInReach;
        }
        public bool CheckPromote()
        {
            Vector2 position = Position;
            if(ColorPiece == "white" && position.Y == 7)
            {
                return true;
            }
            else if(ColorPiece == "black" && position.Y == 0)
            {
                return true;
            }
            return false;


        }

    }


}
