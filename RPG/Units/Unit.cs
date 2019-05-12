using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Enums;
using RPG.GameBoard;
using RPG.Goods;
using RPG.Action;

namespace RPG.Units
{
    public abstract class Unit : IItem, IActionable
    {
        public IArmy Army { get; set; }

        public int Health { get; set; }

        public int Weapons { get; set; }

        public int Hit { get; set; }

        public Direction Direction { get; set; } = Direction.LEFT;

        public bool IsAlive
        {
            get { return Health > 0; }
        }
        
        public int X { get; set; }

        public int Y { get; set; }

        public void ChangeDirection()
        {
            Random rnd = new Random();
            Direction = (Direction)(rnd.Next(0, 4));
        }

        public void Act(GameBoard.GameBoard gameBoard)
        {
            if (!IsAlive) return;
            IAction action = new Attack();
            if (!action.Act(this, gameBoard))
            {
                ChangeDirection();
                action = new Move(Direction);
                action.Act(this, gameBoard);
            }
        }

        public void Act(GameBoard.GameBoard gameBoard, IAction action)
        {
            if (!IsAlive) return;
            action.Act(this, gameBoard);
        }
    }
}
