using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Transform groundDetect;
    private PlayerMovement pMovement;
    void Start()
    {
        animator = GetComponent<Animator>();
        pMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        RunAnimation();
        FlyAnimation();
    }
    
    void RunAnimation()
    {
        Collider2D groundCollider = Physics2D.OverlapCircle(groundDetect.position, 0.1f);
        if (groundCollider != null && groundCollider.CompareTag("Ground"))
        {
            animator.SetBool("isRunning", true);
        } else  {
            animator.SetBool("isRunning", false);
        }
    }

    void FlyAnimation()
    {
        if (pMovement.isFlying) {
            animator.SetBool("isFlyingUp", true);
            animator.SetBool("isFlyingDown", false);
        } else { 
            animator.SetBool("isFlyingUp", false);
            animator.SetBool("isFlyingDown", true);
        }
    }
}
