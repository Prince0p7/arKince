using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Press A to Start
    public bool GameIsStarted;
    public AudioSource GameStartSound;
    [SerializeField] private Animator StartPanelAnimator;
    void Update()
    {
        if(GameIsStarted == false)
        {
            if(InputManager.Instance.Action())
            {
                GameIsStarted = true;
                GameStartSound.Play();
                StartPanelAnimator.SetTrigger("Exit");
                Invoke(nameof(PlayerSpawn), 1f);
            }
        }
    }
    private void PlayerSpawn()
    {
        // Sound SFX
        // Coming out Animation
        Debug.Log("Chuha laterin Se bahar aa gaya");
    }
}