using UnityEngine;

public class CoinMovement : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OscileUpAndDown();
        rotateYConstantly();
    }

    void OscileUpAndDown() 
    {
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + Mathf.Sin(Time.time) * 0.0005f);
    }

    void rotateYConstantly()
    {
        this.transform.Rotate(new Vector3(0, 80 * Time.deltaTime, 0));
    }

}
