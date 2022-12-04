using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HowToButton : MonoBehaviour
{
    [SerializeField] Button button;
    bool isClicked = false;
    GameObject table1;
    GameObject table2;

    private void Awake()
    {
        table1 = transform.Find("Table1").gameObject;
        table2 = transform.Find("Table2").gameObject;
        button.onClick.AddListener(ChangeChat);
    }

    private void ChangeChat()
    {
        if (isClicked) return;
        isClicked = true;
        StartCoroutine(Change());
    }
    IEnumerator Change()
    {
        table1.SetActive(true);
        yield return new WaitForSeconds(2f);
        table1.SetActive(false);

        table2.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        table2.SetActive(false);

        isClicked = false;
    }
}
