using UnityEngine;

public class GameManager : MonoBehaviour
{

    private PlayerBehavior player;
    public bool GameIsStarted;
    [SerializeField] private Animator playerEntryAnim;
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
        playerEntryAnim.enabled = true;
        Invoke(nameof(PlayerEntry), 1f);
        Debug.Log("Chuha laterin Se bahar aa gaya");
    }
    private void PlayerEntry()
    {
        Camera.main.GetComponent<Animator>().enabled = true;
        player.canMove = true;
    }
}