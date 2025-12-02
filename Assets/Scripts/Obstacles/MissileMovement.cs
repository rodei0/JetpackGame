using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float destroyXPosition = -15f;

    private void FixedUpdate()
    {
        MovementMissile();
        DestroyItself();
    }

    private void MovementMissile()
    {
               transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void DestroyItself()
    {
        if (transform.position.x <= destroyXPosition)
        {
            Destroy(gameObject);
        }
    }
}
