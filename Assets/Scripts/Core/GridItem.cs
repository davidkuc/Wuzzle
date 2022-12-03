using UnityEngine;
using Zenject;

public class GridItem : MonoBehaviour
{
    [SerializeField] private int index;

    private GridCellsContainer gridCellsContainer;

    public void SetPosition(int gridIndex) => transform.position = gridCellsContainer.GridCells[gridIndex].transform.position;

    [ContextMenu("Debug Set Position")]
    public void DebugSetPosition() => SetPosition(index);

    [Inject]
    public void Setup(GridCellsContainer gridCellsContainer) => this.gridCellsContainer = gridCellsContainer;
}

