using Unity.VisualScripting;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private PlayerBehavior player;
    public int distance;
    public Transform cursor;
    public LayerMask whatAreObstacles;
    [SerializeField] private float delay;
    [SerializeField] private float maxDelay;
    public bool canJump;
    void Start()
    {
        player = GetComponent<PlayerBehavior>();
    }
    void Update()
    {
        if(player.canMove == false || player.endPoint.gameFinished == true) return;

        Vector2 nextPosition = new (Mathf.RoundToInt(InputManager.Instance.MoveInput().x), Mathf.RoundToInt(InputManager.Instance.MoveInput().y));

        if(nextPosition.magnitude >= .6f)
        {
            Vector2 cursorPosition = (Vector2)transform.position + nextPosition * distance;
            
            Collider2D col = Physics2D.OverlapCircle(cursorPosition, 0.1f, whatAreObstacles);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, nextPosition - (Vector2) transform.position, distance, whatAreObstacles);

            if(col == null || hit.collider == null)
            {
                cursor.position = Vector2.Lerp(cursor.position, cursorPosition, 5 * Time.deltaTime);

                if(delay > maxDelay)
                {
                    cursor.gameObject.SetActive(false);

                    if(canJump == false)
                    {
                        canJump = true;
                    }
                }
                else
                {
                    canJump = false;
                    cursor.gameObject.SetActive(true);
                    delay += Time.deltaTime;
                }
            }
            else
            {
                delay = 0;
                canJump = false;
                cursor.position = (Vector2)transform.position;                
                cursor.gameObject.SetActive(false);
            }
        }
        else
        {
            delay = 0;
            canJump = false;
            cursor.position = (Vector2)transform.position;
            cursor.gameObject.SetActive(false);
        }
    }
    public void ResetCursor()
    {
        delay = 0;
        canJump = false;
    }
}