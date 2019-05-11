using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using RPG.GameBoard;

namespace RPG.ViewModels
{
    public class ItemViewModel : BindableBase
    {
        public ItemViewModel(IItem item)
        {
            _item = item;
        }

        public IItem Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }

        public int X
        {
            get { return _item.X; }
        }

        public int Y
        {
            get { return _item.Y; }
        }

        private IItem _item;
    }
}
