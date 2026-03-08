using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference footstepSFX { get; private set; }

    [field: Header("Coin SFX")]
    [field: SerializeField] public EventReference coinCollectSFX { get; private set; }

    [field: Header("Missile SFX")]
    [field: SerializeField] public EventReference missileSFX { get; private set; }

    [field: Header("Jetpack SFX")]
    [field: SerializeField] public EventReference jetpackSFX { get; private set; }

    [field: Header("Music SFX")]
    [field: SerializeField] public EventReference musicSFX { get; private set; }


    public static FMODEvents Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
