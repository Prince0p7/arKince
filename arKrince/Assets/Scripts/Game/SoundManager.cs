using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [System.Serializable]
    public class ObjectSound
    {
        public string name;
        public AudioClip objectSound;
    }
    public ObjectSound[] objectSound;
    [SerializeField]
    private AudioSource objectSoundSource;
    public LayerMask Objects;
    public float radius;
    public GameObject nearestObject;
    private PlayerBehavior player;
    public bool audioPlayed;
    public GameObject currentAudioObject;
    void Start()
    {
        player = GetComponent<PlayerBehavior>();
    }
    void Update()
    {
        if(player.canMove == false) return;

        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, radius, Objects);
        
        if(col.Length > 0)
        {
            foreach(Collider2D C in col)
            {
                if(nearestObject == null)
                {
                    nearestObject = C.gameObject;
                }
                else
                {
                    if(Vector2.Distance(transform.position, C.transform.position) < Vector2.Distance(transform.position, nearestObject.transform.position))
                    {
                        nearestObject = C.gameObject;
                    }
                }
            }

            if(currentAudioObject != null)
            {
                if(nearestObject != currentAudioObject)
                {
                    audioPlayed = false;
                }
            }

            if(nearestObject == null) return;

            for(int i = 0; i < objectSound.Length; i++)
            {
                if(objectSound[i].name == nearestObject.name)
                {
                    if(audioPlayed == false)
                    {
                        audioPlayed = true;
                        objectSoundSource.PlayOneShot(objectSound[i].objectSound);
                        currentAudioObject = nearestObject;
                    }
                    return;
                }
            }
        }
        else
        {
            nearestObject = null;
            currentAudioObject = null;
            audioPlayed = false;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}