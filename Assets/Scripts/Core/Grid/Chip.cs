using System;
using UnityEngine;
using Zenject;

public class Chip : Debuggable
{
    [SerializeField] private int index;
    [SerializeField] private ChipColorRanks chipColorRank;

    private GridCellsContainer gridCellsContainer;
    private ChipsContainer chipsContainer;
    private Draggable draggable;
    private ChipAnimations chipAnimations;
    private GameAudio gameAudio;

    public ChipColorRanks ChipColorRank => chipColorRank;

    public int Index => index;

    public bool IsBeingDragged => draggable.IsBeingDragged;

    public GridCell CurrentGridCell => gridCellsContainer.GridCells[index];

    private void OnEnable()
    {
        if (!chipsContainer.IsFirstSpawn && chipColorRank == ChipColorRanks.Orange)
            gameAudio.PlayOrangeSpawnSFX();
    }

    private void OnDisable()
    {
        
    }


    private void Awake()
    {
        draggable = GetComponent<Draggable>();
        chipAnimations = GetComponent<ChipAnimations>();
    }

    public void SetupChip(int gridIndex)
    {
        transform.position = gridCellsContainer.GridCells[gridIndex].transform.position;
        index = gridIndex;
        OnChipSpawn();
    }

    [ContextMenu("Debug Set Position")]
    public void DebugSetPosition() => SetupChip(Index);

    [Inject]
    public void Setup(GridCellsContainer gridCellsContainer, ChipsContainer gridItemsContainer, GameAudio gameAudio)
    {
        this.gridCellsContainer = gridCellsContainer;
        this.chipsContainer = gridItemsContainer;
        this.gameAudio = gameAudio;
    }

    public void OnChipSpawn()
    {
        chipAnimations.ConnectAnimation();
    }

    public void OnDragStart()
    {
        chipAnimations.DragStartAnimation();
    }

    public void OnDragEnd()
    {
        chipAnimations.DragEndAnimation();
    }

    public class OrangeChipPool : MonoMemoryPool<int, Chip>
    {
        protected override void Reinitialize(int gridIndex, Chip item)
        {
            base.Reinitialize(gridIndex, item);
            item.SetupChip(gridIndex);
        }
    }

    public class YellowChipPool : MonoMemoryPool<int, Chip>
    {
        protected override void Reinitialize(int gridIndex, Chip item)
        {
            base.Reinitialize(gridIndex, item);
            item.SetupChip(gridIndex);
        }
    }

    public class GreenChipPool : MonoMemoryPool<int, Chip>
    {
        protected override void Reinitialize(int gridIndex, Chip item)
        {
            base.Reinitialize(gridIndex, item);
            item.SetupChip(gridIndex);
        }
    }

    public class BlueChipPool : MonoMemoryPool<int, Chip>
    {
        protected override void Reinitialize(int gridIndex, Chip item)
        {
            base.Reinitialize(gridIndex, item);
            item.SetupChip(gridIndex);
        }
    }
}

