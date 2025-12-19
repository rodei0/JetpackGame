using UnityEngine;

public class AsteroidsMovement : MonoBehaviour
{
    private float rotationSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float destroyXPosition = -20f;


    void Start()
    {
        rotationSpeed = Random.Range(0.3f, 0.7f);
    }

    private void FixedUpdate()
    {
        RotateItself();
        Movement();
        DestroyItself();
    }

    void RotateItself() 
    {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime * rotationSpeed);
    }

    void Movement()
    {
        //para añadir velocidad global multiplicar speed por la variable global(no creada)
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void DestroyItself()
    {
        if (transform.position.x <= destroyXPosition)
        {
            Destroy(transform.parent.gameObject);
        }
    }

  
}
