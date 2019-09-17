using System.Windows;
using Prism.Unity;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using System;

namespace Tetris {
    class Bootstrapper : UnityBootstrapper {
        protected override DependencyObject CreateShell() {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell() {
            base.InitializeShell();
            Application.Current.MainWindow.Show();
        }

        protected override IModuleCatalog CreateModuleCatalog() {
            base.CreateModuleCatalog();

            return new DirectoryModuleCatalog()
            {
                ModulePath = AppDomain.CurrentDomain.BaseDirectory + "Modules"
            };
        }
    }
}
