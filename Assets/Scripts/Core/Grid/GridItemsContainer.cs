using System;
using UnityEngine;
using Zenject;

public class GridItemsContainer : MonoBehaviour
{
    private GridCellsContainer gridCellsContainer;

    private GridItem[] gridItems;

    public GridItem[] GridItems => gridItems;

    void Start()
    {

    }

    void Update()
    {

    }

    [Inject]
    public void Setup(GridCellsContainer gridCellsContainer) => this.gridCellsContainer = gridCellsContainer;

    public void ConnectChips(GridItem gridItem, GridItem neighbourGridCell)
    {
        throw new NotImplementedException();
    }
}

