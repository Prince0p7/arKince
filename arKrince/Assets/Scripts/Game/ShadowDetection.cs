using Unity.VisualScripting;
using UnityEngine;

public class ShadowDetection : MonoBehaviour
{
    public LayerMask shadows;
    public GameState gameState;
    private PlayerBehavior player;
    void Start()
    {
        player = GetComponent<PlayerBehavior>();
    }
    void Update()
    {
        if(player.canMove == false) return;
        
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, 0.3f, shadows);
        
        if(col.Length > 0)
        {
            foreach(Collider2D C in col)
            {
                if(C.TryGetComponent<SpriteRenderer>(out var sprite))
                {
                    if(sprite.bounds.Contains(transform.position))
                    {
                        gameState.IsInsideShadow = true;
                        return;
                    }
                }
            }

            gameState.IsInsideShadow = false;
        }
        else
        {
            gameState.IsInsideShadow = false;
        }
    }
}