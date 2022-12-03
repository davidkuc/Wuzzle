using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleGenerator : MonoBehaviour
{
    [SerializeField] GameObject mainPrefab;

    private void Start()
    {
        for (int i = 0; i < 400; i++)
            GenerateCircles();
        StartCoroutine(ChangePosition());
    }
    
    public void GenerateCircles()
    {
        byte r = (byte)(160);
        byte g = (byte)(160);
        byte b = (byte)(160);

        Vector2 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        GameObject gameObject = Instantiate(mainPrefab);
        gameObject.transform.SetParent(transform);
        gameObject.name = "Circle";
        gameObject.transform.localPosition = new Vector2(Random.Range(-stageDimensions.x, stageDimensions.x), Random.Range(-stageDimensions.y, stageDimensions.y));
        float scale = Random.Range(1.2f, 2f); ;
        gameObject.transform.localScale = new Vector2(scale, scale);
        gameObject.GetComponent<Image>().color = new Color32(r,g,b,255);

    }
    IEnumerator ChangePosition()
    {
        Vector2 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        int maxIndex = transform.childCount;
        int count = 0;

        float xSpeed= 0;
        float ySpeed= 0;

        bool isDirectionInit = false;
        while(true)
        {
            if (!isDirectionInit)
            {
               xSpeed = 20;
               ySpeed = -50 - Random.Range(0,20);

               if (count == maxIndex-1) isDirectionInit = true;
            }

            if (transform.GetChild(count).transform.localPosition.y < -stageDimensions.y)
                transform.GetChild(count).transform.localPosition = new Vector2(Random.Range(-stageDimensions.x, stageDimensions.x), stageDimensions.y);

            if (transform.GetChild(count).transform.localPosition.x < -stageDimensions.x)
                transform.GetChild(count).transform.localPosition = new Vector2(stageDimensions.x, Random.Range(-stageDimensions.y, stageDimensions.y));

            if (transform.GetChild(count).transform.localPosition.x > stageDimensions.x)
                transform.GetChild(count).transform.localPosition = new Vector2(-stageDimensions.x, Random.Range(-stageDimensions.y, stageDimensions.y));


            transform.GetChild(count).GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, ySpeed);

            count++;
            if (count > maxIndex - 1) count = 0;

            yield return null;
        }
    }

}
