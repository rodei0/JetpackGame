using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [Header("Player variables")] 
    [SerializeField] private float flyingPower;

    private Rigidbody2D rb;
    public bool isFlying;
    public bool isDead;
    private float intensity = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        isFlying = Input.GetKey(KeyCode.Space);

        PauseGame();
        UpdateJetpackIntensity();
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

    private void UpdateJetpackIntensity() 
    {
        if ((MenuManager.Instance != null && MenuManager.Instance.isPaused) || isDead)
        {
            intensity = 0f;
            AudioManager.Instance.SetJetpackParameter("jetpack_intensity", 0f);
            return;
        }

        if (isFlying && intensity < 1)
        {
            intensity += 0.01f;
            Debug.Log("Flying - Intensity: " + intensity);
        } else if (intensity > 0f)
        {
            intensity -= 0.1f;
        }

        AudioManager.Instance.SetJetpackParameter("jetpack_intensity", intensity);
    }

    private void FlyMovement()
    {
        rb.AddForce(new Vector2(0, flyingPower), ForceMode2D.Force);
    }

    private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !MenuManager.Instance.isPaused)
        {
        AudioManager.Instance.SetJetpackParameter("jetpack_intensity", 0f);
        MenuManager.Instance.ShowPauseMenu();
        } else if (Input.GetKeyDown(KeyCode.Escape) && MenuManager.Instance.isPaused)
        {
        Time.timeScale = 1f;
        MenuManager.Instance.Resume();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Player hit an obstacle!");
            isDead = true;
            intensity = 0f;
            AudioManager.Instance.SetJetpackParameter("jetpack_intensity", 0f);
            GameManager.Instance.OnPlayerDead();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            GameManager.Instance.AddCoin();
            AudioManager.Instance.PlayOneShot(FMODEvents.Instance.coinCollectSFX, transform.position);
            Destroy(collision.gameObject);
        }
    }

}
