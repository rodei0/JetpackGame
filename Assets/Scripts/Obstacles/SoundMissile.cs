using UnityEngine;
using FMOD.Studio;
public class SoundMissile : MonoBehaviour
{

    private EventInstance missileSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        missileSound = AudioManager.Instance.CreateEventInstance(FMODEvents.Instance.missileSFX);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            missileSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));
            missileSound.start();
        }
    }
}
