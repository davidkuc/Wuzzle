using System;
using UnityEngine;

public class UI_Container : MonoBehaviour
{
    protected event Action<bool> ContainerToggled;

    private GameObject container;
    private GameObject canvas;

    protected GameObject Container => container;

    protected GameObject Canvas => canvas; 

    protected virtual void Awake()
    {
        canvas = transform.Find("canvas").gameObject;
        container = Canvas.transform.Find("container").gameObject;
    }

    public virtual bool ToggleContainer(bool active)
    {
        Container.SetActive(active);
        ContainerToggled?.Invoke(Container.activeInHierarchy);
        return Container.activeInHierarchy;
    }
}
