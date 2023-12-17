using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public bool IsInsideShadow;
    public bool HasPlayerReachedTheDestination;
    public int nextLevelIndex;
    private float TimeOutsideShadow;
    private PlayerBehavior player;

    void Start()
    {
        player = GetComponentInChildren<PlayerBehavior>();
    }
    void Update()
    {
        if(GameOver())
        {
            player.canMove = false;
            PlayerDead();
            return;
        }

        if(HasPlayerReachedTheDestination == true)
        {
            player.canMove = false;
            GameFinish();
        }

    }
    private void GameFinish()
    {
        // Win Animation
        // Win SFX
        // Fade In Transition
        Invoke(nameof(NextLevel), 2);
    }
    private void NextLevel()
    {
        SceneManager.LoadScene(nextLevelIndex);
    }
    private bool GameOver()
    {
        if(IsInsideShadow == true)
        {
            TimeOutsideShadow = 0;
            PlayerInsideShadow();
            return false;
        }

        if(TimeOutsideShadow >= 1f)
        {
            return true;
        }

        TimeOutsideShadow += Time.deltaTime;
        PlayerOutsideShadow();
        return false;
    }
    private void PlayerInsideShadow()
    {
        // Normal FX
    }
    private void PlayerOutsideShadow()
    {
        // Vignette
        // Hit Animation
        // Hit SFX
    }
    private void PlayerDead()
    {
        // Death Animation
        // Death SFX
        // Fade In Transition
        Invoke(nameof(RestartGame), 2);
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}