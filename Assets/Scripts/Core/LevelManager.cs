using UnityEngine.SceneManagement;
using UnityEngine;
using Zenject;
using Wuzzle.Settings;

namespace Wuzzle.Managers
{
    public class LevelManager : MonoBehaviour
    {
        private ZenjectSceneLoader zenjectSceneLoader;
        private GameSettings gameSettings;

        [Inject]
        public void Setup(ZenjectSceneLoader zenjectSceneLoader, GameSettings gameSettings)
        {
            this.zenjectSceneLoader = zenjectSceneLoader;
            this.gameSettings = gameSettings;
        }

        public void ReloadGameScene()
        {
            UnloadGameScene();
            LoadGameScene();
        }

        public void LoadGameScene()
        {
            zenjectSceneLoader.LoadScene(gameSettings.gameSceneName, LoadSceneMode.Additive, (container) =>
            {
                container.BindInstance(this);
            });
        }

        public void UnloadGameScene() => SceneManager.UnloadSceneAsync(gameSettings.gameSceneName);
    }
}