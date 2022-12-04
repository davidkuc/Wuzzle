using Zenject;

public class MenuSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<LevelHandler>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<UI_MainMenu>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}