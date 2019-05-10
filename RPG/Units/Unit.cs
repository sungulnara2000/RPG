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

        public int Health
        {
            get; set;
        }

        public int Weapons { get; set; }

        public bool IsAlive
        {
            get { return Health > 0; }
        }
       

        public int X { get; set; }

        public int Y { get; set; } 
    }
}