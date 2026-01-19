using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightOscile : MonoBehaviour
{
    private Light2D light1;
    [SerializeField] private float oscillationSpeed = 2f;
    void Start()
    {
        light1 = GetComponent<Light2D>();

    }

    // Update is called once per frame
    void Update()
    {
        OscileLightFalloff();
    }

    void OscileLightFalloff()
    {
        light1.falloffIntensity = 0.95f + Mathf.Sin(Time.time * oscillationSpeed) * 0.15f;
    }
}
