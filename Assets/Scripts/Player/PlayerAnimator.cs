using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Transform groundDetect;
    private PlayerMovement pMovement;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        ApplySkin();
        pMovement = GetComponent<PlayerMovement>();
    }

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

    private void ApplySkin()
    {
        Skin currentSkin = SkinManager.Instance.GetCurentSkin();
        if (currentSkin != null)
        {
            if (currentSkin.animatorController != null)
            {
                animator.runtimeAnimatorController = currentSkin.animatorController;
            }
            spriteRenderer.sprite = currentSkin.skinSprite;
        }
    }
}
