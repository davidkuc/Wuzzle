using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Wuzzle.Audio
{
    public class SoundDisable : MonoBehaviour
    {
        [SerializeField] private Sprite buttonOn;
        [SerializeField] private Sprite buttonOff;
        TextMeshProUGUI text;
        private Image image;
        private int index = 1;
        private Button button;
        private bool delay = false;

        private AudioManager audio;

        private void Awake()
        {
            audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
            text = transform.GetComponentInChildren<TextMeshProUGUI>();
            image = transform.Find("Image").GetComponent<Image>();
            button = transform.GetComponent<Button>();
        }

        private void Start() => button.onClick.AddListener(OnClickChangeState);

        public void OnClickChangeState()
        {
            if (delay) return;

            if (index == 0)
            {
                text.color = new Color32(65, 255, 110, 255);
                text.text = "sound on";
                image.sprite = buttonOn;
                audio.MuteOffAudio();
            }
            if (index == 1)
            {
                text.color = new Color32(255, 70, 70, 255);
                text.text = "sound off";
                image.sprite = buttonOff;
                audio.MuteAudio();
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
}
