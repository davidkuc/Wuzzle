using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class ChipsContainer : Debuggable
{

    [SerializeField] private float timeBetweenOrangeChipSpawns;
    [SerializeField] private float timeBetweenEmptyGridCellsCheck;
    [Space(2)]
    [Header("Debugging")]
    [SerializeField] private Chip chip1;
    [SerializeField] private Chip chip2;

    private GridCellsContainer gridCellsContainer;
    private ChipFactory chipFactory;
    private GameAudio gameAudio;

    private Coroutine spawningCoroutine;
    private WaitForSecondsRealtime waitForNextSpawn;
    private WaitForSecondsRealtime waitForNextEmptyGridCellsCheck;

    private bool isFirstSpawn = true;

    private Chip[] chips;

    public Chip[] Chips => chips;

    public bool IsFirstSpawn => isFirstSpawn;

    private void OnEnable() => isFirstSpawn = true;

    private void OnDisable()
    {
        isFirstSpawn = true;
        //StopCoroutine(spawningCoroutine);
    }

    private void Awake()
    {
        waitForNextSpawn = new WaitForSecondsRealtime(timeBetweenOrangeChipSpawns);
        waitForNextEmptyGridCellsCheck = new WaitForSecondsRealtime(timeBetweenEmptyGridCellsCheck);
    }

    //
    private void Start()
    {
        gameAudio.PlayGameStartSFX();
        //spawningCoroutine = StartCoroutine(SpawnOrangeChipsInEmptyGridCells());
    }

    [ContextMenu("Start Spawning in empty slots")]
    public void StartSpawning()
    {
        spawningCoroutine = StartCoroutine(SpawnOrangeChipsInEmptyGridCells());
    }

    [Inject]
    public void Setup(GridCellsContainer gridCellsContainer, ChipFactory chipFactory, GameAudio gameAudio)
    {
        this.gridCellsContainer = gridCellsContainer;
        this.chipFactory = chipFactory;
        this.gameAudio = gameAudio;
    }

    public void ConnectChips(Chip chip1, Chip chip2)
    {
        if (!ChipsEqualInRank(chip1, chip2))
            return;

        var indexArray = new int[2] { chip1.Index, chip2.Index };
        var gridIndex = indexArray[Random.Range(0, 2)];

        SpawnHigherRankedChip(chip1.ChipColorRank, gridIndex);

        //despawn previous chips
        DespawnChip(chip1);
        DespawnChip(chip2);

        //give points
    }

    private void SpawnHigherRankedChip(ChipColorRanks chipColorRank, int gridIndex)
    {
        if (chipColorRank == ChipColorRanks.Blue)
            gameAudio.PlayBlueConnectSFX();
        else
            gameAudio.PlayConnectSFX();

        if (chipColorRank == ChipColorRanks.Orange)
        {
            SpawnChip(ChipColorRanks.Yellow, gridIndex);
        }
        else if (chipColorRank == ChipColorRanks.Yellow)
        {
            SpawnChip(ChipColorRanks.Green, gridIndex);
        }
        else if (chipColorRank == ChipColorRanks.Green)
        {
            SpawnChip(ChipColorRanks.Blue, gridIndex);
        }

        //if (chipColorRank == ChipColorRanks.Orange)
        //{
        //    spawnedChip = SpawnChip(chipColorRank, gridIndex);

        //    if (!IsFirstSpawn)
        //        gameAudio.PlayConnectSFX();
        //}
        //else if (chipColorRank == ChipColorRanks.Yellow)
        //{
        //    chipFactory.SpawnChip(ChipColorRanks.Green, gridIndex);
        //    gameAudio.PlayConnectSFX();
        //}
        //else if (chipColorRank == ChipColorRanks.Green)
        //{
        //     chipFactory.SpawnChip(ChipColorRanks.Blue, gridIndex);
        //    gameAudio.PlayConnectSFX();
        //}
        //else if (chipColorRank == ChipColorRanks.Blue)
        //{
        //    gameAudio.PlayBlueConnectSFX();
        //    // Both explode with a nice effect + bonus points!
        //}
    }

    private Chip SpawnChip(ChipColorRanks chipColorRank, int gridIndex)
    {
        var spawnedChip = chipFactory.SpawnChip(chipColorRank, gridIndex);
        gridCellsContainer.GridCells[gridIndex].AttachChip(spawnedChip);
        return spawnedChip;
    }

    private void DespawnChip(Chip chip1)
    {
        chipFactory.DespawnChip(chip1);
        gridCellsContainer.GridCells[chip1.Index].UnattachChip();
    }

    [ContextMenu("Connect Chips")]
    public void DebugConnectChips() => ConnectChips(chip1, chip2);

    private IEnumerator SpawnOrangeChipsInEmptyGridCells()
    {
        //PrintDebugLog($"1");
        //while (true)
        //{
        //    PrintDebugLog($"2");
        //    var emptySlotsIndexes = GetEmptySlotsInArray();
        //    foreach (var emptySlot in emptySlotsIndexes)
        //    {
        //        PrintDebugLog($"Empty slot index: {emptySlot}");
        //        chipFactory.SpawnChip(ChipColorRanks.Orange, emptySlot);
        //        gameAudio.PlayOrangeSpawnSFX();

        //        yield return waitForNextSpawn;
        //    }

        //    yield return waitForNextEmptyGridCellsCheck;
        //}

        while (true)
        {
            yield return new WaitUntil(() => !isFirstSpawn);

            GridCell emptyGridCell = GetRandomEmptyGridCell();

            if (emptyGridCell == null)
                yield break;

            SpawnChip(ChipColorRanks.Orange, emptyGridCell.Index);
            gameAudio.PlayOrangeSpawnSFX();

            PrintDebugLog($"Spawned orange chip!");
            yield return waitForNextSpawn;
        }
    }

    private GridCell GetRandomEmptyGridCell()
    {
        GridCell emptyGridCell;
        int i;

        for (i = Random.Range(0, gridCellsContainer.GridCells.Length); i < gridCellsContainer.GridCells.Length - 1; i++)
        {
            if (!gridCellsContainer.GridCells[i].HasChip)
            {
                emptyGridCell = gridCellsContainer.GridCells[i];
                break;
            }
        }

        return null;

        //while (!emptyGridCellFound)
        //{
        //    gridCell = gridCellsContainer.GridCells[Random.Range(0, 25)];
        //    if (!gridCell.HasChip)
        //    {
        //        emptyGridCell = gridCell;
        //        emptyGridCellFound= true;
        //    }

        //    PrintDebugLog("Searching for empty grid cell!");
        //}
    }

    private int[] GetEmptySlotsInArray()
    {
        int[] emptySlotsIndexes = new int[25];
        foreach (var chip in chipFactory.OrangeChips)
        {
            emptySlotsIndexes[chip.Index] = 1;
            PrintDebugLog("Getting orange chips");
        }
        foreach (var chip in chipFactory.YellowChips)
        {
            emptySlotsIndexes[chip.Index] = 1;
        }
        foreach (var chip in chipFactory.GreenChips)
        {
            emptySlotsIndexes[chip.Index] = 1;
        }
        foreach (var chip in chipFactory.BlueChips)
        {
            emptySlotsIndexes[chip.Index] = 1;
        }
        var emptySlotsIndexList = new List<int>();

        for (int i = 0; i < emptySlotsIndexes.Length - 1; i++)
        {
            if (emptySlotsIndexes[i] == 0)
            {
                PrintDebugLog($"Getting empty slot index: {i}");
                emptySlotsIndexList.Add(i);
            }
        }

        return emptySlotsIndexList.ToArray();
    }

    public void RespawnChips()
    {
        DespawnChips();
        InitialSpawn();
    }

    [ContextMenu("Spawn Chips")]
    public void InitialSpawn()
    {
        for (int i = 0; i < gridCellsContainer.GridCells.Length; i++)

            SpawnChip(ChipColorRanks.Orange, i);

        isFirstSpawn = false;
    }

    [ContextMenu("Despawn Chips")]
    public void DespawnChips()
    {
        foreach (var gridCell in gridCellsContainer.GridCells)
            gridCell.UnattachChip();

        chipFactory.DespawnChips();
        isFirstSpawn = true;
    }

    private bool ChipsEqualInRank(Chip chip1, Chip chip2) => chip1.ChipColorRank == chip2.ChipColorRank;
}

