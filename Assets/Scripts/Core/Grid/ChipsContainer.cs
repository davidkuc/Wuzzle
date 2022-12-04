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
    private GameAudio gameAudio;

    private bool isFirstSpawn = true;

    private Chip[] chips;

    public Chip[] Chips => chips;

    public bool IsFirstSpawn => isFirstSpawn;

    private void OnEnable() => isFirstSpawn = true;

    private void OnDisable() => isFirstSpawn = true;

    //
    private void Start()
    {
        gameAudio.PlayGameStartSFX();
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

        if (chip1.ChipColorRank == ChipColorRanks.Orange)
        {
            chipFactory.SpawnChip(ChipColorRanks.Yellow, gridIndex);

            if (!IsFirstSpawn)
                gameAudio.PlayConnectSFX();
        }
        else if (chip1.ChipColorRank == ChipColorRanks.Yellow)
        {
            chipFactory.SpawnChip(ChipColorRanks.Green, gridIndex);
            gameAudio.PlayConnectSFX();
        }
        else if (chip1.ChipColorRank == ChipColorRanks.Green)
        {
            chipFactory.SpawnChip(ChipColorRanks.Blue, gridIndex);
            gameAudio.PlayConnectSFX();
        }
        else if (chip1.ChipColorRank == ChipColorRanks.Blue)
        {
            gameAudio.PlayBlueConnectSFX();
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
        isFirstSpawn = false;
    }

    [ContextMenu("Despawn Chips")]
    public void DespawnChips()
    {
        chipFactory.DespawnChips();
        isFirstSpawn = true;
    }

    private bool ChipsEqualInRank(Chip chip1, Chip chip2) => chip1.ChipColorRank == chip2.ChipColorRank;
}

