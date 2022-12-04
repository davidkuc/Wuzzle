using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class ChipsContainer : MonoBehaviour
{
    private GridCellsContainer gridCellsContainer;

    private Chip[] chips;

    public Chip[] Chips => chips;

    void Start()
    {

    }

    void Update()
    {

    }

    [Inject]
    public void Setup(GridCellsContainer gridCellsContainer) => this.gridCellsContainer = gridCellsContainer;

    public void ConnectChips(Chip gridItem, Chip neighbourGridCell)
    {
        // animations?
        var indexArray = new int[2] { gridItem.Index, neighbourGridCell.Index};
        var index = indexArray[Random.Range(0, 2)];

        if (gridItem.ChipColorRank == ChipColorRanks.Orange)
        {
            //Instantiate higher lvl
  //factory?

        }
        else if (gridItem.ChipColorRank == ChipColorRanks.Yellow)
        {
            //Instantiate higher lvl

        }
        else if (gridItem.ChipColorRank == ChipColorRanks.Green)
        {
            //Instantiate higher lvl

        }
        else
        {
            // Both explode with a nice effect
        }

        //give points
    }
}

