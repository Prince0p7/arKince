using UnityEngine;

public class GameManager : MonoBehaviour
{

    private PlayerBehavior player;
    public bool GameIsStarted;
    public AudioSource GameStartSound;
    [SerializeField] private Animator StartPanelAnimator;

    void Start()
    {
        player = GetComponentInChildren<PlayerBehavior>();
    }
    void Update()
    {
        if(GameIsStarted == false)
        {
            if(InputManager.Instance.Action())
            {
                player.canMove = true;
                GameIsStarted = true;
               // GameStartSound.Play();
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