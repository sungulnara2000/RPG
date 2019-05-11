using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Enums;
using RPG.GameBoard;
using RPG.Goods;
using RPG.Units.States;

namespace RPG.Units
{
    public abstract class Unit : IItem
    {
        public State State { get; set; }

        public IArmy Army { get; set; }

        public int Health { get; set; }

        public int Weapons { get; set; }

        public int Hit { get; set; }

        public Direction direction { get; set; }

        public bool IsAlive
        {
            get { return Health > 0; }
        }
        
        public void SetNewStuff(IItem temp, IItem stuff, GameBoard.GameBoard gameBoard)
        {
            if (gameBoard.GameBoardItems[temp.X + 1][temp.Y] is Ground)
            {
                stuff.X = temp.X + 1;
                stuff.Y = temp.Y;
                gameBoard.GameBoardItems[temp.X + 1][temp.Y] = stuff;
            }
            if (gameBoard.GameBoardItems[temp.X][temp.Y + 1] is Ground)
            {
                stuff.X = temp.X;
                stuff.Y = temp.Y + 1;
                gameBoard.GameBoardItems[temp.X][temp.Y + 1] = stuff;
            }
            if (gameBoard.GameBoardItems[temp.X - 1][temp.Y] is Ground)
            {
                stuff.X = temp.X - 1;
                stuff.Y = temp.Y;
                gameBoard.GameBoardItems[temp.X - 1][temp.Y] = stuff;
            }
            if (gameBoard.GameBoardItems[temp.X][temp.Y - 1] is Ground)
            {
                stuff.X = temp.X;
                stuff.Y = temp.Y - 1;
                gameBoard.GameBoardItems[temp.X][temp.Y - 1] = stuff;
            }
        }

        // подбираем элемент
        public void PickUp(IItem temp, GameBoard.GameBoard gameBoard)
        {
            if (temp is Weapon)
            {
                Weapons += 1;
                temp = new Ground { X = temp.X, Y = temp.Y };
                var newWeapon = new Weapon { X = 0, Y = 0 };
                SetNewStuff(temp, newWeapon, gameBoard);
            }
            if (temp is Life)
            {
                Health += 1;
                temp = new Ground { X = temp.X, Y = temp.Y };
                var newLife = new Life { X = 0, Y = 0 };
                SetNewStuff(temp, newLife, gameBoard);
            }
        }

        
        public void Move(GameBoard.GameBoard gameBoard)
        {
            
            switch (direction)
            {
                case Direction.LEFT:
                    if (X - 1 < 0) break;
                    var temp1 = gameBoard.GameBoardItems[Y][X - 1];
                    PickUp(temp1, gameBoard);

                    gameBoard.GameBoardItems[Y][X - 1] = this;
                    gameBoard.GameBoardItems[Y][X] = temp1;
                    X -= 1;
                    temp1.X += 1;
                    break;
                case Direction.UP:
                    if (Y - 1 < 0) break;
                    var temp2 = gameBoard.GameBoardItems[Y - 1][X];
                    PickUp(temp2, gameBoard);
                    gameBoard.GameBoardItems[Y - 1][X] = this;
                    gameBoard.GameBoardItems[Y][X] = temp2;
                    Y -= 1;
                    temp2.Y += 1;
                    break;
                case Direction.RIGHT:
                    if (X + 1 >= gameBoard.Width) break;
                    var temp3 = gameBoard.GameBoardItems[Y][X + 1];
                    PickUp(temp3, gameBoard);
                    gameBoard.GameBoardItems[Y][X + 1] = this;
                    gameBoard.GameBoardItems[Y][X] = temp3;
                    X += 1;
                    temp3.X -= 1;
                    break;
                case Direction.DOWN:
                    if (Y + 1 >= gameBoard.Height) break;
                    var temp4 = gameBoard.GameBoardItems[Y + 1][X];
                    PickUp(temp4, gameBoard);
                    gameBoard.GameBoardItems[Y + 1][X] = this;
                    gameBoard.GameBoardItems[Y][X] = temp4;
                    Y += 1;
                    temp4.Y -= 1;
                    break;
            }
        }

        public bool Attack(GameBoard.GameBoard gameBoard)
        {
            if (Weapons == 0) return false;
            if (X - 1 >= 0 && gameBoard.GameBoardItems[Y][X - 1] is Unit &&
                ((Unit)gameBoard.GameBoardItems[Y][X - 1]).Army != Army)
            {
                ((Unit)gameBoard.GameBoardItems[Y][X - 1]).Health -= Hit;
                return true;
            }
            if (Y - 1 >= 0 && gameBoard.GameBoardItems[Y - 1][X] is Unit &&
                ((Unit)gameBoard.GameBoardItems[Y - 1][X]).Army != Army)
            {
                ((Unit)gameBoard.GameBoardItems[Y - 1][X]).Health -= Hit;
                return true;
            }
            if (X + 1 < gameBoard.Width && gameBoard.GameBoardItems[Y][X + 1] is Unit &&
                ((Unit)gameBoard.GameBoardItems[Y][X + 1]).Army != Army)
            {
                ((Unit)gameBoard.GameBoardItems[Y][X + 1]).Health -= Hit;
                return true;
            }
            if (Y + 1 < gameBoard.Height && gameBoard.GameBoardItems[Y + 1][X] is Unit &&
                ((Unit)gameBoard.GameBoardItems[Y + 1][X]).Army != Army)
            {
                ((Unit)gameBoard.GameBoardItems[Y + 1][X]).Health -= Hit;
                return true;
            }
            return false;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public void ChangeDirection()
        {
            direction = (Direction)((int)direction + 1);
        }

        public void Act(GameBoard.GameBoard gameBoard, Direction direction)
        {
            switch (direction)
            {
                case Direction.LEFT:
                    if (gameBoard.GameBoardItems[Y][X - 1] is Wall || X - 1 < 0)
                    {
                        ChangeDirection();
                        break;
                    }
                    if (!Attack(gameBoard))
                    {
                        Move(gameBoard);
                    }
                    break;
                case Direction.UP:
                    if (gameBoard.GameBoardItems[Y - 1][X] is Wall || Y - 1 < 0)
                    {
                        ChangeDirection();
                        break;
                    }
                    if (!Attack(gameBoard))
                    {
                        Move(gameBoard);
                    }
                    break;
                case Direction.RIGHT:
                    if (gameBoard.GameBoardItems[Y][X + 1] is Wall || X + 1 >= gameBoard.Width)
                    {
                        ChangeDirection();
                        break;
                    }
                    if (!Attack(gameBoard))
                    {
                        Move(gameBoard);
                    }
                    break;
                case Direction.DOWN:
                    if (gameBoard.GameBoardItems[Y + 1][X] is Wall || Y + 1 >= gameBoard.Height)
                    {
                        ChangeDirection();
                        break;
                    }
                    if (!Attack(gameBoard))
                    {
                        Move(gameBoard);
                    }
                    break;
            }
        }
    }
}