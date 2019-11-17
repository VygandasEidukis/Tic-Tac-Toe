using Caliburn.Micro;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    class SelectionViewModel : Screen
    {
        #region PROPS
        private BindableCollection<GameMap> _MapSizes;
        public BindableCollection<GameMap> MapSizes
        {
            get { return _MapSizes; }
            set 
            { 
                _MapSizes = value;
                SelectedMapSize = MapSizes[0];
                NotifyOfPropertyChange(() => MapSizes);
            }
        }
        private GameMap _selectedMapSize;
        public GameMap SelectedMapSize
        {
            get { return _selectedMapSize; }
            set 
            { 
                _selectedMapSize = value;
                if ((Parent as MainViewModel) != null)
                    (Parent as MainViewModel).Game.Map = value;
                NotifyOfPropertyChange(() => SelectedMapSize);
            }
        }
        public Player Player 
        { 
            get => (Parent as MainViewModel)?.Game.Players[0];
            set 
            { 
                ((MainViewModel) Parent).Game.Players[0] = value; 
                if(value.Sign == SignEnum.X)
                {
                    ((MainViewModel) Parent).Game.Players[1].Sign = SignEnum.O;
                }
                else
                {
                    ((MainViewModel) Parent).Game.Players[1].Sign = SignEnum.X;
                }
            } 
        }
        #endregion
        public SelectionViewModel()
        {
            MapSizes = new BindableCollection<GameMap>()
            {
                {
                    new GameMap(){Name="3x3", Size = 3}
                },
                {
                    new GameMap(){Name="4x4", Size = 4}
                },
                {
                    new GameMap(){Name="5x5", Size = 5}
                }
            };
        }

        public void FormLoaded()
        {
            ((MainViewModel) Parent).Game = new Game();
        }

        public void XChoice()
        {
            Player.Sign = SignEnum.X;
        }

        public void OChoice()
        {
            Player.Sign = SignEnum.O;
        }

        public void Choose()
        {
            if (Player == null) return;
            
            SaveSettings();
            (Parent as MainViewModel)?.ChangeViewToGame();
        }

        private void SaveSettings()
        {
            ((MainViewModel) Parent).Game.Players[1].Sign = Player.Sign == SignEnum.O ? SignEnum.X : SignEnum.O;
            ((MainViewModel) Parent).Game.Map = SelectedMapSize;
        }

    }
}
