using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Zenject.Asteroids;


public class ChipFactory : Debuggable
{
    private Chip.OrangeChipPool orangePool;
    readonly private List<Chip> orangeChips = new List<Chip>();

    private Chip.YellowChipPool yellowPool;
    readonly private List<Chip> yellowChips = new List<Chip>();

    private Chip.GreenChipPool greenPool;
    readonly private List<Chip> greenChips = new List<Chip>();

    private Chip.BlueChipPool bluePool;
    readonly private List<Chip> blueChips = new List<Chip>();

    [Inject]
    public void Setup(Chip.OrangeChipPool orangePool,
                      Chip.YellowChipPool yellowPool,
                      Chip.GreenChipPool greenPool,
                      Chip.BlueChipPool bluePool)
    {
        this.orangePool = orangePool;
        this.yellowPool = yellowPool;
        this.greenPool = greenPool;
        this.bluePool = bluePool;
    }

    public void SpawnChip(ChipColorRanks chipColorRank, int gridIndex)
    {
        Chip chip;
        switch (chipColorRank)
        {
            case ChipColorRanks.Orange:
                chip = orangePool.Spawn(gridIndex);
                orangeChips.Add(chip);
                break;
            case ChipColorRanks.Yellow:
                chip = yellowPool.Spawn(gridIndex);
                yellowChips.Add(chip);
                break;
            case ChipColorRanks.Green:
                chip = greenPool.Spawn(gridIndex);
                greenChips.Add(chip);
                break;
            case ChipColorRanks.Blue:
                chip = bluePool.Spawn(gridIndex);
                blueChips.Add(chip);
                break;
            default:
                break;
        }
    }

    public void DespawnChip(Chip chip)
    {
        PrintDebugLog("Despawning!");
        switch (chip.ChipColorRank)
        {
            case ChipColorRanks.Orange:
                orangeChips.Remove(chip);
                orangePool.Despawn(chip);
                break;
            case ChipColorRanks.Yellow:
                yellowChips.Remove(chip);
                yellowPool.Despawn(chip);
                break;
            case ChipColorRanks.Green:
                greenChips.Remove(chip);
                greenPool.Despawn(chip);
                break;
            case ChipColorRanks.Blue:
                blueChips.Remove(chip);
                bluePool.Despawn(chip);
                break;
            default:
                break;
        }
    }

    public void DespawnChips()
    {
        foreach (var chip in orangeChips)
            orangePool.Despawn(chip);

        for (int i = orangeChips.Count - 1; i > -1; i--)
            orangeChips.RemoveAt(i);

        PrintDebugLog($"orangeChips count ==> {orangeChips.Count}");

        //

        foreach (var chip in yellowChips)
            yellowPool.Despawn(chip);

        for (int i = yellowChips.Count - 1; i > -1; i--)
            yellowChips.RemoveAt(i);

        //

        foreach (var chip in greenChips)
            greenPool.Despawn(chip);

        for (int i = greenChips.Count - 1; i > -1; i--)
            greenChips.RemoveAt(i);

        //

        foreach (var chip in blueChips)
            bluePool.Despawn(chip);

        for (int i = blueChips.Count - 1; i > -1; i--)
            blueChips.RemoveAt(i);
    }
}

