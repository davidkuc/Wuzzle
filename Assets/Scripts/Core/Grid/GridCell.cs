using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class GridCell : Debuggable
{
    [SerializeField] private int index;
    private Chip chipOnGridCell;

    public bool HasChip => chipOnGridCell != null;

    public int Index => index; 

    public void SetIndex(int index) => this.index = index;

    public void AttachChip(Chip spawnedChip) => chipOnGridCell = spawnedChip;

    public void UnattachChip() => chipOnGridCell = null;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.Label(transform.position, Index.ToString());
        Handles.color = Color.magenta;
    }
#endif
}

