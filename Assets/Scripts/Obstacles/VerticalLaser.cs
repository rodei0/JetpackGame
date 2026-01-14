using UnityEngine;

public class VerticalLaser : MonoBehaviour
{
    [SerializeField] private Transform laserUp;
    [SerializeField] private Transform laserDown;
    [SerializeField] private Transform posUp;
    [SerializeField] private Transform posDown;
    [SerializeField] private float destroyXPosition = -20f;

    [SerializeField] private float speed = 5f;
    void Start()
    {
        RandomizeSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsObjective();
        DestroyItself();
    }

    void MoveTowardsObjective()
    {
        transform.position += Vector3.left * (speed + GameManager.Instance.velocidadActual) * Time.deltaTime;
        laserUp.position = Vector3.MoveTowards(laserUp.position, posUp.transform.position, 5f * Time.deltaTime);
        laserDown.position = Vector3.MoveTowards(laserDown.position, posDown.transform.position, 5f * Time.deltaTime);
    }
    
   void RandomizeSpawn()
   {
       float randomY = Random.Range(-3f, 3f);
       transform.position = new Vector2(transform.position.x, transform.position.y + randomY);
   }

    private void DestroyItself()
    {
        if (transform.position.x <= destroyXPosition)
        {
            Destroy(gameObject);
        }
    }
}
