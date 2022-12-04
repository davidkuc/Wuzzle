using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    private GameSettings gameSettings;

    [Inject]
    public void Setup(GameSettings gameSettings)
    {
       this.gameSettings = gameSettings;
    }

    public override void InstallBindings()
    {
        Container.Bind<GridCellsContainer>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<ChipsContainer>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<ChipFactory>().FromComponentInHierarchy().AsSingle().NonLazy();

        Container.BindMemoryPool<Chip, Chip.OrangeChipPool>().WithInitialSize(20)
        .FromComponentInNewPrefab(gameSettings.orangeChipPrefab).UnderTransformGroup(gameSettings.orangeTransformGroupName);
        Container.BindMemoryPool<Chip, Chip.YellowChipPool>().WithInitialSize(10)
       .FromComponentInNewPrefab(gameSettings.yellowChipPrefab).UnderTransformGroup(gameSettings.yellowTransformGroupName);
        Container.BindMemoryPool<Chip, Chip.GreenChipPool>().WithInitialSize(10)
       .FromComponentInNewPrefab(gameSettings.greenChipPrefab).UnderTransformGroup(gameSettings.greenTransformGroupName);
        Container.BindMemoryPool<Chip, Chip.BlueChipPool>().WithInitialSize(10)
       .FromComponentInNewPrefab(gameSettings.blueChipPrefab).UnderTransformGroup(gameSettings.blueTransformGroupName);
    }
}