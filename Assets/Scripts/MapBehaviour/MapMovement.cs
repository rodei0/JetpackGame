using UnityEngine;

public class MapMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private float width;
    float widthFloor;
    [SerializeField] private Transform bg1;
    [SerializeField] private Transform bg2;

    [SerializeField] private Transform floor1;
    [SerializeField] private Transform floor2;
    [SerializeField] private Transform parentFloor;


    void Start()
    {
        SpriteRenderer sr = bg1.GetComponent<SpriteRenderer>();
        width = sr.bounds.size.x;
        widthFloor = calculateWidthFloor(parentFloor);
    }

    // Update is called once per frame
    void Update()
    {
        BackgroundMovement();
        FloorMovement();
    }

    void BackgroundMovement()
    {
        bg1.position += Vector3.left * speed * Time.deltaTime;
        bg2.position += Vector3.left * speed * Time.deltaTime;
        if (bg1.position.x <= -width)
        {
            bg1.position = new Vector2(bg2.position.x + width, bg1.position.y);
        }
        if (bg2.position.x <= -width)
        {
            bg2.position = new Vector2(bg1.position.x + width, bg2.position.y);
        }
    }

    void FloorMovement()
    {
        
        floor1.position += Vector3.left * speed * Time.deltaTime;
        floor2.position += Vector3.left * speed * Time.deltaTime;
        if (floor1.position.x <= -widthFloor)
        {
            floor1.position = new Vector2(floor2.position.x + widthFloor, floor1.position.y);
        }
        if (floor2.position.x <= -widthFloor)
        {
            floor2.position = new Vector2(floor1.position.x + widthFloor, floor1.position.y);
        }
    }

    float calculateWidthFloor(Transform parent)
    {
        float totalWidth = 0;
        foreach (Transform child in parent )
        {
            SpriteRenderer sr = child.GetComponent<SpriteRenderer>();
            if (sr != null) { 
            totalWidth += sr.bounds.size.x;
            }
        }
        return totalWidth;
    }

}
