using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class ChipsContainer : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField] private Chip chip1;
    [SerializeField] private Chip chip2;

    private GridCellsContainer gridCellsContainer;
    private ChipFactory chipFactory;

    private Chip[] chips;

    public Chip[] Chips => chips;

    [Inject]
    public void Setup(GridCellsContainer gridCellsContainer, ChipFactory chipFactory)
    {
        this.gridCellsContainer = gridCellsContainer;
        this.chipFactory = chipFactory;
    }

    public void ConnectChips(Chip chip1, Chip chip2)
    {
        if (!ChipsEqualInRank(chip1, chip2))
            return;

        // animations?
        var indexArray = new int[2] { chip1.Index, chip2.Index };
        var index = indexArray[Random.Range(0, 2)];

        if (chip1.ChipColorRank == ChipColorRanks.Orange)
        {
            //Instantiate higher lvl
            chipFactory.SpawnChip(ChipColorRanks.Yellow, index);
        }
        else if (chip1.ChipColorRank == ChipColorRanks.Yellow)
        {
            //Instantiate higher lvl
            chipFactory.SpawnChip(ChipColorRanks.Green, index);
        }
        else if (chip1.ChipColorRank == ChipColorRanks.Green)
        {
            //Instantiate higher lvl
            chipFactory.SpawnChip(ChipColorRanks.Blue, index);
        }
        else if (chip1.ChipColorRank == ChipColorRanks.Blue)
        {
            // Both explode with a nice effect + bonus points!
        }

        //despawn previous chips
        chipFactory.DespawnChip(chip1);
        chipFactory.DespawnChip(chip2);

        //give points
    }

    [ContextMenu("Connect Chips")]
    public void DebugConnectChips() => ConnectChips(chip1, chip2);

    [ContextMenu("Spawn Chips")]
    public void SpawnChips()
    {
        for (int i = 0; i < gridCellsContainer.GridCells.Length; i++)
        {
            chipFactory.SpawnChip(ChipColorRanks.Orange, i);
        }
    }

    private bool ChipsEqualInRank(Chip chip1, Chip chip2) => chip1.ChipColorRank == chip2.ChipColorRank;
}

