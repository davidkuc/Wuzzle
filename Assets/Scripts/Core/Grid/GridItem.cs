using UnityEngine;
using Zenject;

public class GridItem : Debuggable
{
    [SerializeField] private int index;
    [SerializeField] private ChipColorRanks chipRank;

    private GridCellsContainer gridCellsContainer;
    private GridItemsContainer gridItemsContainer;

    public ChipColorRanks ChipRank => chipRank;

    public void SetPosition(int gridIndex) => transform.position = gridCellsContainer.GridCells[gridIndex].transform.position;

    [ContextMenu("Debug Set Position")]
    public void DebugSetPosition() => SetPosition(index);

    [Inject]
    public void Setup(GridCellsContainer gridCellsContainer, GridItemsContainer gridItemsContainer)
    {
        this.gridCellsContainer = gridCellsContainer;
        this.gridItemsContainer = gridItemsContainer;
    }

    [ContextMenu("Check Connections")]
    private void CheckForConnections()
    {
        bool connected;
        int checkingIndex = index;

        if (checkingIndex - 1 > -1)
            CheckNeighbourChipColor(checkingIndex - 1, out connected);

        PrintDebugLog($"Checking index ==> {checkingIndex}");
    }

    private void CheckNeighbourChipColor(int index, out bool connected)
    {
        var neighbourGridCell = gridItemsContainer.GridItems[index];
        if (chipRank == neighbourGridCell.ChipRank)
        {
            gridItemsContainer.ConnectChips(this, neighbourGridCell);
            connected = true;
        }
        else
            connected = false;
    }
}

