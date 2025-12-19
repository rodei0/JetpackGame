using UnityEngine;

public class Autodestroy : MonoBehaviour
{
    [SerializeField] private int lifetime = 1;
    private float timer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
