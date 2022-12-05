using UnityEngine;
using Wuzzle.Managers;
using Zenject;

namespace Wuzzle.UI.Buttons
{
    public class UI_PlayButton : MonoBehaviour
    {
        private LevelManager levelManager;
        private UI_MainMenu uI_MainMenu;

        public void StartGame()
        {
            levelManager.LoadGameScene();
            uI_MainMenu.gameObject.SetActive(false);
        }

        [Inject]
        public void Setup(LevelManager levelManager, UI_MainMenu uI_MainMenu)
        {
            this.levelManager = levelManager;
            this.uI_MainMenu = uI_MainMenu;
        }
    }
}

