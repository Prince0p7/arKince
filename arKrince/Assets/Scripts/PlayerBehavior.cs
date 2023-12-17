using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private InputManager inputManager;
    [SerializeField] private Animator anim;
    private SpriteRenderer spriteRenderer;
    [HideInInspector] public float direction;
    private Vector2 moveInput;
    [Header("FX")]
    private AudioSource playerAudioSource;
    [SerializeField] private Animator landingAnimator;
    private string[] IdleMovement = { "Idle N", "Idle NW", "Idle W", "Idle SW", "Idle S", "Idle SE", "Idle E", "Idle NE" };
    private string[] RunMovement = { "Run N", "Run NW", "Run W", "Run SW", "Run S", "Run SE", "Run E", "Run NE" };

    void Start()
    {
        inputManager = InputManager.Instance;
        playerAudioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        moveInput = inputManager.MoveInput();
        GetDirection();
    }
    private void GetDirection()
    {
        if (moveInput.magnitude >= 0.2f)
        {
            direction = -Mathf.RoundToInt(Vector2.SignedAngle(transform.up, moveInput));

            if (direction < 0)
            {
                direction += 360;
            }

            switch (direction)
            {
                case <= 23:
                    spriteRenderer.flipX = false;
                    direction = 0;
                    break;
                case <= 68:
                    spriteRenderer.flipX = false;
                    direction = 1;
                    break;
                case <= 113:
                    spriteRenderer.flipX = true;
                    direction = 2;
                    break;
                case <= 150:
                    spriteRenderer.flipX = true;
                    direction = 3;
                    break;
                case <= 203:
                    spriteRenderer.flipX = true;
                    direction = 4;
                    break;
                case <= 248:
                    spriteRenderer.flipX = false;
                    direction = 5;
                    break;
                case <= 293:
                    spriteRenderer.flipX = false;
                    direction = 6;
                    break;
                case <= 338:
                    spriteRenderer.flipX = false;
                    direction = 7;
                    break;
                default:
                    spriteRenderer.flipX = false;
                    direction = 0;
                    break;
            }

            anim.Play(RunMovement[(int)direction]);
        }
        else
        {
            anim.Play(IdleMovement[(int)direction]);
        }        
    }
    public void PlayerFX()
    {
        playerAudioSource.Stop();
        playerAudioSource.Play();
        landingAnimator.gameObject.SetActive(false);
        landingAnimator.gameObject.SetActive(true);
    }
}