using UnityEngine;
using FMOD.Studio;
public class PlayerAnimator : MonoBehaviour
{
    private EventInstance playerFootsteps;

    private Animator animator;
    [SerializeField] private Transform groundDetect;
    private PlayerMovement pMovement;
    private SpriteRenderer spriteRenderer;

    private bool isRunning = false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        ApplySkin();
        pMovement = GetComponent<PlayerMovement>();
        playerFootsteps = AudioManager.Instance.CreateEventInstance(FMODEvents.Instance.footstepSFX);
    }

    void Update()
    {
        RunAnimation();
        FlyAnimation();
        stopRunningSound();
    }
    
    void RunAnimation()
    {
        Collider2D groundCollider = Physics2D.OverlapCircle(groundDetect.position, 0.1f);
        bool isGrounded = groundCollider != null && groundCollider.CompareTag("Ground");
        if (isGrounded && !isRunning)
        {
            animator.SetBool("isRunning", true);
            playerFootsteps.start();
            isRunning = true;
        } else if (!isGrounded && isRunning) {
            animator.SetBool("isRunning", false);
            playerFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
            isRunning = false;
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

    void stopRunningSound()
    {
        if (MenuManager.Instance.isPaused || GameManager.Instance.gameover)
        {
        playerFootsteps.stop(STOP_MODE.ALLOWFADEOUT);     
        isRunning = false;
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
