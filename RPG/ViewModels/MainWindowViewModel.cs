using System;
using System.Windows;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using RPG.Enums;
using RPG.GameBoard;
using RPG.Units;

namespace RPG.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        public MainWindowViewModel()
        {
            StartCommand = new DelegateCommand(Start);
            SetPlayerCommand = new DelegateCommand<string>(SetPlayer);
            SetLevelCommand = new DelegateCommand<string>(SetLevel);
        }

        public ICommand StartCommand { get; }

        public ICommand SetPlayerCommand { get; }

        public ICommand SetLevelCommand { get; }
        
        public bool IsStarted
        {
            get { return _isStarted; }
            set { SetProperty(ref _isStarted, value); }
        }

        public Level Level { get; private set; } = Level.UNKHOWN;

        public UnitType Player { get; set; } = UnitType.UNKNOWN;

        public TimeSpan RoundTime
        {
            get { return _roundTime; }
            set { SetProperty(ref _roundTime, value); }
        }



        public GameBoard.GameBoard GameBoard
        {
            get { return _gameBoard; }
            set { SetProperty(ref _gameBoard, value); }
        }

        private void Start()
        {
            if (Level == Level.UNKHOWN || Player == UnitType.UNKNOWN) return;
            var game = new Game.Game(Level, Player);
            game.Start();
            GameBoard = game.GameBoard;
            IsStarted = true;
        }

        private void SetLevel(string level)
        {
            Level = (Level)int.Parse(level);
        }

        private void SetPlayer(string type)
        {
            Player = (UnitType) int.Parse(type);
        }
        
        private bool _isStarted = false;
        private TimeSpan _roundTime = TimeSpan.Zero;
        private GameBoard.GameBoard _gameBoard;
    }
}
