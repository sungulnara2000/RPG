using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Prism.Ioc;
using RPG.Views;
using Unity;
using Application = System.Windows.Forms.Application;
using MessageBox = System.Windows.MessageBox;

namespace RPG
{
    public class ViewLauncher
    {
        public ViewLauncher(IContainerProvider container)
        {
            _container = container;
        }

        public void ShowMainWindow()
        {
            _container.Resolve<MainWindow>().Show();
            _container.Resolve<MainWindow>().Activate();
        }

        public void ShowWinner(bool winner)
        {
            var title = winner ? "Победа" : "Проигрыш";
            var message = winner
                ? "Поздравляем! Переходите на следующий уровень!"
                : "Не переживайте! В следующий раз удача будет на вашей стороне.";
            var result = MessageBox.Show(message, title,
                MessageBoxButton.OK,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                App.Current.Shutdown();
            }
        }

        private readonly IContainerProvider _container;
    }
}
