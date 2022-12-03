using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SoundDisable : MonoBehaviour
{
    TextMeshProUGUI text;
    Image image;
    int index = 1;
    Button button;
    [SerializeField] Sprite buttonOn;
    [SerializeField] Sprite buttonOff;
    bool delay = false;
    private void Awake()
    {
        text = transform.GetComponentInChildren<TextMeshProUGUI>();
        image = transform.Find("Image").GetComponent<Image>();
        button = transform.GetComponent<Button>();
    }
    private void Start()
    {
        button.onClick.AddListener(OnClickChangeState);
    }
    public void OnClickChangeState()
    {
        if (delay) return;

        if(index == 0)
        {
            text.color = new Color32(65,255,110,255);
            text.text = "sound on";
            image.sprite = buttonOn;
        }
        if(index == 1)
        {
            text.color = new Color32(255, 70, 70, 255);
            text.text = "sound off";
            image.sprite = buttonOff;
        }

        index++;
        if (index > 1) index = 0;
        Delay();
    }
    IEnumerator Delay()
    {
        delay = true;
        yield return new WaitForSeconds(0.2f);
        delay = false;
    }
}
