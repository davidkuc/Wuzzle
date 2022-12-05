using Wuzzle.Managers;
using Wuzzle.UI;
using Zenject;

namespace Wuzzle.Installers
{
    public class MenuSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LevelManager>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<UI_MainMenu>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}