using UnityEngine;

public class GameAudio : MonoBehaviour
{
    [SerializeField] private AudioClip gameStartSound;
    [SerializeField] private AudioClip orangeSpawnSound;
    [SerializeField] private AudioClip connectSound;
    [SerializeField] private AudioClip blueConnectSound;
    private AudioSource audioSourceSFX;

    private void Awake() => audioSourceSFX = GetComponent<AudioSource>();

    public void PlayGameStartSFX() => audioSourceSFX.PlayOneShot(gameStartSound);

    public void PlayConnectSFX() => audioSourceSFX.PlayOneShot(connectSound);

    public void PlayBlueConnectSFX() => audioSourceSFX.PlayOneShot(blueConnectSound);

    public void PlayOrangeSpawnSFX() => audioSourceSFX.PlayOneShot(orangeSpawnSound);
}

