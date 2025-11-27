using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player variables")] 
    [SerializeField] private float flyingPower;

    private Rigidbody2D rb;
    private bool isFlying;

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

}
