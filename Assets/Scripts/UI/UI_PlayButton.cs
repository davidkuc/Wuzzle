using UnityEngine;
using Zenject;

public class UI_PlayButton : MonoBehaviour
{
    private LevelHandler levelHandler;
    private UI_MainMenu uI_MainMenu;

    public void StartGame()
    {
        levelHandler.LoadGameScene();
        uI_MainMenu.gameObject.SetActive(false);
    }

    [Inject]
    public void Setup(LevelHandler levelHandler, UI_MainMenu uI_MainMenu)
    {
        this.levelHandler = levelHandler;
        this.uI_MainMenu = uI_MainMenu;
    }
}

