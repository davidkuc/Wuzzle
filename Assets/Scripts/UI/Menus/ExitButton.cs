using UnityEngine;
using UnityEngine.UI;

namespace Wuzzle.UI.Buttons
{
    public class ExitButton : MonoBehaviour
    {
        Button button;
        private void Start()
        {
            button = transform.GetComponent<Button>();
            button.onClick.AddListener(Exit);
        }
        void Exit()
        {
            Application.Quit();
        }
    }
}
