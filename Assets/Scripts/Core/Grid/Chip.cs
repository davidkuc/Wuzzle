using UnityEngine;
using Zenject;

public class Chip : Debuggable
{
    [SerializeField] private int index;
    [SerializeField] private ChipColorRanks chipRank;

    private GridCellsContainer gridCellsContainer;
    private ChipsContainer gridItemsContainer;

    public ChipColorRanks ChipColorRank => chipRank;

    public int Index => index;

    public void SetPosition(int gridIndex) => transform.position = gridCellsContainer.GridCells[gridIndex].transform.position;

    [ContextMenu("Debug Set Position")]
    public void DebugSetPosition() => SetPosition(Index);

    [Inject]
    public void Setup(GridCellsContainer gridCellsContainer, ChipsContainer gridItemsContainer)
    {
        this.gridCellsContainer = gridCellsContainer;
        this.gridItemsContainer = gridItemsContainer;
    }

    [ContextMenu("Check Connections")]
    private void CheckForConnections()
    {
        bool connected;
        int checkingIndex = Index;

        if (checkingIndex - 1 > -1)
            CheckNeighbourChipColor(checkingIndex - 1, out connected);

        PrintDebugLog($"Checking index ==> {checkingIndex}");
    }

    private void CheckNeighbourChipColor(int index, out bool connected)
    {
        var neighbourGridCell = gridItemsContainer.Chips[index];
        if (chipRank == neighbourGridCell.ChipColorRank)
        {
            gridItemsContainer.ConnectChips(this, neighbourGridCell);
            connected = true;
        }
        else
            connected = false;
    }

    public class OrangeChipPool : MonoMemoryPool<int, Chip>
    {
        protected override void Reinitialize(int gridIndex, Chip item)
        {
            base.Reinitialize(gridIndex, item);
            item.SetPosition(gridIndex);
        }
    }

    public class YellowChipPool : MonoMemoryPool<int, Chip>
    {
        protected override void Reinitialize(int gridIndex, Chip item)
        {
            base.Reinitialize(gridIndex, item);
            item.SetPosition(gridIndex);
        }
    }

    public class GreenChipPool : MonoMemoryPool<int, Chip>
    {
        protected override void Reinitialize(int gridIndex, Chip item)
        {
            base.Reinitialize(gridIndex, item);
            item.SetPosition(gridIndex);
        }
    }

    public class BlueChipPool : MonoMemoryPool<int, Chip>
    {
        protected override void Reinitialize(int gridIndex, Chip item)
        {
            base.Reinitialize(gridIndex, item);
            item.SetPosition(gridIndex);
        }
    }
}

