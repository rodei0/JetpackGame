using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player variables")] 
    [SerializeField] private float flyingPower;

    private Rigidbody2D rb;
    public bool isFlying;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
      
    }


    // Update is called once per frame
    void Update()
    {
        isFlying = Input.GetKey(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        if (isFlying)
        {
            rb.gravityScale = 0.4f;
        }
        else { rb.gravityScale = 1.5f; }
        if (isFlying)
        {
            FlyMovement();
        }
    }

    private void FlyMovement()
    {
        rb.AddForce(new Vector2(0, flyingPower), ForceMode2D.Force);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Player hit an obstacle!");
            GameManager.Instance.OnPlayerDead();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            GameManager.Instance.AddCoin();
            Destroy(collision.gameObject);
        }

    }

}
