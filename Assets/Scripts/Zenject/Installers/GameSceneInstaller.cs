using UnityEngine;
using Wuzzle.Audio;
using Wuzzle.Core;
using Wuzzle.Factories;
using Wuzzle.Settings;
using Zenject;

namespace Wuzzle.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        // this is temporary, should use main camera from persistant scene
        [SerializeField] private Camera camera;
        private GameSettings gameSettings;

        [Inject]
        public void Setup(GameSettings gameSettings) => this.gameSettings = gameSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(camera).AsSingle().NonLazy();
            Container.Bind<GridCellsContainer>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<ChipsContainer>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<ChipFactory>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<GameAudio>().FromComponentInHierarchy().AsSingle().NonLazy();

            Container.BindMemoryPool<Chip, Chip.OrangeChipPool>().WithInitialSize(25)
            .FromComponentInNewPrefab(gameSettings.orangeChipPrefab).UnderTransformGroup(gameSettings.orangeTransformGroupName);
            Container.BindMemoryPool<Chip, Chip.YellowChipPool>().WithInitialSize(10)
           .FromComponentInNewPrefab(gameSettings.yellowChipPrefab).UnderTransformGroup(gameSettings.yellowTransformGroupName);
            Container.BindMemoryPool<Chip, Chip.GreenChipPool>().WithInitialSize(10)
           .FromComponentInNewPrefab(gameSettings.greenChipPrefab).UnderTransformGroup(gameSettings.greenTransformGroupName);
            Container.BindMemoryPool<Chip, Chip.BlueChipPool>().WithInitialSize(10)
           .FromComponentInNewPrefab(gameSettings.blueChipPrefab).UnderTransformGroup(gameSettings.blueTransformGroupName);
        }
    }
}