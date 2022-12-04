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

    public List<Chip> OrangeChips => orangeChips;

    public List<Chip> YellowChips => yellowChips;

    public List<Chip> GreenChips => greenChips;

    public List<Chip> BlueChips => blueChips;

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

    public Chip SpawnChip(ChipColorRanks chipColorRank, int gridIndex)
    {
        Chip chip;
        switch (chipColorRank)
        {
            case ChipColorRanks.Orange:
                chip = orangePool.Spawn(gridIndex);
                OrangeChips.Add(chip);
                PrintDebugLog("Orange spawned!");
                break;
            case ChipColorRanks.Yellow:
                chip = yellowPool.Spawn(gridIndex);
                YellowChips.Add(chip);
                break;
            case ChipColorRanks.Green:
                chip = greenPool.Spawn(gridIndex);
                GreenChips.Add(chip);
                break;
            case ChipColorRanks.Blue:
                chip = bluePool.Spawn(gridIndex);
                BlueChips.Add(chip);
                break;
            default:
                chip = orangePool.Spawn(gridIndex);
                OrangeChips.Add(chip);
                break;
        }

        return chip;
    }

    public void DespawnChip(Chip chip)
    {
        PrintDebugLog("Despawning!");
        switch (chip.ChipColorRank)
        {
            case ChipColorRanks.Orange:
                OrangeChips.Remove(chip);
                orangePool.Despawn(chip);
                break;
            case ChipColorRanks.Yellow:
                YellowChips.Remove(chip);
                yellowPool.Despawn(chip);
                break;
            case ChipColorRanks.Green:
                GreenChips.Remove(chip);
                greenPool.Despawn(chip);
                break;
            case ChipColorRanks.Blue:
                BlueChips.Remove(chip);
                bluePool.Despawn(chip);
                break;
            default:
                break;
        }
    }

    public void DespawnChips()
    {
        foreach (var chip in OrangeChips)
            orangePool.Despawn(chip);

        for (int i = OrangeChips.Count - 1; i > -1; i--)
            OrangeChips.RemoveAt(i);

        PrintDebugLog($"orangeChips count ==> {OrangeChips.Count}");

        //

        foreach (var chip in YellowChips)
            yellowPool.Despawn(chip);

        for (int i = YellowChips.Count - 1; i > -1; i--)
            YellowChips.RemoveAt(i);

        //

        foreach (var chip in GreenChips)
            greenPool.Despawn(chip);

        for (int i = GreenChips.Count - 1; i > -1; i--)
            GreenChips.RemoveAt(i);

        //

        foreach (var chip in BlueChips)
            bluePool.Despawn(chip);

        for (int i = BlueChips.Count - 1; i > -1; i--)
            BlueChips.RemoveAt(i);
    }
}

