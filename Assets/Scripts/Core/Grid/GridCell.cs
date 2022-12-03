using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class GridCell : Debuggable
{
    [SerializeField] private int index;

    public void SetIndex(int index)
    {
        this.index = index;
    }

    private void OnDrawGizmos()
    {
        Handles.Label(transform.position, index.ToString());
        Handles.color = Color.magenta;
    }
}

