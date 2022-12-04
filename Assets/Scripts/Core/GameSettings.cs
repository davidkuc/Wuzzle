using System;
using UnityEngine;

[Serializable]
public class GameSettings
{
    [Header("Prefabs")]
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
    [Space(2)]
    [Header("Tags")]
    public string gridCellTag = "GridCell";
    public string chipTag = "Chip";
    [Space(2)]
    [Header("Scenes")]
    public string gameSceneName = "GameScene";
}

