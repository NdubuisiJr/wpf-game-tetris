using Prism.Modularity;
using Microsoft.Practices.ServiceLocation;
using Prism.Regions;
using Tetris.Infrastructure;
using Tetris.Game.View;

namespace Tetris.Game {
    public class GameModule : IModule {
        public void Initialize() {
            RegionManager.RegisterViewWithRegion(RegionNames.GAMEREGION, typeof(GameView));
            RegionManager.RegisterViewWithRegion(RegionNames.HOMEREGION, typeof(HomeView));
            RegionManager.RegisterViewWithRegion(RegionNames.SCOREREGION, typeof(ScoreView));
        }
        private IRegionManager RegionManager { get { return ServiceLocator.Current.GetInstance<IRegionManager>(); } }
    }
}
