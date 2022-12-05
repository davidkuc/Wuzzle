using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Wuzzle.UI
{
    public class BackgroundColorChange : MonoBehaviour
    {
        private Image image;
        private void Awake()
        {
            image = transform.GetComponent<Image>();

        }
        private void OnEnable()
        {
            StartCoroutine(ChangeColor());
        }
        private void OnDisable()
        {
            StopAllCoroutines();
        }
        IEnumerator ChangeColor()
        {
            int minus = 110;
            byte r = (byte)(190 - minus);
            byte g = (byte)(200 - minus);
            byte b = (byte)(230 - minus);

            bool isUp = false;

            while (true)
            {
                image.color = new Color32(r, g, b, 255);

                if (!isUp)
                {
                    r--;
                    g--;
                    b--;
                }
                else
                {
                    r++;
                    g++;
                    b++;
                }

                if (r < 1) isUp = true;
                else if (r > 190 - minus) isUp = false;

                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
