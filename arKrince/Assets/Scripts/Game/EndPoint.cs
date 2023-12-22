using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private GameState gameState;
    public bool gameFinished;
    [SerializeField] private Animator player;
    void Start()
    {
        gameState = GetComponent<GameState>();
    }
    void Update()
    {
        if(gameFinished == false)
        {
            if(Vector2.Distance(transform.position, player.transform.position) <= 1)
            {
                gameFinished = true;
                gameState.HasPlayerReachedTheDestination = true;
            }
        }
    }
}