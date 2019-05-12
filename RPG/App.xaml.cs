using System.ComponentModel;
using RPG.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using RPG.ViewModels;

namespace RPG
{
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var viewLauncher = new ViewLauncher(Container);
            containerRegistry.RegisterInstance(typeof(ViewLauncher), viewLauncher);
        }
    }
}
