using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public bool IsInsideShadow;
    public bool HasPlayerReachedTheDestination;
    public int nextLevelIndex;
    private float TimeOutsideShadow;
    private float MaxTimeOutsideShadow = 2;
    [SerializeField] private PlayerBehavior player;
    private HitFeedback hitFeedback;
    void Start()
    {
        hitFeedback = FindObjectOfType<HitFeedback>();
        MaxTimeOutsideShadow = hitFeedback.maxShadowTimer;
    }
    void Update()
    {
        if(GameOver())
        {
            player.canMove = false;
            InputManager.Instance.GetComponent<RumbleManager>().RumblePusle(1f, 1.2f, .005f);
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
        Invoke(nameof(NextLevel), 1);
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

        if(TimeOutsideShadow >= MaxTimeOutsideShadow)
        {
            return true;
        }

        TimeOutsideShadow += Time.deltaTime;
        PlayerOutsideShadow();
        return false;
    }
    private void PlayerInsideShadow()
    {
        hitFeedback.callVignette = false;
        // Normal FX
    }
    private void PlayerOutsideShadow()
    {
        hitFeedback.callVignette = true;
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