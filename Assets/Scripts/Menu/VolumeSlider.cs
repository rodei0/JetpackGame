using UnityEngine;
using UnityEngine.UI;
public class VolumeSlider : MonoBehaviour
{
    private enum VolumeType { Master, Music, SFX }

    [Header("Volume Type")]
    [SerializeField] private VolumeType volumeType;

    private Slider volumeSlider;

    private void Awake()
    {
        volumeSlider = this.GetComponentInChildren<Slider>();
    }

    private void Start()
    {
        switch (volumeType)
        {
            case VolumeType.Master:
                volumeSlider.value = AudioManager.Instance.masterVolume;
                break;
            case VolumeType.Music:
                volumeSlider.value = AudioManager.Instance.musicVolume;
                break;
            case VolumeType.SFX:
                volumeSlider.value = AudioManager.Instance.sfxVolume;
                break;
        }
    }

    public void OnVolumeChanged(float value)
    {
        switch (volumeType)
        {
            case VolumeType.Master:
                AudioManager.Instance.masterVolume = value;
                break;
            case VolumeType.Music:
                AudioManager.Instance.musicVolume = value;
                break;
            case VolumeType.SFX:
                AudioManager.Instance.sfxVolume = value;
                break;
        }
    }
}
