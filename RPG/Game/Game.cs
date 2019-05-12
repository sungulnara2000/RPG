using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using RPG.Action;
using RPG.Enums;
using RPG.GameBoard;
using RPG.Units;
using RPG.Goods;

namespace RPG.Game
{
    public class Game
    {
        public Game(Level level, UnitType unit)
        {
            _level = level;
            _unit = unit;
            _redArmy = new RedArmy();
            _blueArmy = new BlueArmy();
            Actions = new Queue<IAction>();
        }

        public GameBoard.GameBoard GameBoard { get; set; }

        public int X
        {
            get { return _player.X; }
        }

        public int Y
        {
            get { return _player.Y; }
        }

        public int Weapons
        {
            get { return _player.Weapons; }
        }

        public int Health
        {
            get { return _player.Health; }
        }

        public bool IsFinished
        {
            get { return Winner != null; }
        }

        public Queue<IAction> Actions { get; set; }

        public IArmy Winner { get; private set; }

        public void Start()
        {
            Initialize();
            _timer = new DispatcherTimer();
            _timer.Tick += new EventHandler(GameStep);
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Start();
        }

        public void GameStep(object sender, EventArgs e)
        {
            if (_redArmy.IsAlive() && _blueArmy.IsAlive())
            {
                _redArmy.UpdateAliveUnits();
                _blueArmy.UpdateAliveUnits();
                _redArmy.ActWithout(GameBoard, _player);
                if(Actions.Count > 0) _player.Act(GameBoard, Actions.Dequeue());
                _blueArmy.Act(GameBoard);
            }
            if (!_blueArmy.IsAlive()) Winner = _redArmy;
            if (!_redArmy.IsAlive()) Winner = _blueArmy;
        }

        private void Initialize()
        {
            var builder = new GameBoardBuilder();
            IGameBoardDirector director;
            _redArmy.Initialize(1, 1, 1);
            _blueArmy.Initialize(1, 1, 1);
            switch (_unit)
            {
                case UnitType.ARCHER:
                    _player = _redArmy.Archer;
                    break;
                case UnitType.FIREMAN:
                    _player = _redArmy.FireMan;
                    break;
                case UnitType.ICEMAN:
                    _player = _redArmy.IceMan;
                    break;
            }
            
            switch (_level)
            {
                case Level.EASY:
                    director = new LightGameBoardDirector(builder);
                    break;
                case Level.MEDIUM:
                    director = new MediumGameBoardDirector(builder);
                    break;
                case Level.HARD:
                    director = new HardGameBoardDirector(builder);
                    break;
                default:
                    throw new NotSupportedException();
            }
            director.Create(_redArmy.Units, _blueArmy.Units, _life, _weapon);
            GameBoard = builder.GetGameBoard();
        }


        private IItem _life;
        private IItem _weapon;
        private Unit _player;
        private RedArmy _redArmy;
        private BlueArmy _blueArmy;
        private Level _level;
        private UnitType _unit;
        private DispatcherTimer _timer;
    }
}
