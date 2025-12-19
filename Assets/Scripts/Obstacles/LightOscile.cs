using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightOscile : MonoBehaviour
{
    private Light2D light;
    void Start()
    {
        light = GetComponent<Light2D>();
        InvokeRepeating(nameof(OscileLightFalloff), 0f, 0.02f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OscileLightFalloff()
    {
        light.falloffIntensity = 0.5f + Mathf.PingPong(Time.time, 0.5f);
    }
}
