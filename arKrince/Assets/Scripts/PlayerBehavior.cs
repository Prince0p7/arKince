using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    private InputManager inputManager;
    [SerializeField] private Animator directionAnim;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [HideInInspector] public float direction;
    private Vector2 moveInput;
    private Vector2 directionVector;
    [Header("FX")]
    private AudioSource playerAudioSource;
    [SerializeField] private Animator landingAnimator;
    private string[] IdleMovement = { "Idle N", "Idle NW", "Idle W", "Idle SW", "Idle S", "Idle SE", "Idle E", "Idle NE" };
    private string[] RunMovement = { "Run N", "Run NW", "Run W", "Run SW", "Run S", "Run SE", "Run E", "Run NE" };

    private CursorManager cursorManager;
    public bool canMove;
    
    public EndPoint endPoint;

    void Start()
    {
        inputManager = InputManager.Instance;
        cursorManager = GetComponent<CursorManager>();
        playerAudioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        moveInput = inputManager.MoveInput();

        if(canMove == true && endPoint.gameFinished != true)
        {
            GetDirection();
        }
        else
        {
            playerAnim.Play("Idle");
            
            if(endPoint.gameFinished == false)
            {
                directionAnim.Play(IdleMovement[(int)direction]);            
            }
            else
            {
                directionAnim.Play("Exit");
            }
        }
    }
    private void GetDirection()
    {
        if (moveInput.magnitude >= 0.2f)
        {
            if(cursorManager.canJump == true)
            {
                playerAnim.Play("Jump");
                directionAnim.Play(RunMovement[(int)direction]);
                spriteRenderer.transform.position = transform.position;
            }
            else
            {
                direction = -Mathf.RoundToInt(Vector2.SignedAngle(spriteRenderer.transform.up, moveInput));

                if (direction < 0)
                {
                    direction += 360;
                }

                switch (direction)
                {
                    case <= 23:
                        spriteRenderer.flipX = false;
                        direction = 0;
                        directionVector = new(0, 1);
                        break;
                    case <= 68:
                        spriteRenderer.flipX = false;
                        direction = 1;
                        directionVector = new(1, 1);
                        break;
                    case <= 113:
                        spriteRenderer.flipX = true;
                        direction = 2;
                        directionVector = new(1, 0);
                        break;
                    case <= 150:
                        spriteRenderer.flipX = true;
                        direction = 3;
                        directionVector = new(1, -1);
                        break;
                    case <= 203:
                        spriteRenderer.flipX = true;
                        direction = 4;
                        directionVector = new(0, -1);
                        break;
                    case <= 248:
                        spriteRenderer.flipX = false;
                        direction = 5;
                        directionVector = new(-1, -1);
                        break;
                    case <= 293:
                        spriteRenderer.flipX = false;
                        direction = 6;
                        directionVector = new(-1, 0);
                        break;
                    case <= 338:
                        spriteRenderer.flipX = true;
                        direction = 7;
                        directionVector = new(-1, 1);
                        break;
                    default:
                        spriteRenderer.flipX = false;
                        direction = 0;
                        directionVector = new(0, 1);
                        break;
                }
                
                transform.rotation = Quaternion.LookRotation(transform.forward, directionVector);
            
                playerAnim.Play("Idle");
                directionAnim.Play(IdleMovement[(int)direction]);
            }
        }
        else
        {
            if(cursorManager.canJump == false)
            {
                playerAnim.Play("Idle");
                directionAnim.Play(IdleMovement[(int)direction]);
            }
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