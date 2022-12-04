using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
