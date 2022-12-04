using System;
using UnityEngine;

[Serializable]
public class GameSettings
{
    public GameObject orangeChipPrefab;
    public string orangeTransformGroupName = "orangeChips";
    [Space]
    public GameObject yellowChipPrefab;
    public string yellowTransformGroupName = "yellowChips";
    [Space]
    public GameObject greenChipPrefab;
    public string greenTransformGroupName = "greenChips";
    [Space]
    public GameObject blueChipPrefab;
    public string blueTransformGroupName = "blueChips";
}

