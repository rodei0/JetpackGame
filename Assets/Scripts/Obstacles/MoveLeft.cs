using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float destroyXPosition = -15f;
    void Update()
    {
        moveTowardsLeft();
        DestroyItself();
    }

    void moveTowardsLeft()
    {
        this.transform.Translate(Vector2.left * (5f + GameManager.Instance.velocidadActual) * Time.deltaTime);
    }

    private void DestroyItself()
    {
        if (transform.position.x <= destroyXPosition)
        {
            Destroy(this.gameObject);
        }
    }

}
