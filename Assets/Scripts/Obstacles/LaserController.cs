using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LaserController : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    private float timeBeforeSpawn = 1.5f;
    [SerializeField] private Light2D laserLight;
    [SerializeField] private SpriteRenderer srLaser;
    [SerializeField] private BoxCollider2D laserCollider;
    [SerializeField] private float colliderGrowth = 0.3f;
    void Start()
    {
        StartCoroutine(WaitForLaser());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitForLaser()
    {
        yield return new WaitForSeconds(timeBeforeSpawn);
        laser.SetActive(true);
        laserLight.enabled = true;
        for (int i = 0; i < 25; i++)
        {
            laserLight.pointLightOuterRadius += 1f;

            laserCollider.size = new Vector2(laserCollider.size.x + colliderGrowth, laserCollider.size.y);

            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i < 50; i++)
        {
            laserLight.pointLightOuterRadius -= 0.4f;
            Color color = srLaser.color;
            color.a -= 1f / 30f; // Reduce alpha gradualmente
            srLaser.color = color;
            if (laserLight.intensity >= 0) { laserLight.intensity -= 1f / 10f; }
            yield return new WaitForSeconds(0.02f);
        }

        Destroy(laser);
    }


}
