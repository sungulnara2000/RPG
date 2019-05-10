using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.GameBoard
{
    public class GameBoard
    {
        public int Height
        {
            get { return GameBoardItems.Length; }
        }

        public int Width
        {
            get { return GameBoardItems[0].Length; }
        }

        public IItem[][] GameBoardItems { get; set; }
    }
}
