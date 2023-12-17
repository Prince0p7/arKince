using Unity.VisualScripting;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public int distance;
    public Transform cursor;
    private Animator anim;
    public LayerMask whatAreObstacles;
    void Start()
    {
        anim = cursor.GetComponent<Animator>();
    }
    void Update()
    {
        Vector2 nextPosition = new (Mathf.RoundToInt(InputManager.Instance.MoveInput().x), Mathf.RoundToInt(InputManager.Instance.MoveInput().y));

        if(nextPosition.magnitude >= .6f)
        {
            Vector2 cursorPosition = (Vector2)transform.position + nextPosition * distance;
            
            Collider2D col = Physics2D.OverlapCircle(cursorPosition, 0.1f, whatAreObstacles);

            if(col == null)
            {
                cursor.gameObject.SetActive(true);
                cursor.position = Vector2.Lerp(cursor.position, cursorPosition, 5 * Time.deltaTime);
            }
            else
            {
                cursor.position = (Vector2)transform.position;
                anim.SetTrigger("Exit");
                Invoke(nameof(ResetCursor), 1);
            }
        }
        else
        {
            cursor.position = (Vector2)transform.position;
            anim.SetTrigger("Exit");
            Invoke(nameof(ResetCursor), 1);
        }
    }
    private void ResetCursor()
    {
        cursor.gameObject.SetActive(false);
    }
}