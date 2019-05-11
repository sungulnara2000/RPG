using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace RPG.ViewModels
{
    public class GameViewModel : BindableBase
    {
        public GameViewModel(GameBoard.GameBoard gameBoard)
        {
            _gameBoard = gameBoard;
        }

        public int Height
        {
            get { return _gameBoard.Height; }
        }

        public int Width
        {
            get { return _gameBoard.Width; }
        }
        
       

        private GameBoard.GameBoard _gameBoard;
    }
}
