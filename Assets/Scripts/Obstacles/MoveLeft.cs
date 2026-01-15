using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        moveTowardsLeft();
    }

    void moveTowardsLeft()
    {
        this.transform.Translate(Vector2.left * (5f + GameManager.Instance.velocidadActual) * Time.deltaTime);
    }
}
