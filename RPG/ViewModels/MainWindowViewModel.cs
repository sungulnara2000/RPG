using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Threading;
using Prism.Commands;
using Prism.Mvvm;
using RPG.Action;
using RPG.Enums;
using RPG.GameBoard;
using RPG.Units;

namespace RPG.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel(ViewLauncher viewLauncher)
        {
            _viewLauncher = viewLauncher;

            StartCommand = new DelegateCommand(Start);
            SetPlayerCommand = new DelegateCommand<string>(SetPlayer);
            SetLevelCommand = new DelegateCommand<string>(SetLevel);
            MoveLeftCommand = new DelegateCommand(MoveLeft);
            MoveUpCommand = new DelegateCommand(MoveUp);
            MoveRightCommand = new DelegateCommand(MoveRight);
            MoveDownCommand = new DelegateCommand(MoveDown);
            AttackCommand = new DelegateCommand(Attack);
        }

        public ICommand StartCommand { get; }

        public ICommand SetPlayerCommand { get; }

        public ICommand SetLevelCommand { get; }

        public ICommand MoveLeftCommand { get; }

        public ICommand MoveUpCommand { get; }

        public ICommand MoveRightCommand { get; }

        public ICommand MoveDownCommand { get; }

        public ICommand AttackCommand { get; }
        
        public string Name
        {
            get
            {
                switch (Player)
                {
                    case UnitType.ARCHER:
                        return "Лучник";
                    case UnitType.FIREMAN:
                        return "Человек-огня";
                    case UnitType.ICEMAN:
                        return "Человек-льда";
                }

                return "Неизвестно";
            }
        }

        public int X
        {
            get { return _x; }
            set { SetProperty(ref _x, value); }
        }

        public int Y
        {
            get { return _y; }
            set { SetProperty(ref _y, value); }
        }

        public int Health
        {
            get { return _health; }
            set { SetProperty(ref _health, value); }
        }

        public int Weapons
        {
            get { return _weapons; }
            set { SetProperty(ref _weapons, value); }
        }

        public bool IsStarted
        {
            get { return _isStarted; }
            set { SetProperty(ref _isStarted, value); }
        }

        public Level Level { get; private set; } = Level.UNKHOWN;

        public UnitType Player { get; set; } = UnitType.UNKNOWN;

        public Game.Game Game { get; set; }

        public GameBoard.GameBoard GameBoard
        {
            get { return _gameBoard; }
            set { SetProperty(ref _gameBoard, value); }
        }

        private void Start()
        {
            if (Level == Level.UNKHOWN || Player == UnitType.UNKNOWN) return;
            Game = new Game.Game(Level, Player);
            Game.Start();
            GameBoard = Game.GameBoard;
            IsStarted = true;
            _timer = new DispatcherTimer();
            _timer.Tick += new EventHandler(GameStep);
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Start();
        }

        public void GameStep(object sender, EventArgs e)
        {
            GameBoard = null;
            GameBoard = Game.GameBoard;
            Weapons = Game.Weapons;
            X = Game.X;
            Y = Game.Y;
            Health = Game.Health;
            if (Health <= 0)
            {
                _timer.Stop();
                _viewLauncher.ShowWinner(false);
            }
            if (Game.IsFinished)
            {
                _timer.Stop();
                _viewLauncher.ShowWinner(Game.Winner.GetType() == typeof(RedArmy));
            }
        }

        private void SetLevel(string level)
        {
            Level = (Level)int.Parse(level);
        }

        private void SetPlayer(string type)
        {
            Player = (UnitType) int.Parse(type);
            RaisePropertyChanged(nameof(Name));
        }

        private void MoveLeft()
        {
            Game.Actions?.Enqueue(new Move(Direction.LEFT));
        }

        private void MoveUp()
        {
            Game.Actions?.Enqueue(new Move(Direction.UP));
        }

        private void MoveRight()
        {
            Game.Actions?.Enqueue(new Move(Direction.RIGHT));
        }

        private void MoveDown()
        {
            Game.Actions?.Enqueue(new Move(Direction.DOWN));
        }

        private void Attack()
        {
            Game.Actions?.Enqueue(new Attack());
        }

        private bool _isStarted;
        private GameBoard.GameBoard _gameBoard;
        private int _x, _y, _health, _weapons;
        private DispatcherTimer _timer;
        private ViewLauncher _viewLauncher;
    }
}
